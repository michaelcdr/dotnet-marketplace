using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DotnetMarketplace.WebApps.MVC.Configuration
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}