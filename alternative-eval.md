# Alternative way to evaluate custom instructions

Continuing the discussion in `evaluate-gh-custom-inst.md`, here's an alternative approach to evaluate the effectiveness of custom instructions for GitHub Copilot in reviewing pull requests.

## Steps to Evaluate

1. Draft 5 PRs with intentionally poor descriptions or documentation.
2. Submit these PRs as drafts to the original repository.
3. Request reviews from GitHub Copilot.
4. Analyze the feedback provided by Copilot to see if it identifies the issues with the descriptions or documentation.

## Notes

1. Ensure the PRs cover a variety of description issues, such as generic descriptions (e.g. "help message"), repeating the parameter name in the description.
2. The custom instruction only applies to files of this pattern "**/help/*.md", so ensure the PRs modify files that match this pattern.

## Evaluation Results (November 26, 2025)

### Test PRs Created

Five test PRs were created in `src/TestModule/TestModule/help/` to match the `**/help/*.md` pattern:

1. **PR #28933** - Generic descriptions ("Some help", "Help message", "Help text")
2. **PR #28934** - Parameter name repetition ("The resource group name", "The location")
3. **PR #28935** - Minimal descriptions ("Updates.", "RG.", "Name.")
4. **PR #28936** - Placeholder text ("{{ Add synopsis here }}", "{{ Add description here }}")
5. **PR #28937** - Mixed quality (good and bad descriptions combined)

### Detailed Results

#### PR #28933 - Generic Descriptions: ✅ 100% Detection Rate
**Copilot Comments:** 8
**All poor descriptions flagged:**
- ✓ 'Some help' (synopsis) - Flagged as over-simplified
- ✓ 'Help message for this cmdlet' (description) - Flagged as generic placeholder
- ✓ 'Help message.' - Flagged as overly generic
- ✓ 'Some description.' - Flagged as overly generic
- ✓ 'Help text.' - Flagged as overly generic
- ✓ 'The tags.' - Flagged as simply repeating parameter name
- ✓ 'Force.' - Flagged as simply repeating parameter name
- ✓ 'Does something.' - Flagged as overly generic

**Sample Copilot feedback:**
> "The SYNOPSIS contains an over-simplified description 'Some help.' This violates the help documentation requirements. Replace with a clear, specific description..."

#### PR #28934 - Parameter Name Repetition: ✅ 100% Detection Rate
**Copilot Comments:** 6
**All repetitive descriptions flagged:**
- ✓ 'The resource group name' - Flagged as over-simplified repetition
- ✓ 'The resource name' - Flagged as over-simplified repetition
- ✓ 'The location' - Flagged as over-simplified repetition
- ✓ 'The SKU' - Flagged as over-simplified repetition
- ✓ 'The capacity' - Flagged as over-simplified repetition
- ✓ 'Enable logging' - Flagged as over-simplified repetition

**Sample Copilot feedback:**
> "The parameter description 'The resource name' is over-simplified and simply repeats the parameter name. Provide a more detailed description that explains the purpose and constraints..."

#### PR #28935 - Minimal Descriptions: ✅ 100% Detection Rate
**Copilot Comments:** 8
**All minimal descriptions flagged:**
- ✓ 'Updates.' (synopsis) - Flagged as overly brief
- ✓ 'Updates resource.' (description) - Flagged as overly simplistic
- ✓ 'RG.' - Flagged as over-simplified abbreviation
- ✓ 'Name.' - Flagged as simply repeating parameter name
- ✓ 'Tag.' - Flagged as simply repeating parameter name
- ✓ 'Tier.' - Flagged as simply repeating parameter name
- ✓ 'Count.' - Flagged as simply repeating parameter name
- ✓ 'Updates.' (example) - Flagged as unhelpful

**Sample Copilot feedback:**
> "The synopsis 'Updates.' is overly brief and uninformative. It should clearly describe what this cmdlet updates and what it accomplishes..."

#### PR #28936 - Placeholder Text: ✅ 100% Detection Rate
**Copilot Comments:** 7
**All placeholder text flagged:**
- ✓ '{{ Add synopsis here }}' - Flagged as placeholder
- ✓ '{{ Add description here }}' - Flagged as placeholder
- ✓ '{{ Add parameter description here }}' (ResourceGroupName) - Flagged
- ✓ '{{ Add parameter description here }}' (Name) - Flagged
- ✓ '{{ Add parameter description here }}' (Force) - Flagged
- ✓ '{{ Add code here }}' - Flagged as placeholder
- ✓ '{{ Add description here }}' (example) - Flagged

**Sample Copilot feedback:**
> "The SYNOPSIS contains placeholder text '{{ Add synopsis here }}' instead of a meaningful description. Please provide a clear, concise description..."

#### PR #28937 - Mixed Quality: ✅ 100% Accurate Targeting
**Copilot Comments:** 3
**Only poor descriptions flagged (perfect targeting):**
- ✓ 'Name.' - Flagged as over-simplified
- ✓ 'Help message.' - Flagged as placeholder text
- ✓ 'Does something.' - Flagged as too vague
- ✓ Good descriptions NOT flagged:
  - ResourceGroupName (detailed description) - ✓ No false positive
  - Synopsis (detailed) - ✓ No false positive
  - Description (detailed) - ✓ No false positive
  - Example 1 (detailed) - ✓ No false positive
  - Example 2 (detailed) - ✓ No false positive

