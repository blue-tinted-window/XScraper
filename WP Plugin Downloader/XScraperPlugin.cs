using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;

using XScraper.PluginSystem;
using HtmlAgilityPack;

namespace WP_Plugin_Downloader
{
    public class XScraperPlugin : IPlugin
    {
        public delegate void OnThreadCompletedDel();
        public delegate void OnThreadStartDel();

        public string PluginName { 
            get {
                return "Wordpress Plugin Downloader";
            }
        }

        public string PluginAuthor {
            get {
                return "shoeb0x";
            }
        }

        public string PluginDescription {
            get {
                return "Mass-Downloads Wordpress plugins. Useful for things "
                    + "like going on plugin auditing sprees.";
            }
        }

        public string PluginVersion {
            get {
                return "1.0.0";
            }
        }

        public IPluginHost PluginHost { get; set; }
        
        public Form GetConfigForm() {
            return null;
        }

        public Form GetScrapeForm() {
            return new ScraperForm(this);
        }

        public void OnEnable() {

        }

        public void OnDisable() {

        }

        public event OnThreadCompletedDel OnThreadCompleted;
        public event OnThreadStartDel OnThreadStart;

        public void Scrape(params object[] args) {
            ScraperForm form = args[0] as ScraperForm;
            string tag = args[1] as string;
            uint startPage = Convert.ToUInt32(args[2]);
            uint stopPage = Convert.ToUInt32(args[3]);
            string saveLocation = args[4] as string;
            if (String.IsNullOrEmpty(saveLocation) || String.IsNullOrWhiteSpace(saveLocation)) {
                saveLocation = Directory.GetCurrentDirectory() + "/wp_dump/";
            }

            for (uint ctr = startPage; ctr < stopPage; ctr++) {
                int workerThreads;
                int portThreads;
                ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                while (workerThreads == 0) { } 
                /* I guess we block until we have some thread available
                 * I'm bad at threading, so if anyone can fix this so that it works in a 
                 * more elegant way, I would love them.*/
                FindDownloadPages(form, tag, ctr, saveLocation);
            }
        }

        private void FindDownloadPages(ScraperForm form, string tag, uint page, string dir)
        {
            string page_url = "http://wordpress.org/extend/plugins/tags/" + tag + "/page/" + Convert.ToString(page + 1) + "/";

            List<String> nodelist = new List<String>();
            ThreadPool.QueueUserWorkItem(new WaitCallback((object pass) => {
                try {
                        using (WebClient client = new WebClient()) {
                        WriteLine(form, "Downloading plugin pages from " + page_url);
                        client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1468.0 Safari/537.36";
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(client.DownloadString(page_url));
                        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='plugin-block']/h3[1]/a[1]")) {
                            nodelist.Add(node.Attributes["href"].Value);
                            WriteLine(form, "Found " + node.Attributes["href"].Value + " in page " + page);
                        }
                        foreach (string link in nodelist) {
                            form.Invoke(new MethodInvoker(() => { //start new thread from parent UI thread
                                ScrapeDownloadLocation(form, link, dir);
                            }));
                        }
                    }
                } catch (Exception) {
                    MessageBox.Show("An error occured in scraping.", "[Error]");
                }
            }));
        }

        private void ScrapeDownloadLocation(ScraperForm form, string url, string dir) {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object method0val) => {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                using (WebClient client = new WebClient()) {
                    client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1468.0 Safari/537.36";
                    doc.LoadHtml(client.DownloadString(url));
                    if (!(Directory.Exists(Directory.GetCurrentDirectory() + "/downloads/"))) {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/downloads/");
                    }
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//p[@class='button']/a[@itemprop='downloadUrl']")) {
                        string link = node.Attributes["href"].Value;
                        try {
                            client.DownloadFile(link, dir);
                            WriteLine(form, "Successfully downloaded " + link + "!");
                        } catch (Exception) {
                            WriteLine(form, "Failed to download " + link);
                        }
                    }
                }
            }));
        }


        private void WriteLine(ScraperForm form, string text) {
            form.OutputText(text);
        }

        private void OnThreadStartEvent() {
            if (OnThreadStart != null)
                OnThreadStart();
        }

        private void OnThreadCompletedEvent() {
            if (OnThreadCompleted != null)
                OnThreadCompleted();
        }
    }
}
