@echo off
color 0A

echo #############################################
echo ## Unity Visual Studio Utils by Luisango

:menu
echo #############################################
echo ##
echo ## Type 'install10' (VS2010) or 'install13' (VS2013) to install utilities 
echo ## or anything else to change project version.
SET /P ANSWER=## 
if /i {%ANSWER%}=={install10} (goto downloadVS2010) 
if /i {%ANSWER%}=={install13} (goto downloadVS2013)
goto changeversion

:downloadVS2010
mkdir Download > nul
if exist "Download\uvs10.msi" goto installVS2010
echo | set /p=## Downloading utils for VS2010... 
Utils\wget.exe https://visualstudiogallery.msdn.microsoft.com/6e536faa-ce73-494a-a746-6a14753015f1/file/137660/7/Visual%20Studio%202010%20Tools%20for%20Unity.msi -O Download\uvs10.msi --no-check-certificate
echo OK!

:installVS2010
echo | set /p=## Installing utils for VS2010... 
msiexec.exe /i Download\uvs10.msi
echo OK!
goto menu

:downloadVS2013
mkdir Download > nul
if exist "Download\uvs13.msi" goto installVS2013
echo | set /p=## Downloading utils for VS2013... 
Utils\wget.exe https://visualstudiogallery.msdn.microsoft.com/20b80b8c-659b-45ef-96c1-437828fe7cf2/file/92287/6/Visual%20Studio%202013%20Tools%20for%20Unity.msi -O Download\uvs13.msi --no-check-certificate
echo OK!

:installVS2013
echo | set /p=## Installing utils for VS2013... 
msiexec.exe /i Download\uvs13.msi
echo OK!
goto menu

:changeversion
if exist "Assets\UnityVS2013" goto askVS2013
if exist "Assets\UnityVS2010" goto askVS2010
echo ## 
echo ## Something is wrong with your configuration!
echo ##
goto exit

:askVS2013
SET /P ANSWER=## Do you really want to change project to VS2013? [Y/N] 
if /i {%ANSWER%}=={y} (goto changeVS2013) 
if /i {%ANSWER%}=={yes} (goto changeVS2013)
goto exit

:askVS2010
SET /P ANSWER=## Do you really want to change project to VS2010? [Y/N] 
if /i {%ANSWER%}=={y} (goto changeVS2010) 
if /i {%ANSWER%}=={yes} (goto changeVS2010)
goto exit

:changeVS2013
echo ##
echo | set /p=## Changing to VS2013... 
move "Assets\UnityVS" "Assets\UnityVS2010" > nul
move "Assets\UnityVS2013" "Assets\UnityVS" > nul
echo OK
goto exit

:changeVS2010
echo ##
echo | set /p=## Changing to VS2010... 
move "Assets\UnityVS" "Assets\UnityVS2013" > nul
move "Assets\UnityVS2010" "Assets\UnityVS" > nul
echo OK
goto exit

:exit
echo ##
echo ## Enjoy coding! :)
echo ##
pause
 
