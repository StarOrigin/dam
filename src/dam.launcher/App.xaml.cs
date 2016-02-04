using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace org.starorigin.dam.launcher
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            ApplicationThemeHelper.UpdateApplicationThemeName();
            LoadLanguage();
        }
        private void LoadLanguage()
        {
            var currentCultureInfo = CultureInfo.CurrentCulture;
            var uri = new Uri(string.Format("language/{0}.xaml", currentCultureInfo.Name), UriKind.Relative);
            var langRd = LoadComponent(uri) as ResourceDictionary;
            if (langRd == null) return;
            this.Resources.MergedDictionaries.Add(langRd);
        }
    }
}
