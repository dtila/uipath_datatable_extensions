echo "Building solution"
msbuild ..\src\DataTableExtensions.sln /t:Clean,Build /p:Configuration=Release
echo "Building NuGet"
nuget pack project.nuspec -Properties Configuration=Release
pause