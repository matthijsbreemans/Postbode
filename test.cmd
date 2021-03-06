nuget install OpenCover -Version 4.6.519 -OutputDirectory tools
nuget install coveralls.io -Version 1.3.4 -OutputDirectory tools

.\tools\OpenCover.4.6.519\tools\OpenCover.Console.exe -register:user -oldStyle -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test test/Postbode.Test" -output:"coverage.xml"

SET PATH=C:\\Python34;C:\\Python34\\Scripts;%PATH%

pip install codecov

codecov -f "coverage.xml"