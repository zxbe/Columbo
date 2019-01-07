using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Columbo.Shared.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, Inherited = false)]
    public class SqlScriptAttribute : Attribute
    {
        public string Name { get; private set; }
        public string FileName { get; private set; }
        
        public SqlScriptAttribute(string fileName)
        {
            if (Path.GetExtension(fileName) == string.Empty || Path.GetExtension(fileName) != ".sql")
                throw new ArgumentException("The file name must have a sql extension.");

            FileName = fileName;
            Name = fileName.Replace(Path.GetExtension(fileName), string.Empty);
        }

        public SqlScriptAttribute(string fileName, string name)
        {
            if (Path.GetExtension(fileName) == string.Empty || Path.GetExtension(fileName) != ".sql")
                throw new ArgumentException("The file name must have a sql extension.");

            FileName = fileName;
            Name = name;
        }
    }
}
