import json
import urllib.request
import urllib.parse
import gzip
from pathlib import Path
from collections import defaultdict
import time

MANIFEST = Path("./manifest.json")

def fetch_json(url: str):
    """Fetch JSON data from a URL with error handling and gzip support."""
    try:
        req = urllib.request.Request(url, headers={
            "User-Agent": "dependency-tree-script",
            "Accept-Encoding": "gzip, deflate"
        })
        with urllib.request.urlopen(req) as resp:
            data = resp.read()
            
            # Check if the response is gzipped
            if resp.headers.get('Content-Encoding') == 'gzip':
                data = gzip.decompress(data)
            
            return json.loads(data.decode('utf-8'))
    except Exception as e:
        print(f"⚠️  Failed to fetch {url}: {e}")
        return None

def get_catalog_entry(package, version):
    """Get catalog entry for a specific package version."""
    reg_url = f"https://api.nuget.org/v3/registration5-gz-semver2/{package.lower()}/index.json"
    index = fetch_json(reg_url)
    if not index:
        return None
    
    for page in index["items"]:
        page_data = fetch_json(page["@id"]) if "items" not in page else page
        if not page_data:
            continue
            
        for item in page_data["items"]:
            if item["catalogEntry"]["version"].lower() == version.lower():
                return item["catalogEntry"]
    
    print(f"⚠️  Package {package} {version} not found in catalog")
    return None

def dependency_group_for_framework(entry, target_framework):
    """Get the dependency group for a specific target framework."""
    if not entry:
        return {"dependencies": []}
        
    groups = entry.get("dependencyGroups", [])
    
    # Try exact match first (case insensitive)
    target_lower = target_framework.lower()
    for group in groups:
        group_tf = group.get("targetFramework", "").lower()
        if group_tf == target_lower:
            return group
    
    # Try compatible frameworks for netstandard2.0
    if target_lower == "netstandard2.0":
        compatible = [".netstandard2.0", ".netstandard,version=v2.0"]
        for compat in compatible:
            for group in groups:
                group_tf = group.get("targetFramework", "").lower()
                if group_tf == compat:
                    return group
    
    # Try compatible frameworks for other .NET Framework versions
    framework_mappings = {
        "net461": [".netframework4.6.1", ".netframework,version=v4.6.1", "net461"],
        "net47": [".netframework4.7", ".netframework,version=v4.7", "net47"],
        "net472": [".netframework4.7.2", ".netframework,version=v4.7.2", "net472"],
        "net46": [".netframework4.6", ".netframework,version=v4.6", "net46"],
        "net45": [".netframework4.5", ".netframework,version=v4.5", "net45"]
    }
    
    if target_lower in framework_mappings:
        for compatible_fw in framework_mappings[target_lower]:
            for group in groups:
                group_tf = group.get("targetFramework", "").lower()
                if group_tf == compatible_fw:
                    return group
    
    # Return group without targetFramework as fallback (usually applies to all frameworks)
    for group in groups:
        if "targetFramework" not in group or not group.get("targetFramework"):
            return group
    
    # If no match found, return empty dependencies
    print(f"    ⚠️  No compatible framework found for {target_framework}, available: {[g.get('targetFramework', 'None') for g in groups]}")
    return {"dependencies": []}

def parse_version_range(version_range):
    """Parse NuGet version range to get a concrete version."""
    if not version_range:
        return None
    
    # Remove brackets and parentheses, take the first version
    cleaned = version_range.strip("[]()").split(",")[0].strip()
    return cleaned if cleaned else None

def identify_direct_dependencies(manifest_packages):
    """Identify which packages are likely direct dependencies."""
    direct_prefixes = ["Azure.", "Microsoft.Identity.", "Microsoft.Bcl.AsyncInterfaces"]
    
    direct_deps = []
    for pkg in manifest_packages:
        package_name = pkg["PackageName"]
        if any(package_name.startswith(prefix) for prefix in direct_prefixes):
            direct_deps.append(pkg)
    
    # Group by target framework
    framework_groups = defaultdict(list)
    for pkg in direct_deps:
        framework_groups[pkg["TargetFramework"]].append(pkg)
    
    return framework_groups

