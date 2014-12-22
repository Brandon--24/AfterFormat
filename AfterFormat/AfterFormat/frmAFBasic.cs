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
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Threading;

namespace AfterFormat
{
    public partial class frmAFBasic : Form
    {
        public frmAFBasic()
        {
            InitializeComponent();

            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Interval = 300;
        }

        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        List<Downloader> dlList = new List<Downloader>();

        string downLoc = @"C:\";
        string customSilentInstallPath = @"D:\Applications\";
        bool useSilentInstall = true;
        bool useCustomInstallPath = false;

        private void frmAFBasic_Load(object sender, EventArgs e)
        {
            List<ApplicationInfo> appList = new List<ApplicationInfo>();
            try
            {
                appList = DeserializeFromXML();
            }
            catch (Exception ex)
            {
                appList = new List<ApplicationInfo>();
                SerializeToXML(appList);
            }

            foreach (ApplicationInfo app in appList)
            {
                app.GetInstalledVersionNumber();
                app.GetLatestVersionNumber();
                app.GetDownloadLink();

                Panel pnl = new Panel();
                pnl.Name = "pnl" + app.Name;
                pnl.Height = 80;
                pnl.Width = 400;
                pnl.BackColor = Color.LightCyan;
                flpApplications.Controls.Add(pnl);

                Label lbl = new Label();
                lbl.Name = "lbl" + app.Name;
                lbl.Text = app.Name;
                lbl.Height = 20;
                lbl.Width = 220;
                lbl.Location = new Point(0, 0);
                lbl.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
                lbl.BackColor = Color.LightCoral;
                pnl.Controls.Add(lbl);

                ProgressBar progressBar = new ProgressBar();
                progressBar.Name = "progressBar" + app.Name;
                progressBar.Height = 16;
                progressBar.Width = 220;
                progressBar.Location = new Point(0, 24);
                pnl.Controls.Add(progressBar);

                Label labelPerc = new Label();
                labelPerc.Name = "labelPerc" + app.Name;
                labelPerc.Height = 20;
                labelPerc.Width = 50;
                labelPerc.Location = new Point(225, 22);
                labelPerc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                labelPerc.BackColor = Color.LightCoral;
                pnl.Controls.Add(labelPerc);

                Label labelDownloaded = new Label();
                labelDownloaded.Name = "labelDownloaded" + app.Name;
                labelDownloaded.Height = 20;
                labelDownloaded.Width = 150;
                labelDownloaded.Location = new Point(0, 44);
                labelDownloaded.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                labelDownloaded.BackColor = Color.LightCoral;
                pnl.Controls.Add(labelDownloaded);

                Label labelSpeed = new Label();
                labelSpeed.Name = "labelSpeed" + app.Name;
                labelSpeed.Height = 20;
                labelSpeed.Width = 115;
                labelSpeed.Location = new Point(160, 44);
                labelSpeed.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                labelSpeed.BackColor = Color.LightCoral;
                pnl.Controls.Add(labelSpeed);

                Button btnResumeStop = new Button();
                btnResumeStop.Name = "btnResumeStop" + app.Name;
                btnResumeStop.Text = "Download";
                btnResumeStop.Height = 20;
                btnResumeStop.Width = 100;
                btnResumeStop.Location = new Point(280, 22);
                btnResumeStop.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                btnResumeStop.FlatStyle = FlatStyle.System;
                btnResumeStop.Tag = app;
                btnResumeStop.Click += new System.EventHandler(btnResumeStop_Click);
                pnl.Controls.Add(btnResumeStop);

                Button btnInstall = new Button();
                btnInstall.Name = "btnInstall" + app.Name;
                btnInstall.Text = "Install";
                btnInstall.Height = 20;
                btnInstall.Width = 100;
                btnInstall.Location = new Point(280, 44);
                btnInstall.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                btnInstall.FlatStyle = FlatStyle.System;
                btnInstall.Tag = app;
                btnInstall.Visible = false;
                btnInstall.Click += new System.EventHandler(btnInstall_Click);
                pnl.Controls.Add(btnInstall);
            }
            SerializeToXML(appList);
        }

