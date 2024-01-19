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
/// <summary>
/// Pobiera wszystkie gatunki z bazy
/// </summary>
/// <returns>Kolekcja encji gatunek</returns>
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
                Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
            });
        }
        return result;
    }
    
/// <summary>
/// Dodaje do bazy gatunek
/// </summary>
/// <param name="genreDto">Obiekt transferu danych dla gatunku</param>
    public async Task AddNewGenre(GenreDto genreDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO gatunki (gatunek_nazwa, gatunek_opis)" +
                                        $" VALUES ('{genreDto.Name}', '{genreDto.Description}');", _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
}