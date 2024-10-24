# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/metaphor.yuki.skillnames/*" -Force -Recurse
dotnet publish "./metaphor.yuki.skillnames.csproj" -c Release -o "$env:RELOADEDIIMODS/metaphor.yuki.skillnames" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location