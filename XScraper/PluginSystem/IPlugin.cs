using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XScraper.PluginSystem
{
    public interface IPlugin
    {
        #region Plugin Information

        string PluginName { get; }
        string PluginAuthor { get; }
        string PluginDescription { get; }
        string PluginVersion { get; }

        #endregion

        #region Plugin Variables
        IPluginHost PluginHost { get; set; }

        /// <summary>
        /// The form that allows for plugin configuration.
        /// If null, then an exception is thrown and handled by XScraper
        /// </summary>
        /// <returns></returns>
        Form GetConfigForm();

        /// <summary>
        /// The form that allows for configuration of the scrape.
        /// If null, Scrape will just be directly called.
        /// Note that the form, at some point, needs to call Scrape().
        /// </summary>
        /// <returns></returns>
        Form GetScrapeForm();
        #endregion

        #region Methods
        /// <summary>
        /// Called when the plugin is loaded by XScraper.
        /// </summary>
        void OnEnable();

        /// <summary>
        /// Called when the plugin is disabled by XScraper
        /// </summary>
        void OnDisable();
        void Scrape(params object[] args);
        #endregion
    }
}
