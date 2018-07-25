using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using WinShellShortcuts;
using System.Collections.Generic;

namespace UnitTestProject1
{
  [TestClass]
  public class AoTestarOutput
  {
    [TestMethod]
    public void ComVariosUsos_FazParserCorreto()
    {
      string output = @"
explorer.exe       pid: 4140   type: File          BH01\sade                  A70: C:\_Wilsade

explorer.exe       pid: 4140   type: File          BH01\sade                  B6C: C:\_Wilsade\Atalhos\Desenvolvimento

explorer.exe       pid: 4140   type: File          BH01\sade                  B74: C:\_Wilsade\Atalhos\Trabalho

explorer.exe       pid: 4140   type: File          BH01\sade                  B98: C:\_Wilsade\Atalhos\Menu Iniciar

explorer.exe       pid: 4140   type: File          BH01\sade                  DA0: C:\_Wilsade\Atalhos\Quick Launch

explorer.exe       pid: 4140   type: File          BH01\sade                  EA8: C:\_Wilsade

explorer.exe       pid: 4140   type: File          BH01\sade                 18F0: C:\_Wilsade\Atalhos\Trabalho

explorer.exe       pid: 4140   type: File          BH01\sade                 1A24: C:\_Wilsade\Atalhos\Quick Launch

explorer.exe       pid: 4140   type: File          BH01\sade                 1A34: C:\_Wilsade\Atalhos\Desenvolvimento

explorer.exe       pid: 4140   type: File          BH01\sade                 1A78: C:\_Wilsade\Atalhos\Menu Iniciar

explorer.exe       pid: 4140   type: File          BH01\sade                 1FDC: C:\_Wilsade\Programas

explorer.exe       pid: 4140   type: File          BH01\sade                 1FE8: C:\_Wilsade\Programas

explorer.exe       pid: 4140   type: File          BH01\sade                 2004: C:\_Wilsade\Programas\Handle

explorer.exe       pid: 4140   type: File          BH01\sade                 2060: C:\_Wilsade\Programas\Handle

CLCL.exe           pid: 5472   type: File          BH01\sade                   28: C:\_Wilsade\Programas\_clipboards\clcl112_eng

OUTLOOK.EXE        pid: 5680   type: File          BH01\sade                 18B4: C:\_Wilsade\Outlook\sade2017_2018.pst

OUTLOOK.EXE        pid: 5680   type: File          BH01\sade                 1CCC: C:\_Wilsade\Outlook\~sade2017_2018.pst.tmp

OUTLOOK.EXE        pid: 5680   type: File          BH01\sade                 228C: C:\_Wilsade\Outlook\sade2017_2018.pst

OUTLOOK.EXE        pid: 5680   type: File          BH01\sade                 3194: C:\_Wilsade\Outlook\sade2017_2018.pst

OUTLOOK.EXE        pid: 5680   type: File          BH01\sade                 3368: C:\_Wilsade\Outlook\sade2017_2018.pst

DPoint.exe         pid: 4900   type: File          BH01\sade                   28: C:\_Wilsade\CSharp\DPoint\DPoint-Win\Bin

DPoint.exe         pid: 4900   type: File          BH01\sade                  484: C:\_Wilsade\CSharp\DPoint\DPoint-Win\Bin\DPoint.Library.dll

DPoint.exe         pid: 4900   type: File          BH01\sade                  584: C:\_Wilsade\CSharp\DPoint\DPoint-Win\Bin\DPoint.Library.XmlSerializers.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                   10: C:\_Wilsade\CSharp\Informativus\bin

Informativus.exe   pid: 10804  type: File          BH01\sade                  220: C:\_Wilsade\CSharp\Informativus\bin\Informativus.exe

Informativus.exe   pid: 10804  type: File          BH01\sade                  22C: C:\_Wilsade\CSharp\Informativus\bin\Informativus.Comuns.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  238: C:\_Wilsade\CSharp\Informativus\bin\Informativus.Comuns.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  26C: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  274: C:\_Wilsade\CSharp\Informativus\bin\Informativus.Forms.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  27C: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  280: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.WinForms.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  288: C:\_Wilsade\CSharp\Informativus\bin\Informativus.Forms.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  28C: C:\_Wilsade\CSharp\Informativus\bin\WSP.Utils.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  294: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.WinForms.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  2A8: C:\_Wilsade\CSharp\Informativus\bin\WSP.Utils.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  3B0: C:\_Wilsade\CSharp\Informativus\bin\ICSharpCode.AvalonEdit.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  434: C:\_Wilsade\CSharp\Informativus\bin\esiListener.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  46C: C:\_Wilsade\CSharp\Informativus\bin\WeifenLuo.WinFormsUI.Docking.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  490: C:\_Wilsade\CSharp\Informativus\bin\Ribbon.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  4EC: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.DataAccess.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  4F8: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.DataAccess.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  558: C:\_Wilsade\CSharp\Informativus\bin\ICSharpCode.NRefactory.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  55C: C:\_Wilsade\CSharp\Informativus\bin\Devart.Data.SqlServer.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  668: C:\_Wilsade\CSharp\Informativus\bin\Devart.Data.Oracle.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  68C: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.SqlParser.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  6A0: C:\_Wilsade\CSharp\Informativus\bin\ICSharpCode.TextEditor.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  6D4: C:\_Wilsade\CSharp\Informativus\bin\WSP.Lib.SqlParser.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  750: C:\_Wilsade\CSharp\Informativus\bin\Devart.Data.dll

Informativus.exe   pid: 10804  type: File          BH01\sade                  910: C:\_Wilsade\CSharp\Informativus\bin\gudusoft.gsqlparser.dll

cmd.exe            pid: 5492   type: File          BH01\sade                   88: C:\_Wilsade\Programas\Handle

devenv.exe         pid: 8212   type: File          BH01\sade                 12A8: C:\_Wilsade\CSharp\WinShellShortcuts

devenv.exe         pid: 8212   type: File          BH01\sade                 1968: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

devenv.exe         pid: 8212   type: File          BH01\sade                 1B80: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

devenv.exe         pid: 8212   type: File          BH01\sade                 1DE4: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

ServiceHub.RoslynCodeAnalysisService32.exe pid: 6264   type: File          BH01\sade                  7C8: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

ServiceHub.RoslynCodeAnalysisService32.exe pid: 6264   type: File          BH01\sade                  9A4: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

ServiceHub.RoslynCodeAnalysisService32.exe pid: 6264   type: File          BH01\sade                  A14: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

ServiceHub.RoslynCodeAnalysisService32.exe pid: 6264   type: File          BH01\sade                  A74: C:\_Wilsade\CSharp\WinShellShortcuts\.vs\WinShellShortcuts\v15\sqlite3\storage.ide

Handle.exe         pid: 8676   type: File          BH01\sade                   38: C:\_Wilsade\Programas\Handle

Handle64.exe       pid: 5272   type: File          BH01\sade                   20: C:\_Wilsade\Programas\Handle
";

      string[] splited = output.Split(new string[] { "\r\r", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
      Assert.AreEqual(60, splited.Length);

      var lst = new List<HandleProcessItem>();
      foreach (string estaLinha in splited)
      {
        HandleProcessItem item = HandleProcessItem.Parse(estaLinha);
        lst.Add(item);
      }
    }
  }
}
