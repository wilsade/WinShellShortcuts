using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShellShortcuts
{
  /// <summary>
  /// Constantes
  /// </summary>
  public static class Constantes
  {
    /// <summary>
    /// Directory\shell\{0}\command
    /// </summary>
    public const string DirectoryPromptAquiCommand = @"Directory\shell\{0}\command";
    public const string DirectoryPromptAqui = @"Directory\shell\{0}";

    /// <summary>
    /// Directory\shell\runas
    /// </summary>
    public const string DirectoryShellRunas = @"Directory\shell\runas";

    /// <summary>
    /// Directory\Background\shell\runas
    /// </summary>
    public const string DirectoryBackgroundShellRunas = @"Directory\Background\shell\runas";

    /// <summary>
    /// Directory\shell\runas\command
    /// </summary>
    public const string DirectoryShellRunasCommand = @"Directory\shell\runas\command";

    /// <summary>
    /// Directory\Background\shell\runas\command
    /// </summary>
    public const string DirectoryBackgroundShellRunasCommand = @"Directory\Background\shell\runas\command";

    /// <summary>
    /// NoWorkingDirectory
    /// </summary>
    public const string NoWorkingDirectory = "NoWorkingDirectory";

    /// <summary>
    /// Directory\background\shell\{0}\command
    /// </summary>
    public const string DirectoryBackPromptAquiCommand = @"Directory\background\shell\{0}\command";
    public const string DirectoryBackPromptAqui = @"Directory\background\shell\{0}";

    /// <summary>
    /// Directory\shell\{0}\command
    /// </summary>
    public const string DirectoryCopiarNomePastaCommand = @"Directory\shell\{0}\command";
    public const string DirectoryCopiarNomePasta = @"Directory\shell\{0}";

    /// <summary>
    /// Directory\shell\{0}\command
    /// </summary>
    public const string DirectoryVerificarUsoPastaCommand = @"Directory\shell\{0}\command";
    public const string DirectoryVerificarUsoPasta = @"Directory\shell\{0}";

    /// <summary>
    /// Directory\background\shell\{0}\command
    /// </summary>
    public const string DirectoryBackCopiarNomePastaCommand = @"Directory\background\shell\{0}\command";
    public const string DirectoryBackCopiarNomePasta = @"Directory\background\shell\{0}";

    /// <summary>
    /// *\shell\{0}\command
    /// </summary>
    public const string ArquivoPromptAquiCommand = @"*\shell\{0}\command";
    public const string ArquivoPromptAqui = @"*\shell\{0}";

    /// <summary>
    /// *\shell\runas
    /// </summary>
    public const string ArquivoShellRunas = @"*\shell\runas";

    /// <summary>
    /// *\shell\runas\command
    /// </summary>
    public const string ArquivoShellRunasCommand = @"*\shell\runas\command";

    /// <summary>
    /// *\shell\{0}\command
    /// </summary>
    public const string ArquivoCopiarNomePastaOuNomeArquivoCommand = @"*\shell\{0}\command";
    public const string ArquivoCopiarNomePastaOuNomeArquivo = @"*\shell\{0}";

    /// <summary>
    /// HK_CurrentUser\Software\Microsoft\Windows\CurrentVersion\Explorer
    /// </summary>
    public const string SoftwareMicrosoftWindowsCurrentVersionExplorer = @"Software\Microsoft\Windows\CurrentVersion\Explorer";

    /// <summary>
    /// MultipleInvokePromptMinimum
    /// </summary>
    public const string MultipleInvokePromptMinimum = "MultipleInvokePromptMinimum";

    /// <summary>
    /// Caminho de ícone para copiar nome de arquivo
    /// http://help4windows.com/windows_7_imageres_dll.shtml
    /// </summary>
    public const string IconeCopiarArquivo = @"%SystemRoot%\system32\imageres.dll,14";

    /// <summary>
    /// Caminho de ícone para copiar pasta
    /// </summary>
    public const string IconeCopiarPasta = @"%SystemRoot%\system32\imageres.dll,153";

    /// <summary>
    /// Caminho de ícone para verificar uso da pasta
    /// http://help4windows.com/windows_7_imageres_dll.shtml
    /// </summary>
    //public const string IconeVerificarUsoPasta = @"%SystemRoot%\system32\shell32.dll,171";
    //public const string IconeVerificarUsoPasta = @"%SystemRoot%\system32\imageres.dll,73";
    public const string IconeVerificarUsoPasta = @"%SystemRoot%\system32\imageres.dll,7";

    /// <summary>
    /// Caminho de ícone para prompt
    /// </summary>
    public const string IconePrompt = @"%SystemRoot%\system32\cmd.exe";

    /// <summary>
    /// "Icon"
    /// </summary>
    public const string Icon = "Icon";

    /// <summary>
    /// Caminho do executável Handle
    /// </summary>
    public static readonly string HandlePath = Path.Combine(
      Path.GetDirectoryName(Application.ExecutablePath), "Handle.exe");

    /// <summary>
    /// Caminho do executável WinShellShortcuts
    /// </summary>
    public static readonly string WinShellShortcutsFullPath =
      Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WinShellShortcuts.exe");

    /// <summary>
    /// Caminho do executável WinShellShortcuts de administrador
    /// </summary>
    public static readonly string WinShellShortcutsFullPath_Adm =
      Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WinShellShortcuts_Adm.exe");
  }

  /// <summary>
  /// Valores para as ações no menu de diretório
  /// </summary>
  public static class DirectoryValues
  {
    /// <summary>
    /// Valor de Directory\shell\Prompt aqui\command
    /// </summary>
    public const string PromptAqui = "cmd.exe /k cd %1";

    /// <summary>
    /// Caminho completo do executável + comando para copiar o arquivo selecionado
    /// </summary>
    public static readonly string CopiarNomePasta =
      string.Format("\"{0}\" /c=DiretorioCopiarNomePasta \"%1\"", Application.ExecutablePath);

    /// <summary>
    /// Caminho completo do Handle + comando para verificar uso da pasta
    /// </summary>
    public static readonly string VerificarUsoPasta =
      string.Format("\"{0}\" /h=DiretorioVerificarUsoPasta \"%1\"",
        Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WinShellShortcuts.exe"));
    //Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "WinShellShortcuts_adm.exe"));

    /// <summary>
    /// Valores para as ações no menu de runas
    /// </summary>
    public static class RunasValues
    {
      /// <summary>
      /// Valor de Directory\shell\runas\command
      /// </summary>
      public const string PromptAqui = "cmd.exe /k cd %1";
    }
  }

  /// <summary>
  /// Valores para ações no menu background de diretório
  /// </summary>
  public static class DirectoryBackgroundValues
  {
    /// <summary>
    /// Valor de Directory\background\shell\Prompt aqui\command
    /// </summary>
    public const string PromptAqui = "cmd.exe /k";

    /// <summary>
    /// Caminho completo do executável + comando BACK para copiar a pasta selecionada
    /// </summary>
    public static readonly string CopiarNomePasta =
      string.Format("\"{0}\" /c=DiretorioBackCopiarNomePasta \"%V\"", Application.ExecutablePath);

    /// <summary>
    /// Valor de Directory\background\shell\runas
    /// </summary>
    public static class RunasValues
    {
      /// <summary>
      /// Valor de Directory\background\shell\runas\command
      /// </summary>
      public const string PromptAqui = "cmd.exe /s /k pushd \"%V\"";
    }
  }

  /// <summary>
  /// Valores para ações no menu arquivo
  /// </summary>
  public static class ArquivoValues
  {
    /// <summary>
    /// Valor de *\shell\Prompt aqui\command
    /// </summary>
    //public const string PromptAqui = "cmd.exe /k";

    public static readonly string PromptAqui2 =
      string.Format("\"{0}\" /c=ArquivoPromptAqui \"%1\"", Application.ExecutablePath);

    /// <summary>
    /// Caminho completo do executável + comando para copiar o arquivo selecionado
    /// </summary>
    public static readonly string CopiarNomePasta =
      string.Format("\"{0}\" /c=ArquivoCopiarNomePasta \"%w\"", Application.ExecutablePath);

    /// <summary>
    /// Caminho completo do executável + comando para copiar o arquivo selecionado
    /// </summary>
    public static readonly string CopiarNomeArquivo =
      string.Format("\"{0}\" /c=ArquivoCopiarNomeArquivo \"%1\"", Application.ExecutablePath);

    /// <summary>
    /// HKEY_CLASSES_ROOT\*\shell\runas
    /// </summary>
    public static class RunasValues
    {
      /// <summary>
      /// Valor de HKEY_CLASSES_ROOT\*\shell\runas\Prompt aqui
      /// </summary>
      //public const string PromptAqui = "cmd.exe /s /k pushd \"%w\"";

      public static readonly string PromptAqui2 =
        string.Format("\"{0}\" /c=ArquivoRunasPromptAqui \"%1\"", Application.ExecutablePath);
    }
  }

  public static class MessageBoxEx
  {
    public static void ShowWarning(string text)
    {
      MessageBox.Show(text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void ShowError(string text)
    {
      MessageBox.Show(text, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
  }

}
