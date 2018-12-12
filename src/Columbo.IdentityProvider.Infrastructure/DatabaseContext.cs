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

namespace Columbo.IdentityProvider.Infrastructure
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IDatabaseInitializer _initializer;

        public DatabaseContext(IDatabaseInitializer initializer)
        {
            _initializer = initializer;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["IdentityProviderDatabase"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        public void InitializeDatabase()
        {
            _initializer.Initialize(this);
            _initializer.Seed(this);
        }
    }
}
