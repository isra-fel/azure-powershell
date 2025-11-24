# PR Analysis Script - Comparing before and after August 22, 2025 enhancement
# This script analyzes the time to first check and overall review time for PRs

param(
    [string]$BeforePeriod = "May 22 - Aug 22, 2025",
    [string]$AfterPeriod = "Aug 22 - Nov 22, 2025"
)

function Get-PullRequestData {
    param(
        [string]$StartDate,
        [string]$EndDate
    )

    Write-Host "Fetching PR data from $StartDate to $EndDate..." -ForegroundColor Cyan

    $query = "created:$StartDate..$EndDate"
    $prJson = gh pr list --repo Azure/azure-powershell --state all --search $query --limit 1000 --json number,title,createdAt,closedAt,mergedAt,state,comments

    return $prJson | ConvertFrom-Json
}

function Get-TimeToFirstCheck {
    param($pr)

    $createdAt = [DateTime]::Parse($pr.createdAt)

    # Look for "Azure Pipelines successfully started running" comment
    $checkStartComment = $pr.comments | Where-Object {
        $_.body -match "Azure Pipelines successfully started running.*pipeline"
    } | Select-Object -First 1

    if ($checkStartComment) {
        $checkStartedAt = [DateTime]::Parse($checkStartComment.createdAt)
        $timeToCheck = $checkStartedAt - $createdAt
        return $timeToCheck.TotalMinutes
    }

    return $null
}

function Get-TimeToClose {
    param($pr)

    if (-not $pr.closedAt) {
        return $null
    }

    $createdAt = [DateTime]::Parse($pr.createdAt)
    $closedAt = [DateTime]::Parse($pr.closedAt)
    $timeToClose = $closedAt - $createdAt

    return $timeToClose.TotalHours
}

function Analyze-Period {
    param(
        [string]$StartDate,
        [string]$EndDate,
        [string]$PeriodName
    )

    Write-Host "`n=== Analyzing $PeriodName ===" -ForegroundColor Yellow

    $prs = Get-PullRequestData -StartDate $StartDate -EndDate $EndDate

    Write-Host "Total PRs in period: $($prs.Count)" -ForegroundColor Green

    # Calculate time to first check
    $timesToFirstCheck = @()
    $prsWithChecks = 0

    foreach ($pr in $prs) {
        $timeToCheck = Get-TimeToFirstCheck -pr $pr
        if ($null -ne $timeToCheck) {
            $timesToFirstCheck += $timeToCheck
            $prsWithChecks++
        }
    }

    # Calculate time to close/merge
    $timesToClose = @()
    $closedPRs = 0

    foreach ($pr in $prs) {
        $timeToClose = Get-TimeToClose -pr $pr
        if ($null -ne $timeToClose) {
            $timesToClose += $timeToClose
            $closedPRs++
        }
    }

    # Calculate statistics
    $avgTimeToCheck = if ($timesToFirstCheck.Count -gt 0) {
        ($timesToFirstCheck | Measure-Object -Average).Average
    } else { 0 }

    $medianTimeToCheck = if ($timesToFirstCheck.Count -gt 0) {
        $sorted = $timesToFirstCheck | Sort-Object
        $sorted[[Math]::Floor($sorted.Count / 2)]
    } else { 0 }

    $avgTimeToClose = if ($timesToClose.Count -gt 0) {
        ($timesToClose | Measure-Object -Average).Average
    } else { 0 }

    $medianTimeToClose = if ($timesToClose.Count -gt 0) {
        $sorted = $timesToClose | Sort-Object
        $sorted[[Math]::Floor($sorted.Count / 2)]
    } else { 0 }

    return @{
        PeriodName = $PeriodName
        TotalPRs = $prs.Count
        PRsWithChecks = $prsWithChecks
        AvgTimeToFirstCheck = [Math]::Round($avgTimeToCheck, 2)
        MedianTimeToFirstCheck = [Math]::Round($medianTimeToCheck, 2)
        ClosedPRs = $closedPRs
        AvgTimeToClose = [Math]::Round($avgTimeToClose, 2)
        MedianTimeToClose = [Math]::Round($medianTimeToClose, 2)
    }
}

