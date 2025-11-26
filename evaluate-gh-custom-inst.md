# Evaluate GitHub Copilot Custom Instructions

After introducing a custom instruction for GitHub Copilot about avoiding over-simple descriptions in the help documents, I want to verify is it working and how effective it is.

The instruction was introduced by https://github.com/Azure/azure-powershell/pull/28858 , merged on Nov 13, 2025. It's in `.github\instructions\reference-doc.instructions.md`.

## Steps to Evaluate

Look at all the pull requests created (instead of merged!) after Nov 13, 2025. See if there are any review comments about the descriptions being too simple or not detailed enough.

## Notes

1. Use GitHub CLI `gh` to interact with the repository.
2. Don't spend time checking if a PR modifies help documents or not. Check all PRs created after the instruction was introduced.
3. Focus on review comments by GitHub Copilot.

## Evaluation Results (Nov 26, 2025)

### PRs Created After Nov 13, 2025

Total PRs checked: ~50 PRs created between Nov 13-26, 2025

**PRs with GitHub Copilot reviews:** 15 PRs
- PR #28927, #28925, #28924, #28923, #28920, #28918, #28917, #28914, #28912, #28893, #28877, #28873, #28872, #28871, #28870, #28869

### Key Findings

#### PR #28927 - Add ResiliencyView parameter to Get-AzVmssVM
- **Created:** Nov 25, 2025
- **Help file modified:** `src/Compute/Compute/help/Get-AzVmssVM.md`
- **Copilot comment on help file:**
  > "The help documentation states 'This parameter is only supported when retrieving a specific VM instance (when InstanceId is provided)' but there is no validation in the code to enforce this restriction. Consider adding parameter validation or removing this restriction from the documentation. If the restriction is intentional, add code to check that InstanceId is provided when ResiliencyView is used, similar to how InstanceView is only available in the FriendMethod parameter set."

  Suggested improvement:
  ```
  Gets the resilient VM deletion status for the VM, which indicates whether retries are in progress, failed, or not started.
  ```

**Analysis:** Copilot provided a substantive suggestion to improve the parameter description, recommending a clearer and more detailed description. This aligns with the custom instruction's goal.

#### PR #28870 - New PowerShell Module for Disconnected Operations
- **Created:** Nov 14, 2025
- **Help files modified:** 9 help files in `src/DisconnectedOperations/DisconnectedOperations/help/`
- **Copilot comments:** Flagged all 9 help files with identical feedback:
  > "The help documentation contains placeholder examples that need to be replaced with actual working examples. All example sections show `{{ Add title here }}`, `{{ Add code here }}`, and `{{ Add description here }}` placeholders."

**Files flagged:**
- Get-AzDisconnectedOperationsDisconnectedOperation.md
- Get-AzDisconnectedOperationsArtifactDownloadUri.md
- Get-AzDisconnectedOperationsArtifact.md
- Update-AzDisconnectedOperationsDisconnectedOperation.md
- Remove-AzDisconnectedOperationsDisconnectedOperation.md
- Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest.md
- New-AzDisconnectedOperationsDisconnectedOperation.md
- Get-AzDisconnectedOperationsImageDownloadUri.md
- Get-AzDisconnectedOperationsImage.md

**Analysis:** Copilot correctly identified placeholder content in help documentation, which is related to the spirit of the custom instruction (avoiding low-quality descriptions).

### Other PRs

The following PRs had Copilot reviews but either:
- Did not modify help files
- Had Copilot comments on non-help files only
- Had no specific comments about descriptions

**PRs:** #28925, #28924, #28923, #28920, #28918, #28917, #28914, #28912, #28893, #28877, #28873, #28872, #28871, #28869

### Assessment

**Evidence of custom instruction working:**
- ✅ Copilot IS actively reviewing help documentation files
- ✅ Copilot IS catching issues with descriptions (placeholder content, unclear descriptions)
- ✅ Copilot provided substantive suggestions for improvement in at least 1 case (PR #28927)

**Limitations:**
- ❌ Small sample size - only 2 PRs with substantive help file modifications
- ❌ Most PRs were automated commits or didn't touch help files
- ❌ Weak correlation between findings and the specific custom instruction text
- ❌ Only 13 days of data since the instruction was introduced
- ⚠️ Comments found appear to be general Copilot review patterns, not clearly tied to the custom instruction

**Conclusion:**
The custom instruction appears to be functioning, but there isn't strong evidence that Copilot's review behavior changed specifically due to this instruction. The comments observed (placeholder detection, description clarity) may be part of Copilot's general review capabilities rather than responses to the custom instruction.

**Recommendation:**
Need a different evaluation method to determine if the custom instruction is effective, such as:
1. A/B testing with and without the instruction
2. Looking at PRs created before Nov 13 for comparison
3. Examining more PRs with substantial help file changes
4. Creating test PRs with intentionally simple descriptions to see if Copilot flags them
