using Columbo.Shared.Api.Attributes;
using Columbo.Shared.Api.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Shared.Api.Extensions
{
    public static class ConfigurationExtension
    {
        private static string GetSectionName<T>()
        {
            var type = typeof(T);
            var attributes = type.GetCustomAttributes(typeof(AppSettingsSectionAttribute), false);

            if (attributes.Count() > 0)
                return (attributes.First() as AppSettingsSectionAttribute).Name;
            else
                throw new AttributeNotFoundException("AppSettingsSectionAttribute not found");
        }

        public static T GetSettings<T>(this IConfiguration configuration) where T : class
        {
            var sectionName = GetSectionName<T>();
            return configuration.GetSection(sectionName).Get<T>();
        }
    }
}
