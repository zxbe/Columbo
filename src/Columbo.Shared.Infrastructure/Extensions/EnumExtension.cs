using Columbo.Shared.Infrastructure.Attributes;
using Columbo.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Shared.Infrastructure.Extensions
{
    public static class EnumExtension
    {
        public static string GetAssignedScriptName(this Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(SqlScriptAttribute), false);
            if (attributes.Count() > 0)
                return (attributes.First() as SqlScriptAttribute).Name;
            else
                throw new AttributeNotFoundException("DescriptionAttribute not found");
        }

        public static List<string> GetAssignedScriptNames<T>()
        {
            var scriptNames = new List<string>();
            var type = typeof(T);

            if (!type.IsEnum)
                throw new ArgumentException("The type argument must be an enum.");

            var fields = type.GetFields().Where(x => x.IsPublic && x.IsStatic);

            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes(typeof(SqlScriptAttribute), false);
                if (attributes.Count() > 0)
                    scriptNames.Add((attributes.First() as SqlScriptAttribute).Name);
                else
                    throw new AttributeNotFoundException($"DescriptionAttribute not found for a field {field.Name}");
            }

            return scriptNames;
        }
    }
}
