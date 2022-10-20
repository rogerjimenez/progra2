using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Threading.Tasks;
using WebApplication4.Repositorios;

namespace WebApplication4.Repositorios
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration configuration;

        public ConnectionProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IDbConnection> OpenAsync()
        {
            // var connection = new OracleConnection(configuration.GetConnectionString("DefaultConnection"));
            var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            return connection;
        }
    }
}
