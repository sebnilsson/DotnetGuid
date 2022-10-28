$csproj = 'src/DotnetGuid/DotnetGuid.csproj'

dotnet tool uninstall -g dotnet-guid

dotnet pack $csproj --output ./nupkg

$version = ([Xml] (Get-Content $csproj)).Project.PropertyGroup.Version

dotnet tool install -g dotnet-guid --add-source 'nupkg/' --version $version
