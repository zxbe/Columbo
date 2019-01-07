using Columbo.Shared.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_configuration.GetConnectionString("IdentityProviderDatabase"));
        }
    }
}
