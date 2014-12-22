using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AfterFormat
{
    public class ApplicationInfo
    {
        #region Constructor, Variables & Properties

        public ApplicationInfo()
        {
            name = "";
            installedVersion = "0.0";
            latestVersion = "0.0";
            url = "";
            downloadLink = "";
            downloadLocation = "";
            regKeyLocation = "";
            isInstalled = false;
            isDownloaded = false;
        }

        private string name;
        private string installedVersion;
        private string latestVersion;
        private string url;
        private string downloadLink;
        private string downloadLocation;
        private string regKeyLocation;
        private bool isInstalled;
        private bool isDownloaded;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string InstalledVersion
        {
            get { return installedVersion; }
            set { installedVersion = value; }
        }
        public string LatestVersion
        {
            get { return latestVersion; }
            set { latestVersion = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public string DownloadLink
        {
            get { return downloadLink; }
            set { downloadLink = value; }
        }
        public string DownloadLocation
        {
            get { return downloadLocation; }
            set { downloadLocation = value; }
        }
        public string RegKeyLocation
        {
            get { return regKeyLocation; }
            set { regKeyLocation = value; }
        }
        public bool IsInstalled
        {
            get { return isInstalled; }
            set { isInstalled = value; }
        }
        public bool IsDownloaded
        {
            get { return isDownloaded; }
            set { isDownloaded = value; }
        }

        #endregion

        #region Methods

        public void GetInstalledVersionNumber()
        {
            RegistryKey key = Registry.LocalMachine;
            key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);

            foreach (String subKeyName in key.GetSubKeyNames())
            {
                if (key.OpenSubKey(subKeyName) != null)
                {
                    RegistryKey subkey = key.OpenSubKey(subKeyName);
                    if (subkey.GetValue("DisplayName") != null)
                    {
                        string appName = subkey.GetValue("DisplayName").ToString();
                        if (appName.Contains(name))
                        {
                            if (subkey.GetValue("DisplayVersion") != null)
                            {
                                installedVersion = subkey.GetValue("DisplayVersion").ToString();
                            }

                        }
                    }
                }
            }
        }

        public void GetLatestVersionNumber()
        {
            //http://www.downloadx64.com/ccleaner/
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

                //getting version number
                if (thisLine.Contains("softwareVersion"))
                {
                    responseFromServer = thisLine;
                    break;
                }

            }
            //<meta content="CCleaner 5.00.5050" abp="38" itemprop="softwareVersion">
            string fileVersion = "";
            fileVersion = responseFromServer;
            fileVersion = fileVersion.Remove(0, fileVersion.LastIndexOf("content=\"" + Name));
            fileVersion = fileVersion.Replace("content=\"" + Name, "");
            fileVersion = fileVersion.Remove(fileVersion.LastIndexOf("\""));
            fileVersion = fileVersion.Trim();

            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            latestVersion = fileVersion;
        }

        public void GetDownloadLink()
        {
            //http://www.downloadx64.com/ccleaner/
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

                //getting link
                if (thisLine.Contains("href=\"http://") && thisLine.Contains(".exe"))
                {
                    responseFromServer = thisLine;
                    break;
                }
            }
            //<a rel=\"nofollow\" class=\"left\" href=\"http://download.piriform.com/ccsetup500.exe\" title=\"Download CCleaner for Windows 8.1, 8, 7, Vista, XP (64-bit / 32-bit)\">ccsetup500.exe</a>
            string downLink = "";
            downLink = responseFromServer;
            downLink = downLink.Remove(0, downLink.LastIndexOf("href=\""));
            downLink = downLink.Replace("href=\"", "");
            downLink = downLink.Remove(downLink.LastIndexOf("\" title="));
            downLink = downLink.Trim();

            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            downloadLink = downLink;
        }

        public void SilentInstall(string installLocation)
        {
            

        }

        public bool CheckAvailableUpdate()
        {
            //get installed version
            GetInstalledVersionNumber();

            //get latest version
            GetLatestVersionNumber();

            //compare versions
            Version insVer = new Version(installedVersion);
            Version latVer = new Version(latestVersion);
            int verCompare = latVer.CompareTo(insVer);

            if (verCompare > 0)
            {
                return true; //Update Available
            }
            else
            {
                return false; //Update Not Available
            }
        }
        
        public string GetFileName()
        {
            return downloadLink.Substring(downloadLink.LastIndexOf('/') + 1);
        }

        #endregion
    }
}
