using Reflection.Exceptions;
using System;
using System.Xml;
using PluginBase;

namespace Providers
{
    public class ConfigurationManagerConfigurationProvider : IConfigurationProvider
    {
        public ProviderType ProviderType { get; } = ProviderType.ConfigurationManager;

        public string FilePath { get; set; }

        public object Read(string key)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(FilePath)) return result;

            try
            {
                var doc = new XmlDocument();
                doc.Load(FilePath);
                var root = doc.DocumentElement;
                var node = root.SelectSingleNode(key);
                result = node.InnerText;
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
                var doc = new XmlDocument();
                doc.Load(FilePath);
                var root = doc.DocumentElement;

                if (value == null || key == null || root == null) return;

                var node = root.SelectSingleNode(key);

                if (node == null)
                {
                    node = doc.CreateElement(key);
                    root.AppendChild(node);
                }

                node.InnerText = null;
                node.InnerText = value.ToString() ?? string.Empty;
                doc.Save(FilePath);

            }
            catch (Exception e)
            {
                throw new FileConfigurationException("Error writing app settings", e);
            }

        }
    }
}
