using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinShellShortcuts.RegistryItens;

namespace WinShellShortcuts
{
  /// <summary>
  /// Tela de configuração de menus
  /// </summary>
  /// <seealso cref="System.Windows.Forms.Form" />
  public partial class ConfigForm : Form
  {
    RegistryBaseMenuItem _menuWSPackDirectory;
    RegistryBaseMenuItem _menuWSPackDirectoryBackground;
    RegistryBaseMenuItem _menuWSPackArquivos;

    List<RegistryBaseMenuItem> _lstItensDirectory;
    List<RegistryBaseMenuItem> _lstItensDirectoryBackground;
    List<RegistryBaseMenuItem> _lstItensArquivos;

    BindingList<GridItem> _lstItensGrid;

    /// <summary>
    /// Cria uma instância da classe <see cref="ConfigForm"/>
    /// </summary>
    public ConfigForm()
    {
      InitializeComponent();
    }

    private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      //if (DialogResult == System.Windows.Forms.DialogResult.OK)
      //{
      //  //Directory: Prompt aqui
      //  RegistryUtils.AddDirectoryPrompt(edtPromptAqui.Text, edtPromptArquiAdm.Text);

      //  // Directory: Copiar nome da pasta
      //  RegistryUtils.AddDirectoryCopiarNomePasta(edtCopiarNomePasta.Text, edtVerificarUsoPasta.Text);

      //  // Arquivo
      //  RegistryUtils.AddMenusArquivo(edtPromptAqui.Text, edtPromptArquiAdm.Text, edtCopiarNomePasta.Text, edtCopiarNomeArquivo.Text);

      //  // MultipleInvokePromptMinimum
      //  RegistryUtils.ChangeExplorerMaxContextMenus();
      //}
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //RegistryBaseMenuItem itemTeste = new RegistryBaseMenuItem(Registry.ClassesRoot,
      //  @"Directory\shell\02MenuWSPack")
      //{
      //  MUIVerb = "Hello world",
      //  ExtendedSubCommandsKey = @"Directory\ContextMenus\MenuWSPack",
      //  Command = "notepad.exe"
      //};

      RegistryBaseMenuItem itemTeste = new DirectoryMenuWSPackItem();
      RegistryUtils.AddOrUpdate(itemTeste);
      RegistryUtils.Delete(itemTeste);

      itemTeste = new DirectoryBackgroundWSPackMenuItem();
      RegistryUtils.AddOrUpdate(itemTeste);
      RegistryUtils.Delete(itemTeste);
    }

    private void ConfigForm_Load(object sender, EventArgs e)
    {
      _lstItensGrid = new BindingList<GridItem>();
      Icon = Properties.Resources.ws;
      CriarMenus();
      CriarItensFixos();
      PopularGrid();
      toolStrip1.Visible = false;
#if DEBUGx
      toolStrip1.Visible = true;
#endif
    }

    private void PopularGrid()
    {
      var qry = _lstItensDirectory.Select(x => new
      {
        Tipo = MenuTypeEnum.Directory,
        Menu = x
      }).Union(_lstItensDirectoryBackground.Select(y => new
      {
        Tipo = MenuTypeEnum.DirectoryBackground,
        Menu = y
      })).Union(_lstItensArquivos.Select(z => new
      {
        Tipo = MenuTypeEnum.Files,
        Menu = z
      }));

      foreach (var esteItem in qry)
      {
        GridItem item = new GridItem(esteItem.Tipo, esteItem.Menu, true);
        _lstItensGrid.Add(item);
      }
      grid.DataSource = _lstItensGrid;

      grid.Columns[nameof(GridItem.IsFixed)].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

      var list = new List<int>();
      foreach (DataGridViewColumn coluna in grid.Columns)
      {
        coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        list.Add(coluna.Width);
      }
      for (int i = 0; i < grid.Columns.Count; i++)
      {
        grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        grid.Columns[i].Width = list[i];
      }
    }

    private void CriarMenus()
    {
      // Menu em Directory
      _menuWSPackDirectory = new DirectoryMenuWSPackItem();
      RegistryUtils.AddOrUpdate(_menuWSPackDirectory);

      // Menu em DirectoryBackground
      _menuWSPackDirectoryBackground = new DirectoryBackgroundWSPackMenuItem();
      RegistryUtils.AddOrUpdate(_menuWSPackDirectoryBackground);

      // Menu em arquivos
      _menuWSPackArquivos = new ArquivoWSPackMenuItem();
      RegistryUtils.AddOrUpdate(_menuWSPackArquivos);
    }

    private void CriarItensFixos()
    {
      // Diretório
      _lstItensDirectory = new List<RegistryBaseMenuItem>
      {
        new DirectoryCopiarNomePastaItem(RegistryPaths.DirectoryContextMenusMenuWSPack, "%1"),
        new CopiarItensSelecionados(RegistryPaths.DirectoryContextMenusMenuWSPack),
        new DirectoryVerificarUsoPastaItem(RegistryPaths.DirectoryContextMenusMenuWSPack, "%1")
        {
          CommandFlags = 0x00000020
        },
        new DirectoryPrompAquiItem(RegistryPaths.DirectoryContextMenusMenuWSPack, "%1", false)
        {
          CommandFlags = 0x00000020
        },
        new DirectoryPrompAquiItem(RegistryPaths.DirectoryContextMenusMenuWSPack, "%1", true),
      };

      // Diretório Background
      _lstItensDirectoryBackground = new List<RegistryBaseMenuItem>
      {
        new DirectoryCopiarNomePastaItem(RegistryPaths.DirectoryContextMenusMenuWSPackBackground, "%V"),
        new DirectoryVerificarUsoPastaItem(RegistryPaths.DirectoryContextMenusMenuWSPackBackground, "%V")
        {
          CommandFlags = 0x00000020
        },
        new DirectoryPrompAquiItem(RegistryPaths.DirectoryContextMenusMenuWSPackBackground, "", false)
        {
          CommandFlags = 0x00000020
        },
        new DirectoryPrompAquiItem(RegistryPaths.DirectoryContextMenusMenuWSPackBackground, "", true)
      };

      // Arquivos
      _lstItensArquivos = new List<RegistryBaseMenuItem>
      {
        new ArquivosCopiarNomeItem(),
        new CopiarItensSelecionados(RegistryPaths.ArquivosContextMenusMenuWSPack),
        new ArquivosVerificarUsoItem()
        {
          CommandFlags = 0x00000020
        },
        new DirectoryPrompAquiItem(RegistryPaths.ArquivosContextMenusMenuWSPack, "%1", false)
        {
          CommandFlags = 0x00000020
        },
        new DirectoryPrompAquiItem(RegistryPaths.ArquivosContextMenusMenuWSPack, "%1", true)
      };

      foreach (RegistryBaseMenuItem esteItem in _lstItensDirectory.Union(_lstItensDirectoryBackground).Union(_lstItensArquivos))
      {
        RegistryUtils.AddOrUpdate(esteItem);
      }
    }

    private void grid_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      btnExcluir.Enabled = e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
        !(grid.Rows[e.RowIndex].DataBoundItem as GridItem).IsFixed;
    }
  }
}
