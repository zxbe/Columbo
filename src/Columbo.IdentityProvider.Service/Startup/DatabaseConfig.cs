﻿using Columbo.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.IdentityProvider.Service.Startup
{
    public static class DatabaseConfig
    {
        public static void Initialize(IDatabaseContext context)
        {
            context.InitializeDatabase();
        }
    }
}