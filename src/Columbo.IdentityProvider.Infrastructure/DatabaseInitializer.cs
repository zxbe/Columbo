using Columbo.Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        public void Initialize(IDatabaseContext context)
        {
            context.Database.EnsureCreated(); // Migrate() to use migration
        }

        public void Seed(IDatabaseContext context)
        {
            //todo seed
        }
    }
}