        public void SerializeToXML(List<ApplicationInfo> _listOfApplications)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ApplicationInfo>));
                TextWriter textWriter = new StreamWriter(@"apps.xml");
                serializer.Serialize(textWriter, _listOfApplications);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<ApplicationInfo> DeserializeFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<ApplicationInfo>));
            TextReader textReader = new StreamReader(@"apps.xml");
            List<ApplicationInfo> _listOfApplications;
            _listOfApplications = (List<ApplicationInfo>)deserializer.Deserialize(textReader);
            textReader.Close();

            return _listOfApplications;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string appName = btn.Tag.ToString().Split(':')[0];
            string loc = btn.Tag.ToString().Substring(appName.Length + 1);

            if (useSilentInstall && useCustomInstallPath)
            {
                Process.Start(loc, "/S /D=" + customSilentInstallPath);
            }
            else if (useSilentInstall)
            {
                Process.Start(loc, "/S");
            }
            else
            {
                Process.Start(loc);
            }
        }

        private void btnResumeStop_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ApplicationInfo app = new ApplicationInfo();
            app = (ApplicationInfo)btn.Tag;
            string appName = app.Name;
            string fileName = app.GetFileName();
            string downLink = app.DownloadLink;

            if (btn.Text == "Download") //Download not started - Needs to start.
            {
                bool downExists = false;
                foreach (Downloader dl in dlList)
                {
                    if (app.Name == dl.DownloadName) //if it already exists, start it
                    {
                        downExists = true;
                        dl.FileDownload();

                        if (!tmr.Enabled)
                        {
                            tmr.Start();
                        }
                    }
                }
                if (!downExists) //if it doesn't, create new and start it
                {
                    Downloader dl = new Downloader(appName, downLink, downLoc + fileName);
                    dlList.Add(dl);
                    dl.FileDownload();

                    if (!tmr.Enabled)
                    {
                        tmr.Start();
                    }
                }
            }
            else //Download in progress - Needs to cancel.
            {
                foreach (Downloader dl in dlList)
                {
                    if (appName == dl.DownloadName)
                    {
                        dl.CancelDownload();
                    }
                }
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            foreach (Downloader dl in dlList)
            {
                string appName = dl.DownloadName;
                //MessageBox.Show(sender.ToString());
                // Calculate download speed and output it to labelSpeed.
                Control[] cs = flpApplications.Controls.Find("pnl" + appName, true);
                Control c = cs[0];
                Panel pnlThis = (Panel)c;
                cs = pnlThis.Controls.Find("labelSpeed" + appName, true);
                c = cs[0];
                Label labelSpeed = (Label)c;

                cs = pnlThis.Controls.Find("progressBar" + appName, true);
                c = cs[0];
                ProgressBar progressBar = (ProgressBar)c;

                cs = pnlThis.Controls.Find("labelPerc" + appName, true);
                c = cs[0];
                Label labelPerc = (Label)c;

                cs = pnlThis.Controls.Find("labelDownloaded" + appName, true);
                c = cs[0];
                Label labelDownloaded = (Label)c;

                cs = pnlThis.Controls.Find("btnResumeStop" + appName, true);
                c = cs[0];
                Button btnResumeStop = (Button)c;

                labelSpeed.Text = dl.DownloadSpeed;

                // Update the progressbar percentage only when the value is not the same.
                progressBar.Value = Convert.ToInt32(dl.DownloadPercentage);

                // Show the percentage on our label.
                labelPerc.Text = dl.DownloadPercentage + "%";

                // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
                labelDownloaded.Text = dl.DownloadedFromTotal;

                if (dl.IsDownloading)
                {
                    btnResumeStop.Text = "Cancel";
                }
                else if (dl.IsCancelled)
                {
                    btnResumeStop.Text = "Download";
                    //if (dls.Count == 1)
                    //{
                    //    t.Stop();
                    //}
                    //dls.Remove(d);
                    break;
                }
                else if (dl.IsFinished)
                {
                    btnResumeStop.Text = "Download";
                    btnResumeStop.Enabled = false;
                    //if (dls.Count == 1)
                    //{
                    //    t.Stop();
                    //}
                    //dls.Remove(d);
                    break;
                }
            }
        }
    }
}
