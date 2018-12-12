using Columbo.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.IdentityProvider.Service.Startup
{
    public static class DatabaseConfig
    {
        public static void Initialing(IDatabaseContext context)
        {
            context.Database.EnsureCreated(); // Migrate() to use migration
        }
    }
}