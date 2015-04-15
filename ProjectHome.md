OpenWebKitSharp is a .net wrapper for the webkit engine based on the WebKit.NET 0.5 project. It adds more functionality to the 0.5 version and it provides more methods than that build. OpenWebKitSharp supports both the Cairo build (0.5) and the nightly builds of webkit (Nightly by default). In Version 1.5 Stable and more the nightly build is included and automatically copied after building. In earlier versions this happens with the cairo build. OpenWebKitSharp currently powers GTLite Navigator, a fast, stable and flexible web browser.

OpenWebKitSharp is developed by GT Web Software (http://www.gt-web-software.webs.com/)

Show us what you have done with OpenWebKitSharp: http://gt-web-software.webs.com/apps/forums/show/6508813-show-off-your-openwebkitsharp-application-

# Version 3 re-released as Version 3.0.1.0023 with important bug fixes #

Check below in the changelog for more details

# Important - critical bug fixed! #

Version 3.0 has been released with the most important change being the fix to a huge memory leak that occured due to false management of mouseDidMoveOverElement inside uiDelegate.cs. The code has been modified but the methods that relied on this buggy implementation are still avaiable and working correctly. A lot of changes have been made to the project to keep the same features while reducing memory usage, together with the Dispose() and Release() (internal) methods for DOM objects.

# Support by Donating #

If you want to support this project financially you can do so using this page: http://gt-web-software.webs.com/apps/donations/

# WebKit Developers needed #

As some of you might already know, a huge number of methods and properties are not implemented in the Windows port of the Nightly WebKit Build, like DOMEvents, Undo/Redo actions (custom method implemented in OpenWebKitSharp) and Headers management. All these things are implemented inside OpenWebKitSharp but cannot be used because they are not available inside WebKit. So, if some of you are interested in helping the development of OpenWebKitSharp and you have the appropriate knowledge to improve the Windows port of WebKit then your contribution would be highly appreciated and you will certainly be credited.


# Updates #

**Version 3.0.1.0023:**

Fixed dispose and finalizing bugs that could cause crash
FIxed printing dialogs' size bug

Fixed Binary\_NET2 files because they were build for .NET Framework 4.0 instead
of 2.0

Added new event: HTTPErrorOccured

Minor bug fixes

**Version 3.0:**

Fixed huge memory leak which occured due to false management of the
mouseDidMoveOverElement method from UIDelegate

Using custom WebKit build with better DOM management (source included) and more
methods implemented

Added more functions for interfering with HTML inside DOM

Added Dispose() method inside DOM and HTML classes, which destroy the COM object
using Marshal.ReleaseCOMObject() in order to fix memory leaks


**Version 2.9:**

Added LinuxWebKitBrowser for use in Linux with GTK

Fixed IgnoreSSLErrors

Minor bug fixes and optimizations

Included JSCore in OpenWebKitSharp.sln

Upgraded engine


**Version 2.8:**

Added Appearance class for interfering with how the page looks

Now PopupCreated and NewWindowCreated events are trigered also at the first time a link is clicked

PluginFailed is also trigered via IWebUIDelegatePrivate and with description string

Focus issues fixed

Windows 8 compatibility improved


**Version 2.7.0.2301:**

Fixed null events

Added AddMessageToConsole event at ScriptManager

Fixed minor bugs

Better error handling to increase stability

Fixed some methods inside uiDelegate.cs that would throw exceptions during debugging

**Version 2.7([r119](https://code.google.com/p/open-webkit-sharp/source/detail?r=119)):**

Updated to the latest WebKit revision (108083)

Created custom undo-redo system

Added the ability to accept or reject a Geolocation policy request

Added the WebKit Modified Source folder to show the changes that are made in the
interfaces and not violate Apple's license

Added Binaries.txt

Minor code optimizations

Reset repository due to TortoiseSVN errors

**Version 2.6.1([r118](https://code.google.com/p/open-webkit-sharp/source/detail?r=118)):**

Fixed null events

Created Binary\_NET2 and updated all folders with the correct DLL combinations

Updated the example projects to use the correct dlls

**Version 2.6([r117](https://code.google.com/p/open-webkit-sharp/source/detail?r=117)):**

Fixed minor bugs and removed unnecessary code parts

Added the ability to listen to specific events of all the DOM Objects that can
be accessed including mouseover, click, keyup, keydown and focus

**Version 2.5([r115](https://code.google.com/p/open-webkit-sharp/source/detail?r=115)):**

Upgraded to the latest WebKit revision

Fixed context menu bugs

Fixed JSManagement.CallFunction that didn't work in previous versions

Improved Downloader's compatibility

General bug fixes and overall performance improved

Disabled the run of the terminal at the startup by using IWebPreferencesPrivate to enable the inspector

**Version 2.4([r111](https://code.google.com/p/open-webkit-sharp/source/detail?r=111)):**

Added modified JSCore project to enable JavaScript access via C# (only in .NET
4)

Upgraded to the latest WebKit ([r103679](https://code.google.com/p/open-webkit-sharp/source/detail?r=103679))

Fixed general bugs

Fixed Printing (it is now done via the .NET WebBrowser object)

Created Release\_NET2 and Debug\_NET2 for people who want to use OpenWebKitSharp
with .NET Framework 2 but they don't have access to JSCore

Reorganized project

**Version 2.3([r105](https://code.google.com/p/open-webkit-sharp/source/detail?r=105)):**

PopupCreated event and NewWindowCreated events are propertly working

LinkContextMenu added

Improved the way modals are loaded

Fixed minor bugs


**Version 2.2([r100](https://code.google.com/p/open-webkit-sharp/source/detail?r=100)):**

WebInspector is now available to be used

Fixed Download Image bug

Added PageZoom property

Improved Downloader's performance

Started developing a method for listening DOM events (cannot be used yet)


**Version 2.1([r67](https://code.google.com/p/open-webkit-sharp/source/detail?r=67)):**

Fixed print dialog issues

Fixed stability issues (downgrading to earlier WebKit)


**Version 2.1([r55](https://code.google.com/p/open-webkit-sharp/source/detail?r=55)):**

Improved LanguageLoader with more languages (Credits at Credits.ini)

Upgraded to the latest WebKit revision

Fixed general bugs

Removed the dependency on WebKit.Interop.old.dll and IWebFramePrivate interface

imported to the new interop and type library

Printing bugs probably fixed (testers needed)

From now on, the development of OpenWebKitSharp will move to revision changes
intead of version changes


**Version 2.0:**

Completely changed working environment

Upgraded to newer WebKit engine

Major bug fixes (including the NullReferenceExceptions when editing preferences)

Stability increased and no more COMException crashes

Fixed the Navigating event

languageLoader completed

Added Header support (edit, add and get headers for a request)

ResourceIntercepter completed

Compatibility with VS2011 improved

Added How-To-Use.txt (Please read it! Important changes compared to earlier versions)



**Version 1.9:**

Added ResourceIntercepter class (monitoring the loading of all resources that
the page attempts to load)

Improved Popup Detecter

Many Bug-Fixes and General and Stability Improvements

OpenWebKitSharp.manifest can now be created if not exists in the build directory

Added How to use.txt file

Added example of the ResourceIntercepter class in the example project

Major bug in GlobalPreferences fixed (sometimes the preferences were not
editable)


**Version 1.7:**

TukruScript Plugins Implementation (More info
at:http://intellotech.x10.mx/tukruscript/)

TukruScript Example Project added

PopupCreated event

Popup Blocker inside the example project

The user can now edit the default context menu for the body and when text is
selected

FaviconAvailable event now returns the favicon more quickly and with no freeze
(using BackgroundWorker)

ShowDownloader method

Stability Improved (less crashy)

Minor changes and bug fixes


**Version 1.6:**

Added CustomMenuImplementation example which demonstrates how custom context
menu should be used

Added new downloader (credits to MyDownloader from Code Project) which is more
advanced than the previous one and supports more hosting services

Added ViewSource form and WebKitBrowser.GetSourceCode (Credits to Philippe Asmar)

Fixed general bugs

Removed StartSpeaking and StopSpeaking (which didn't function)




**Version 1.5 Stable:**

StatusText bug fixed

Nightly build included instead of Cairo

Added CSS management with 5 new classes

Added the ability to create custom context menu and giving information about the element that the cursor is currently on

Fixed bugs in default downloader

IsWebBrowserContextMenuEnabled changed to UseDefaultContextMenu which, if false, allows custom menu implementation via Browser.CustomContextMenuManager

Fixed ElementAtPoint

Added a few new features to WebKitBrowser

Fixed bugs in Example Project





**Version 1.5 Beta:**

StatusText gives the Url of the link when using Nightly Builds

Fixed minor performance issues

Upgraded to WebKit 534

Improved downloader (thanks to dodgeball)

Fixed a few bugs in example project

Added CanCopyLinkContents, CanCopySelectedText properties and CopySelectedText
and CopyLinkContents methods
Eliminated some annoying and useless exceptions which occured while debugging

Added Document.GetElementById and HTMLElement.ID




**Version 1.2R1 Released:**

Eliminated the Null Exception when debugging and the url is empty

Fixed a bug in the example project for the new window (works only with nightly builds)




**Version 1.2 Released! Changes:**

Added Example Project

Fixed important bugs related to the initialization of the engine, which sometimes threw exceptions (NullReferenceExceptions and Failed to Initialize Activation Context). If the 2nd exception still occurs check if the WebKitBrowser.dll.manifest file exists. If not then rebuild your OpenWebKitSharp source and set the build folder to the folder of your project where you use OpenWebKitSharp.

Added FishPhish class (credits to Eric Dong)

Added DangerousSiteDetected, ShowJavaScriptConfirmPanel, ShowJavaScriptAlertPanel and ShowJavaScriptInputPanel events.

Minor Bugs Fixes


# Getting Started #

In order to use OpenWebKitSharp with your project you must follow these steps:


1. Reference OpenWebKitSharp.dll and WebKit.Interop.dll in your project

2. Copy the contents of the cairo build to your debug/release folder.

3. Build your project

4. You are ready to use OpenWebKitSharp with your project


If you want to develop OpenWebKitSharp together with your main project then add the OpenWebKitSharp project to your solution and set the build path to your main project's build path. OpenWebKitSharp 1.2 and newer versions will place the cairo build inside the build folder by default. If you don't want the project to do so then remove all lines from the post-build events.

In order to use a nightly build follow the steps of this guide (Credits to Peter Nelson):
http://peterdn.com/post/(First!)-Using-WebKit-nightly-builds-with-WebKit-NET.aspx

# Changelog compared to WebKit.NET 0.5 #

DownloadBegin event now returns as arguments the url of the file and the suggested file name letting you handle downloads in your own way or use the advanced built-in downloader.

You can create your own downloader by setting Browser.WillHandleDownloadsManually = true. Otherwise the event will not be fired and the default downloader will show up.

ProgressChanged event

StatusTextChanged event.

WindowClosed event.

Added form delegate, which fires an event when the user submits a form, edits a textbox of a form etc.

Find method with text highlighting and total matches information

Page and Text Zoom easily accesible (IncreaseZoom, DecreaseZoom etc.)

Added StartSpeaking and StopSpeaking methods (WebView.startSpeaking and WebView.stopSpeaking)

Added GlobalPreferences class

Added FaviconAvailable event

Cutom ContextMenu can be implemented

CSS management

Many new features including a Resources Intercepter, a Popup detector and support for TukruScript (plugin framework)


# Future Plans #

Better DOM Access - Started working...

Provide better Script Management