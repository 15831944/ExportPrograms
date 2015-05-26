namespace ExportPrograms
{
    partial class frmExportPrograms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportPrograms));
            this.lbMachineList = new System.Windows.Forms.ListBox();
            this.ofdSelectProgs = new System.Windows.Forms.OpenFileDialog();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butChangeSelection = new System.Windows.Forms.Button();
            this.butPods = new System.Windows.Forms.Button();
            this.butFlat = new System.Windows.Forms.Button();
            this.fbdSelectBackupDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.butDeleteFromMachines = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbDelete = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMachineList
            // 
            this.lbMachineList.FormattingEnabled = true;
            this.lbMachineList.ItemHeight = 15;
            this.lbMachineList.Location = new System.Drawing.Point(276, 34);
            this.lbMachineList.Name = "lbMachineList";
            this.lbMachineList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbMachineList.Size = new System.Drawing.Size(139, 289);
            this.lbMachineList.TabIndex = 0;
            // 
            // lbFileList
            // 
            this.lbFileList.AllowDrop = true;
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.ItemHeight = 15;
            this.lbFileList.Location = new System.Drawing.Point(12, 34);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbFileList.Size = new System.Drawing.Size(258, 289);
            this.lbFileList.TabIndex = 1;
            this.lbFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFileList_DragDrop);
            this.lbFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbFileList_KeyDown);
            this.lbFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFileList_MouseDown);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(13, 329);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(341, 329);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butChangeSelection
            // 
            this.butChangeSelection.Location = new System.Drawing.Point(94, 329);
            this.butChangeSelection.Name = "butChangeSelection";
            this.butChangeSelection.Size = new System.Drawing.Size(120, 23);
            this.butChangeSelection.TabIndex = 4;
            this.butChangeSelection.Text = "Change Selection";
            this.butChangeSelection.UseVisualStyleBackColor = true;
            this.butChangeSelection.Click += new System.EventHandler(this.butChangeSelection_Click);
            // 
            // butPods
            // 
            this.butPods.Location = new System.Drawing.Point(276, 5);
            this.butPods.Name = "butPods";
            this.butPods.Size = new System.Drawing.Size(63, 23);
            this.butPods.TabIndex = 5;
            this.butPods.Text = "Pods";
            this.butPods.UseVisualStyleBackColor = true;
            this.butPods.Click += new System.EventHandler(this.butPods_Click);
            // 
            // butFlat
            // 
            this.butFlat.Location = new System.Drawing.Point(352, 5);
            this.butFlat.Name = "butFlat";
            this.butFlat.Size = new System.Drawing.Size(63, 23);
            this.butFlat.TabIndex = 6;
            this.butFlat.Text = "Flat";
            this.butFlat.UseVisualStyleBackColor = true;
            this.butFlat.Click += new System.EventHandler(this.butFlat_Click);
            // 
            // fbdSelectBackupDestination
            // 
            this.fbdSelectBackupDestination.SelectedPath = "\"\\\\AMSTORE-SVR-22\\cnc\\CNCDXF\\WEEKE\"";
            // 
            // butDeleteFromMachines
            // 
            this.butDeleteFromMachines.Location = new System.Drawing.Point(13, 5);
            this.butDeleteFromMachines.Name = "butDeleteFromMachines";
            this.butDeleteFromMachines.Size = new System.Drawing.Size(136, 23);
            this.butDeleteFromMachines.TabIndex = 7;
            this.butDeleteFromMachines.Text = "Delete From Machines";
            this.butDeleteFromMachines.UseVisualStyleBackColor = true;
            this.butDeleteFromMachines.Click += new System.EventHandler(this.butDeleteFromMachines_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(428, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // tbDelete
            // 
            this.tbDelete.Location = new System.Drawing.Point(156, 7);
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(114, 23);
            this.tbDelete.TabIndex = 9;
            // 
            // frmExportPrograms
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 382);
            this.Controls.Add(this.tbDelete);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.butDeleteFromMachines);
            this.Controls.Add(this.butFlat);
            this.Controls.Add(this.butPods);
            this.Controls.Add(this.butChangeSelection);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.lbFileList);
            this.Controls.Add(this.lbMachineList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExportPrograms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Programs";
            this.TransparencyKey = System.Drawing.Color.Purple;
            this.Load += new System.EventHandler(this.frmExportPrograms_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmExportPrograms_DragDrop);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMachineList;
        private System.Windows.Forms.OpenFileDialog ofdSelectProgs;
        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butChangeSelection;
        private System.Windows.Forms.Button butPods;
        private System.Windows.Forms.Button butFlat;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectBackupDestination;
        private System.Windows.Forms.Button butDeleteFromMachines;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tbDelete;
    }
}

