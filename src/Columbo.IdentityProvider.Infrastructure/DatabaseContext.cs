using Columbo.Shared.Infrastructure;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Columbo.IdentityProvider.Infrastructure
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("IdentityProviderDatabase"));
        }

        public void InitializeDatabase(IDatabaseInitializer databaseInitializer, bool seed)
        {
            databaseInitializer.InitializeDatabase(this);

            if (seed)
                databaseInitializer.Seed(this);
        }
    }
}
