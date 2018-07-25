using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Classe para copiar o nome da pasta
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class DirectoryCopiarNomePastaItem : RegistryBaseMenuItem
  {
    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryCopiarNomePastaItem"/>
    /// </summary>
    public DirectoryCopiarNomePastaItem()
    {

    }

    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryCopiarNomePastaItem"/>
    /// </summary>
    /// <param name="path">Caminho do registro onde a chave se encontra</param>
    /// <param name="paramPattern">Padrão para recuperar o parâmetro. Ex: %1, %V</param>
    public DirectoryCopiarNomePastaItem(string path, string paramPattern)
      : base(Registry.ClassesRoot, path + "\\Shell\\01CopiarNomePasta")
    {
      MUIVerb = "Copiar nome da pasta";
      Icon = "%SystemRoot%\\system32\\imageres.dll,153";
      Command = $"\"{Constantes.WinShellShortcutsFullPath}\" /c={typeof(DirectoryCopiarNomePastaItem).FullName} \"{paramPattern}\" ";
    }

    /// <summary>
    /// Executar o comando
    /// </summary>
    /// <param name="context">Contexto de execução</param>
    public override void Execute(object context)
    {
      CommandClass.SetTextInClipboard(Convert.ToString(context));
    }
  }
}
