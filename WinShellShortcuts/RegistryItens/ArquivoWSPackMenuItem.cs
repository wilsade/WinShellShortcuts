using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Menu WSPack para arquivos
  /// </summary>
  public class ArquivoWSPackMenuItem : RegistryBaseMenuItem
  {
    /// <summary>
    /// Cria uma instância da classe <see cref="ArquivoWSPackMenuItem"/>
    /// </summary>
    public ArquivoWSPackMenuItem()
      : base(Registry.ClassesRoot, RegistryPaths.Arquivos + "\\01WSPack")
    {
      MUIVerb = "WS Pack";
      ExtendedSubCommandsKey = RegistryPaths.ArquivosContextMenusMenuWSPack;
      Icon = Constantes.WinShellShortcutsFullPath;
      MultiSelectModel = "Player";
      Position = RegistryPositionEnum.Top;
    }
  }
}
