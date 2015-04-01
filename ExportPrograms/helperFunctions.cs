using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExportPrograms
{
    public partial class frmExportPrograms
    {
        private String sMachineListFile;
        private IniParser fsMachines;
        private String[] saMachineArray;
        private String[] selectedFileArray;
        private String selectedBackupFolder;

        private void readIniFile()
        {
            try
            {
                sMachineListFile = "\\\\AMSTORE-SVR-22\\cad\\machines.ini";
                fsMachines = new IniParser(sMachineListFile);
                saMachineArray = fsMachines.EnumSection("MACHINES");
                System.Array.Sort(saMachineArray);
                lbMachineList.Items.AddRange(saMachineArray);
            }
            catch (Exception ex)
            {
                throw new ExportProgramsException("Error reading " + sMachineListFile, ex);
            }
        }

        private void InitializeOpenFileDialog()
        {
            this.ofdSelectProgs.Multiselect = true;
            this.ofdSelectProgs.Filter = "Machine programs (*.mpr)|*.MPR|All files (*.*)|*.*";
            this.ofdSelectProgs.Title = "Select machine programs";
        }

        private void selectFiles()
        {
            DialogResult dr = this.ofdSelectProgs.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                selectedFileArray = ofdSelectProgs.FileNames;
            }
        }

        private void selectMachinesByType(Boolean pods)
        {
            foreach (String s in saMachineArray)
            {
                if (fsMachines.GetSetting(s, "Type") == "POD")
                    this.lbMachineList.SetSelected(this.lbMachineList.Items.IndexOf(s), pods);
                else
                    this.lbMachineList.SetSelected(this.lbMachineList.Items.IndexOf(s), !pods);
            }
        }

        private Boolean connected(String path)
        {
            String hostName = path.Split('\\')[2];
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pr = null;

            try
            {
                pr = p.Send(hostName, 1000);
            }
            catch (System.Net.NetworkInformation.PingException pEx)
            {
                return false;
                //throw new ExportProgramsException("Ping exception", pEx);
            }
            catch (Exception ex)
            {
                return false;
            }

            switch (pr.Status)
	        {
                case System.Net.NetworkInformation.IPStatus.Success:
                    return true;
                case System.Net.NetworkInformation.IPStatus.TimedOut:
                    ExportProgramsException ex = new ExportProgramsException("Network timout on " + path);
                    throw ex;
                case  System.Net.NetworkInformation.IPStatus.DestinationHostUnreachable:
                    return false;
                case System.Net.NetworkInformation.IPStatus.Unknown:
                    return false;
                default:
                    return false;
	        }
        }

        private void copyFiles()
        {
            System.Collections.ArrayList alCopyFailArray = new System.Collections.ArrayList();

            foreach (String file in selectedFileArray)
            {
                foreach (String s in saMachineArray)
                {
                    String baseName = Path.GetFileName(file);
                    String newPath = fsMachines.GetSetting("MACHINES", s);
                    String target = newPath + "\\" + baseName;
                    if (lbMachineList.GetSelected(lbMachineList.Items.IndexOf(s)) && !File.Exists(target))
                    {
                        toolStripStatusLabel1.Text = "Writing " + baseName + " to " + s + "...";
                        try
                        {
                            if (connected(target))
                            {
                                File.Copy(file, target);
                            }
                            else
                            {
                                alCopyFailArray.Add(s);
                                this.lbMachineList.SetSelected(this.lbMachineList.Items.IndexOf(s), false);
                            }
                        }
                        catch (Exception ex)
                        {
                            ExportProgramsException e = new ExportProgramsException("Failed to copy " + target + ".", ex);
                            e.Data.Add("file", file);
                            e.Data.Add("machine", s);
                            e.Data.Add("baseName", baseName);
                            e.Data.Add("target", target);
                            throw e;
                        }
                    }
                    else if (lbMachineList.GetSelected(lbMachineList.Items.IndexOf(s)))
                    {
                        toolStripStatusLabel1.Text = "Writing " + baseName + " to " + s + "...";
                        try
                        {
                            if (connected(target))
                            {
                            File.Delete(target);
                            File.Copy(file, target);
                            }
                            else
                            {
                                alCopyFailArray.Add(s);
                                this.lbMachineList.SetSelected(this.lbMachineList.Items.IndexOf(s), false);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new ExportProgramsException("Failed to copy " + target + ".", ex);
                        }
                    }
                    else
                        toolStripStatusLabel1.Text = "Skipping " + s + "...";
                }
            }
            toolStripStatusLabel1.Text = String.Empty;
            presesnceCheck("The following machines could not be accessed:\n", alCopyFailArray);
        }

        private void moveFiles()
        {
            toolStripStatusLabel1.Text = "Moving files...";
            InitializeFolderSelectDialog();
            DialogResult dr = this.fbdSelectBackupDestination.ShowDialog();
            selectedBackupFolder = this.fbdSelectBackupDestination.SelectedPath;
            if (dr == System.Windows.Forms.DialogResult.OK)
	        {
	            foreach (String file in selectedFileArray)
                {
                    String baseName = Path.GetFileName(file);
                    String target = selectedBackupFolder + "\\" + baseName;
                    if (File.Exists(target))
                    {
                        toolStripStatusLabel1.Text = "Moving " + baseName + " to " + selectedBackupFolder + "...";
                        try
                        {
                            File.Delete(target);
                            File.Move(file, target);
                        }
                        catch (Exception ex)
                        {
                            throw new ExportProgramsException("Failed to move " + target + ".", ex);
                        }
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Moving " + baseName + " to " + selectedBackupFolder + "...";
                        try
                        {
                            File.Move(file, target);
                        }
                        catch (Exception ex)
                        {
                            throw new ExportProgramsException("Failed to move " + target + ".", ex);
                        }
                    }

                }	 
	        }
            toolStripStatusLabel1.Text = String.Empty;
        }

        private void deleteFiles()
        {
            toolStripStatusLabel1.Text = "Deleting files...";
            DialogResult dr = MessageBox.Show("Delete '" + tbDelete.Text + ".mpr' from all machines?", "Really?", MessageBoxButtons.YesNo);

            System.Collections.ArrayList alDeleteFailArray = new System.Collections.ArrayList();
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                String path = null;
                String target = null;
                foreach (String s in fsMachines.EnumSection("MACHINES"))
                {
                    path = fsMachines.GetSetting("MACHINES", s);
                    target = path + "\\" + tbDelete.Text + ".mpr";
                    if (File.Exists(target))
                    {
                        toolStripStatusLabel1.Text = "Deleting '" + tbDelete.Text.Trim() + ".mpr' from " + s + "...";
                        try
                        {
                            File.Delete(target);
                        }
                        catch (Exception ex)
                        {
                            throw new ExportProgramsException("Failed to delete " + target + ".", ex);
                        }
                    } 
                    else if (!connected(target)) 
                    {
                        alDeleteFailArray.Add(s);
                    }
                }
            }
            toolStripStatusLabel1.Text = String.Empty;
            presesnceCheck("The following machines could not be accessed:\n", alDeleteFailArray);
        }

        private void presesnceCheck(String m, System.Collections.ArrayList al)
        {
            if (al.Count != 0)
            {
                String msg = m;
                foreach (String item in al)
                {
                    msg += "\n" + item;
                }

                MessageBox.Show(msg, "Machines offline");   
            }
            al.Clear();
        }

        private void InitializeFolderSelectDialog()
        {
            this.fbdSelectBackupDestination.RootFolder = Environment.SpecialFolder.MyComputer;
            this.fbdSelectBackupDestination.SelectedPath = "Q:\\WEEKE";
        }

        private void _sendErrMessage(Exception e)
        {
            String msg = e.TargetSite + "threw an error: " + e.Message + "\n";

            foreach (System.Collections.DictionaryEntry item in e.Data)
            {
                msg += "\n" + item.Key + ": " + item.Value;
            }
            MessageBox.Show(msg, "Show this to your programmer and see if he can understand it.");
        }
    }
}
