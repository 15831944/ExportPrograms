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

namespace ExportPrograms
{
    public partial class frmExportPrograms : Form
    {
        public frmExportPrograms()
        {
            InitializeComponent();
        }

        private void AddItem(string item)
        {
            if (!this.lbFileList.Items.Contains(item))
                this.lbFileList.Items.Add(item);
        }

        private void frmExportPrograms_Load(Object sender, EventArgs e)
        {
            try
            {
                readIniFile();
            }
            catch (Exception ex)
            {
                _sendErrMessage(ex);
            }

            InitializeOpenFileDialog();
            lbFileList.Items.Clear();
        }

        private void butChangeSelection_Click(object sender, EventArgs e)
        {
            lbFileList.Items.Clear();
            selectFiles();
            if (this.selectedFileArray != null)
                foreach (string item in selectedFileArray)
                    this.AddItem(item);
        }

        private void butPods_Click(object sender, EventArgs e)
        {
            selectMachinesByType(true);
        }

        private void butFlat_Click(object sender, EventArgs e)
        {
            selectMachinesByType(false);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (selectedFileArray != null)
            {
                try
                {
                    copyFiles();
                    moveFiles();
                }
                catch (ExportProgramsException ex)
                {
                    _sendErrMessage(ex);
                }
                catch (Exception ex)
                {
                    _sendErrMessage(ex);
                }
            }
            AllDone ad = new AllDone();
            ad.ShowDialog();
            this.Close();
        }

        private void butDeleteFromMachines_Click(object sender, EventArgs e)
        {
            try
            {
                deleteFiles();
            }
            catch (ExportProgramsException ex)
            {
                _sendErrMessage(ex);
            }
            catch (Exception ex)
            {
                _sendErrMessage(ex);
            }
        }

        private void lbFileList_MouseDown(object sender, MouseEventArgs e)
        {
            lbFileList.Items.Clear();
            selectFiles();
            if (selectedFileArray != null)
            {
                lbFileList.Items.AddRange(selectedFileArray);
            }
        }

        private void lbFileList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    this.deleteSelected();
                    break;
                default:
                    break;
            }
        }

        private void deleteSelected()
        {
            while (lbFileList.SelectedItems.Count > 0)
                this.lbFileList.Items.Remove(this.lbFileList.SelectedItem);
        }

        private void frmExportPrograms_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] f = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string s in f)
                    this.AddItem(s);                
            }
        }

        private void lbFileList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] f = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string s in f)
                    this.AddItem(s);
            }
        }
    }
}
