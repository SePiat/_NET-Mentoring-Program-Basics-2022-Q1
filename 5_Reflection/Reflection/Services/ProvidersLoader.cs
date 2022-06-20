using PluginBase;
using Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Reflection.Exceptions;

namespace Reflection.Services
{
    public class ProvidersLoader : IProvidersLoader
    {
        public IEnumerable<IConfigurationProvider> LoadProviders(string pluginPath)
        {
            var providers = new List<IConfigurationProvider>();

            try
            {
                var assembly = Assembly.LoadFrom(pluginPath);
                var types = assembly.GetTypes().Where(x => typeof(IConfigurationProvider).IsAssignableFrom(x));
                
                foreach (var type in types)
                {
                    var provider = Activator.CreateInstance(type) as IConfigurationProvider;
                    providers.Add(provider);
                }
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                {
                    Console.WriteLine("The plugin was not found");
                }
                else
                {
                    throw new LoadProviderException("Error in LoadProviders", e);
                }
            }

            return providers;
        }
    }
}
