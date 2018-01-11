namespace ExportPrograms {
  partial class ManageMachinePaths {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.mACHIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.mACHNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.mACHNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nICKNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.mSORTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cUTMACHINESBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.machines = new ExportPrograms.Machines();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.cUT_MACHINESTableAdapter = new ExportPrograms.MachinesTableAdapters.CUT_MACHINESTableAdapter();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cUTMACHINESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.machines)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 200);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mACHIDDataGridViewTextBoxColumn,
            this.mACHNUMDataGridViewTextBoxColumn,
            this.mACHNAMEDataGridViewTextBoxColumn,
            this.nICKNAMEDataGridViewTextBoxColumn,
            this.tYPEDataGridViewTextBoxColumn,
            this.lOCDataGridViewTextBoxColumn,
            this.mSORTDataGridViewTextBoxColumn});
      this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
      this.dataGridView1.DataSource = this.cUTMACHINESBindingSource;
      this.dataGridView1.Location = new System.Drawing.Point(3, 3);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(546, 154);
      this.dataGridView1.TabIndex = 0;
      // 
      // mACHIDDataGridViewTextBoxColumn
      // 
      this.mACHIDDataGridViewTextBoxColumn.DataPropertyName = "MACHID";
      this.mACHIDDataGridViewTextBoxColumn.HeaderText = "MACHID";
      this.mACHIDDataGridViewTextBoxColumn.Name = "mACHIDDataGridViewTextBoxColumn";
      this.mACHIDDataGridViewTextBoxColumn.ReadOnly = true;
      this.mACHIDDataGridViewTextBoxColumn.Visible = false;
      // 
      // mACHNUMDataGridViewTextBoxColumn
      // 
      this.mACHNUMDataGridViewTextBoxColumn.DataPropertyName = "MACHNUM";
      this.mACHNUMDataGridViewTextBoxColumn.HeaderText = "MACHNUM";
      this.mACHNUMDataGridViewTextBoxColumn.Name = "mACHNUMDataGridViewTextBoxColumn";
      this.mACHNUMDataGridViewTextBoxColumn.Visible = false;
      // 
      // mACHNAMEDataGridViewTextBoxColumn
      // 
      this.mACHNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.mACHNAMEDataGridViewTextBoxColumn.DataPropertyName = "MACHNAME";
      this.mACHNAMEDataGridViewTextBoxColumn.HeaderText = "MACHNAME";
      this.mACHNAMEDataGridViewTextBoxColumn.Name = "mACHNAMEDataGridViewTextBoxColumn";
      this.mACHNAMEDataGridViewTextBoxColumn.Width = 94;
      // 
      // nICKNAMEDataGridViewTextBoxColumn
      // 
      this.nICKNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.nICKNAMEDataGridViewTextBoxColumn.DataPropertyName = "NICKNAME";
      this.nICKNAMEDataGridViewTextBoxColumn.HeaderText = "NICKNAME";
      this.nICKNAMEDataGridViewTextBoxColumn.Name = "nICKNAMEDataGridViewTextBoxColumn";
      this.nICKNAMEDataGridViewTextBoxColumn.Width = 88;
      // 
      // tYPEDataGridViewTextBoxColumn
      // 
      this.tYPEDataGridViewTextBoxColumn.DataPropertyName = "TYPE";
      this.tYPEDataGridViewTextBoxColumn.HeaderText = "TYPE";
      this.tYPEDataGridViewTextBoxColumn.Name = "tYPEDataGridViewTextBoxColumn";
      this.tYPEDataGridViewTextBoxColumn.Visible = false;
      // 
      // lOCDataGridViewTextBoxColumn
      // 
      this.lOCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.lOCDataGridViewTextBoxColumn.DataPropertyName = "LOC";
      this.lOCDataGridViewTextBoxColumn.HeaderText = "LOC";
      this.lOCDataGridViewTextBoxColumn.Name = "lOCDataGridViewTextBoxColumn";
      this.lOCDataGridViewTextBoxColumn.Width = 53;
      // 
      // mSORTDataGridViewTextBoxColumn
      // 
      this.mSORTDataGridViewTextBoxColumn.DataPropertyName = "MSORT";
      this.mSORTDataGridViewTextBoxColumn.HeaderText = "MSORT";
      this.mSORTDataGridViewTextBoxColumn.Name = "mSORTDataGridViewTextBoxColumn";
      this.mSORTDataGridViewTextBoxColumn.Visible = false;
      // 
      // cUTMACHINESBindingSource
      // 
      this.cUTMACHINESBindingSource.DataMember = "CUT_MACHINES";
      this.cUTMACHINESBindingSource.DataSource = this.machines;
      // 
      // machines
      // 
      this.machines.DataSetName = "Machines";
      this.machines.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // button1
      // 
      this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.button1.Location = new System.Drawing.Point(3, 163);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(270, 34);
      this.button1.TabIndex = 1;
      this.button1.Text = "Cancel";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.button2.Location = new System.Drawing.Point(279, 163);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(270, 34);
      this.button2.TabIndex = 2;
      this.button2.Text = "OK";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // cUT_MACHINESTableAdapter
      // 
      this.cUT_MACHINESTableAdapter.ClearBeforeFill = true;
      // 
      // ManageMachinePaths
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(552, 200);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ManageMachinePaths";
      this.Text = "ManageMachinePaths";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageMachinePaths_FormClosing);
      this.Load += new System.EventHandler(this.ManageMachinePaths_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cUTMACHINESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.machines)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private Machines machines;
    private System.Windows.Forms.BindingSource cUTMACHINESBindingSource;
    private MachinesTableAdapters.CUT_MACHINESTableAdapter cUT_MACHINESTableAdapter;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.DataGridViewTextBoxColumn mACHIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn mACHNUMDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn mACHNAMEDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nICKNAMEDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tYPEDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn lOCDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn mSORTDataGridViewTextBoxColumn;
  }
}