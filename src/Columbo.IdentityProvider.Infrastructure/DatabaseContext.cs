using Columbo.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Columbo.Shared.Infrastructure.SqlTypes;
using Columbo.Shared.Infrastructure.Extensions;
using System.IO;
using Columbo.IdentityProvider.Infrastructure.StoredProcedures;
using Columbo.Shared.Infrastructure.Helpers;

namespace Columbo.IdentityProvider.Infrastructure
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlScriptExecutor _sqlScriptExecutor;

        public DatabaseContext(IConfiguration configuration, ISqlScriptExecutor sqlScriptExecutor)
        {
            _configuration = configuration;
            _sqlScriptExecutor = sqlScriptExecutor;
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
            
            CreateTypes();
            CreateStoredProcedures();
            
            if (seed)
                databaseSeeder.Seed(this);
        }

        private void CreateStoredProcedures()
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
                        var connection = Database.GetDbConnection() as SqlConnection;
                        _sqlScriptExecutor.Execute(scriptStream.ReadToEnd(), connection);
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

        private void CreateTypes()
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
                        var connection = Database.GetDbConnection() as SqlConnection;
                        _sqlScriptExecutor.Execute(scriptStream.ReadToEnd(), connection);
                    }
                }
            }
        }
    }
}
