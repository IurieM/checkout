$src = (Get-Item -Path ".\" -Verbose).FullName;
$services = @()

$services += @{name="src\Apis\Identity\Identity.API";}
$services += @{name="src\Apis\Catalog\Catalog.Api";}
$services += @{name="src\Apis\Basket\Basket.Api";}
$services += @{name="src\Client\WebSpa"; angularcli = "true";}

setx ASPNETCORE_ENVIRONMENT "Development"

$services | % { 
	echo "Starting $($_.name) ..."
	$cdProjectDir = [string]::Format("cd /d {0}\{1}",$src, $_.name);
	$command = '';
	if($_.angularcli -eq "true")
	{
		$command = " && npm install && npm run start"
	}
	else
	{
		$command = " &&  dotnet restore && dotnet run"
	}
	$params=@("/C"; $cdProjectDir; $command; )	
	Start-Process -Verb runas "cmd.exe" $params;
}

