using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Interfaces
{
    public interface IProvidersFactory
    {
        IConfigurationProvider GetProvider(ProviderType providerType);
    }
}
