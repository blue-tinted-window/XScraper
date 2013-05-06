using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XScraper.PluginSystem
{
    /// <summary>
    /// An interface that describes a plugin loader for XScraper
    /// </summary>
    public interface IPluginHost {
        void LoadPlugins();
        void AddPlugin(IPlugin plugin);
        void DisablePlugin(IPlugin plugin);
        void DisablePluginByName(string name);
        string GetPluginsDirectory();
        PluginConfiguration GetPluginConfig(IPlugin plugin);
        PluginConfiguration GetPluginConfigByPluginName(string name);
        List<PluginInformation> GetLoadedPlugins();
        PluginInformation GetPluginInfoByName(string name);
        IPlugin GetPluginByName(string name);
    }
}
