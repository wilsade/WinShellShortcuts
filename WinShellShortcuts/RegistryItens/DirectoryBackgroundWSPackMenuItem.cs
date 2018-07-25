using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Menu WSPack para Background de diretórios
  /// </summary>
  /// <seealso cref="WinShellShortcuts.RegistryItens.RegistryBaseMenuItem" />
  public class DirectoryBackgroundWSPackMenuItem : RegistryBaseMenuItem
  {
    /// <summary>
    /// Cria uma instância da classe <see cref="DirectoryBackgroundWSPackMenuItem"/>
    /// </summary>
    public DirectoryBackgroundWSPackMenuItem()
      : base(Registry.ClassesRoot, RegistryPaths.DirectoryBackgroundShell + "\\01WSPack")
    {
      MUIVerb = "WS Pack";
      ExtendedSubCommandsKey = RegistryPaths.DirectoryContextMenusMenuWSPackBackground;
      Icon = Constantes.WinShellShortcutsFullPath;
      Position = RegistryPositionEnum.Top;
    }
  }
}
