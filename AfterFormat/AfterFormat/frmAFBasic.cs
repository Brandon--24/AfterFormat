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



namespace AfterFormat
{
    public partial class frmAFBasic : Form
    {
        public frmAFBasic()
        {
            InitializeComponent();
        }

        WebClient webClient;               // Our WebClient that will be doing the downloading for us

        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed

        string downLoc = @"C:\";
        string customSilentInstallPath = @"D:\\Applications\\";
        bool useSilentInstall = true;
        bool useCustomInstallPath = false;

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

        private void frmAFBasic_Load(object sender, EventArgs e)
        {

            List<ApplicationInfo> applicationsList = new List<ApplicationInfo>();
            try
            {
                applicationsList = DeserializeFromXML();
            }
            catch (Exception ex)
            {
                applicationsList = new List<ApplicationInfo>();
                SerializeToXML(applicationsList);
            }

            ApplicationInfo app = new ApplicationInfo();

            //app.Name = "CCleaner";
            //app.Url = @"http://www.downloadx64.com/ccleaner/";

            //app.GetInstalledVersionNumber();
            //app.GetLatestVersionNumber();
            //app.GetDownloadLink();

            //applicationsList.Add(app);




            //MessageBox.Show(app.Name + " v" + app.LatestVersion + "\n"+app.DownloadLink);
            //MessageBox.Show(app.Name + ": Latest Version is v" + app.LatestVersion + "\nCurrently Instalkled Version is v" + app.InstalledVersion + "\nTo Update?" + app.CheckAvailableUpdate() + " \nDownload Link:" + app.DownloadLink);
            /*Code needed to add stuff in the flow layout panel
             * - need to add a panel and insert details of application in it.
             * for (int i = 0; i < dt.Rows.Count; i++)
        {
            Button btn = new Button();
            btn.Name = "btn" + dt.Rows[i][1];
            btn.Tag = dt.Rows[i][1];
            btn.Text = dt.Rows[i][2].ToString();
            btn.Font = new Font("Arial", 14f, FontStyle.Bold);
            // btn.UseCompatibleTextRendering = true;
            btn.BackColor = Color.Green;
            btn.Height = 57;
            btn.Width = 116;
            btn.Click += button1_Click;   //  set any method
            btn.Enter += button1_Enter;   // 
            btn.Leave += button1_Leave;   //


            flowLayoutPanel1.Controls.Add(btn);                

        }
            */

            /*
            private string name;
            private int installedVersion;
            private int latestVersion;
            private string url;
            private string regKeyLocation;
            private bool isInstalled;
            */

            foreach (ApplicationInfo appl in applicationsList)
            {
                appl.GetInstalledVersionNumber();
                appl.GetLatestVersionNumber();
                appl.GetDownloadLink();

                Panel pnl = new Panel();
                pnl.Name = "pnl" + appl.Name;
                pnl.Height = 80;
                pnl.Width = 400;
                pnl.BackColor = Color.LightCyan;
                flpApplications.Controls.Add(pnl);

                Label lbl = new Label();
                lbl.Name = "lbl" + appl.Name;
                lbl.Text = appl.Name;
                lbl.Height = 20;
                lbl.Width = 220;
                lbl.Location = new Point(0, 0);
                lbl.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
                lbl.BackColor = Color.LightCoral;
                pnl.Controls.Add(lbl);

                ProgressBar progressBar = new ProgressBar();
                progressBar.Name = "progressBar" + appl.Name;
                progressBar.Height = 16;
                progressBar.Width = 220;
                progressBar.Location = new Point(0, 24);
                pnl.Controls.Add(progressBar);

                Label labelPerc = new Label();
                labelPerc.Name = "labelPerc" + appl.Name;
                labelPerc.Height = 20;
                labelPerc.Width = 50;
                labelPerc.Location = new Point(225, 22);
                labelPerc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                labelPerc.BackColor = Color.LightCoral;
                pnl.Controls.Add(labelPerc);

                Label labelDownloaded = new Label();
                labelDownloaded.Name = "labelDownloaded" + appl.Name;
                labelDownloaded.Height = 20;
                labelDownloaded.Width = 150;
                labelDownloaded.Location = new Point(0, 44);
                labelDownloaded.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                labelDownloaded.BackColor = Color.LightCoral;
                pnl.Controls.Add(labelDownloaded);
                string downLink = appl.DownloadLink;
                string fileName = downLink.Substring(downLink.LastIndexOf('/'));

                Label labelSpeed = new Label();
                labelSpeed.Name = "labelSpeed" + appl.Name;
                labelSpeed.Height = 20;
                labelSpeed.Width = 115;
                labelSpeed.Location = new Point(160, 44);
                labelSpeed.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                labelSpeed.BackColor = Color.LightCoral;
                pnl.Controls.Add(labelSpeed);

                Button btnResumeStop = new Button();
                btnResumeStop.Name = "btnResumeStop" + appl.Name;
                btnResumeStop.Text = "Download";
                btnResumeStop.Height = 20;
                btnResumeStop.Width = 100;
                btnResumeStop.Location = new Point(280, 22);
                btnResumeStop.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                btnResumeStop.FlatStyle = FlatStyle.System;
                btnResumeStop.Tag = appl.Name + ":" + fileName + ":" + downLink;
                btnResumeStop.Click += new System.EventHandler(btnResumeStop_Click);
                pnl.Controls.Add(btnResumeStop);

                Button btnInstall = new Button();
                btnInstall.Name = "btnInstall" + appl.Name;
                btnInstall.Text = "Install";
                btnInstall.Height = 20;
                btnInstall.Width = 100;
                btnInstall.Location = new Point(280, 44);
                btnInstall.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                btnInstall.FlatStyle = FlatStyle.System;
                btnInstall.Tag = appl.Name + ":" + downLoc + fileName;
                btnInstall.Visible = false;
                btnInstall.Click += new System.EventHandler(btnInstall_Click);
                pnl.Controls.Add(btnInstall);
            }

            SerializeToXML(applicationsList);

            //DownloadFile(downLink, @"C:\" + fileName);

            //Panel pnl2 = new Panel();
            //pnl2.Name = "pnlApp2";
            //pnl2.Height = 80;
            //pnl2.Width = 400;
            //pnl2.BackColor = Color.LightCyan;
            //flpApplications.Controls.Add(pnl2);

            //Label lbl2 = new Label();
            //lbl2.Name = "lblAppName2";
            //lbl2.Text = "<Application Name Here>";
            //lbl2.Height = 20;
            //lbl2.Width = 220;
            //lbl2.Location = new Point(0, 0);
            //lbl2.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
            //lbl2.BackColor = Color.LightCoral;
            //pnl2.Controls.Add(lbl2);

            //Control[] cs = flpApplications.Controls.Find("pnlApp1", true);
            //Control c = cs[0];
            //Panel pnlThis = (Panel)c;
            //button7.Text = pnlThis.Name;

            //getting latest version and link for ccleaner
            //MessageBox.Show("Download Link for CCleaner v" + GetLatestVersionFromLink("http://www.piriform.com/blog/ccleaner", "CCleaner") + "\n" + GetDownloadLink("http://www.piriform.com/ccleaner/download/standard"));


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
            string appName = btn.Tag.ToString().Split(':')[0];
            string fileName = btn.Tag.ToString().Split(':')[1];
            string downLink = btn.Tag.ToString().Substring(appName.Length + fileName.Length + 2);

            if (!sw.IsRunning)
            {
                DownloadFile(downLink, downLoc + fileName, appName);
            }
            else
            {
                webClient.CancelAsync();
            }
        }

