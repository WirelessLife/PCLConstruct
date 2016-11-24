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
        public static AzureSettings GetConfig()
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

            AzureSettings settings = JsonConvert.DeserializeObject<AzureSettings>(jsonText);

            return settings;
            //return (string)settings[settingName];

        }
    }
}
