using Columbo.Shared.Infrastructure.Attributes;
using Columbo.Shared.Infrastructure.Exceptions;
using Columbo.Shared.Infrastructure.Sql.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Shared.Infrastructure.Extensions
{
    public static class TypeExtension
    {
        public static string GetAssignedScriptName(this Type tableValuedType)
        {
            var attributes = tableValuedType.GetCustomAttributes(typeof(SqlScriptAttribute), false);
            if (attributes.Count() > 0)
                return (attributes.First() as SqlScriptAttribute).Name;
            else
                throw new AttributeNotFoundException("DescriptionAttribute not found");
        }
    }
}
