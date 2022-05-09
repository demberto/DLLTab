#define AppName "DLLTab"
#define AppVersion "0.1.0"
#define AppPublisher "demberto"
#define AppURL "https://github.com/demberto/DLLTab"

[Setup]
AppId={{CC402EAC-4EF3-445D-B880-140341BD4B3D}
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}/issues
AppUpdatesURL={#AppURL}/releases
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
LicenseFile=..\LICENSE
OutputDir=..\build
OutputBaseFilename=DLLTab
Compression=lzma
SolidCompression=yes
WizardStyle=modern
WizardSizePercent=100
DisableReadyPage=yes
DisableFinishedPage=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "armenian"; MessagesFile: "compiler:Languages\Armenian.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "icelandic"; MessagesFile: "compiler:Languages\Icelandic.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "slovak"; MessagesFile: "compiler:Languages\Slovak.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Files]
Source: "..\bin\Release\DLLTab.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\PeNet.Asn1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\PeNet.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\ServerRegistrationManager.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\SharpShell.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
// Issue - https://github.com/secana/PeNet/issues/238
// Solution - https://stackoverflow.com/a/62770487
Source: "..\patch\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\System.Security.Cryptography.Pkcs.dll"; DestDir: "{app}"; Flags: ignoreversion

[Run]
Filename: "{app}\ServerRegistrationManager"; Parameters: "install {app}\DLLTab.dll -codebase"; StatusMsg: "Registering COM server..."; Flags: runhidden;

[UninstallRun]
Filename: "{app}\ServerRegistrationManager"; Parameters: "uninstall {app}\DLLTab.dll"; Flags: runhidden;
Filename: "{cmd}"; Parameters: "/c tskill explorer"; Flags: runhidden nowait;

[Code]
procedure CurPageChanged(CurPageID: Integer);
begin
  if CurPageID = wpSelectDir then
    WizardForm.NextButton.Caption := SetupMessage(msgButtonInstall)
  else
    WizardForm.NextButton.Caption := SetupMessage(msgButtonNext);
end;