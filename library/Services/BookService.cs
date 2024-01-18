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
        var command = new NpgsqlCommand("SELECT * FROM ksiazki_group_view", _context.GetConnection());
        var result = new List<BookView>();
        using var reader = command.ExecuteReader();
        {
            while(reader.Read())
            {
                result.Add(new BookView()
                {
                    Title = reader.GetString(0),
                    Author = new AuthorDto()
                    {
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    },
                    GenreName = reader.GetString(3),
                    PublisherName = reader.GetString(4),
                    Edition = reader.GetInt32(5),
                    AverageRating = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                    RatingsCount = reader.IsDBNull(7) ? 0 : reader.GetInt32(7), 
                    Isbn = reader.GetString(8)
                });
            }

            return result;
        }
    }

    public ICollection<BookDetailedView> GetDetailsAllBooks()
    {
        var command = new NpgsqlCommand("SELECT * FROM ksiazki_view", _context.GetConnection());
        var result = new List<BookDetailedView>();
        using var reader = command.ExecuteReader();
        {
            while(reader.Read())
            {
                result.Add(new BookDetailedView()
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
                    Isbn = reader.GetString(9)
                });
            }

            return result;
        }
    }
    public async Task AddNewBook(BookDto bookDto)
    {
        var command = new NpgsqlCommand($"SELECT public." +
                                        $"dodaj_ksiazke('{bookDto.Title}', '{bookDto.AuthorName}', '{bookDto.AuthorSurName}'," +
                                        $" '{bookDto.Genre}', '{bookDto.Publisher}',{bookDto.Edition}," +
                                        $" '{bookDto.Isbn}')", _context.GetConnection());
        var res = await command.ExecuteScalarAsync() ?? throw new NpgsqlException("Could not add book.");
    }

    public ICollection<BookMoreInfo> GetBookByIsbn(string isbn)
    {
        var command = new NpgsqlCommand($"SELECT * FROM public.ksiazki_detailed_view WHERE isbn = '{isbn}';", _context.GetConnection());
        var result = new List<BookMoreInfo>();
        using var reader = command.ExecuteReader();
        {
            while(reader.Read())
            {
                result.Add(new BookMoreInfo()
                {
                    Title = reader.GetString(0),
                    Author = new AuthorDto()
                    {
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    },
                    GenreName = reader.GetString(3),
                    PublisherName = reader.GetString(4),
                    Edition = reader.GetInt32(5),
                    Isbn = reader.GetString(6),
                    Rating = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                    ReviewText = reader.IsDBNull(8) ? "" : reader.GetString(8),
                    Username = reader.IsDBNull(9) ? "" : reader.GetString(9),
                });
            }

            return result;
        }
    }
}