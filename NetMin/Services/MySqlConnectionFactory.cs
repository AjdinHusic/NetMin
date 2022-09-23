using System.Data;
using DotNetEnv;
using MySql.Data.MySqlClient;
using NetMin.Interfaces;

namespace NetMin.Services;

public class MySqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    private string Database { get; set; }

    public MySqlConnectionFactory()
    {
        _connectionString = Env.GetString("DB_CONNECTION");
        var builder = new MySqlConnectionStringBuilder(_connectionString);
        Database = builder.Database;
    }

    public IDbConnection GetDbConnection(string? database = null)
    {
        var builder = new MySqlConnectionStringBuilder(_connectionString);
        Database = database ?? builder.Database;
        builder.Database = Database;
        return new MySqlConnection(builder.ConnectionString);
    }
}