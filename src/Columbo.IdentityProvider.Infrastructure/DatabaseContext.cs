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
using Columbo.IdentityProvider.Infrastructure.Sql.StoredProcedures;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Columbo.Shared.Infrastructure.Sql;

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

        public void InitializeDatabase(IDatabaseSeeder databaseSeeder, bool seed)
        {
            Database.EnsureCreated(); // Migrate() to use migration

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
                databaseSeeder.Seed(this);
        }

        private void CreateStoredProcedures(Server server)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sqlScriptInfoList = EnumExtension.GetSqlScriptInfoList<StoredProcedureEnum>();
            
            foreach (var sqlScriptInfo in sqlScriptInfoList)
            {                
                if (!SqlHelper.CheckIfStoredProcedureExists(Database.GetDbConnection(), sqlScriptInfo.Name))
                {
                    var scriptResorceName = assembly.GetManifestResourceNames().First(y => y.EndsWith(sqlScriptInfo.FileName));
                    using (var scriptStream = new StreamReader(assembly.GetManifestResourceStream(scriptResorceName)))
                    {
                        server.ConnectionContext.ExecuteNonQuery(scriptStream.ReadToEnd());
                    }
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
            var sqlTypesAssembly = Assembly.GetAssembly(typeof(ITableValuedType));
            var sqlTypes = sqlTypesAssembly.GetTypes().Where(x => x.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ITableValuedType)) && x.IsClass);
            
            foreach (var sqlScriptInfo in sqlTypes.GetSqlScriptInfoList())
            {
                if (!SqlHelper.CheckIfTypeExists(Database.GetDbConnection(), sqlScriptInfo.Name))
                {
                    var scriptResorceName = sqlTypesAssembly.GetManifestResourceNames().First(x => x.EndsWith(sqlScriptInfo.FileName));
                    using (var scriptStream = new StreamReader(sqlTypesAssembly.GetManifestResourceStream(scriptResorceName)))
                    {
                        server.ConnectionContext.ExecuteNonQuery(scriptStream.ReadToEnd());
                    }
                }
            }
        }
    }
}