def build_dependency_tree(package_name, package_version, target_framework, manifest_lookup, visited=None, depth=0):
    """Build a dependency tree for a package."""
    if visited is None:
        visited = set()
    
    if depth > 10:  # Prevent infinite recursion
        return {"name": package_name, "version": package_version, "framework": target_framework, "error": "Max depth reached"}
    
    key = (package_name.lower(), package_version.lower(), target_framework.lower())
    if key in visited:
        return {"name": package_name, "version": package_version, "framework": target_framework, "cycle": True}
    
    visited.add(key)
    
    # Check if this package exists in our manifest
    is_in_manifest = (package_name.lower(), package_version.lower(), target_framework.lower()) in manifest_lookup
    
    print(f"{'  ' * depth}📦 Fetching {package_name} {package_version} for {target_framework}")
    
    # Add a small delay to be respectful to the API
    time.sleep(0.1)
    
    entry = get_catalog_entry(package_name, package_version)
    if not entry:
        return {
            "name": package_name, 
            "version": package_version, 
            "framework": target_framework,
            "in_manifest": is_in_manifest,
            "error": "Package not found",
            "dependencies": []
        }
    
    group = dependency_group_for_framework(entry, target_framework)
    dependencies = []
    
    for dep in group.get("dependencies", []):
        dep_version = parse_version_range(dep.get("range", ""))
        if dep_version:
            dep_tree = build_dependency_tree(
                dep["id"], dep_version, target_framework, manifest_lookup, visited.copy(), depth + 1
            )
            dependencies.append(dep_tree)
    
    return {
        "name": package_name,
        "version": package_version,
        "framework": target_framework,
        "in_manifest": is_in_manifest,
        "dependencies": dependencies
    }

def detect_version_conflicts(all_trees):
    """Detect version conflicts between packages."""
    package_versions = defaultdict(set)
    
    def collect_packages(node):
        if isinstance(node, dict):
            name = node.get("name", "")
            version = node.get("version", "")
            if name and version:
                package_versions[name.lower()].add(version)
            
            for dep in node.get("dependencies", []):
                collect_packages(dep)
    
    for tree in all_trees:
        collect_packages(tree)
    
    conflicts = {name: versions for name, versions in package_versions.items() if len(versions) > 1}
    return conflicts

def render_tree_html(node, conflicts, depth=0):
    """Render a dependency tree node as HTML."""
    if not isinstance(node, dict):
        return ""
    
    name = node.get("name", "Unknown")
    version = node.get("version", "Unknown")
    framework = node.get("framework", "")
    in_manifest = node.get("in_manifest", False)
    is_cycle = node.get("cycle", False)
    error = node.get("error", "")
    dependencies = node.get("dependencies", [])
    
    # Determine CSS classes
    css_classes = ["tree-node"]
    if in_manifest:
        css_classes.append("in-manifest")
    if is_cycle:
        css_classes.append("cycle")
    if error:
        css_classes.append("error")
    if name.lower() in conflicts:
        css_classes.append("conflict")
    
    # Create the node HTML
    indent = "  " * depth
    node_html = [f'{indent}<li class="{" ".join(css_classes)}">']
    
    node_content = f'<span class="package-name">{name}</span>'
    node_content += f'<span class="package-version">v{version}</span>'
    
    if in_manifest:
        node_content += '<span class="manifest-badge">📦 In Manifest</span>'
    if is_cycle:
        node_content += '<span class="cycle-badge">🔄 Cycle</span>'
    if error:
        node_content += f'<span class="error-badge">❌ {error}</span>'
    if name.lower() in conflicts:
        versions = ", ".join(conflicts[name.lower()])
        node_content += f'<span class="conflict-badge">⚠️ Conflict: {versions}</span>'
    
    node_html.append(f'{indent}  <div class="node-content">{node_content}</div>')
    
    # Add dependencies
    if dependencies and not is_cycle:
        node_html.append(f'{indent}  <ul class="dependencies">')
        for dep in dependencies:
            node_html.append(render_tree_html(dep, conflicts, depth + 1))
        node_html.append(f'{indent}  </ul>')
    
    node_html.append(f'{indent}</li>')
    return '\n'.join(node_html)

