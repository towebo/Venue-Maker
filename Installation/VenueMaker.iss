#define AppVersion GetFileVersion(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe")
#define AppName GetStringFileInfo(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe", "ProductName")
#define CompanyName GetStringFileInfo(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe", "CompanyName")
#define CopyrightText GetStringFileInfo(AddBackslash(SourcePath) + "..\VenueMaker\bin\Release\venuemaker.exe", "LegalCopyright")
#define BinariesFolder "\src\Binaries"
#define DotNETVersionRequired "v4.8"
#define DotNETInstallExe "ndp48-web.exe"


[Files]
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.batteries_green.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.batteries_v2.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.core.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\SQLitePCLRaw.provider.e_sqlite3.dll; DestDir: {app}
Source: ..\VenueMaker\bin\Release\VenueMaker.exe; DestDir: {app}; Flags: replacesameversion
Source: ..\VenueMaker\bin\Release\VenueMaker.exe.config; DestDir: {app}; Flags: replacesameversion
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
Source: "{#BinariesFolder}\Microsoft\{#DotNETInstallExe}"; DestDir: {tmp}; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

[Dirs]
Name: {app}\x64
Name: {app}\x86

[Icons]
Name: {group}\{#AppName}; Filename: {app}\VenueMaker.exe
Name: {commondesktop}\{#AppName}; Filename: {app}\VenueMaker.exe; IconIndex: 0

[Setup]
SignTool=MAWINGU
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
AppPublisherURL=https://mawingu.se/
AppSupportURL=https://mawingu.se/
AppUpdatesURL=https://mawingu.se/
AppID={{261C8BD3-34E8-40EE-AD36-030BEF9D48EB}
OutputBaseFilename=setup_{#AppName}_{#AppVersion}
UninstallDisplayName={#AppName}

[LangOptions]
LanguageName=Swedish
LanguageID=$041D

[Languages]
Name: Svenska; MessagesFile: compiler:Languages\Swedish.isl


[Run]
Filename: {tmp}\{#DotNETInstallExe}; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft .NET Framework {#DotNETVersionRequired} installeras. Vänligen vänta...




[Code]
// .NET checking
function DotNETMinimumRelease(version : string) : Cardinal;
begin
  if (version = 'v4.5') then
  Result := 378389
  else if (version = 'v4.6.1') then
    Result := 394254
  else if (version = 'v4.7.2') then
    Result := 461808
  else if (version = 'v4.8') then
    Result := 528040
  else 
    Result := 0;

end;


function IsDotNETVersionKnownToUs(version : string) : boolean;
begin
  Result := DotNETMinimumRelease(version) > 0;
end;

function IsDotNetDetected(version: string; service: cardinal): boolean;
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key: string;
    install, release, serviceCount: cardinal;
     success: boolean;
var reqNetVer : string;
var minimum_release : Cardinal;
begin
  minimum_release := DotNETMinimumRelease(version);

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full';
    success := RegQueryDWordValue(HKLM, key, 'Install', install);
    success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
    success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);

    success := success and (release >= minimum_release);
    success := success and (install = 1) and (serviceCount >= service);

  Result := success;
end;


function IsRequiredDotNetDetected(): Boolean;  
begin
    result := IsDotNetDetected('{#DotNETVersionRequired}', 0);
end;





function InitializeSetup(): Boolean;
begin
    if not IsDotNETVersionKnownToUs('{#DotNETVersionRequired}') then begin
        MsgBox('{#AppName} kräver Microsoft .NET Framework {#DotNETVersionRequired}.'#13#13
          'Du måste ladda ner och installera det för att den här applikationen ska fungera.', mbInformation, MB_OK);
    end

    result := true;
end;
