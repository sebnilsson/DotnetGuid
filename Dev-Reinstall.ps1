dotnet tool uninstall -g dotnet-guid

dotnet pack 'src/DotnetGuid/DotnetGuid.csproj' --output ./

dotnet tool install -g dotnet-guid --add-source 'src/DotnetGuid/'
