using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ExportPrograms {
  public partial class frmExportPrograms : Form {
    const int THISFUNCTION = 8;
    private string[] selectedFileArray;
    private string selectedBackupFolder;

    public frmExportPrograms() {
      InitializeComponent();
      Text = Text + @" " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    private void AddItem(string item) {
      if (!this.lbFileList.Items.Contains(item))
        this.lbFileList.Items.Add(item);
    }

    private void frmExportPrograms_Load(Object sender, EventArgs e) {
      Location = Properties.Settings.Default.WindowLocation;
      cUT_MACHINESTableAdapter.FillCopyable(this.machines.CUT_MACHINES);
      InitializeOpenFileDialog();
      lbFileList.Items.Clear();
      IncrementOdometer();
    }

    private void IncrementOdometer() {
      MachinesTableAdapters.GEN_USERSTableAdapter guta = new MachinesTableAdapters.GEN_USERSTableAdapter();
      int uid = (int)guta.GetUIDByUsername(Environment.UserName);
      Machines.IncrementOdometer(THISFUNCTION, uid);
    }

    private void butChangeSelection_Click(object sender, EventArgs e) {
      lbFileList.Items.Clear();
      selectFiles();
      if (this.selectedFileArray != null)
        foreach (string item in selectedFileArray)
          this.AddItem(item);
    }

    private void butPods_Click(object sender, EventArgs e) {
      selectMachinesByType(true);
    }

    private void butFlat_Click(object sender, EventArgs e) {
      selectMachinesByType(false);
    }

    private void butCancel_Click(object sender, EventArgs e) {
      Close();
    }

    private void butOK_Click(object sender, EventArgs e) {
      if (selectedFileArray != null) {
        if (lbMachineList.SelectedIndices.Count > 0) {
          try {
            copyFiles();
            moveFiles();
          } catch (ExportProgramsException ex) {
            _sendErrMessage(ex);
          } catch (Exception ex) {
            _sendErrMessage(ex);
          }
          AllDone ad = new AllDone();
          ad.ShowDialog();
          Close();
        } else {
          System.Windows.Forms.MessageBox.Show(@"Please select more than 0 machines.");
        }
      } else {
        System.Windows.Forms.MessageBox.Show(@"Please select more than 0 files.");
      }
    }

    private void butDeleteFromMachines_Click(object sender, EventArgs e) {
      try {
        deleteFiles();
      } catch (ExportProgramsException ex) {
        _sendErrMessage(ex);
      } catch (Exception ex) {
        _sendErrMessage(ex);
      }
    }

    private void lbFileList_MouseDown(object sender, MouseEventArgs e) {
      lbFileList.Items.Clear();
      selectFiles();
      if (selectedFileArray != null) {
        lbFileList.Items.AddRange(selectedFileArray);
      }
    }

    private void lbFileList_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Delete:
          this.deleteSelected();
          break;
        default:
          break;
      }
    }

    private void deleteSelected() {
      while (lbFileList.SelectedItems.Count > 0)
        this.lbFileList.Items.Remove(this.lbFileList.SelectedItem);
    }

    private void frmExportPrograms_DragDrop(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        string[] f = e.Data.GetData(DataFormats.FileDrop, true) as string[];
        foreach (string s in f)
          this.AddItem(s);
      }
    }

    private void lbFileList_DragDrop(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        string[] f = e.Data.GetData(DataFormats.FileDrop, true) as string[];
        foreach (string s in f)
          this.AddItem(s);
      }
    }

    private void InitializeOpenFileDialog() {
      this.ofdSelectProgs.Multiselect = true;
      this.ofdSelectProgs.Filter = "Machine programs (*.mpr)|*.MPR|Laser Programs (*.lcd)|*.LCD|All files (*.*)|*.*";
      this.ofdSelectProgs.Title = "Select machine programs";
    }

    private void selectFiles() {
      DialogResult dr = this.ofdSelectProgs.ShowDialog();
      if (dr == System.Windows.Forms.DialogResult.OK) {
        selectedFileArray = ofdSelectProgs.FileNames;
      }
    }

    private void selectMachinesByType(Boolean pods) {
      List<object> l = new List<object>();
      foreach (var item in lbMachineList.Items) {
        l.Add(item);
      }

      foreach (var drv in l) {
        if ((drv as DataRowView)[@"TYPE"].ToString() == @"P") {
          lbMachineList.SetSelected(lbMachineList.Items.IndexOf(drv), pods);
        } else if ((drv as DataRowView)[@"TYPE"].ToString() == @"F") {
          lbMachineList.SetSelected(lbMachineList.Items.IndexOf(drv), !pods);
        }
      }
    }

    private Boolean connected(String path) {
      String hostName = path.Split('\\')[2];
      System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
      System.Net.NetworkInformation.PingReply pr = null;

      try {
        pr = p.Send(hostName, 1000);
      } catch (System.Net.NetworkInformation.PingException) {
        return false;
        //throw new ExportProgramsException("Ping exception", pEx);
      } catch (Exception) {
        return false;
      }

      switch (pr.Status) {
        case System.Net.NetworkInformation.IPStatus.Success:
          return true;
        case System.Net.NetworkInformation.IPStatus.TimedOut:
          ExportProgramsException ex = new ExportProgramsException("Network timout on " + path);
          throw ex;
        case System.Net.NetworkInformation.IPStatus.DestinationHostUnreachable:
          return false;
        case System.Net.NetworkInformation.IPStatus.Unknown:
          return false;
        default:
          return false;
      }
    }

    private void copyFiles() {
      System.Collections.ArrayList alCopyFailArray = new System.Collections.ArrayList();
      List<object> l = new List<object>();
      foreach (var item in lbMachineList.Items) {
        l.Add(item);
      }

      foreach (String file in selectedFileArray) {
        foreach (DataRowView item in l) {
          string machname = (string)item[@"MACHNAME"];
          string baseName = Path.GetFileName(file);
          string newPath = (string)item[@"LOC"];
          string target = newPath + @"\" + baseName;
          int idx = lbMachineList.Items.IndexOf(item);
          bool selected = lbMachineList.GetSelected(idx);
          if (selected) {
            toolStripStatusLabel1.Text = @"Writing " + baseName + @" to " + machname + @"...";
            try {
              if (connected(target)) {
                File.Copy(file, target, true);
              } else {
                alCopyFailArray.Add(machname);
                lbMachineList.SetSelected(idx, false);
              }
            } catch (Exception ex) {
              ExportProgramsException e = new ExportProgramsException(@"Failed to copy " + target + @".", ex);
              e.Data.Add("file", file);
              e.Data.Add("machine", machname);
              e.Data.Add("baseName", baseName);
              e.Data.Add("target", target);
              throw e;
            }
          } else {
            toolStripStatusLabel1.Text = "Skipping " + machname + "...";
          }
        }
      }
      toolStripStatusLabel1.Text = String.Empty;
      presesnceCheck("The following machines could not be accessed:\n", alCopyFailArray);
    }

    private void moveFiles() {
      toolStripStatusLabel1.Text = "Moving files...";
      InitializeFolderSelectDialog();
      DialogResult dr = this.fbdSelectBackupDestination.ShowDialog();
      selectedBackupFolder = this.fbdSelectBackupDestination.SelectedPath;
      if (dr == System.Windows.Forms.DialogResult.OK) {
        foreach (String file in selectedFileArray) {
          String baseName = Path.GetFileName(file);
          String target = selectedBackupFolder + "\\" + baseName;
          if (File.Exists(target)) {
            toolStripStatusLabel1.Text = "Moving " + baseName + " to " + selectedBackupFolder + "...";
            try {
              File.Delete(target);
              File.Move(file, target);
            } catch (Exception ex) {
              throw new ExportProgramsException("Failed to move " + target + ".", ex);
            }
          } else {
            toolStripStatusLabel1.Text = "Moving " + baseName + " to " + selectedBackupFolder + "...";
            try {
              File.Move(file, target);
            } catch (Exception ex) {
              throw new ExportProgramsException("Failed to move " + target + ".", ex);
            }
          }

        }
      }
      toolStripStatusLabel1.Text = String.Empty;
    }

    private void deleteFiles() {
      toolStripStatusLabel1.Text = "Deleting files...";
      DialogResult dr = MessageBox.Show("Delete '" + tbDelete.Text + ".mpr' from all machines?", "Really?", MessageBoxButtons.YesNo);

      System.Collections.ArrayList alDeleteFailArray = new System.Collections.ArrayList();
      if (dr == System.Windows.Forms.DialogResult.Yes) {
        String path = null;
        String target = null;
        foreach (DataRowView s in lbMachineList.Items) {
          path = (string)s[@"LOC"];
          target = path + @"\" + tbDelete.Text + ".mpr";
          if (File.Exists(target)) {
            toolStripStatusLabel1.Text = "Deleting '" + tbDelete.Text.Trim() + ".mpr' from " + s + "...";
            try {
              File.Delete(target);
            } catch (Exception ex) {
              throw new ExportProgramsException("Failed to delete " + target + ".", ex);
            }
          } else if (!connected(target)) {
            alDeleteFailArray.Add((string)s[@"MACHNAME"]);
          }
        }
      }
      toolStripStatusLabel1.Text = String.Empty;
      presesnceCheck("The following machines could not be accessed:\n", alDeleteFailArray);
    }

    private void presesnceCheck(String m, System.Collections.ArrayList al) {
      if (al.Count != 0) {
        String msg = m;
        foreach (String item in al) {
          msg += "\n" + item;
        }

        MessageBox.Show(msg, "Machines offline");
      }
      al.Clear();
    }

    private void InitializeFolderSelectDialog() {
      this.fbdSelectBackupDestination.RootFolder = Environment.SpecialFolder.MyComputer;
      this.fbdSelectBackupDestination.SelectedPath = "Q:\\WEEKE";
    }

    private void _sendErrMessage(Exception e) {
      String msg = e.TargetSite + "threw an error: " + e.Message + "\n";

      foreach (System.Collections.DictionaryEntry item in e.Data) {
        msg += "\n" + item.Key + ": " + item.Value;
      }
      MessageBox.Show(msg, "Show this to your programmer and see if he can understand it.");
    }

    private void button1_Click(object sender, EventArgs e) {
      ManageMachinePaths mmp = new ManageMachinePaths();
      mmp.ShowDialog(this);
      cUT_MACHINESTableAdapter.FillCopyable(this.machines.CUT_MACHINES);
    }

    private void frmExportPrograms_FormClosing(object sender, FormClosingEventArgs e) {
      Properties.Settings.Default.WindowLocation = Location;
      Properties.Settings.Default.Save();
    }
  }
}
