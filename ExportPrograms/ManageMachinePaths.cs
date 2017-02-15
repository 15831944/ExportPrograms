using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportPrograms {
  public partial class ManageMachinePaths : Form {
    public ManageMachinePaths() {
      InitializeComponent();
    }

    private void ManageMachinePaths_Load(object sender, EventArgs e) {
      Location = Properties.Settings.Default.ManageMachinePathsLocation;
      Size = Properties.Settings.Default.ManageMachinePathsSize;
      cUT_MACHINESTableAdapter.Fill(this.machines.CUT_MACHINES);
    }

    private void button1_Click(object sender, EventArgs e) {
      Close();
    }

    private void button2_Click(object sender, EventArgs e) {
      DialogResult d = MessageBox.Show(@"Are you sure?", @"Update Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (d == DialogResult.Yes) {
        cUT_MACHINESTableAdapter.Update(machines.CUT_MACHINES);
      }
      Close();
    }
  }
}
