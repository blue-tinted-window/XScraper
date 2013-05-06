using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XScraper.PluginSystem
{
    public class PluginListViewControl : ListViewItem {

        public IPlugin Plugin { get; private set; }

        public PluginListViewControl(IPlugin plgn) {
            this.Plugin = plgn;
        }
    }
}
