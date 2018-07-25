using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShellShortcuts.RegistryItens
{
  /// <summary>
  /// Definir caminhos de chave de registro do Windows
  /// </summary>
  public static class RegistryPaths
  {
    /// <summary>
    /// *\shell
    /// </summary>
    public const string Arquivos = @"*\shell";

    /// <summary>
    /// *\ContextMenus\MenuWSPack
    /// </summary>
    public const string ArquivosContextMenusMenuWSPack = @"*\ContextMenus\MenuWSPack";

    /// <summary>
    /// Directory\shell
    /// </summary>
    public const string DirectoryShell = @"Directory\shell";

    /// <summary>
    /// Directory\Background\shell
    /// </summary>
    public const string DirectoryBackgroundShell = @"Directory\Background\shell";

    /// <summary>
    /// Directory\ContextMenus\MenuWSPack
    /// </summary>
    public const string DirectoryContextMenusMenuWSPack = @"Directory\ContextMenus\MenuWSPack";

    /// <summary>
    /// Directory\ContextMenus\MenuWSPackBackground
    /// </summary>
    public const string DirectoryContextMenusMenuWSPackBackground = @"Directory\ContextMenus\MenuWSPackBackground";
  }
}
