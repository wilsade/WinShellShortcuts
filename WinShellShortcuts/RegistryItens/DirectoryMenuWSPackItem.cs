using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Menu WSPack para diretórios
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class DirectoryMenuWSPackItem : RegistryBaseMenuItem
  {
    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryMenuWSPackItem"/>
    /// </summary>
    public DirectoryMenuWSPackItem()
      : base(Registry.ClassesRoot, RegistryPaths.DirectoryShell + "\\01WSPack")
    {
      MUIVerb = "WS Pack";
      ExtendedSubCommandsKey = RegistryPaths.DirectoryContextMenusMenuWSPack;
      Icon = Constantes.WinShellShortcutsFullPath;
      MultiSelectModel = "Player";
      Position = RegistryPositionEnum.Top;
    }
  }
}
