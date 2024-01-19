using library.Database;
using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class OrderService : IOrderService
{
    private readonly DbContext _dbContext;

    public OrderService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
/// <summary>
/// Pobiera wszystkie rezerwacje
/// </summary>
/// <returns>Kolekcja widoków rezerwacji</returns>
    public ICollection<OrderView> GetOrderViews()
    {
        var command = new NpgsqlCommand("SELECT * FROM zamowienia_view", _dbContext.GetConnection());
        var result = new List<OrderView>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new OrderView()
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                OrderDate = reader.GetDateTime(4),
                EndDate =reader.GetDateTime(5),
            });
        }
        return result;
    }
/// <summary>
/// Zwraca rezerwacje użytkownika
/// </summary>
/// <param name="userId">ID użytkownika</param>
/// <returns>Kolekcja widoków rezerwacji z kontekstem użytkownika</returns>
    public ICollection<UserOrderView> GetUsersOrder(int userId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM uzytkownik_zamowienia_view WHERE uzytkownik_id = {userId}", _dbContext.GetConnection());
        var result = new List<UserOrderView>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new UserOrderView()
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
                OrderDate = reader.GetDateTime(9),
                EndDate = reader.GetDateTime(10)
            });
        }

        return result;
    }
/// <summary>
/// Dodanie rezerwacji
/// </summary>
/// <param name="userId">ID użytkownika</param>
/// <param name="isbn">ISBN książki</param>
    public async Task AddNewOrder(int userId, string isbn)
    {
        var command = new NpgsqlCommand(
            $"SELECT zarezerwuj_ksiazke({userId}, '{isbn}');",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
    
}