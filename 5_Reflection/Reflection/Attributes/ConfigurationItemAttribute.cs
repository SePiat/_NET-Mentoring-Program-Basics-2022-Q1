using PluginBase;
using System;

namespace Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; set; }
        public ProviderType ProviderType { get; set; }

        public ConfigurationItemAttribute(ProviderType providerType, string settingName)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }
    }
}
