﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Columbo.Shared.Infrastructure.Sql
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Create();
    }
}
