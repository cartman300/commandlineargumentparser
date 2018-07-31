rem @echo off
setlocal
del CARP.ArgumentParser.*.nupkg

nuget pack

dir /b CARP.ArgumentParser.*.nupkg | (set /p PkgName= )
nuget push CARP.ArgumentParser.1.0.0.nupkg %NUGET_PUSH_NEW% -Source https://www.nuget.org/api/v2/package

pause
