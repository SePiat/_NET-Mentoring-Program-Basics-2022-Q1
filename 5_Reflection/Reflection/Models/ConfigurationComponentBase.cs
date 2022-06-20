using Reflection.Attributes;
using Reflection.Interfaces;
using System;

namespace Reflection.Models
{
    public abstract class ConfigurationComponentBase
    {
        private readonly IProvidersFactory _providersFactory;

        protected ConfigurationComponentBase(IProvidersFactory providersFactory)
        {
            _providersFactory = providersFactory;
        }

        public virtual string SomeString
        {
            get
            {
                var value = LoadSetting(nameof(SomeString));
                return value?.ToString();
            }
            set => SaveSetting(nameof(SomeString), value);
        }

        public virtual TimeSpan? SomeTimespan
        {
            get
            {
                var value = LoadSetting(nameof(SomeTimespan));

                if (value == null) return null;

                if (TimeSpan.TryParse(value.ToString(), out TimeSpan timeSpan))
                {
                    return timeSpan;
                }

                return null;
            }
            set => SaveSetting(nameof(SomeTimespan), value);
        }

        public virtual int? SomeInt
        {
            get
            {
                var value = LoadSetting(nameof(SomeInt));

                if (value == null) return null;

                if (int.TryParse(value.ToString(), out var someInt))
                {
                    return someInt;
                }
                return null;
            }
            set => SaveSetting(nameof(SomeInt), value);
        }

        public virtual float? SomeFloat
        {
            get
            {
                var value = LoadSetting(nameof(SomeFloat));

                if (value == null) return null;

                if (float.TryParse(value.ToString(), out var someFloat))
                {
                    return someFloat;
                }

                return null;
            }
            set => SaveSetting(nameof(SomeFloat), value);
        }

        protected virtual object LoadSetting(string propertyName)
        {
            var attribute = GetAttribute(propertyName);

            if (attribute == null) return null;

            var provider = _providersFactory.GetProvider(attribute.ProviderType);

            return provider?.Read(attribute.SettingName);
        }

        protected virtual void SaveSetting(string propertyName, object value)
        {
            var attribute = GetAttribute(propertyName);

            if (attribute == null) return;

            var provider = _providersFactory.GetProvider(attribute.ProviderType);
            provider?.Write(attribute.SettingName, value);
        }

        private ConfigurationItemAttribute GetAttribute(string propertyName)
        {
            var type = GetType();
            var property = type.GetProperty(propertyName);

            if (property == null) return null;

            var attribute = Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute))
                as ConfigurationItemAttribute;
            return attribute;
        }
    }
}
