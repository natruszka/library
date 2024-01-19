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
    /// <summary>
    /// Pobiera wszystkie wydawnictwa
    /// </summary>
    /// <returns>Kolekcja encji wydawnictwa</returns>
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
    /// <summary>
    /// Dodaje nowe wydawnictwo
    /// </summary>
    /// <param name="name">Nazwa wydawnictwa</param>
    public async Task AddNewPublisher(String name)
    {
        var command = new NpgsqlCommand($"INSERT INTO wydawcy (wydawca_nazwa) " +
                                        $"VALUES ('{name}');", _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
}