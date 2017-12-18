# CabMaker

CabMaker is a free tool that lets you quickly package up an entire folder of files (including subfolders) into a .cab file.

It's a helpful utility for certain development scenarios like working with SharePoint .wsp files or InfoPath .xsn files (both of which are actually just .cab files with different extensions).

Essentially, what it does is provide a graphical user interface on top of the "makecab" command-line utility that ships with Windows. In fact, it literally calls "makecab" under the hood to create the actual .cab file. But it removes all the work you'd normally have to do of creating a .ddf file to describe all the files you want to include (which is a tedious and error-prone process).

CabMaker does _not_ support every single option that's built into "makecab" in Windows. If you need additional options, please edit the source code and add whatever you need for your particular requirements.

This was a tool I built in literally 5 minutes to help with SharePoint development as described [in this blog post](https://yieldreturnpost.wordpress.com/2016/06/22/free-tool-to-create-cab-file-from-folder/), so please keep that in mind when downloading and using the tool.

Enjoy!
