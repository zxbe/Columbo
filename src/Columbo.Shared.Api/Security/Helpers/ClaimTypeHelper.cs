using Columbo.Shared.Api.Security.Attributes;
using Columbo.Shared.Api.Security.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Columbo.Shared.Api.Security.Helpers
{
    public static class ClaimTypeHelper
    {
        private static IList<Claim> GetClaimsFromProperty<T>(PropertyInfo propertyInfo, T valueSource)
        {
            var claims = new List<Claim>();
            var attribute = (ClaimTypeAttribute)propertyInfo.GetCustomAttribute(typeof(ClaimTypeAttribute));

            if (propertyInfo.PropertyType.IsGenericType && typeof(ICollection<>).IsAssignableFrom(propertyInfo.PropertyType.GetGenericTypeDefinition()))
            {
                var collection = (ICollection)propertyInfo.GetValue(valueSource);
                foreach (var @enum in collection)
                {
                    claims.Add(new Claim(attribute.ClaimType, ((int)@enum).ToString()));
                }
            }
            else
            {
                var value = propertyInfo.GetValue(valueSource)?.ToString();

                if (value == null)
                    return claims;

                if (propertyInfo.PropertyType.IsEnum)
                {
                    var enumField = propertyInfo.PropertyType.GetField(value);
                    var intValue = (int)enumField.GetValue(null);
                    value = intValue.ToString();
                }

                claims.Add(new Claim(attribute.ClaimType, value));
            }

            return claims;
        }

        private static IDictionary<ClaimTypeTargetEnum, List<PropertyInfo>> GroupPropertiesByTarget(IEnumerable<PropertyInfo> propertyInfos)
        {
            var groupedProperties = new Dictionary<ClaimTypeTargetEnum, List<PropertyInfo>>();

            var groups = propertyInfos.GroupBy(x =>
            {
                var attribute = (ClaimTypeAttribute)x.GetCustomAttribute(typeof(ClaimTypeAttribute));
                return attribute.Target;
            });

            foreach (var group in groups)
            {
                groupedProperties.Add(group.Key, group.ToList());
            }

            return groupedProperties;
        }

        public static IEnumerable<Claim> GetClaimsFromObject<T>(T @object)
        {
            var claims = new List<Claim>();

            if (@object == null)
                return claims;

            var propertyInfos = @object.GetType().GetProperties();

            var propertiesWithClaimTypeAttribute = propertyInfos.Where(x => x.GetCustomAttributes(typeof(ClaimTypeAttribute), false).Any());
            var groupedProperties = GroupPropertiesByTarget(propertiesWithClaimTypeAttribute);

            if (groupedProperties.ContainsKey(ClaimTypeTargetEnum.BuiltIn))
            {
                groupedProperties[ClaimTypeTargetEnum.BuiltIn].ForEach(x =>
                {
                    claims.AddRange(GetClaimsFromProperty(x, @object));
                });
            }

            if (groupedProperties.ContainsKey(ClaimTypeTargetEnum.Collection))
            {
                groupedProperties[ClaimTypeTargetEnum.Collection].ForEach(x =>
                {
                    var collection = (ICollection)x.GetValue(@object);

                    foreach (var sourceObject in collection)
                    {
                        claims.AddRange(GetClaimsFromObject(sourceObject));
                    }
                });
            }

            if (groupedProperties.ContainsKey(ClaimTypeTargetEnum.Complex))
            {
                groupedProperties[ClaimTypeTargetEnum.Complex].ForEach(x =>
                {
                    var sourceObject = x.GetValue(@object);
                    claims.AddRange(GetClaimsFromObject(sourceObject));
                });
            }

            if (groupedProperties.ContainsKey(ClaimTypeTargetEnum.EnumCollection))
            {
                groupedProperties[ClaimTypeTargetEnum.EnumCollection].ForEach(x =>
                {
                    claims.AddRange(GetClaimsFromProperty(x, @object));
                });
            }

            return claims;
        }
    }
}
