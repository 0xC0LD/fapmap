# fapmap
Hidden personal gallery of erotica (C#, GUI)

Programs in this repository:
- fapmaper ("fapmaper" is the "installation" program... all it really does is copy the contents from the "data" folder to the given location, then it hides the destination folder):
- Lock (LockedFolder) (password GUI) ("Lock" should be the entry point of your gallery. The program is supposed to be accessed through a shortcut on your desktop. When opened, the user should be prompted with a password GUI (the password is stored in the data/password.dll file)):
- fapmap ("fapmap" is the file browser, link/URL bookmarker):
    - custom video player UI (uses WMP binaries)
    - custom image/gif viewer UI
    - a file downloader (+ GUI for webgrab)
    - a file scanner (GUI for fscan)
    - a video downloader (GUI for youtube-dl)
    - a media converter (GUI for ffmpeg)
    - a video downloader (GUI for youtube-dl)
    - an editable URL/website board with favicons (./data/favicons)
    - settings (./data/fapmap.ini)

EVERY GUI PREVIEW IN ONE [IMAGE](https://github.com/0xC0LD/fapmap/blob/master/fapmap.png)

TIPS/HINTS:
- hover over buttons to see what they do... (tooltip)
- you can drag 'n' drop links in the treeview/fileDisplay to open them in the downloader
- you can drag 'n' drop files
- before opening downloader/fscan/youtube-dl/... select the working location in the treeview/fileDisplay
- ctrl + scroll on fileDisplay to zoom in/out icons
- in the Video Player you can change the audio peek
  for the audio graph by holding the mouse on the text label and moving your mouse up/down...
  right click on the audio peek label to enable/disable auto peek change


OTHER INFO:
- Some of the icons/images used in the GUI can be found on the web...
- More info: [here](https://github.com/0xC0LD/fapmap/blob/master/fapmaper/fapmaper/bin/Release/data/ReadMe.txt)