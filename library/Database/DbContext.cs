using Npgsql;

namespace library.Database;

public class DbContext
{
    private readonly IConfiguration _configuration;
    private readonly NpgsqlConnection _connection = null!;
    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connection = new NpgsqlConnection(_configuration.GetConnectionString("Database"));
        _connection.Open();
    }

    public NpgsqlConnection GetConnection()
    {
        return _connection;
    }
    ~DbContext()
    {
        _connection.Close();
    }
}