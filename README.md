# CabMaker

CabMaker is a free tool that lets you quickly and easily package up a folder of files into a .cab (Cabinet) file.

It's essentially a GUI for makecab.exe (the command-line utility that ships with Windows).

It's a helpful utility for certain scenarios like SharePoint and InfoPath development. Both of those rely on .cab files but with different file extensions (.wsp for SharePoint and .xsn for InfoPath).

CabMaker does _not_ support every single option that's built into makecab.exe, nor does it support the entire range of options provided by the [cab file spec](https://msdn.microsoft.com/en-us/library/bb417343.aspx). If you need additional options, please edit the source code and add whatever you need to suit your requirements.

This was a tool I built in literally 5 minutes to help with SharePoint development as described [in this blog post](https://yieldreturnpost.wordpress.com/2016/06/22/free-tool-to-create-cab-file-from-folder/), so please keep that in mind when downloading and using the tool.

Enjoy!
