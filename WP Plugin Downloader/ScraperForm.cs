using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WP_Plugin_Downloader
{
    public partial class ScraperForm : Form
    {
        private XScraperPlugin Plugin { get; set; }

        public ScraperForm(XScraperPlugin plugin)
        {
            InitializeComponent();
            this.Plugin = plugin;
        }

        private void btnScrape_Click(object sender, EventArgs e) {
            rTxtBoxOutput.Text = "";
            Plugin.Scrape(this, txtBoxTag.Text, mTxtBoxStartPage.Text, mTxtBoxStopPage.Text, txtSaveLocation.Text);
        }

        public void OutputText(string text) {
            rTxtBoxOutput.Invoke(new MethodInvoker(() => {
                rTxtBoxOutput.AppendText("[" + DateTime.Now + "] - " + text + "\r\n");
            }));
        }
    }
}
