@echo off
if not exist "bin\nuget" mkdir "bin\nuget"
nuget pack AutoBuildConfig/BDDD.nuspec
move "BDDD.*.nupkg" "bin\nuget\"
