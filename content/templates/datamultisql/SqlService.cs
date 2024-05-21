using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Logging;

namespace CSSharpTemplates;

public class PostgresService : IDatabase
{
    private readonly ILogger _logger;
    private readonly string _connectionString;
    private readonly CSSharpTemplatesConfig _config;

    public PostgresService(CoreConfig config, ILogger logger)
    {
        _logger = logger;
        _config = config;

        _connectionString = BuildConnectionString(config);
    }

    private string BuildDatabaseConnectionString()
    {
        MySqlConnectionStringBuilder builder = new()
        {
            Server = config.DatabaseHost,
            Port = (uint)config.DatabasePort,
            UserID = config.DatabaseUser,
            Password = config.DatabasePassword,
            Database = config.DatabaseName,
            AllowUserVariables = true,
            Pooling = true,
        };

        return builder.ConnectionString;
    }
}