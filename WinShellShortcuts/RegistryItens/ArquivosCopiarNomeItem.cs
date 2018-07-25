using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Copiar nome do arquivo
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class ArquivosCopiarNomeItem : RegistryBaseMenuItem
  {
    #region Construtor
    /// <summary>
    /// Cria uma instância da classe <see cref="ArquivosCopiarNomeItem"/>
    /// </summary>
    public ArquivosCopiarNomeItem()
      : base(Registry.ClassesRoot, RegistryPaths.ArquivosContextMenusMenuWSPack + "\\Shell\\01CopiarNomeArquivo")
    {
      MUIVerb = "Copiar nome do arquivo";
      Icon = @"%SystemRoot%\system32\imageres.dll,14";
      Command = $"\"{Constantes.WinShellShortcutsFullPath}\" /c={typeof(ArquivosCopiarNomeItem).FullName} \"%1\" ";
    }
    #endregion

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
