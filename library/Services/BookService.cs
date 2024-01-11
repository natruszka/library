using library.Database;
using library.DTOs;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class BookService : IBookService
{
    private readonly DbContext _context;

    public BookService(DbContext context)
    {
        _context = context;
    }

    public ICollection<BookView> GetAllBooks()
    {
        var command = new NpgsqlCommand("SELECT * FROM ksiazki_view", _context.GetConnection());
        var result = new List<BookView>();
        using var reader = command.ExecuteReader();
        {
            while(reader.Read())
            {
                result.Add(new BookView()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Author = new AuthorDto()
                    {
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3)
                    },
                    GenreName = reader.GetString(4),
                    PublisherName = reader.GetString(5),
                    Edition = reader.GetInt32(6),
                    IsBorrowed = reader.GetBoolean(7),
                    IsOrdered = reader.GetBoolean(8),
                    AverageRating = reader.GetDecimal(9),
                    RatingsCount = reader.GetInt32(10)
                });
            }

            return result;
        }
    }

    public async Task AddNewBook(BookDto bookDto)
    {
        
    }
    
}