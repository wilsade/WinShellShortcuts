using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Copiar todos os itens selecionados
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class CopiarItensSelecionados : RegistryBaseMenuItem
  {
    #region Construtores

    /// <summary>
    /// Cria uma instância da classe <see cref="CopiarItensSelecionados"/>
    /// </summary>
    public CopiarItensSelecionados()
    {

    }

    /// <summary>
    /// Cria uma instância da classe <see cref="CopiarItensSelecionados"/>
    /// </summary>
    /// <param name="path">Caminho do registro onde a chave se encontra</param>
    public CopiarItensSelecionados(string path)
      : base(Registry.ClassesRoot, path + "\\shell\\02CopiarItensSelecionados")
    {
      MUIVerb = "Copiar nome dos itens selecionados";
      Icon = @"%SystemRoot%\system32\DxpTaskSync.dll,2";
      Command = $"\"{Constantes.WinShellShortcutsFullPath}\" /c={typeof(CopiarItensSelecionados).FullName} ";
    }
    #endregion

    static IEnumerable<string> GetItensSelecionadosExplorer(TipoComandoEnum tipoComando)
    {
      // get the active window
      IntPtr handle = NativeMethods.GetForegroundWindow();

      string filename;

      List<Tuple<string, bool>> lstItens = new List<Tuple<string, bool>>();

      SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
      foreach (SHDocVw.InternetExplorer window in shellWindows)
      {
        // match active window
        if (window.HWND != (int)handle)
          continue;

        filename = Path.GetFileNameWithoutExtension(window.FullName).ToLower();
        if (filename.ToLowerInvariant() == "explorer")
        {
          Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
          foreach (Shell32.FolderItem item in items)
          {
            lstItens.Add(Tuple.Create(item.Path, item.IsFolder));
            //bool isArquivo = File.Exists(item.Path);

            //if (tipoComando == TipoComandoEnum.ArquivoCopiarNomeArquivo)
            //{
            //  if (isArquivo)
            //    lstItens.Add(item.Path);
            //}
            //else if (item.IsFolder)
            //  lstItens.Add(item.Path);
          }
        }
        else
          Trace.WriteLine("Não achei janela do explorer");
      }
      return lstItens.OrderByDescending(x => x.Item2).ThenBy(x => x.Item1).Select(x => x.Item1);
    }

    /// <summary>
    /// Executar o comando
    /// </summary>
    /// <param name="context">Contexto de execução</param>
    public override void Execute(object context)
    {
      IEnumerable<string> lstItens = GetItensSelecionadosExplorer(TipoComandoEnum.None);
      string strToClipboard = string.Join(Environment.NewLine, lstItens);
      CommandClass.SetTextInClipboard(strToClipboard);
    }
  }
}

/*
 private static string GetActiveExplorerPath()
{
    // get the active window
    IntPtr handle = GetForegroundWindow();

    // Required ref: SHDocVw (Microsoft Internet Controls COM Object) - C:\Windows\system32\ShDocVw.dll
    ShellWindows shellWindows = new SHDocVw.ShellWindows();

    // loop through all windows
    foreach (InternetExplorer window in shellWindows)
    {
        // match active window
        if (window.HWND == (int)handle)
        {
            // Required ref: Shell32 - C:\Windows\system32\Shell32.dll
            var shellWindow = window.Document as Shell32.IShellFolderViewDual2;

            // will be null if you are in Internet Explorer for example
            if (shellWindow != null)
            {
                // Item without an index returns the current object
                var currentFolder = shellWindow.Folder.Items().Item();

                // special folder - use window title
                // for some reason on "Desktop" gives null
                if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                {
                    // Get window title instead
                    const int nChars = 256;
                    StringBuilder Buff = new StringBuilder(nChars);
                    if (GetWindowText(handle, Buff, nChars) > 0)
                    {
                        return Buff.ToString();
                    }
                }
                else
                {
                    return currentFolder.Path;
                }
            }

            break;
        }
    }

    return null;
}

// COM Imports

[DllImport("user32.dll")]
private static extern IntPtr GetForegroundWindow();

[DllImport("user32.dll")]
static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
 */
