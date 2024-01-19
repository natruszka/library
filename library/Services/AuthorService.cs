using library.Database;
using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class AuthorService : IAuthorService
{
    private readonly DbContext _dbContext = null!;

    public AuthorService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <summary>
    /// Dodaje autora do bazy
    /// </summary>
    /// <returns>Kolekcja encji typu autor</returns>
    public ICollection<Author> GetAllAuthors()
    {
        var command = new NpgsqlCommand("SELECT * FROM autorzy", _dbContext.GetConnection());
        var result = new List<Author>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Author()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2)
            });
        }
        return result;
    }
    /// <summary>
    /// Dodaje nowego autora do bazy
    /// </summary>
    /// <param name="authorDto">Obiekt transferu danych typu autor</param>
    public async Task AddNewAuthor(AuthorDto authorDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO autorzy (autor_imie, autor_nazwisko) " +
                                        $"VALUES ('{authorDto.FirstName}', '{authorDto.LastName}');", _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
    
}