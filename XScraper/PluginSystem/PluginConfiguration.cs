using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace XScraper.PluginSystem
{
    public class PluginConfiguration
    {
        /// <summary>
        /// The delegate that is used for the OnSetDefaults event
        /// </summary>
        public delegate void SetDefaultsDel(Dictionary<string, string> cfg);

        /// <summary>
        /// The Dictionary that stores the data from the plugin.pcfg
        /// file created for the plugin
        /// </summary>
        private Dictionary<string, string> ConfigValues { get; set; }

        private IPlugin Plugin { get; set; }

        private string FileName { get; set; }

        public PluginConfiguration(IPlugin plugin, string cfile) {
            ConfigValues = new Dictionary<string, string>();
            FileName = cfile + ".pcfg";
            if (!File.Exists(FileName)) {
                File.Create(FileName);
            }
            this.Plugin = plugin;
            ParseFileIntoConfig();
        }
        
        /// <summary>
        /// Sets a value in ConfigValues, then saves the file
        /// </summary>
        public void SetValue(string key, string value) {
            ConfigValues[key] = value;
            SaveConfig();
        }

        /// <summary>
        /// Gets a value from the ConfigValues
        /// </summary>
        public string GetValue(string key) {
            return ConfigValues[key];
        }

        public event SetDefaultsDel OnSetDefaults;

        /// <summary>
        /// Serializes the .pcfg file into a Dictionary
        /// </summary>
        private void ParseFileIntoConfig() {
            if (File.Exists(FileName)) {
                SetDefaults(ConfigValues);
                try {
                    using (StreamReader rdr = new StreamReader(FileName)) {
                        String s;
                        while ((s = rdr.ReadLine()) != null) {
                            string[] pair = s.Split(new string[] { "|*|" }, StringSplitOptions.None);
                            if (pair.Length < 2) {
                                continue;
                            }
                            ConfigValues[pair[0]] = pair[1];
                        }
                        rdr.Close();
                    }
                } catch (Exception) {}
            } else {
                try {
                    File.Create(FileName);
                } catch (Exception) { }
                SetDefaults(ConfigValues);
                SaveConfig();
            }
        }

        private void SetDefaults(Dictionary<string, string> cfg) {
            if (OnSetDefaults != null) {
                OnSetDefaults(cfg);
            }
        }

        private void SaveConfig() {
            try {
                if (File.Exists(FileName)) {
                    File.Delete(FileName);
                }
                using (StreamWriter writer = new StreamWriter(FileName)) {
                    foreach (KeyValuePair<string, string> value in ConfigValues) {
                        writer.WriteLine(value.Key + "|*|" + value.Value);
                    }
                    writer.Close();
                }

            } catch (Exception) {
            }
        }
    }
}
