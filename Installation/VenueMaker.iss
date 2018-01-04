#define AppVersion GetFileVersion(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe")
#define AppName GetStringFileInfo(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe", "ProductName")
#define CompanyName GetStringFileInfo(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe", "CompanyName")
#define CopyrightText GetStringFileInfo(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe", "LegalCopyright")

[Files]
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.batteries_green.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.batteries_v2.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.core.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.provider.e_sqlite3.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\VenueMaker.exe; DestDir: {app}; Flags: replacesameversion
Source: ..\VenueMaker\bin\Release\Newtonsoft.Json.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\Newtonsoft.Json.xml; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.Data.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.Data.xml; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.Graphviz.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.Graphviz.xml; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.Serialization.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.Serialization.xml; DestDir: {app}
Source: ..\VenueMaker\bin\Release\QuickGraph.xml; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLite-net.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLite-net.xml; DestDir: {app}
Source: ..\VenueMaker\bin\Release\x64\e_sqlite3.dll; DestDir: {app}\x64\
Source: ..\VenueMaker\bin\Release\x86\e_sqlite3.dll; DestDir: {app}\x86\
[Dirs]
Name: {app}\x64
Name: {app}\x86

[Icons]
Name: {group}\{#AppName}; Filename: {app}\VenueMaker.exe

[Setup]
AppCopyright={#CopyrightText}
AppName={#AppName}
AppVerName={#AppName} {#AppVersion}
AllowCancelDuringInstall=false
DefaultDirName={pf}\{#CompanyName}\{#AppName}
DefaultGroupName={#CompanyName}
DisableProgramGroupPage=true
AlwaysShowComponentsList=false
DisableReadyPage=true
ShowLanguageDialog=auto
AppPublisher={#CompanyName}
AppPublisherURL=http://mawingu.se/
AppSupportURL=http://mawingu.se/
AppUpdatesURL=http://mawingu.se/
AppID={{261C8BD3-34E8-40EE-AD36-030BEF9D48EB}
OutputBaseFilename=setup_{#AppName}_{#AppVersion}
UninstallDisplayName={#AppName}

[LangOptions]
LanguageName=Swedish
LanguageID=$041D

[Languages]
Name: Svenska; MessagesFile: compiler:Languages\Swedish.isl
