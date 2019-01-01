using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, Inherited = false)]
    public class SqlScriptAttribute : Attribute
    {
        public string Name { get; private set; }
        
        public SqlScriptAttribute(string name)
        {
            //todo extension check
            Name = name;
        }
    }
}
