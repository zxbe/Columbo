using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AppSettingsSectionAttribute : Attribute
    {
        public string Name { get; private set; }

        public AppSettingsSectionAttribute(string name)
        {
            Name = name;
        }
    }
}
