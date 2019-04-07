@echo off
SET "HOSTS=%WinDir%\System32\drivers\etc\hosts"
SET "THOSTS=%TEMP%\hosts"

Attrib -r %HOSTS%

FINDSTR /V "smadav.org" "%HOSTS%" > "%THOSTS%"
ECHO #removed1 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "smadav.net" "%HOSTS%" > "%THOSTS%"
ECHO #removed2 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "lempar.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed3 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "sistemcerdas.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed4 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "konfirmasi.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed5 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "smadaver.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed6 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "viruslokal.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed7 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "mesiu.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed8 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "smadav.co" "%HOSTS%" > "%THOSTS%"
ECHO #removed9 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "prblm.com" "%HOSTS%" > "%THOSTS%"
ECHO #removed10 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

FINDSTR /V "smadav.me" "%HOSTS%" > "%THOSTS%"
ECHO #removed11 >> "%THOSTS%"
COPY /b/v/y "%THOSTS%" "%HOSTS%"

Attrib +r %HOSTS%

exit



