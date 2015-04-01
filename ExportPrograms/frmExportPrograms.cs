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
            if (selectedFileArray != null)
            {
                lbFileList.Items.AddRange(selectedFileArray);   
            }
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

    }

    [Serializable]
    public class ExportProgramsException : Exception
    {
        public ExportProgramsException() { }
        public ExportProgramsException(string message) : base(message) { }
        public ExportProgramsException(string message, Exception inner) : base(message, inner) { }
        protected ExportProgramsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