def add_tree_css_styles():
    """Add CSS styles for tree visualization."""
    return """
<style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        margin: 40px;
        background-color: #f5f5f5;
        color: #333;
        line-height: 1.6;
    }
    
    h1 {
        color: #2c3e50;
        text-align: center;
        border-bottom: 3px solid #3498db;
        padding-bottom: 10px;
        margin-bottom: 30px;
    }
    
    .summary {
        background: #3498db;
        color: white;
        padding: 20px;
        border-radius: 8px;
        margin: 20px 0;
        text-align: center;
    }
    
    .framework-section {
        background: white;
        margin: 30px 0;
        padding: 25px;
        border-radius: 8px;
        box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        border-left: 5px solid #3498db;
    }
    
    .framework-section h2 {
        color: #2c3e50;
        margin-top: 0;
        padding-bottom: 15px;
        border-bottom: 2px solid #ecf0f1;
    }
    
    .dependency-forest {
        margin: 20px 0;
    }
    
    .dependency-tree {
        background: #f8f9fa;
        border: 1px solid #dee2e6;
        border-radius: 6px;
        margin: 15px 0;
        padding: 15px;
    }
    
    .tree-root {
        font-weight: bold;
        color: #2c3e50;
        font-size: 1.1em;
        margin-bottom: 10px;
        padding: 10px;
        background: #e9ecef;
        border-radius: 4px;
        border-left: 4px solid #28a745;
    }
    
    .tree-container {
        margin-left: 20px;
    }
    
    ul.tree-list {
        list-style: none;
        padding-left: 20px;
        margin: 5px 0;
        border-left: 2px solid #dee2e6;
    }
    
    ul.dependencies {
        list-style: none;
        padding-left: 25px;
        margin: 8px 0;
        border-left: 2px solid #dee2e6;
    }
    
    .tree-node {
        margin: 5px 0;
        position: relative;
    }
    
    .tree-node::before {
        content: "├─";
        color: #6c757d;
        font-weight: bold;
        margin-right: 8px;
    }
    
    .tree-node:last-child::before {
        content: "└─";
    }
    
    .node-content {
        display: inline-flex;
        align-items: center;
        flex-wrap: wrap;
        gap: 8px;
        padding: 6px 10px;
        background: white;
        border-radius: 4px;
        border: 1px solid #dee2e6;
        margin-left: 20px;
    }
    
    .package-name {
        font-weight: 600;
        color: #495057;
    }
    
    .package-version {
        background: #6c757d;
        color: white;
        padding: 2px 6px;
        border-radius: 3px;
        font-family: 'Courier New', monospace;
        font-size: 0.85em;
    }
    
    .manifest-badge {
        background: #28a745;
        color: white;
        padding: 2px 6px;
        border-radius: 3px;
        font-size: 0.75em;
        font-weight: bold;
    }
    
    .cycle-badge {
        background: #ffc107;
        color: #212529;
        padding: 2px 6px;
        border-radius: 3px;
        font-size: 0.75em;
        font-weight: bold;
    }
    
    .error-badge {
        background: #dc3545;
        color: white;
        padding: 2px 6px;
        border-radius: 3px;
        font-size: 0.75em;
        font-weight: bold;
    }
    
    .conflict-badge {
        background: #fd7e14;
        color: white;
        padding: 2px 6px;
        border-radius: 3px;
        font-size: 0.75em;
        font-weight: bold;
    }
    
    .in-manifest .node-content {
        border-left: 4px solid #28a745;
        background: #f8fff8;
    }
    
    .cycle .node-content {
        border-left: 4px solid #ffc107;
        background: #fffbf0;
    }
    
    .error .node-content {
        border-left: 4px solid #dc3545;
        background: #fff5f5;
    }
    
    .conflict .node-content {
        border-left: 4px solid #fd7e14;
        background: #fff8f0;
    }
    
    .legend {
        background: white;
        padding: 20px;
        border-radius: 8px;
        margin: 20px 0;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }
    
    .legend h3 {
        margin-top: 0;
        color: #2c3e50;
    }
    
    .legend-item {
        display: flex;
        align-items: center;
        margin: 10px 0;
        gap: 12px;
    }
    
    .legend-badge {
        padding: 4px 8px;
        border-radius: 3px;
        font-size: 0.8em;
        font-weight: bold;
        min-width: 120px;
        text-align: center;
    }
    
    .legend-direct { background: #28a745; color: white; }
    .legend-indirect { background: #6c757d; color: white; }
    .legend-cycle { background: #ffc107; color: #212529; }
    .legend-error { background: #dc3545; color: white; }
    .legend-conflict { background: #fd7e14; color: white; }
    
    .conflicts-section {
        background: #fff3cd;
        border: 1px solid #ffeaa7;
        border-radius: 8px;
        padding: 20px;
        margin: 20px 0;
    }
    
    .conflicts-section h3 {
        color: #856404;
        margin-top: 0;
    }
    
    .conflict-item {
        background: white;
        margin: 10px 0;
        padding: 10px;
        border-radius: 4px;
        border-left: 4px solid #fd7e14;
    }
</style>
"""

def create_legend():
    """Create a legend explaining the visualization."""
    html = ['<div class="legend">']
    html.append('<h3>Legend</h3>')
    html.append('<div class="legend-item"><span class="legend-badge legend-direct">📦 In Manifest</span>Package is included in the manifest (resolved dependency)</div>')
    html.append('<div class="legend-item"><span class="legend-badge legend-indirect">Indirect</span>Package is an indirect dependency (not in manifest)</div>')
    html.append('<div class="legend-item"><span class="legend-badge legend-cycle">🔄 Cycle</span>Circular dependency detected</div>')
    html.append('<div class="legend-item"><span class="legend-badge legend-error">❌ Error</span>Failed to fetch package information</div>')
    html.append('<div class="legend-item"><span class="legend-badge legend-conflict">⚠️ Conflict</span>Multiple versions of same package found</div>')
    html.append('</div>')
    return '\n'.join(html)

