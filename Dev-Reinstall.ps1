$package = 'dotnet-guid'
$project = 'DotnetGuid'
$csproj = "src/${project}/${project}.csproj"

dotnet tool uninstall -g $package

dotnet pack $csproj --output ./nupkg

$version = ([Xml] (Get-Content $csproj)).Project.PropertyGroup.Version

dotnet tool install -g $package --add-source 'nupkg/' --version $version
