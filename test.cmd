nuget install OpenCover -Version 4.6.519 -OutputDirectory tools
nuget install coveralls.io -Version 1.3.4 -OutputDirectory tools

C:\projects\postbode\tools\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe -register:user -oldStyle -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test test/Postbode.Test" -output:"coverage.xml"
C:\projects\postbode\tools\packages\coveralls.io\1.3.4\tools\coveralls.net.exe --opencover coverage.xml