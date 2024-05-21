using Dapper;
using Npgsql;
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
        NpgsqlConnectionStringBuilder builder = new()
        {
            Host = _config.DatabaseHost,
            Port = _config.DatabasePort,
            Username = _config.DatabaseUser,
            Password = _config.DatabasePassword,
            Database = _config.DatabaseName,
            Pooling = true,
        };

        return builder.ConnectionString;
    }
}