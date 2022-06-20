using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PluginBase;
using Reflection.Exceptions;
using System;
using System.IO;
namespace Providers
{
    public class FileConfigurationProvider : IConfigurationProvider
    {
        public ProviderType ProviderType { get; } = ProviderType.File;

        public string FilePath { get; set; }

        public object Read(string key)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(FilePath)) return result;

            try
            {
                var json = File.ReadAllText(FilePath);
                dynamic jsonObj = JsonConvert.DeserializeObject<JObject>(json);
                if (jsonObj != null) result = jsonObj[key];
            }
            catch (Exception e)
            {
                throw new FileConfigurationException("Error reading app settings", e);
            }

            return result;
        }

        public void Write(string key, object value)
        {
            if (string.IsNullOrEmpty(FilePath)) return;

            try
            {
                var json = File.ReadAllText(FilePath);
                var jsonObj = JsonConvert.DeserializeObject<JObject>(json);

                if (value == null || key == null || jsonObj == null) return;

                jsonObj[key] = null;
                jsonObj[key] = value.ToString();
                var output = JsonConvert.SerializeObject(jsonObj, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
                File.WriteAllText(FilePath, output);
            }
            catch (Exception e)
            {
                throw new FileConfigurationException("Error writing app settings", e);
            }
        }
    }
}
