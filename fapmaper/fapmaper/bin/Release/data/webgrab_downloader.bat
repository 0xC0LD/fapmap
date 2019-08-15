::======================================================
::  webgrab gets updated occasionally
::  use this downloader to download the latest version
::======================================================
@echo off
echo :: Downloading webgrab...
certutil.exe -urlcache -split -f "https://github.com/0xC0LD/webgrab/raw/master/webgrab/webgrab/bin/Release/webgrab.exe" webgrab.exe
IF ERRORLEVEL 0 echo :: Downloaded webgrab.exe successfully
pause >nul