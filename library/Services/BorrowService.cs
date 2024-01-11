using System.Data;
using library.Database;
using library.DTOs;
using library.Entities;
using Npgsql;

namespace library.Services;

public class BorrowService
{
    private readonly DbContext _dbContext;

    public BorrowService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<Borrow> GetAllBorrows()
    {
        var command = new NpgsqlCommand("SELECT * FROM wypozyczenia", _dbContext.GetConnection());
        var result = new List<Borrow>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Borrow()
            {
                BookId = reader.GetInt32(0),
                MemberId = reader.GetInt32(1),
                BorrowDate = reader.GetDateTime(2),
                ReturnDate = reader.GetDateTime(3),
                DueDate = reader.GetDateTime(4),
                Id = reader.GetInt32(5)
            });
        }

        return result;
    }

    public async Task AddNewBorrow(BorrowDto borrowDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO wypozyczenia" +
                                        $"(ksiazka_id, uzytkownik_id, data_wypozyczenia, termin_zwrotu)" +
                                        $"VALUES ({borrowDto.BookId}, {borrowDto.MemberId}, '{borrowDto.BorrowDate}', '{borrowDto.BorrowDate.AddMonths(1)}');",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }

    public Borrow GetBorrowById(int borrowId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM wypozyczenia WHERE wypozyczenie_id = {borrowId}",
            _dbContext.GetConnection());
        var result = new List<Borrow>();
        using var reader = command.ExecuteReader();
        return new Borrow()
        {
            BookId = reader.GetInt32(0),
            MemberId = reader.GetInt32(1),
            BorrowDate = reader.GetDateTime(2),
            ReturnDate = reader.GetDateTime(3),
            DueDate = reader.GetDateTime(4),
            Id = reader.GetInt32(5)
        };
    }


}