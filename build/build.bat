echo "Building solution"
msbuild ..\DataTableExtensions.sln /t:Clean,Build /p:Configuration=Release
echo "Building NuGet"
nuget pack project.nuspec -Properties Configuration=Release
pause