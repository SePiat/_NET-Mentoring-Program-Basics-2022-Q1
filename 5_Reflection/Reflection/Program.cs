using System;
using Reflection.Models;
using Reflection.Services;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new ProvidersLoader();
            var factory = new ProvidersFactory(loader);

            var appSettings = new AppConfiguration(factory);
            var file = new FileConfiguration(factory);

            WriteConfig(appSettings);
            ReadConfig(appSettings);
            Console.WriteLine();
            WriteConfig(file);
            ReadConfig(file);

        }

        public static void WriteConfig(ConfigurationComponentBase config)
        {
            config.SomeInt = 777;
            config.SomeTimespan = TimeSpan.FromSeconds(77);
            config.SomeString = "Example of a string";
            config.SomeFloat = 1234;
        }

        public static void ReadConfig(ConfigurationComponentBase config)
        {
            var someString = config.SomeString;
            var someInt = config.SomeInt;
            var someTimespan = config.SomeTimespan;
            var someFloat = config.SomeFloat;

            Console.WriteLine($"{nameof(config.SomeString)}: {someString}");
            Console.WriteLine($"{nameof(config.SomeInt)}: {someInt}");
            Console.WriteLine($"{nameof(config.SomeTimespan)}: {someTimespan}");
            Console.WriteLine($"{nameof(config.SomeFloat)}: {someFloat}");
            Console.ReadLine();
        }
    }
}
