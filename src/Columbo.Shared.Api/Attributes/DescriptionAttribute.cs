using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
