using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinShellShortcuts.RegistryItens;

namespace WinShellShortcuts
{
  /// <summary>
  /// Item de registro para grid
  /// </summary>
  public class GridItem
  {
    /// <summary>
    /// Cria uma instância da classe <seealso cref="GridItem" /></summary>
    /// <param name="menuType">Tipo de menu</param>
    /// <param name="menuItem">Item de registro</param>
    /// <param name="isFixed">Indica se o item é fixo</param>
    public GridItem(MenuTypeEnum menuType, RegistryBaseMenuItem menuItem, bool isFixed = false)
    {
      MenuType = menuType;
      MenuItem = menuItem;
      IsFixed = isFixed;
    }

    /// <summary>
    /// Indica se o item é fixo
    /// </summary>
    public bool IsFixed { get; set; }

    /// <summary>
    /// Item de registro
    /// </summary>
    [System.ComponentModel.Browsable(false)]
    public RegistryBaseMenuItem MenuItem { get; set; }

    /// <summary>
    /// Tipo de menu
    /// </summary>
    public MenuTypeEnum MenuType { get; set; }

    /// <summary>
    /// Título do menu
    /// </summary>
    public string Caption
    {
      get { return MenuItem.MUIVerb; }
      set { MenuItem.MUIVerb = value; }
    }

    /// <summary>
    /// Íconde do menu
    /// </summary>
    public string Icon
    {
      get { return MenuItem.Icon; }
      set { MenuItem.Icon = value; }
    }

    /// <summary>
    /// Comando a ser executado
    /// </summary>
    public string Command
    {
      get { return MenuItem.Command; }
      set { MenuItem.Command = value; }
    }
  }
}
