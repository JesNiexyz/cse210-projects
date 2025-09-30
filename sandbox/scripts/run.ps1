param(
    [string]$name
)

if (-not $name) {
    Write-Host "Usage: .\run.ps1 <SandboxName>"
    exit 1
}

$proj = Join-Path -Path $PSScriptRoot -ChildPath "..\sandboxes\$name\$name.csproj"
if (-not (Test-Path $proj)) {
    Write-Host "Could not find project: $proj"
    exit 1
}

dotnet run --project $proj
