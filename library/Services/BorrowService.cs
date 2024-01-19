using System.Data;
using library.Database;
using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class BorrowService : IBorrowService
{
    private readonly DbContext _dbContext;

    public BorrowService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
/// <summary>
/// Dodaje wypożyczenie
/// </summary>
/// <param name="userId">ID użytkownika</param>
/// <param name="isbn">ISBN książki</param>
    public async Task AddNewBorrow(int userId, string isbn)
    {
        var command = new NpgsqlCommand($"SELECT wypozycz_ksiazke({userId}, '{isbn}')",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
/// <summary>
/// Pobiera widoki wypożyczeń z bazy
/// </summary>
/// <returns>Kolekcja widoków wypożyczeń z informacją o użytkowniku</returns>
    public ICollection<BorrowView> GetBorrowViews()
    {
        var command = new NpgsqlCommand("SELECT * FROM wypozyczenia_view", _dbContext.GetConnection());
        var result = new List<BorrowView>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new BorrowView()
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                BorrowDate = reader.GetDateTime(4),
                ReturnDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                DueDate = reader.GetDateTime(6)
            });
        }
        return result;
    }
/// <summary>
/// Pobiera wypożyczenia danego użytkownika
/// </summary>
/// <param name="userId">ID użytkownika</param>
/// <returns>Kolekcja wypożyczeń z kontekstem użytkownika</returns>
    public ICollection<UserBorrowView> GetUsersBorrow(int userId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM uzytkownik_wypozyczenia_view WHERE uzytkownik_id = {userId}",
            _dbContext.GetConnection());
        var result = new List<UserBorrowView>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new UserBorrowView()
            {
                UserId = reader.GetInt32(0),
                UserName = reader.GetString(1),
                UserSurname = reader.GetString(2),
                IsStaff = reader.GetBoolean(3),
                IsBanned = reader.GetBoolean(4),
                Id = reader.GetInt32(5),
                Title = reader.GetString(6),
                FirstName = reader.GetString(7),
                LastName = reader.GetString(8),
                BorrowDate = reader.GetDateTime(9),
                ReturnDate = reader.IsDBNull(10) ? null : reader.GetDateTime(10),
                DueDate = reader.GetDateTime(11)
            });
        }

        return result;
    }
/// <summary>
/// Zwracanie książki
/// </summary>
/// <param name="bookId">ID książki do zwrotu</param>
    public async Task ReturnBook(int bookId)
    {
        var command = new NpgsqlCommand($"SELECT zwroc_ksiazke({bookId})",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
}