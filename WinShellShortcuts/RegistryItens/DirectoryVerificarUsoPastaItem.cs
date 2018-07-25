using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Verificar se a pasta está sendo utilizada por algum processo
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class DirectoryVerificarUsoPastaItem : RegistryBaseMenuItem
  {
    #region Construtores
    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryVerificarUsoPastaItem"/>
    /// </summary>
    public DirectoryVerificarUsoPastaItem()
    {

    }

    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryVerificarUsoPastaItem"/>
    /// </summary>
    /// <param name="path">Caminho do registro onde a chave se encontra</param>
    /// <param name="paramPattern">Padrão para recuperar o parâmetro. Ex: %1, %V</param>
    public DirectoryVerificarUsoPastaItem(string path, string paramPattern)
      : base(Registry.ClassesRoot, path + "\\Shell\\03VerificarUsoPasta")
    {
      MUIVerb = "Verificar uso da pasta";
      Icon = @"%SystemRoot%\system32\imageres.dll,7";
      HasLUAShield = true;

      Command = $"\"{Constantes.WinShellShortcutsFullPath_Adm}\" /h={typeof(DirectoryVerificarUsoPastaItem).FullName} \"{paramPattern}\" ";
    }
    #endregion

    /// <summary>
    /// Executar o comando
    /// </summary>
    /// <param name="context">Contexto de execução</param>
    public override void Execute(object context)
    {
      CommandClass.ProcessHandle(Convert.ToString(context));
    }
  }
}
