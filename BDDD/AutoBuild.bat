@echo off

if NOT DEFINED DOTNET_HOME set DOTNET_HOME=%windir%\Microsoft.NET\Framework\v3.5

%DOTNET_HOME%\MSBUILD.exe AutoBuildConfig\Default.csproj
