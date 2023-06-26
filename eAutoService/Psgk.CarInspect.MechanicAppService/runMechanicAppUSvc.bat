@echo off
setlocal

set "bat_dir=%~dp0"
set "projekt_dir=%bat_dir%Psgk.CarInspect.ClientAppService.Rest"

cd /d "%projekt_dir%"

dotnet run

endlocal
