using library.Database;
using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class GenreService : IGenreService
{
    private readonly DbContext _dbContext;

    public GenreService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Genre> GetAllGenres()
    {
        var command = new NpgsqlCommand("SELECT * FROM gatunki", _dbContext.GetConnection());
        var result = new List<Genre>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Genre()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2)
            });
        }
        return result;
    }

    public ICollection<String> GetAllGenresNames()
    {
        var command = new NpgsqlCommand("SELECT * FROM gatunki", _dbContext.GetConnection());
        var result = new List<String>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(reader.GetString(1));
        }
        return result;
    }

    public async Task AddNewGenre(GenreDto genreDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO gatunki (gatunek_nazwa, gatunek_opis)" +
                                        $" VALUES ('{genreDto.Name}', '{genreDto.Description}');", _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
}