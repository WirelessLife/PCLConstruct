using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Xamarin.Forms;
using PCLConstruct.Client.Security;

namespace PCLConstruct.Client.Helpers
{
    public static class SettingsHelper
    {
        private static AzureSettings _settings;

        public static AzureSettings GetConfig()
        {
            if (_settings == null)
            {
                var assembly = typeof(SettingsHelper).GetTypeInfo().Assembly;

                var StreamResourceName = "PCLConstruct.Client.settings.json";
                Stream stream = assembly.GetManifestResourceStream(StreamResourceName);
                var t = assembly.GetManifestResourceNames();
                string jsonText = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                }

                _settings = JsonConvert.DeserializeObject<AzureSettings>(jsonText);
            }
            
            return _settings;
            //return (string)settings[settingName];

        }
    }
}
