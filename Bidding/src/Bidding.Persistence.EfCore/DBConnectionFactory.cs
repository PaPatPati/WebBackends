using Npgsql;
using Microsoft.Extensions.Options;

namespace Bidding.Data;
{
    public class DBConnectionFactory(IOptions<DbSettings> dbSettings)
    {

        public NpsqlConnection GetConnection()
        {
            var conStr = GenerateConnectionString() ?? dbSettings.Value.ConnectionString;

            var connectionString = new NpgsqlConnectionStringBuilder(conStr);

            connectionString.Open();

            return connectionString;
        }

        private string? GenerateConnectionString()
        {
            Host = Environment.GetEnvironmentVariable("DbSettings__Host");
            Port = Environment.GetEnvironmentVariable("DbSettings__Port");
            Database = Environment.GetEnvironmentVariable("DbSettings__Database");
            Username = Environment.GetEnvironmentVariable("DbSettings__Username");
            Password = Environment.GetEnvironmentVariable("DbSettings__Password");

            if (Host == null || Port == null || Database == null || Username == null || Password == null)
            {
                return null;
            }

            return new DbSettings
            {
                Host = Host,
                Port = Port,
                Database = Database,
                Username = Username,
                Password = Password
            }.ConnectionString;
        }
    }
}