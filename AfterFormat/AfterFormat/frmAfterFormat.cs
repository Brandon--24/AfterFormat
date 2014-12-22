using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.Collections;

namespace AfterFormat
{
    public partial class frmAfterFormat : Form
    {
        public frmAfterFormat()
        {
            InitializeComponent();
            loadingFinished = false;
            installedList = new List<string>();
        }

        bool loadingFinished;
        List<string> installedList;

        private void btnRegReset_Click(object sender, EventArgs e)
        {
            //disable button
            btnRegReset.Enabled = false;
            //create a new process
            Process p = new Process();
            //create a process start info to execute the task kill program
            ProcessStartInfo tsKill = new ProcessStartInfo("taskkill.exe", "/F /IM explorer.exe");
            //hide the command prompt from the user
            tsKill.WindowStyle = ProcessWindowStyle.Hidden;
            //set the process start info
            p.StartInfo = tsKill;
            //start the process
            p.Start();
            //wait until the task kill process is done
            p.WaitForExit();

            //wait some time for process to be 100% complete
            Thread.Sleep(1000);
            //start process again
            Process.Start("explorer.exe");
            //wait some time for the explorer to load
            Thread.Sleep(2000);
            //enable the button again
            btnRegReset.Enabled = true;

        }

        private void btnRegRecommended_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
            key.SetValue("Start_SearchFIles", 2);
            key.SetValue("ServerAdminUI", 0);
            key.SetValue("Hidden", 1);
            key.SetValue("ShowCompColor", 1);
            key.SetValue("HideFileExt", 0);
            key.SetValue("DontPrettyPath", 0);
            key.SetValue("ShowInfoTip", 1);
            key.SetValue("HideIcons", 0);
            key.SetValue("MapNetDrvBtn", 0);
            key.SetValue("WebView", 1);
            key.SetValue("Filter", 0);
            key.SetValue("SuperHidden", 0);
            key.SetValue("SeparateProcess", 0);
            key.SetValue("AutoCheckSelect", 0);
            key.SetValue("IconsOnly", 0);
            key.SetValue("ShowTypeOverlay", 1);
            key.SetValue("ListViewAlphaSelect", 1);
            key.SetValue("ListViewShadow", 1);
            key.SetValue("TaskbarAnimations", 1);
            key.SetValue("StartMenuInit", 4);
            key.SetValue("Start_ShowSetProgramAccessAndDefaults", 0);
            key.SetValue("Start_ShowPrinters", 0);
            key.SetValue("StartMenuFavorites", 1);
            key.SetValue("Start_ShowMyGames", 0);
            key.SetValue("Start_ShowHelp", 0);
            key.SetValue("Start_ShowMyMusic", 0);
            key.SetValue("Start_ShowNetPlaces", 1);
            key.SetValue("Start_ShowMyPics", 0);
            key.SetValue("Start_JumpListItems", 10);
            key.SetValue("Start_AdminToolsRoot", 0);
            key.SetValue("StartMenuAdminTools", 0);
            key.SetValue("TaskbarSizeMove", 0);
            key.SetValue("DisablePreviewDesktop", 0);
            key.SetValue("TaskbarSmallIcons", 0);
            key.SetValue("TaskbarGlomLevel", 0);
            key.SetValue("Start_TrackProgs", 0);
            key.SetValue("Start_PowerButtonAction", 2);
            key.SetValue("AlwaysShowMenus", 0);
            key.SetValue("NavPaneShowAllFolders", 0);
            key.SetValue("NavPaneExpandToCurrentFolder", 0);
            key.SetValue("Start_ShowMyComputer", 1);
            key.SetValue("Start_LargeMFUIcons", 0); //Start Menu - Show Large Most Frequently Used Icons - default 1

            //Software\Microsoft\Windows\CurrentVersion\Explorer 
            key = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer", true);
            key.SetValue("EnableAutoTray", 0); //Always show icons and notifications on the taskbar - default 1

            key.Close();
        }

        private void frmAfterFormat_Load(object sender, EventArgs e)
        {
            GetRegStartMenu();
            GetInstalledApplications();
            loadingFinished = true;
        }

