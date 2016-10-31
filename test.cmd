nuget install OpenCover -Version 4.6.519 -OutputDirectory tools
nuget install coveralls.io -Version 1.3.4 -OutputDirectory tools
.\tools\OpenCover\4.6.519\tools\opencover.console.exe -register:user -oldStyle -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test test/Postbode.Test" -output:"coverage.xml"
.\tools\coveralls.io.1.3.4\tools\coveralls.net.exe --opencover coverage.xml