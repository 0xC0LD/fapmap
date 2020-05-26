# FapMap
### Hidden personal gallery (of erotica) (C#, GUI - WinForms)
- A program/project made for COOMERS!
- Hide your personal files with a click of a button.
- Open/download files & bookmark URL(s) all inside the program.
- ...
### [ENTIRE GUI IN ONE IMAGE](https://raw.githubusercontent.com/0xC0LD/fapmap/master/screenshots/all.png) / outdated... will change this when I'm done with everything...

## Programs in This Repository:
- fapmaper (fapmaper is the "installation" program... all it really does is copy the contents from the "data" folder to the given location and then it hides the destination folder):
- Lock (LockedFolder) (password GUI) (When you "install" fapmap a shortcut should appear on your desktop. (the password is stored in the data/password.dll file)):
- fapmap ("fapmap" is the file browser, link/URL bookmarker), and it contains a/an:
    - custom video player GUI (uses WMP binaries)
    - custom image/gif viewer GUI
    - file downloader (+ GUI for [webgrab](https://github.com/0xC0LD/webgrab))
    - file scanner / dupe searcher (GUI for [fscan](https://github.com/0xC0LD/fscan))
    - video downloader (GUI for [youtube-dl](https://youtube-dl.org/))
    - media converter (GUI for [ffmpeg](https://ffmpeg.org/))
    - editable URL/website board with favicons (./data/favicons)
    - settings (./data/fapmap.ini)
- CrashHandler - just a program that watches fapmap's process and if fapmap exits without killing the CrashHandler's process first, it opens a messagebox asking if you want to open fapmap again...

## Download Latest Version:
\[[here](https://github.com/0xC0LD/fapmap/raw/master/fapmaper/fapmaper/bin/Release/newest.zip)\]
#### note: I sometimes change the files in the 'data' folder (how fapmap reads them, settings, etc.), so if you're updating, and you want everything to work, make sure to remove the data folder... but don't just delete it, backup the files that you need...

## Tips/Hints:
- hover over buttons to see what they do (tooltip)
- right click on 'Change Tabs' to see both tabs
- tray icon: left click = hide the fapmap window, right click = close fapmap
- You can open .txt/.lst files inside fapmap...
- fileDisplay: ctrl + scroll = zoom in/out icons
- drag 'n' drop a FILE path/link in the address bar to open them in a fapmap media player (also works on a media players' titlebar)
- drag 'n' drop a FILE link in the treeview/fileDisplay to open the link in a downloader
- drag 'n' drop a SITE link in the treeview/fileDisplay to open the link in a downloader and scan the webpage with webgrab (you can edit how webgrab scans the pages with the 'wgtl' line in fapmap.ini)
- drag 'n' drop files in the treeview/fileDisplay to copy them to a selected location
- before opening downloader/fscan/youtube-dl/... select the working location in the treeview/fileDisplay
- in the Video Player you can change the audio peak for the audio graph
  by holding down the mouse on the text label and moving it up & down...
  right click on the audio peak label to enable/disable auto peek change...

Quicksearch:
- drag 'n' drop a ___ to the 'Properties' button (next to the file path) to search the gallery for a file
___ can be a:
1. SITE url, uses webgrab to find the the file url, and get's the filename from it (sites supported: rule34.xxx, gelbooru.com, ... will add more)
2. FILE url, get's the filename from the url
3. filename

## Stuff Used in the Project
- Some of the icons/images used in the GUI can be found on the web...
- https://www.codeproject.com/articles/365974/autocomplete-menu
- https://github.com/fabricelacharme/ColorSlider

## More/Other Info:
- \[[here](https://github.com/0xC0LD/fapmap/blob/master/fapmaper/fapmaper/bin/Release/data/ReadMe.txt)\]
- Ask me on twitter
