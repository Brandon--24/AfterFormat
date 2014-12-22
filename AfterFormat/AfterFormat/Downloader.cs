using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AfterFormat
{
    public class Downloader
    {
        public Downloader(string _appName, string _downLink, string _downLoc)
        {
            downloadName = _appName;
            downloadLink = _downLink;
            downloadLocation = _downLoc;

            downloadSpeed = "";
            downloadPercentage = "";
            downloadedFromTotal = "";

            isDownloading = false;
            isCancelled = false;
            isFinished = false;

            webClient = new WebClient();
            sw = new Stopwatch(); 
        }

        WebClient webClient;                // Our WebClient that will be doing the downloading for us
        Stopwatch sw;                       // The stopwatch which we will be using to calculate the download speed

        string downloadName;

        string downloadLocation;
        string downloadLink;
        string downloadSpeed;
        string downloadPercentage;
        string downloadedFromTotal;
        

        bool isDownloading;
        bool isCancelled;
        bool isFinished;

        public void FileDownload()
        {
            //using (webClient = new WebClient())
            {
                //WebClient webClient = new WebClient();
                //webClient.BaseAddress = "//" + appName;
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = downloadLink.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(downloadLink) : new Uri("http://" + downloadLink);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    //webClient.Headers.Add(HttpRequestHeader.Range, "200");
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, downloadLocation);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //WebClient webClient = (WebClient)sender;
            //string appName = webClient.BaseAddress.Replace("file:", "").Replace("/", "");
            //MessageBox.Show(sender.ToString());
            // Calculate download speed and output it to labelSpeed.
            //Control[] cs = flpApplications.Controls.Find("pnl" + appName, true);
            //Control c = cs[0];
            //Panel pnlThis = (Panel)c;
            //cs = pnlThis.Controls.Find("labelSpeed" + appName, true);
            //c = cs[0];
            //Label labelSpeed = (Label)c;

            //cs = pnlThis.Controls.Find("progressBar" + appName, true);
            //c = cs[0];
            //ProgressBar progressBar = (ProgressBar)c;

            //cs = pnlThis.Controls.Find("labelPerc" + appName, true);
            //c = cs[0];
            //Label labelPerc = (Label)c;

            //cs = pnlThis.Controls.Find("labelDownloaded" + appName, true);
            //c = cs[0];
            //Label labelDownloaded = (Label)c;

            //cs = pnlThis.Controls.Find("btnResumeStop" + appName, true);
            //c = cs[0];
            //Button btnResumeStop = (Button)c;

            downloadSpeed = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            //progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            downloadPercentage = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            downloadedFromTotal = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));

            isCancelled = false;
            isDownloading = true;
            isFinished = false;

            //btnResumeStop.Text = "Cancel";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            //WebClient webClient = (WebClient)sender;
            //string appName = webClient.BaseAddress.Replace("file:", "").Replace("/", "");
            //MessageBox.Show(sender.ToString());
            // Calculate download speed and output it to labelSpeed.
            //Control[] cs = flpApplications.Controls.Find("pnl" + appName, true);
            //Control c = cs[0];
            //Panel pnlThis = (Panel)c;
            //cs = pnlThis.Controls.Find("labelSpeed" + appName, true);
            //c = cs[0];
            //Label labelSpeed = (Label)c;

            //cs = pnlThis.Controls.Find("progressBar" + appName, true);
            //c = cs[0];
            //ProgressBar progressBar = (ProgressBar)c;

            //cs = pnlThis.Controls.Find("labelPerc" + appName, true);
            //c = cs[0];
            //Label labelPerc = (Label)c;

            //cs = pnlThis.Controls.Find("labelDownloaded" + appName, true);
            //c = cs[0];
            //Label labelDownloaded = (Label)c;

            //cs = pnlThis.Controls.Find("btnResumeStop" + appName, true);
            //c = cs[0];
            //Button btnResumeStop = (Button)c;

            //cs = pnlThis.Controls.Find("btnInstall" + appName, true);
            //c = cs[0];
            //Button btnInstall = (Button)c;


            if (e.Cancelled == true)
            {
                isCancelled = true;
                isDownloading = false;
                isFinished = false;
                
                downloadPercentage = "0%";
                downloadSpeed = "";
                downloadedFromTotal = "";
                
                //labelSpeed.Text = "Cancelled!";

                //progressBar.Value = progressBar.Minimum;

                //labelPerc.Text = "0%";

                //labelDownloaded.Text = "";

                //btnResumeStop.Text = "Download";
            }
            else
            {
                isCancelled = false;
                isDownloading = false;
                isFinished = true;
                
                downloadPercentage = "100%";
                downloadSpeed = "";
                
                //labelSpeed.Text = "Completed!";

                //progressBar.Value = progressBar.Maximum;

                //labelPerc.Text = "100%";

                //btnResumeStop.Text = "Download";

                //btnResumeStop.Enabled = false;

                //btnInstall.Visible = true;
            }
        }



    }
}