def create_conflicts_section(conflicts):
    """Create a section showing version conflicts."""
    if not conflicts:
        return ""
    
    html = ['<div class="conflicts-section">']
    html.append('<h3>⚠️ Version Conflicts Detected</h3>')
    html.append('<p>The following packages have multiple versions in the dependency tree:</p>')
    
    for package_name, versions in conflicts.items():
        html.append('<div class="conflict-item">')
        html.append(f'<strong>{package_name}</strong>: {", ".join(sorted(versions))}')
        html.append('</div>')
    
    html.append('</div>')
    return '\n'.join(html)

def main():
    """Generate an HTML visualization of the NuGet dependency tree."""
    print("🔍 Loading manifest...")
    manifest = json.loads(MANIFEST.read_text())
    
    # Create lookup for manifest packages
    manifest_lookup = set()
    for pkg in manifest:
        key = (pkg["PackageName"].lower(), pkg["PackageVersion"].lower(), pkg["TargetFramework"].lower())
        manifest_lookup.add(key)
    
    print("🎯 Identifying direct dependencies...")
    direct_dependencies = identify_direct_dependencies(manifest)
    
    print("🌳 Building dependency trees...")
    all_trees = []
    
    html = ['<!DOCTYPE html>', '<html lang="en">', '<head>']
    html.append('<meta charset="UTF-8">')
    html.append('<meta name="viewport" content="width=device-width, initial-scale=1.0">')
    html.append('<title>Azure PowerShell Dependency Tree</title>')
    html.append(add_tree_css_styles())
    html.append('</head>')
    html.append('<body>')
    
    html.append('<h1>🌲 Azure PowerShell Dependency Forest</h1>')
    html.append('<div class="summary">')
    html.append('<h3>Building dependency trees from direct dependencies...</h3>')
    html.append('<p>This visualization shows the actual dependency relationships between packages.</p>')
    html.append('</div>')
    
    # Process each target framework
    total_direct = sum(len(packages) for packages in direct_dependencies.values())
    current = 0
    
    for framework, packages in sorted(direct_dependencies.items()):
        html.append(f'<div class="framework-section">')
        html.append(f'<h2>🎯 Target Framework: {framework}</h2>')
        html.append('<div class="dependency-forest">')
        
        for pkg in packages:
            current += 1
            print(f"📦 Building tree {current}/{total_direct}: {pkg['PackageName']} {pkg['PackageVersion']}")
            
            tree = build_dependency_tree(
                pkg["PackageName"], 
                pkg["PackageVersion"], 
                pkg["TargetFramework"], 
                manifest_lookup
            )
            all_trees.append(tree)
            
            html.append('<div class="dependency-tree">')
            html.append(f'<div class="tree-root">📦 {pkg["PackageName"]} v{pkg["PackageVersion"]} (Direct Dependency)</div>')
            html.append('<div class="tree-container">')
            if tree.get("dependencies"):
                html.append('<ul class="tree-list">')
                conflicts = detect_version_conflicts([tree])
                for dep in tree["dependencies"]:
                    html.append(render_tree_html(dep, conflicts))
                html.append('</ul>')
            else:
                html.append('<p style="margin-left: 20px; color: #6c757d; font-style: italic;">No dependencies</p>')
            html.append('</div>')
            html.append('</div>')
        
        html.append('</div>')
        html.append('</div>')
    
    # Detect conflicts across all trees
    print("🔍 Detecting version conflicts...")
    all_conflicts = detect_version_conflicts(all_trees)
    
    html.append(create_conflicts_section(all_conflicts))
    html.append(create_legend())
    
    html.append('</body></html>')
    
    output_file = Path("dependency-tree.html")
    output_file.write_text('\n'.join(html), encoding='utf-8')
    
    print(f"\n✅ Generated dependency tree visualization: {output_file.absolute()}")
    print(f"🌳 Direct dependencies processed: {total_direct}")
    print(f"🎯 Target frameworks: {len(direct_dependencies)}")
    if all_conflicts:
        print(f"⚠️  Version conflicts detected: {len(all_conflicts)}")
        for pkg, versions in all_conflicts.items():
            print(f"   • {pkg}: {', '.join(sorted(versions))}")
    else:
        print("✅ No version conflicts detected")

if __name__ == "__main__":
    main()