        private void GetInstalledApplications()
        {
            RegistryKey key = Registry.LocalMachine;
            key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",false);

            foreach (String subKeyName in key.GetSubKeyNames())
            {
                if (key.OpenSubKey(subKeyName) != null)
                {
                    RegistryKey subkey = key.OpenSubKey(subKeyName);
                    if (subkey.GetValue("DisplayName") != null)
                    {
                        string appName = subkey.GetValue("DisplayName").ToString();
                        if (appName == "CCleaner" ||
                            appName == "DAEMON Tools Lite" ||
                            appName.StartsWith("Adobe Reader") ||
                            appName.StartsWith("Adobe Flash Player") ||
                            appName.StartsWith("Any Video Converter"))
                        {
                            if (subkey.GetValue("DisplayVersion") != null)
                            {
                                installedList.Add(subkey.GetValue("DisplayName").ToString() + ";" + subkey.GetValue("DisplayVersion").ToString());
                            }
                            else
                            {
                                 installedList.Add(subkey.GetValue("DisplayName").ToString() + ";");
                            }
                            
                        }
                    }
                }
            }
            foreach (string str in installedList)
            {
                lbInstalled.Items.Add(str.Split(';')[0]);
            }



        }

        private void lbInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string str in installedList)
            {
                if (lbInstalled.SelectedItem.ToString() == str.Split(';')[0])
                {
                    lblSelectedAppName.Text = str.Split(';')[0];
                    if (str.Split(';')[1] != "")
                    {
                        lblSelectedAppVersion.Text = "Product Version: " + str.Split(';')[1];
                    }
                    else
                    {
                        lblSelectedAppVersion.Text = "";
                    }
                }
            }

        }

        private void GetRegStartMenu()
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
            if (Convert.ToInt32(key.GetValue("Start_ShowUser", 1)) == 0) { cbRegStaUser.Checked = false; } else { cbRegStaUser.Checked = true; }
            if (Convert.ToInt32(key.GetValue("Start_ShowMyDocs", 1)) == 0) { cbRegStaDocs.Checked = false; } else { cbRegStaDocs.Checked = true; }
            if (Convert.ToInt32(key.GetValue("StartMenuFavorites", 1)) == 0) { cbRegStaFavo.Checked = false; } else { cbRegStaFavo.Checked = true; }
            if (Convert.ToInt32(key.GetValue("Start_ShowMyComputer", 1)) == 0) { cbRegStaComp.Checked = false; } else { cbRegStaComp.Checked = true; }
            if (Convert.ToInt32(key.GetValue("Start_ShowNetPlaces", 1)) == 0) { cbRegStaNetw.Checked = false; } else { cbRegStaNetw.Checked = true; }
            if (Convert.ToInt32(key.GetValue("Start_ShowControlPanel", 1)) == 0) { cbRegStaCPan.Checked = false; } else { cbRegStaCPan.Checked = true; }
            key.Close();
        }

        private void cb_Start_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingFinished)
            {
                RegistryKey key = Registry.CurrentUser;
                key = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);

                Control c = (Control)sender;
                CheckBox cb = (CheckBox)c;

                switch (cb.Name.Substring(cb.Name.Length - 4).ToLower())
                {
                    case "user":
                        if (cb.Checked) { key.SetValue("Start_ShowUser", 1); } else { key.SetValue("Start_ShowUser", 0); }
                        break;
                    case "docs":
                        if (cb.Checked) { key.SetValue("Start_ShowMyDocs", 1); } else { key.SetValue("Start_ShowMyDocs", 0); }
                        break;
                    case "favo":
                        if (cb.Checked) { key.SetValue("StartMenuFavorites", 1); } else { key.SetValue("StartMenuFavorites", 0); }
                        break;
                    case "comp":
                        if (cb.Checked) { key.SetValue("Start_ShowMyComputer", 1); } else { key.SetValue("Start_ShowMyComputer", 0); }
                        break;
                    case "netw":
                        if (cb.Checked) { key.SetValue("Start_ShowNetPlaces", 1); } else { key.SetValue("Start_ShowNetPlaces", 0); }
                        break;
                    case "cpan":
                        if (cb.Checked) { key.SetValue("Start_ShowControlPanel", 1); } else { key.SetValue("Start_ShowControlPanel", 0); }
                        break;
                    default:
                        break;
                }
                key.Close();
            }
        }

        private void cb_UAC_CheckedChanged(object sender, EventArgs e)
        {
            /*
             * [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System]
             * "ConsentPromptBehaviorAdmin"=dword:00000000
             * "EnableLUA"=dword:00000000
             */

            if (loadingFinished)
            {
                RegistryKey key = Registry.LocalMachine;
                key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);

                Control c = (Control)sender;
                CheckBox cb = (CheckBox)c;

                switch (cb.Name)
                {
                    case "cbUAC":
                        if (cb.Checked) { key.SetValue("EnableLUA", 1); } else { key.SetValue("EnableLUA", 0); }
                        break;
                    case "cbUACPrompt":
                        if (cb.Checked) { key.SetValue("ConsentPromptBehaviorAdmin", 5); } else { key.SetValue("ConsentPromptBehaviorAdmin", 0); }
                        break;
                    default:
                        break;
                }
                key.Close();
            }
        }

        private void tbMain_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("changed");

        }

        
    }
}
