@('test/Cortex.SimpleSerialize.Tests') | % { 
    dotnet test $_
    if (!$?) { throw 'Tests failed' }
}
$v = (dotnet ./tools/gitversion/GitVersion.dll | ConvertFrom-Json)
dotnet pack src/Cortex.SimpleSerialize -c Release -p:InformationalVersion=$($v.SemVer)+$($v.ShortSha) -p:Version=$($v.SemVer) -p:NuGetVersion=$($v.NuGetVersion)