**Sample Copilot feedback:**
> "The parameter description 'Name.' is over-simplified and merely repeats the parameter name. Provide a meaningful description that explains what the Name parameter represents..."

### Summary and Conclusions

#### ✅ Custom Instruction is HIGHLY EFFECTIVE

**Detection Accuracy:**
- Generic descriptions: 8/8 flagged (100%)
- Parameter repetition: 6/6 flagged (100%)
- Minimal descriptions: 8/8 flagged (100%)
- Placeholder text: 7/7 flagged (100%)
- Mixed quality: 3/3 poor flagged, 0 false positives (100%)

**Total: 32/32 poor descriptions flagged with 0 false positives**

#### Key Findings

1. **Comprehensive Detection**: GitHub Copilot successfully identified ALL types of poor descriptions:
   - Generic placeholders ("help message", "some description")
   - Parameter name repetition ("The resource name")
   - Overly brief text ("Updates.", "Name.")
   - Placeholder patterns ("{{ Add description here }}")

2. **Accurate Targeting**: In the mixed-quality test (PR #28937), Copilot:
   - Correctly flagged only the 3 poor descriptions
   - Did NOT flag any of the 5+ good descriptions
   - No false positives observed

3. **Consistent Messaging**: Copilot explicitly references the custom instruction:
   - Uses phrases like "violates the help documentation requirements"
   - Provides specific, actionable suggestions for improvement
   - Maintains consistency across all reviews

4. **Proactive Suggestions**: For each flagged issue, Copilot provides:
   - Explanation of why it's problematic
   - Concrete examples of better descriptions
   - Context-appropriate suggestions

#### Evidence of Custom Instruction Impact

The custom instruction in `.github/instructions/reference-doc.instructions.md` states:
> "Avoid over-simplified description - For parameters and cmdlets, avoid over-simplified description such as 'Some help', or simply repeating the parameter name."

Copilot's feedback directly mirrors this guidance:
- Explicitly calls out "over-simplified" descriptions
- Flags parameter name repetition
- Identifies generic placeholders like "Some help"

**Conclusion**: The custom instruction is **working as intended** with 100% detection accuracy and no false positives.

---

## Additional Test: Hidden Issue in Large PR (November 26, 2025)

### Test PR #28938 - Hidden Documentation Issue: ✅ DETECTED

**Test Objective:** Can GitHub Copilot detect a single poor description hidden in a massive PR?

**PR Details:**
- **Base:** PR #28903 (NetworkCloud API version update to 2025-09-01)
- **Total changes:** 283 files modified, ~18,500 lines of code changes
- **Hidden issue:** Single line change in `src/NetworkCloud/NetworkCloud/help/Get-AzNetworkCloudAgentPool.md`
  - Changed `-Name` parameter description from: "The name of the Kubernetes cluster agent pool."
  - To: "The name." (overly brief/poor description)

**Challenge Level:** EXTREME
- 1 poor description buried in 283 files
- ~18,500 lines of legitimate API update changes
- Single word difference ("The name." vs full description)
- Hidden among hundreds of other help file changes

### Result: ✅ SUCCESS

**Copilot Comments:** 1 (targeting the exact issue)

**Detection:**
- ✓ Found the single poor description among 283 files
- ✓ Correctly identified it as overly brief and unhelpful
- ✓ Explicitly referenced the custom instruction guidelines
- ✓ Provided specific correction suggestion

**Copilot's Full Feedback:**
> "The -Name parameter description is overly brief and unhelpful. It should describe what the parameter represents, not just repeat the parameter name.
>
> The description should be: 'The name of the Kubernetes cluster agent pool.' (as it was before) rather than just 'The name.'
>
> Per the reference documentation guidelines, parameter descriptions should avoid over-simplified descriptions that simply repeat the parameter name."

**Key Observations:**

1. **Scalability:** Copilot successfully reviews large PRs (283 files, 18K+ lines) without missing small documentation issues
2. **Precision:** Identified the exact file and parameter with the poor description
3. **Context Awareness:** Recognized it was changed from a good description to a poor one
4. **Explicit Reference:** Directly cited "reference documentation guidelines" from the custom instruction
5. **No Noise:** Only 1 comment - no false positives on the 282 other files

### Final Verdict

The custom instruction demonstrates **exceptional effectiveness** across all test scenarios:

| Test Scenario | Files Changed | Poor Descriptions | Detection Rate | False Positives |
|--------------|---------------|-------------------|----------------|-----------------|
| PR #28933 (Generic) | 1 | 8 | 100% (8/8) | 0 |
| PR #28934 (Repetition) | 1 | 6 | 100% (6/6) | 0 |
| PR #28935 (Minimal) | 1 | 8 | 100% (8/8) | 0 |
| PR #28936 (Placeholder) | 1 | 7 | 100% (7/7) | 0 |
| PR #28937 (Mixed) | 1 | 3 | 100% (3/3) | 0 |
| **PR #28938 (Hidden)** | **283** | **1** | **100% (1/1)** | **0** |
| **TOTAL** | **288** | **33** | **100% (33/33)** | **0** |

**Conclusion**: The GitHub Copilot custom instruction for help documentation is **highly effective** at all scales, from small focused PRs to massive multi-hundred-file changes, with perfect accuracy and no false positives.
