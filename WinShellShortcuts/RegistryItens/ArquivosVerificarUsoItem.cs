using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Verificar se o arquivo está sendo usado por algum processo
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class ArquivosVerificarUsoItem : RegistryBaseMenuItem
  {
    #region Construtor
    /// <summary>
    /// Cria uma instância da classe <see cref="ArquivosVerificarUsoItem"/>
    /// </summary>
    public ArquivosVerificarUsoItem()
      : base(Registry.ClassesRoot, RegistryPaths.ArquivosContextMenusMenuWSPack + "\\shell\\03VerificarUsoArquivo")
    {
      MUIVerb = "Verificar uso do arquivo";
      Icon = @"%SystemRoot%\system32\imageres.dll,7";
      HasLUAShield = true;

      Command = $"\"{Constantes.WinShellShortcutsFullPath_Adm}\" /h={typeof(ArquivosVerificarUsoItem).FullName} \"%1\" ";
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
