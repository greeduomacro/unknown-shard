@ECHO OFF

title CraftBukkit Server JRE7		

Color 17		 		

java -version		 	
timeout/nobreak 3 >NUL
cls


echo Optimizing PC... PLease wait
timeout/nobreak 1 >NUL
echo Removing Temporary Files...
rmdir "%TEMP%" /s /q >NUL		
rd "%WINDIR%\Temp" /s /q >NUL		
timeout/nobreak 1 >NUL
echo Complete!
timeout/nobreak 1 >NUL
echo Prioritizing Java.exe...
cmd /c start /AboveNormal Java.exe >NUL	
timeout/nobreak 4 >NUL
echo Complete!
timeout/nobreak 1 >NUL
echo Optimization Completed Sucessfully!
timeout/nobreak 3 >NUL
cls
timeout/nobreak 1 >NUL
IF /I "%PROCESSOR_ARCHITECTURE:~-2%"=="64"  java -d64 -Xmx3070M -Xms3070M -jar "%~dp0craftbukkit-0.0.1-snapshot.jar"
IF /I "%PROCESSOR_ARCHITECTURE:~-2%"=="86"  java -jar -Xmx2024M -Xms2024M "%~dp0craftbukkit-0.0.1-snapshot.jar"

PAUSE
