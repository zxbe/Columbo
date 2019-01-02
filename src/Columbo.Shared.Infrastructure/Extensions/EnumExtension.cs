using Columbo.Shared.Infrastructure.Sql.Attributes;
using Columbo.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Shared.Infrastructure.Sql;

namespace Columbo.Shared.Infrastructure.Extensions
{
    public static class EnumExtension
    {
        public static SqlScriptInfo GetSqlScriptInfo(this Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(SqlScriptAttribute), false);
            if (attributes.Count() > 0)
            {
                var attribute = attributes.First() as SqlScriptAttribute;
                return new SqlScriptInfo(attribute.FileName, attribute.Name);
            }
            else
                throw new AttributeNotFoundException("DescriptionAttribute not found");
        }

        public static List<SqlScriptInfo> GetSqlScriptInfoList<T>()
        {
            var sqlScriptInfoList = new List<SqlScriptInfo>();
            var type = typeof(T);

            if (!type.IsEnum)
                throw new ArgumentException("The type argument must be an enum.");

            var fields = type.GetFields().Where(x => x.IsPublic && x.IsStatic);

            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes(typeof(SqlScriptAttribute), false);
                if (attributes.Count() > 0)
                {
                    var attribute = attributes.First() as SqlScriptAttribute;
                    sqlScriptInfoList.Add(new SqlScriptInfo(attribute.FileName, attribute.Name));
                }
                else
                    throw new AttributeNotFoundException($"DescriptionAttribute not found for a field {field.Name}");
            }

            return sqlScriptInfoList;
        }
    }
}
