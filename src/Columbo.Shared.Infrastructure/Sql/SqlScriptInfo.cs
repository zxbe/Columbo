using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure.Sql
{
    public class SqlScriptInfo
    {
        public string FileName { get; private set; }
        public string Name { get; private set; }

        public SqlScriptInfo(string fileName, string name)
        {
            FileName = fileName;
            Name = name;
        }
    }
}
