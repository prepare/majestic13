$scriptPath = Split-Path $MyInvocation.InvocationName
Import-Module -force (join-path $scriptPath "Tools\psake.psm1")
invoke-psake ".\default.ps1" -framework '4.0x86'