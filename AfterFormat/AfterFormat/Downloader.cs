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
            downloadPercentage = "0";
            downloadedFromTotal = "";

            isDownloading = false;
            isCancelled = false;
            isFinished = false;

            webClient = new WebClient();
            sw = new Stopwatch();
        }

        WebClient webClient;
        Stopwatch sw;

        string downloadName;
        string downloadLocation;
        string downloadLink;

        string downloadSpeed;
        string downloadPercentage;
        string downloadedFromTotal;

        bool isDownloading;
        bool isCancelled;
        bool isFinished;

        public string DownloadName
        {
            get { return downloadName; }
            set { downloadName = value; }
        }
        public string DownloadLocation
        {
            get { return downloadLocation; }
            set { downloadLocation = value; }
        }
        public string DownloadLink
        {
            get { return downloadLink; }
            set { downloadLink = value; }
        }
        public string DownloadSpeed
        {
            get { return downloadSpeed; }
            set { downloadSpeed = value; }
        }
        public string DownloadPercentage
        {
            get { return downloadPercentage; }
            set { downloadPercentage = value; }
        }
        public string DownloadedFromTotal
        {
            get { return downloadedFromTotal; }
            set { downloadedFromTotal = value; }
        }
        public bool IsDownloading
        {
            get { return isDownloading; }
            set { isDownloading = value; }
        }
        public bool IsCancelled
        {
            get { return isCancelled; }
            set { isCancelled = value; }
        }
        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }

        public void FileDownload()
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                Uri URL = downloadLink.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(downloadLink) : new Uri("http://" + downloadLink);

                sw.Start();

                try
                {
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
            downloadSpeed = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            downloadPercentage = e.ProgressPercentage.ToString();

            downloadedFromTotal = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));

            isCancelled = false;
            isDownloading = true;
            isFinished = false;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();

            if (e.Cancelled == true)
            {
                isCancelled = true;
                isDownloading = false;
                isFinished = false;

                downloadPercentage = "0";
                downloadSpeed = "";
                downloadedFromTotal = "";
            }
            else
            {
                isCancelled = false;
                isDownloading = false;
                isFinished = true;

                downloadPercentage = "100";
                downloadSpeed = "";
            }
        }

        public void CancelDownload()
        {
            if (sw.IsRunning)
            {
                sw.Reset();
                webClient.CancelAsync();
                isCancelled = true;
                isDownloading = false;
                IsFinished = false;
            }
        }

    }
}
