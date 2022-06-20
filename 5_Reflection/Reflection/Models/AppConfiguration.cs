using PluginBase;
using Reflection.Attributes;
using Reflection.Interfaces;
using System;

namespace Reflection.Models
{
    public class AppConfiguration : ConfigurationComponentBase
    {
        public AppConfiguration(IProvidersFactory providersFactory) : base(providersFactory)
        {
        }

        [ConfigurationItem(ProviderType.ConfigurationManager, "SomeString")]
        public override string SomeString
        {
            get => base.SomeString;
            set => base.SomeString = value;
        }

        [ConfigurationItem(ProviderType.ConfigurationManager, "SomeTimespan")]
        public override TimeSpan? SomeTimespan
        {
            get => base.SomeTimespan;
            set => base.SomeTimespan = value;
        }

        [ConfigurationItem(ProviderType.ConfigurationManager, "SomeInt")]
        public override int? SomeInt
        {
            get => base.SomeInt;
            set => base.SomeInt = value;
        }

        [ConfigurationItem(ProviderType.ConfigurationManager, "SomeFloat")]
        public override float? SomeFloat
        {
            get => base.SomeFloat;
            set => base.SomeFloat = value;
        }
    }
}
