@ECHO OFF
SET itdate=%date:~-10%
SET itdate=%itdate:~6,4%-%itdate:~3,2%-%itdate:~0,2%
echo Current date: %itdate%
xcopy /e /c /h /i /v /r /y /q World backup\%itdate%D\
xcopy /e /c /h /i /v /r /y /q plugins backup\%itdate%D\plugins\
SET hour=%time:~0,2%
IF "%hour:~0,1%" == " " SET hour=0%hour:~1,1%
xcopy /e /c /h /i /v /r /y /q backup\%itdate%D backup\%itdate%-%hour%H\
ECHO Backup Complete (assuming no errors above).  Attempting to remove old files..