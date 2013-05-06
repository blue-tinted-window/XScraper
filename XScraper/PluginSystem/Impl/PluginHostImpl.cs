using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;

namespace XScraper.PluginSystem.Impl
{
    public class PluginHostImpl : IPluginHost {
        private List<PluginInformation> loadedPlugins = new List<PluginInformation>();

        private MainForm MForm { get; set; }

        public PluginHostImpl(MainForm form) {
            MForm = form;
        }

        public void LoadPlugins() {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object obj) => {
                string directory = GetPluginsDirectory();
                if (!Directory.Exists(directory)) {
                    Directory.CreateDirectory(directory);
                }
                string[] pluginNames = Directory.GetFiles(directory, "*.dll");
                foreach (string pName in pluginNames) {
                    try {
                        Assembly pluginAssembly = Assembly.LoadFrom(@pName);
                        if (pluginAssembly == null) { continue; }
                        foreach (Type t in pluginAssembly.GetTypes()) {
                            /*make sure that every plugin class gets loaded
                             * to allow for multiple plugins in the same DLL */
                            if (t.GetInterfaces().Contains(typeof(IPlugin))) {
                                IPlugin plugin = (IPlugin)Activator.CreateInstance(t);
                                plugin.PluginHost = this;
                                AddPlugin(plugin);
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }));
        }

        public void Scrape(string pluginName) {
            IPlugin plugin = GetPluginByName(pluginName);
            if (plugin == null) {
                throw new ArgumentNullException("That plugin doesn't exist!");
            }
            if (plugin.GetScrapeForm() == null) {
                plugin.Scrape();
            } else {
                plugin.GetScrapeForm().ShowDialog();
            }
        }

        public void Configure(string pluginName) {
            IPlugin plugin = GetPluginByName(pluginName);
            if (plugin == null) {
                throw new ArgumentNullException("That plugin doesn't exist!");
            }
            if (plugin.GetConfigForm() == null) {
                throw new Exception("The plugin does not support configuration.");
            } else {
                plugin.GetConfigForm().ShowDialog();
            }
        }

        public void AddPlugin(IPlugin plugin) {
            loadedPlugins.Add(new PluginInformation(plugin));
            MForm.cBoxPlugin.Invoke(new MethodInvoker(() =>
            {
                MForm.cBoxPlugin.Items.Add(plugin.PluginName);
            }));
            plugin.OnEnable();
        }

        public void DisablePlugin(IPlugin plugin) {
            plugin.OnDisable();
        }

        public void DisablePluginByName(string name) {
            IPlugin plug = GetPluginByName(name);
            if (plug != null) {
                plug.OnDisable();
            }
        }

        public string GetPluginsDirectory() {
            return Directory.GetCurrentDirectory() + "/plugins/";
        }

        public PluginConfiguration GetPluginConfig(IPlugin plugin) {
            return GetPluginInfoByName(plugin.PluginName).PluginConfig;
        }

        public PluginConfiguration GetPluginConfigByPluginName(string name) {
            return GetPluginInfoByName(name).PluginConfig;
        }

        public List<PluginInformation> GetLoadedPlugins() {
            return loadedPlugins;
        }

        public PluginInformation GetPluginInfoByName(string name) {
            foreach (PluginInformation pinfo in loadedPlugins) {
                if (pinfo.Plugin.PluginName.ToLower().Equals(name)) {
                    return pinfo;
                }
            }
            return null;
        }

        public IPlugin GetPluginByName(string name) {
            foreach (PluginInformation plugin in loadedPlugins) {
                if (plugin.Plugin.PluginName.ToLower().Equals(name.ToLower())) {
                    return plugin.Plugin;
                }
            }
            return null;
        }
    }
}
