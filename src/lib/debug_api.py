import urllib.request
import json
import gzip

def test_api():
    url = "https://api.nuget.org/v3/registration5-gz-semver2/azure.core/index.json"
    req = urllib.request.Request(url, headers={
        "User-Agent": "dependency-tree-script",
        "Accept-Encoding": "gzip, deflate"
    })
    
    with urllib.request.urlopen(req) as resp:
        print(f"Status: {resp.status}")
        print(f"Headers: {dict(resp.headers)}")
        
        data = resp.read()
        
        # Check if the response is gzipped
        if resp.headers.get('Content-Encoding') == 'gzip':
            print("Decompressing gzipped data...")
            data = gzip.decompress(data)
        
        result = json.loads(data.decode('utf-8'))
        print(f"Items count: {len(result['items'])}")
        
        found = False
        for page_idx, page in enumerate(result['items']):
            print(f"\nChecking page {page_idx + 1}...")
            
            if 'items' in page:
                items = page['items']
            else:
                # Need to fetch page content
                page_url = page['@id']
                print(f"Fetching page: {page_url}")
                
                page_req = urllib.request.Request(page_url, headers={
                    "User-Agent": "dependency-tree-script",
                    "Accept-Encoding": "gzip, deflate"
                })
                
                with urllib.request.urlopen(page_req) as page_resp:
                    page_data = page_resp.read()
                    if page_resp.headers.get('Content-Encoding') == 'gzip':
                        page_data = gzip.decompress(page_data)
                    page_result = json.loads(page_data.decode('utf-8'))
                    items = page_result.get('items', [])
            
            print(f"Items in page: {len(items)}")
            
            # Look for version 1.45.0
            for item in items:
                version = item['catalogEntry']['version']
                if version == '1.45.0':
                    print(f"Found version {version}!")
                    catalog_entry = item['catalogEntry']
                    print(f"Dependency groups: {len(catalog_entry.get('dependencyGroups', []))}")
                    
                    for group in catalog_entry.get('dependencyGroups', []):
                        tf = group.get('targetFramework', 'None')
                        deps = group.get('dependencies', [])
                        print(f"  Target framework: {tf}, Dependencies: {len(deps)}")
                        for dep in deps[:5]:  # Show first 5
                            print(f"    - {dep.get('id')} {dep.get('range', '')}")
                    found = True
                    break
            
            if found:
                break
        
        if not found:
            print("Version 1.45.0 not found!")

if __name__ == "__main__":
    test_api()