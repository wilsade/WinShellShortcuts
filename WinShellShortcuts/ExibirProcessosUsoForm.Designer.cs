namespace WinShellShortcuts
{
  partial class ExibirProcessosUsoForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lbTotal = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.grid = new System.Windows.Forms.DataGridView();
      this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuItemMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemInverterMarcacao = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuItemFecharEnderecoItensMarcados = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemFinalizarProcessosMarcados = new System.Windows.Forms.ToolStripMenuItem();
      this.panel2 = new System.Windows.Forms.Panel();
      this.edtNomeItem = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnAtualizar = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      this.menuGrid.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lbTotal);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btnOK);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 294);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(617, 35);
      this.panel1.TabIndex = 0;
      // 
      // lbTotal
      // 
      this.lbTotal.AutoSize = true;
      this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbTotal.Location = new System.Drawing.Point(52, 12);
      this.lbTotal.Name = "lbTotal";
      this.lbTotal.Size = new System.Drawing.Size(14, 13);
      this.lbTotal.TabIndex = 2;
      this.lbTotal.Text = "0";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 12);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Total:";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(531, 7);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "&Fechar";
      this.toolTip1.SetToolTip(this.btnOK, "Fechar esta tela");
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // grid
      // 
      this.grid.AllowUserToAddRows = false;
      this.grid.AllowUserToDeleteRows = false;
      this.grid.AllowUserToOrderColumns = true;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
      this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grid.ContextMenuStrip = this.menuGrid;
      this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid.Location = new System.Drawing.Point(0, 36);
      this.grid.Name = "grid";
      this.grid.ReadOnly = true;
      this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grid.Size = new System.Drawing.Size(617, 258);
      this.grid.TabIndex = 2;
      this.toolTip1.SetToolTip(this.grid, "Clique com o botão direito para opções");
      // 
      // menuGrid
      // 
      this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMarcarTodos,
            this.menuItemDesmarcarTodos,
            this.menuItemInverterMarcacao,
            this.toolStripMenuItem1,
            this.menuItemFecharEnderecoItensMarcados,
            this.menuItemFinalizarProcessosMarcados});
      this.menuGrid.Name = "menuGrid";
      this.menuGrid.Size = new System.Drawing.Size(267, 142);
      this.menuGrid.Opening += new System.ComponentModel.CancelEventHandler(this.menuGrid_Opening);
      // 
      // menuItemMarcarTodos
      // 
      this.menuItemMarcarTodos.Name = "menuItemMarcarTodos";
      this.menuItemMarcarTodos.Size = new System.Drawing.Size(266, 22);
      this.menuItemMarcarTodos.Text = "Marcar todos";
      this.menuItemMarcarTodos.Click += new System.EventHandler(this.menuItemMarcarTodos_Click);
      // 
      // menuItemDesmarcarTodos
      // 
      this.menuItemDesmarcarTodos.Name = "menuItemDesmarcarTodos";
      this.menuItemDesmarcarTodos.Size = new System.Drawing.Size(266, 22);
      this.menuItemDesmarcarTodos.Text = "Desmarcar todos";
      this.menuItemDesmarcarTodos.Click += new System.EventHandler(this.menuItemMarcarTodos_Click);
      // 
      // menuItemInverterMarcacao
      // 
      this.menuItemInverterMarcacao.Name = "menuItemInverterMarcacao";
      this.menuItemInverterMarcacao.Size = new System.Drawing.Size(266, 22);
      this.menuItemInverterMarcacao.Text = "Inverter marcação";
      this.menuItemInverterMarcacao.Click += new System.EventHandler(this.menuItemMarcarTodos_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(263, 6);
      // 
      // menuItemFecharEnderecoItensMarcados
      // 
      this.menuItemFecharEnderecoItensMarcados.Name = "menuItemFecharEnderecoItensMarcados";
      this.menuItemFecharEnderecoItensMarcados.Size = new System.Drawing.Size(266, 22);
      this.menuItemFecharEnderecoItensMarcados.Text = "Fechar endereço dos itens marcados";
      this.menuItemFecharEnderecoItensMarcados.ToolTipText = "Fecha o ponteiro que o programa está utilizando";
      this.menuItemFecharEnderecoItensMarcados.Click += new System.EventHandler(this.menuItemFinalizarItensMarcados_Click);
      // 
      // menuItemFinalizarProcessosMarcados
      // 
      this.menuItemFinalizarProcessosMarcados.Name = "menuItemFinalizarProcessosMarcados";
      this.menuItemFinalizarProcessosMarcados.Size = new System.Drawing.Size(266, 22);
      this.menuItemFinalizarProcessosMarcados.Text = "Finalizar processos marcados";
      this.menuItemFinalizarProcessosMarcados.ToolTipText = "Fecha os processos marcados";
      this.menuItemFinalizarProcessosMarcados.Click += new System.EventHandler(this.menuItemFinalizarProcessosMarcados_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnAtualizar);
      this.panel2.Controls.Add(this.edtNomeItem);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(617, 36);
      this.panel2.TabIndex = 3;
      // 
      // edtNomeItem
      // 
      this.edtNomeItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.edtNomeItem.Location = new System.Drawing.Point(93, 9);
      this.edtNomeItem.Name = "edtNomeItem";
      this.edtNomeItem.ReadOnly = true;
      this.edtNomeItem.Size = new System.Drawing.Size(432, 20);
      this.edtNomeItem.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label1.Location = new System.Drawing.Point(12, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Nome do item:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnAtualizar
      // 
      this.btnAtualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnAtualizar.Location = new System.Drawing.Point(533, 7);
      this.btnAtualizar.Name = "btnAtualizar";
      this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
      this.btnAtualizar.TabIndex = 2;
      this.btnAtualizar.Text = "Atualizar";
      this.toolTip1.SetToolTip(this.btnAtualizar, "Verificar novamente o uso do item");
      this.btnAtualizar.UseVisualStyleBackColor = true;
      this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
      // 
      // ExibirProcessosUsoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(617, 329);
      this.Controls.Add(this.grid);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.MinimumSize = new System.Drawing.Size(450, 300);
      this.Name = "ExibirProcessosUsoForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Informações de uso do item";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.ExibirProcessosUsoForm_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.menuGrid.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.DataGridView grid;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox edtNomeItem;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lbTotal;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ContextMenuStrip menuGrid;
    private System.Windows.Forms.ToolStripMenuItem menuItemMarcarTodos;
    private System.Windows.Forms.ToolStripMenuItem menuItemDesmarcarTodos;
    private System.Windows.Forms.ToolStripMenuItem menuItemInverterMarcacao;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem menuItemFecharEnderecoItensMarcados;
    private System.Windows.Forms.ToolStripMenuItem menuItemFinalizarProcessosMarcados;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnAtualizar;
  }
}