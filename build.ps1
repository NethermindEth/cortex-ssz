@('test/Cortex.SimpleSerialize.Tests') | % { 
    dotnet test $_
    if (!$?) { throw 'Tests failed' }
}
$v = (dotnet ./tools/gitversion/GitVersion.dll | ConvertFrom-Json)
dotnet pack src/Cortex.SimpleSerialize -c Release -p:AssemblyVersion=$($v.AssemblySemVer) -p:FileVersion=$($v.AssemblySemFileVer) -p:Version=$($v.SemVer)+$($v.CommitsSinceVersionSource).Sha.$($v.ShortSha) -p:PackageVersion=$($v.NuGetVersion)
