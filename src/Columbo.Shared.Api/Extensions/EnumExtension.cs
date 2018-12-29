using Columbo.Shared.Api.Attributes;
using Columbo.Shared.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Shared.Api.Extensions
{
    public class EnumField
    {
        public int Value { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public EnumField(int value, string name, string description)
        {
            Value = value;
            Name = name;
            Description = description;
        }
    }

    public static class EnumExtension
    {
        public static string GetDescription(this Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Count() > 0)
                return (attributes.First() as DescriptionAttribute).Description;
            else
                throw new AttributeNotFoundException("DescriptionAttribute not found");
        }

        public static List<EnumField> ToList<T>()
        {
            var enumFields = new List<EnumField>();
            var type = typeof(T);

            if (!type.IsEnum)
                throw new ArgumentException("The type argument must be an enum.");

            var fields = type.GetFields().Where(x => x.IsPublic && x.IsStatic);

            foreach (var field in fields)
            {
                var name = field.Name;
                var description = string.Empty;

                var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attribute.Count() > 0)
                    description = (attribute.First() as DescriptionAttribute).Description;

                int value = (int)field.GetValue(null);

                enumFields.Add(new EnumField(value, name, description));
            }

            return enumFields;
        }
    }
}
