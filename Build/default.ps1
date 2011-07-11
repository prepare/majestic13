Properties {
	$build_dir = Split-Path $psake.build_script_file
	$artifacts_dir = "$build_dir\Artifacts"
	$build_artifacts_dir = "$artifacts_dir\lib\"
	$solution_dir = "$build_dir\BuildSolutions\"
	$builds = @(
		@{Name = "Majestic13.Net20"; OutputDir = "Net35\"},
		@{Name = "Majestic13.Net40"; OutputDir = "Net4\"},
		@{Name = "Majestic13.SL40"; OutputDir = "SL4\"},
		@{Name = "Majestic13.WP70"; OutputDir = "SL3-WP\"}
	)

	$nuspec = "$artifacts_dir\Majestic13.nuspec"
}

function Get-BuildSolution($name) {
	Join-Path $solution_dir ("$name" + ".sln")
}

Task Default -Depends BuildAllPlatforms

Task BuildAllPlatforms -Depends Clean, Build

Task Build -Depends Clean {
	foreach ($build in $builds) {
		$name = $build.Name
		$solution = (Get-BuildSolution($name))
		$outdir = Join-Path $build_artifacts_dir $build.OutputDir
		Write-Host "Building $name" -ForegroundColor Green
		Exec { msbuild "$solution" /t:Rebuild /p:Configuration=Release /v:quiet /p:OutDir=$outdir } 
	}
}

Task Clean {
	Write-Host "Creating BuildArtifacts directory" -ForegroundColor Green
	if (Test-Path $build_artifacts_dir) 
	{
		rd $build_artifacts_dir -rec -force | out-null
	}
	
	mkdir $build_artifacts_dir | out-null
	
	Write-Host "Cleaning helloworld.sln" -ForegroundColor Green
	Exec { msbuild "$build_dir\Majestic13.Build.sln" /t:Clean /p:Configuration=Release /v:quiet } 
}

Task CreateNuget {
	Write-Host "Create NuGet package" -ForegroundColor Green
	echo $nuget
	Exec { .\Tools\NuGet.exe pack $nuspec -OutputDirectory $artifacts_dir }
}