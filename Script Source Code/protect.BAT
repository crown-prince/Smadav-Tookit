@echo off
SET "HOSTS=%WinDir%\System32\drivers\etc\hosts"
SET "THOSTS=%TEMP%\hosts"

Attrib -r %HOSTS%

FINDSTR /V "removed1" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		smadav.org >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed2" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1 		smadav.net >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed3" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		lempar.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed4" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		sistemcerdas.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed5" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		konfirmasi.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed6" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		smadaver.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed7" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		viruslokal.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed8" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		mesiu.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed9" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		smadav.co >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed10" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		prblm.com >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "removed11" "%HOSTS%" > "%THOSTS%"
ECHO 127.0.0.1		smadav.me >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

Attrib +r %HOSTS%

exit



