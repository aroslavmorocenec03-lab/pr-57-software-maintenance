$ErrorActionPreference = 'Stop'
Push-Location $PSScriptRoot/..
try {
    dotnet build DemoApp.Checks/DemoApp.Checks.csproj --configuration Release
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
    dotnet run --project DemoApp.Checks/DemoApp.Checks.csproj --configuration Release --no-build
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
} finally { Pop-Location }
