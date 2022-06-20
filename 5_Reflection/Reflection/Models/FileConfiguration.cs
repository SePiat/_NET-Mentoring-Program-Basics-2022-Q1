using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginBase;
using Reflection.Attributes;
using Reflection.Interfaces;

namespace Reflection.Models
{
    public class FileConfiguration : ConfigurationComponentBase
    {
        public FileConfiguration(IProvidersFactory providersFactory) : base(providersFactory)
        {

        }

        [ConfigurationItem(ProviderType.File, "SomeString")]
        public override string SomeString
        {
            get => base.SomeString;
            set => base.SomeString = value;
        }

        [ConfigurationItem(ProviderType.File, "SomeTimespan")]
        public override TimeSpan? SomeTimespan
        {
            get => base.SomeTimespan;
            set => base.SomeTimespan = value;
        }

        [ConfigurationItem(ProviderType.File, "SomeInt")]
        public override int? SomeInt
        {
            get => base.SomeInt;
            set => base.SomeInt = value;
        }

        [ConfigurationItem(ProviderType.File, "SomeFloat")]
        public override float? SomeFloat
        {
            get => base.SomeFloat;
            set => base.SomeFloat = value;
        }
    }
}
