@echo off
echo Downloading file...
powershell -Command "(New-Object Net.WebClient).DownloadFile('https://github.com/0xC0LD/fscan/raw/master/fscan/bin/Release/fscan.exe', 'fscan.exe')"
echo Done!