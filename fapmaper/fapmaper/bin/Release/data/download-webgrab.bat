@echo off
echo Downloading file...
powershell -Command "(New-Object Net.WebClient).DownloadFile('https://github.com/0xC0LD/webgrab/raw/master/webgrab/webgrab/bin/Release/webgrab.exe', 'webgrab.exe')"
echo Done!