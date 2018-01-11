using System;
using System.Windows.Forms;

namespace ExportPrograms {
  public partial class ManageMachinePaths : Form {
    private bool dataChanged = false;
    public ManageMachinePaths() {
      InitializeComponent();
    }

    private void ManageMachinePaths_Load(object sender, EventArgs e) {
      Location = Properties.Settings.Default.ManageMachinePathsLocation;
      Size = Properties.Settings.Default.ManageMachinePathsSize;
      cUT_MACHINESTableAdapter.Fill(this.machines.CUT_MACHINES);
      dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
    }

    void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
      dataChanged = true;
    }

    private void button1_Click(object sender, EventArgs e) {
      Close();
    }

    private void button2_Click(object sender, EventArgs e) {
      if (dataChanged) {
        DialogResult d = MessageBox.Show(@"Are you sure?", @"Update Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (d == DialogResult.Yes) {
          cUT_MACHINESTableAdapter.Update(machines.CUT_MACHINES);
          Close();
        }
      } else {
        Close();
      }
    }

    private void ManageMachinePaths_FormClosing(object sender, FormClosingEventArgs e) {
      Properties.Settings.Default.ManageMachinePathsLocation = Location;
      Properties.Settings.Default.ManageMachinePathsSize = Size;
      Properties.Settings.Default.Save();
    }
  }
}
