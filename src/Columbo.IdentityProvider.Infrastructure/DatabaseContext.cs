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
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;
using Columbo.Shared.Infrastructure.Sql.Types;
using Columbo.Shared.Infrastructure.Extensions;
using System.IO;
using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

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
            if (databaseInitializer == null)
                throw new Exception(); //todo exception

            databaseInitializer.InitializeDatabase(this);

            var connection = Database.GetDbConnection() as SqlConnection;
            if (connection != null)
            {
                ServerConnection serverConnection = new ServerConnection(connection);
                Server server = new Server(serverConnection);

                CreateTypes(server);
                CreateStoredProcedures(server);
            }
            else
                throw new Exception(); //todo exception

            if (seed)
                databaseInitializer.Seed(this);
        }

        private void CreateStoredProcedures(Server server)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var scriptNames = EnumExtension.GetAssignedScriptNames<StoredProcedureEnum>()
                .Select(x => assembly.GetManifestResourceNames().First(y => y.EndsWith(x)));

            foreach (var scriptName in scriptNames)
            {
                using (var scriptStream = new StreamReader(assembly.GetManifestResourceStream(scriptName)))
                {
                    server.ConnectionContext.ExecuteNonQuery(scriptStream.ReadToEnd());
                }
            }
        }

        //private void CreateSqlTypes()
        //{
        //    string sql = "test";

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id", typeof(int));
        //    dt.Rows.Add(1);
        //    dt.Rows.Add(2);
        //    dt.Rows.Add(3);

        //    using (var connection = Database.GetDbConnection())//new SqlConnection(_configuration.GetConnectionString("IdentityProviderDatabase")))
        //    {
        //        var param = new DynamicParameters();
        //        param.Add("@idList", dt.AsTableValuedParameter("IdList"));

        //        var test = connection.Query<int>(sql, param, commandType: CommandType.StoredProcedure);
        //    }
        //}

        private void CreateTypes(Server server)
        {
            var sqlTypesAssembly = Assembly.GetAssembly(typeof(ITableValuedType<>));
            var sqlTypes = sqlTypesAssembly.GetTypes().Where(x => x.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ITableValuedType)) && x.IsClass);

            foreach (var type in sqlTypes)
            {
                var scriptName = sqlTypesAssembly.GetManifestResourceNames().First(x => x.EndsWith(type.GetAssignedScriptName()));
                using (var scriptStream = new StreamReader(sqlTypesAssembly.GetManifestResourceStream(scriptName)))
                {
                    server.ConnectionContext.ExecuteNonQuery(scriptStream.ReadToEnd());
                }
            }
        }
    }
}
