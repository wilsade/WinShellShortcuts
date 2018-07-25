namespace WinShellShortcuts
{
  partial class ConfigForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.pnlBottom = new System.Windows.Forms.Panel();
      this.btnOK = new System.Windows.Forms.Button();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
      this.btnExcluir = new System.Windows.Forms.ToolStripButton();
      this.gbxItens = new System.Windows.Forms.GroupBox();
      this.grid = new System.Windows.Forms.DataGridView();
      this.pnlBottom.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.gbxItens.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlBottom
      // 
      this.pnlBottom.Controls.Add(this.btnOK);
      this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlBottom.Location = new System.Drawing.Point(0, 457);
      this.pnlBottom.Margin = new System.Windows.Forms.Padding(2);
      this.pnlBottom.Name = "pnlBottom";
      this.pnlBottom.Size = new System.Drawing.Size(684, 39);
      this.pnlBottom.TabIndex = 1;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(605, 8);
      this.btnOK.Margin = new System.Windows.Forms.Padding(2);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(68, 23);
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.btnExcluir});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(684, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnAdicionar
      // 
      this.btnAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
      this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAdicionar.Name = "btnAdicionar";
      this.btnAdicionar.Size = new System.Drawing.Size(62, 22);
      this.btnAdicionar.Text = "Adicionar";
      // 
      // btnExcluir
      // 
      this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnExcluir.Enabled = false;
      this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
      this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnExcluir.Name = "btnExcluir";
      this.btnExcluir.Size = new System.Drawing.Size(45, 22);
      this.btnExcluir.Text = "Excluir";
      // 
      // gbxItens
      // 
      this.gbxItens.Controls.Add(this.grid);
      this.gbxItens.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxItens.Location = new System.Drawing.Point(0, 25);
      this.gbxItens.Name = "gbxItens";
      this.gbxItens.Size = new System.Drawing.Size(684, 432);
      this.gbxItens.TabIndex = 3;
      this.gbxItens.TabStop = false;
      this.gbxItens.Text = "Lista de itens:";
      // 
      // grid
      // 
      this.grid.AllowUserToAddRows = false;
      this.grid.AllowUserToDeleteRows = false;
      this.grid.AllowUserToOrderColumns = true;
      this.grid.AllowUserToResizeRows = false;
      this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.grid.DefaultCellStyle = dataGridViewCellStyle1;
      this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid.Location = new System.Drawing.Point(3, 16);
      this.grid.MultiSelect = false;
      this.grid.Name = "grid";
      this.grid.ReadOnly = true;
      this.grid.Size = new System.Drawing.Size(678, 413);
      this.grid.TabIndex = 0;
      this.grid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_RowEnter);
      // 
      // ConfigForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 496);
      this.Controls.Add(this.gbxItens);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.pnlBottom);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConfigForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Windows Shell Shortcuts - Configurações";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
      this.Load += new System.EventHandler(this.ConfigForm_Load);
      this.pnlBottom.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.gbxItens.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnAdicionar;
    private System.Windows.Forms.GroupBox gbxItens;
    private System.Windows.Forms.DataGridView grid;
    private System.Windows.Forms.ToolStripButton btnExcluir;
  }
}