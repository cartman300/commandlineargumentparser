@echo off
set /p akey=API Key: 
echo Using API key "%akey%"

nuget pack
nuget push CARP.ArgumentParser.1.0.0.nupkg %akey% -Source https://www.nuget.org/api/v2/CARP.ArgumentParser

pause
