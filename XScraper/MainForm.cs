using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XScraper.PluginSystem;
using XScraper.PluginSystem.Impl;

namespace XScraper
{
    public partial class MainForm : Form
    {
        private PluginHostImpl PluginLoader { get; set; }

        public MainForm() {
            InitializeComponent();
            PluginLoader = new PluginHostImpl(this);
        }
        /// <summary>
        /// Commences loading of all of the scraper plugins
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e) {
            PluginLoader.LoadPlugins();
        }

        private void btnScrape_Click(object sender, EventArgs e)
        {
            try {
                PluginLoader.Scrape((string)cBoxPlugin.SelectedItem);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "[Error]");
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try {
                PluginLoader.Configure((string)cBoxPlugin.SelectedItem);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "[Error]");
            }
        }
    }
}
