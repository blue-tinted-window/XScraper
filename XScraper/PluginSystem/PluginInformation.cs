using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XScraper.PluginSystem
{
    public class PluginInformation
    {
        public PluginConfiguration PluginConfig { get; private set; }
        public IPlugin Plugin { get; private set; }
        public bool PluginEnabled { get; set; }

        public PluginInformation(IPlugin plugin) {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/pcfg/")) {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/pcfg/");
            }
            PluginConfig = new PluginConfiguration(plugin, Directory.GetCurrentDirectory() + "/pcfg/" + (plugin.PluginName.Replace(' ', '_') + "_v" + plugin.PluginVersion.Replace(' ', '_')));
            Plugin = plugin;
            PluginEnabled = true;
        }
    }
}
