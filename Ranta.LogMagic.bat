msbuild Ranta.LogMagic.Net40\Ranta.LogMagic.Net40.csproj /t:rebuild /p:configuration=release;DocumentationFile=bin\Release\Ranta.LogMagic.xml;DebugType=none

msbuild Ranta.LogMagic.Net45\Ranta.LogMagic.Net45.csproj /t:rebuild /p:configuration=release;DocumentationFile=bin\Release\Ranta.LogMagic.xml;DebugType=none

nuget pack Ranta.LogMagic.nuspec

move /y Ranta.LogMagic.*.nupkg ..\Nuget\Packages

pause