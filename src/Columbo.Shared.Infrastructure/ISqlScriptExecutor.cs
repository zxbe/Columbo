using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Columbo.Shared.Infrastructure
{
    public interface ISqlScriptExecutor
    {
        void Execute(string sql);
        void Execute(string sql, SqlConnection connection);
    }
}
