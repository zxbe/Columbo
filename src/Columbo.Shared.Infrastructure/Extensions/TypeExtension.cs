using Columbo.Shared.Infrastructure.Sql.Attributes;
using Columbo.Shared.Infrastructure.Exceptions;
using Columbo.Shared.Infrastructure.Sql.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Shared.Infrastructure.Sql;

namespace Columbo.Shared.Infrastructure.Extensions
{
    public static class TypeExtension
    {
        public static List<SqlScriptInfo> GetSqlScriptInfoList(this IEnumerable<Type> tableValuedTypes)
        {
            var sqlScriptInfoList = new List<SqlScriptInfo>();
            foreach(var tableValuedType in tableValuedTypes)
            {
                var attributes = tableValuedType.GetCustomAttributes(typeof(SqlScriptAttribute), false);
                if (attributes.Count() > 0)
                {
                    var attribute = attributes.First() as SqlScriptAttribute;
                    sqlScriptInfoList.Add(new SqlScriptInfo(attribute.FileName, attribute.Name));
                }
                else
                    throw new AttributeNotFoundException("DescriptionAttribute not found");
            }

            return sqlScriptInfoList;
        }

        public static SqlScriptInfo GetSqlScriptInfo(this Type tableValuedType)
        {
            var attributes = tableValuedType.GetCustomAttributes(typeof(SqlScriptAttribute), false);
            if (attributes.Count() > 0)
            {
                var attribute = attributes.First() as SqlScriptAttribute;
                return new SqlScriptInfo(attribute.FileName, attribute.Name);
            }
            else
                throw new AttributeNotFoundException("DescriptionAttribute not found");
        }
    }
}
