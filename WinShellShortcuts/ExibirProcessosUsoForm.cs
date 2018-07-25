using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShellShortcuts
{
  /// <summary>
  /// Form para exibir uso de um item
  /// </summary>
  /// <seealso cref="System.Windows.Forms.Form" />
  public partial class ExibirProcessosUsoForm : Form
  {
    string _itemName;
    SortableBindingList<HandleProcessItem> _lstHandle;

    #region Construtor
    /// <summary>
    /// Cria uma instância da classe <see cref="ExibirProcessosUsoForm"/>
    /// </summary>
    /// <param name="lstHandle">Lista de uso do item</param>
    public ExibirProcessosUsoForm(string itemName, List<HandleProcessItem> lstHandle)
    {
      InitializeComponent();
      _itemName = itemName;
      _lstHandle = new SortableBindingList<HandleProcessItem>(lstHandle.OrderBy(x => x.ProcessName).ThenBy(x => x.HandlePath));
    }
    #endregion

    IEnumerable<HandleProcessItem> ListaHandleGrid => grid.SelectedRows.OfType<DataGridViewRow>().Select(x => (HandleProcessItem)x.DataBoundItem);

    private void ExibirProcessosUsoForm_Load(object sender, EventArgs e)
    {
#if DEBUG
      TopMost = false;
#endif
      edtNomeItem.Text = _itemName;
      BindGrid(_lstHandle);
    }

    private void BindGrid(IEnumerable<HandleProcessItem> lstHandle)
    {
      grid.DataSource = null;
      _lstHandle = new SortableBindingList<HandleProcessItem>(lstHandle.OrderBy(x => x.ProcessName).ThenBy(x => x.HandlePath));
      grid.DataSource = _lstHandle;
      grid.Columns[nameof(HandleProcessItem.HandlePath)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      lbTotal.Text = _lstHandle.Count.ToString();
    }

    private void menuItemMarcarTodos_Click(object sender, EventArgs e)
    {
      if (sender == menuItemInverterMarcacao)
      {
        foreach (DataGridViewRow estaRow in grid.Rows)
        {
          estaRow.Selected = !estaRow.Selected;
        }
      }

      else
      {
        bool flag = false;
        if (sender == menuItemMarcarTodos)
          flag = true;

        foreach (DataGridViewRow estaRow in grid.Rows)
        {
          estaRow.Selected = flag;
        }
      }
    }

    private void menuItemFinalizarItensMarcados_Click(object sender, EventArgs e)
    {
      const string msg = @"ATENÇÃO!!!

Esta opção irá fechar os processos alocados em seus respectivos endereços.
O processo em si não é finalizado, apenas o ponteiro onde o item está sendo utilizado.

Confirma esta opção?";
      if (MessageBox.Show(msg, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        IEnumerable<HandleProcessItem> lstHandle = ListaHandleGrid;
        foreach (var item in lstHandle)
        {
          string result = HandleObj.Instance.CloseHandle(item);
          if (!string.IsNullOrEmpty(result))
          {
            MessageBox.Show(result.Trim(), "Ponteiro não fechado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }
      }
    }

    private void menuItemFinalizarProcessosMarcados_Click(object sender, EventArgs e)
    {
      const string msg = @"ATENÇÃO!!!

Esta opção irá fechar (taskkill) os TODOS os processos marcados.
Todos os processos que têm o mesmo nome serão finalizados.

Confirma esta opção?";
      if (MessageBox.Show(msg, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        IEnumerable<string> lstHandle = ListaHandleGrid.GroupBy(x => x.ProcessName).Select(x => x.Key);
        foreach (var item in lstHandle)
        {
          string args = $"/im {item}";
          string output, outputerror;
          int resultado = CommandClass.ExecuteCommand("taskkill", args, out output, out outputerror, Path.GetDirectoryName(Constantes.HandlePath));
          MessageBox.Show(output, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    private void btnAtualizar_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      btnAtualizar.Enabled = false;
      try
      {
        List<HandleProcessItem> lstProcessos = HandleObj.Instance.GetHandles(edtNomeItem.Text);
        if (lstProcessos.Count > 0)
        {
          BindGrid(lstProcessos);

        }
        else
        {
          grid.DataSource = null;
          MessageBox.Show($"{edtNomeItem.Text}\r\n\r\nNão está em uso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      catch (Exception handleEx)
      {
        MessageBox.Show("Erro(s) ao verificar uso." + Environment.NewLine + handleEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        Cursor = Cursors.Default;
        btnAtualizar.Enabled = true;
      }
    }

    private void menuGrid_Opening(object sender, CancelEventArgs e)
    {
      menuItemDesmarcarTodos.Enabled = menuItemMarcarTodos.Enabled = menuItemInverterMarcacao.Enabled =
        menuItemFecharEnderecoItensMarcados.Enabled = menuItemFinalizarProcessosMarcados.Enabled = grid.Rows.Count > 0;
    }
  }
}