        public void DownloadFile(string urlAddress, string location, string appName)
        {
            using (webClient = new WebClient())
            {
                //WebClient webClient = new WebClient();
                webClient.BaseAddress = "//" + appName;
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    //webClient.Headers.Add(HttpRequestHeader.Range, "200");
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            WebClient webClient = (WebClient)sender;
            string appName = webClient.BaseAddress.Replace("file:", "").Replace("/", "");
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

            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));

            btnResumeStop.Text = "Cancel";
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            WebClient webClient = (WebClient)sender;
            string appName = webClient.BaseAddress.Replace("file:", "").Replace("/", "");
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

            cs = pnlThis.Controls.Find("btnInstall" + appName, true);
            c = cs[0];
            Button btnInstall = (Button)c;


            if (e.Cancelled == true)
            {
                labelSpeed.Text = "Cancelled!";

                progressBar.Value = progressBar.Minimum;

                labelPerc.Text = "0%";

                labelDownloaded.Text = "";

                btnResumeStop.Text = "Download";
            }
            else
            {
                labelSpeed.Text = "Completed!";

                progressBar.Value = progressBar.Maximum;

                labelPerc.Text = "100%";

                btnResumeStop.Text = "Download";

                btnResumeStop.Enabled = false;

                btnInstall.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private string GetDownloadLink(string url)
        {
            //If it doesn't please <a href="
            //If it doesn't please <a href="http://download.piriform.com/ccsetup419.exe">click here to start the download</a></p><div id="BigDownload" align="center"><a href="http://download.piriform.com/ccsetup419.exe"><img id="imgBigDownload" src="//s1.pir.fm/pf/v2/download-start-w.png" alt="Start Download" align="middle" style="padding:0 5px" /></a></div></div>

            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = "";
            while (reader.EndOfStream == false)
            {
                string thisLine = reader.ReadLine();
                if (thisLine.Contains("If it doesn't please <a href=\"") && responseFromServer == "")
                {
                    responseFromServer = thisLine;
                }
            }
            string fileVersion = "";
            fileVersion = responseFromServer;
            //fileVersion = fileVersion.Remove(0, fileVersion.LastIndexOf("If it doesn't please <a href=\""));
            fileVersion = fileVersion.Replace("If it doesn't please <a href=\"", "");
            fileVersion = fileVersion.Remove(fileVersion.LastIndexOf("\">click here to start the download</a>"));
            fileVersion = fileVersion.Trim();

            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return fileVersion;
        }

        private string GetLatestVersionFromLink(string url, string appName)
        {
            //http://www.piriform.com/blog/ccleaner
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = "";
            while (reader.EndOfStream == false)
            {
                string thisLine = reader.ReadLine();
                if (thisLine.Contains("Permalink for CCleaner v") && responseFromServer == "")
                {
                    responseFromServer = thisLine;
                }


                //filehippo
                //if (thisLine.Contains("<title>"))
                //{
                //    responseFromServer = thisLine;
                //}
            }
            //<title>Download CCleaner 4.19.4867 - FileHippo.com</title>

            //<a title="Permalink for CCleaner v4.19" href="/blog/2014/10/24/ccleaner-v419" rel="bookmark" abp="205">CCleaner v4.19</a>
            string fileVersion = "";
            fileVersion = responseFromServer;
            fileVersion = fileVersion.Remove(0, fileVersion.LastIndexOf(">CCleaner v"));
            fileVersion = fileVersion.Replace(">CCleaner v", "");
            fileVersion = fileVersion.Remove(fileVersion.LastIndexOf("</a>"));
            fileVersion = fileVersion.Trim();

            //filehippo
            //string fileVersion = "";
            //fileVersion = responseFromServer;
            //fileVersion = fileVersion = fileVersion.Replace("<title>Download", "");
            //fileVersion = fileVersion.Replace("- FileHippo.com</title>", "");
            //fileVersion = fileVersion.Replace(appName, "");
            //fileVersion = fileVersion.Trim();


            //string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return fileVersion;
        }
    }
}
