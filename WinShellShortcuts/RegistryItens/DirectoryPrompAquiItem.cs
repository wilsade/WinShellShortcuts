using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Prompt de comando na pasta
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class DirectoryPrompAquiItem : RegistryBaseMenuItem
  {
    #region Construtores
    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryPrompAquiItem"/>
    /// </summary>
    public DirectoryPrompAquiItem()
    {

    }

    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryPrompAquiItem"/>
    /// </summary>
    /// <param name="path">Caminho do registro onde a chave se encontra</param>
    /// <param name="paramPattern">Padrão para recuperar o parâmetro. Ex: %1, %V</param>
    /// <param name="isAdm">Indica se o comando será executado com privilégios de administrador</param>
    public DirectoryPrompAquiItem(string path, string paramPattern, bool isAdm)
      : base(Registry.ClassesRoot, path + "\\Shell\\04PromptAqui")
    {
      MUIVerb = "Prompt aqui";
      Icon = "%SystemRoot%\\system32\\cmd.exe";

      string exePath = Constantes.WinShellShortcutsFullPath;
      if (isAdm)
      {
        MUIVerb += " (Adm)";
        exePath = Constantes.WinShellShortcutsFullPath_Adm;
        RegistryPath = RegistryPath.Replace("04PromptAqui", "05PromptAquiAdm");
      }

      Command = $"\"{exePath}\" /p={typeof(DirectoryPrompAquiItem).FullName} \"{paramPattern}\" ";
      HasLUAShield = isAdm;
    }
    #endregion

    /// <summary>
    /// Executar o comando
    /// </summary>
    /// <param name="context">Contexto de execução</param>
    public override void Execute(object context)
    {
      string parametro = Convert.ToString(context);
      if (!string.IsNullOrEmpty(parametro))
      {
        // Verificar se o parâmetro é um arquivo. Se for, vamos chamar a pasta
        if (File.Exists(parametro))
          parametro = Path.GetDirectoryName(parametro);

        parametro = " cd " + parametro;
      }

      Process.Start("cmd.exe", "/k" + parametro);
    }
  }
}