# Main execution
Write-Host "Pull Request Analysis - Impact of August 22, 2025 Enhancement" -ForegroundColor Magenta
Write-Host "================================================================" -ForegroundColor Magenta

# Analyze before period (May 22 - Aug 22, 2025)
$beforeStats = Analyze-Period -StartDate "2025-05-22" -EndDate "2025-08-22" -PeriodName $BeforePeriod

# Analyze after period (Aug 22 - Nov 22, 2025)
$afterStats = Analyze-Period -StartDate "2025-08-22" -EndDate "2025-11-22" -PeriodName $AfterPeriod

# Display results
Write-Host "`n`n=== RESULTS SUMMARY ===" -ForegroundColor Magenta
Write-Host "=====================`n" -ForegroundColor Magenta

Write-Host "BEFORE Enhancement ($($beforeStats.PeriodName)):" -ForegroundColor Cyan
Write-Host "  Total PRs: $($beforeStats.TotalPRs)"
Write-Host "  PRs with checks: $($beforeStats.PRsWithChecks)"
Write-Host "  Average time to first check: $($beforeStats.AvgTimeToFirstCheck) minutes"
Write-Host "  Median time to first check: $($beforeStats.MedianTimeToFirstCheck) minutes"
Write-Host "  Closed PRs: $($beforeStats.ClosedPRs)"
Write-Host "  Average time to close: $($beforeStats.AvgTimeToClose) hours"
Write-Host "  Median time to close: $($beforeStats.MedianTimeToClose) hours"

Write-Host "`nAFTER Enhancement ($($afterStats.PeriodName)):" -ForegroundColor Cyan
Write-Host "  Total PRs: $($afterStats.TotalPRs)"
Write-Host "  PRs with checks: $($afterStats.PRsWithChecks)"
Write-Host "  Average time to first check: $($afterStats.AvgTimeToFirstCheck) minutes"
Write-Host "  Median time to first check: $($afterStats.MedianTimeToFirstCheck) minutes"
Write-Host "  Closed PRs: $($afterStats.ClosedPRs)"
Write-Host "  Average time to close: $($afterStats.AvgTimeToClose) hours"
Write-Host "  Median time to close: $($afterStats.MedianTimeToClose) hours"

# Calculate improvements
$checkImprovement = $beforeStats.AvgTimeToFirstCheck - $afterStats.AvgTimeToFirstCheck
$checkImprovementPct = if ($beforeStats.AvgTimeToFirstCheck -gt 0) {
    [Math]::Round(($checkImprovement / $beforeStats.AvgTimeToFirstCheck) * 100, 2)
} else { 0 }

$closeImprovement = $beforeStats.AvgTimeToClose - $afterStats.AvgTimeToClose
$closeImprovementPct = if ($beforeStats.AvgTimeToClose -gt 0) {
    [Math]::Round(($closeImprovement / $beforeStats.AvgTimeToClose) * 100, 2)
} else { 0 }

Write-Host "`n=== IMPACT ANALYSIS ===" -ForegroundColor Yellow
Write-Host "=====================`n" -ForegroundColor Yellow

if ($checkImprovement -gt 0) {
    Write-Host "✓ Time to first check DECREASED by $([Math]::Round($checkImprovement, 2)) minutes ($checkImprovementPct%)" -ForegroundColor Green
} elseif ($checkImprovement -lt 0) {
    Write-Host "✗ Time to first check INCREASED by $([Math]::Round([Math]::Abs($checkImprovement), 2)) minutes ($([Math]::Abs($checkImprovementPct))%)" -ForegroundColor Red
} else {
    Write-Host "- No change in time to first check" -ForegroundColor Gray
}

if ($closeImprovement -gt 0) {
    Write-Host "✓ Time to close DECREASED by $([Math]::Round($closeImprovement, 2)) hours ($closeImprovementPct%)" -ForegroundColor Green
} elseif ($closeImprovement -lt 0) {
    Write-Host "✗ Time to close INCREASED by $([Math]::Round([Math]::Abs($closeImprovement), 2)) hours ($([Math]::Abs($closeImprovementPct))%)" -ForegroundColor Red
} else {
    Write-Host "- No change in time to close" -ForegroundColor Gray
}

Write-Host "`nAnalysis complete!" -ForegroundColor Magenta
