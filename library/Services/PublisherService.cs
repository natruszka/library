using library.Database;
using library.Entities;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class PublisherService : IPublisherService
{
    private readonly DbContext _dbContext;

    public PublisherService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public ICollection<Publisher> GetAllPublishers()
    {
        var command = new NpgsqlCommand("SELECT * FROM wydawcy", _dbContext.GetConnection());
        var result = new List<Publisher>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Publisher()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
            });
        }
        return result;
    }

    public Publisher GetPublisherById(int id)
    {
        var command = new NpgsqlCommand($"SELECT * FROM wydawcy WHERE wydawca_id = {id};",
            _dbContext.GetConnection());
        using var reader = command.ExecuteReader();
        return new Publisher() { Id = reader.GetInt32(0), Name = reader.GetString(1) };
    }
    public async Task AddNewPublisher(String name)
    {
        var command = new NpgsqlCommand($"INSERT INTO wydawcy (wydawca_nazwa) " +
                                        $"VALUES ('{name}');", _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
}