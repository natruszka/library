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

    public async Task AddNewAuthor(AuthorDto authorDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO autorzy (autor_imie, autor_nazwisko) " +
                                        $"VALUES ('{authorDto.FirstName}', '{authorDto.LastName}');", _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }

    public Author GetAuthorById(int authorId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM autorzy WHERE autor_id = {authorId}", _dbContext.GetConnection());
        var result = new List<Author>();
        using var reader = command.ExecuteReader();
        return new Author()
        {
            Id = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2)
        };

    }
    
    public ICollection<BookDto> GetAuthorDetailedInfo(int authorId)
    {
        var command = new NpgsqlCommand();
        throw new NotImplementedException();
    }
}