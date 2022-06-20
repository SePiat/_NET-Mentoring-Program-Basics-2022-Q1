using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginBase;
using Reflection.Interfaces;

namespace Reflection.Services
{
    public class ProvidersFactory : IProvidersFactory
    {
        private readonly IProvidersLoader _providersLoader;

        public ProvidersFactory(IProvidersLoader providersLoader)
        {
            _providersLoader = providersLoader;
        }

        public IConfigurationProvider GetProvider(ProviderType providerType)
        {
            var providers = _providersLoader.LoadProviders(@"c:\Work\NETMentoringSV\netmentoringsv\5_Reflection\Reflection\Plugins\Providers.dll");
            var provider = providers.FirstOrDefault(x => x.ProviderType == providerType);

            if (provider == null) return null;

            provider.FilePath = providerType switch
            {
                ProviderType.ConfigurationManager =>
                    @"c:\Work\NETMentoringSV\netmentoringsv\5_Reflection\Reflection\appsettings.xml",
                ProviderType.File => @"c:\Work\NETMentoringSV\netmentoringsv\5_Reflection\Reflection\appsettings.json",
                _ => provider.FilePath
            };

            return provider;
        }
    }
}
