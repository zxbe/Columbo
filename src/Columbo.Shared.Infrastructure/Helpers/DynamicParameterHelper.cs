using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Columbo.Shared.Infrastructure.Helpers
{
    public static class DynamicParameterHelper
    {
        public static DynamicParameters AsParameter<T>(T value, string parameterName, DbType? type = null)
        {
            var parameter = new DynamicParameters();
            parameter.Add(parameterName, value, type, ParameterDirection.Input);

            return parameter;
        }
    }
}
