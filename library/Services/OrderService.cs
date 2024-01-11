using System.Data;
using library.Database;
using library.DTOs;
using library.Entities;
using library.Enums;
using Npgsql;

namespace library.Services;

public class OrderService
{
    private readonly DbContext _dbContext;

    public OrderService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<Order> GetAllOrders()
    {
        var command = new NpgsqlCommand("SELECT * FROM zamowienia", _dbContext.GetConnection());
        var result = new List<Order>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Order()
            {
                MemberId = reader.GetInt32(0),
                BookId = reader.GetInt32(1),
                OrderDate = reader.GetDateTime(2),
                Status = (OrderStatus)reader.GetInt32(3),
                Id = reader.GetInt32(4)
            });
        }
        return result;
    }

    public async Task AddNewOrder(OrderDto orderDto)
    {
        var command = new NpgsqlCommand(
            $"INSERT INTO public.zamowienia(uzytkownik_id, ksiazka_id, data_rezerwacji, status)" +
            $"VALUES ({orderDto.MemberId}, {orderDto.BookId}, '{orderDto.OrderDate}', {(int)orderDto.Status});",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }

    public Order GetOrderById(int orderId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM uzytkownicy WHERE uzytkownik_id = {orderId}",
            _dbContext.GetConnection());
        using var reader = command.ExecuteReader();
        return new Order()
        {
            MemberId = reader.GetInt32(0),
            BookId = reader.GetInt32(1),
            OrderDate = reader.GetDateTime(2),
            Status = (OrderStatus) reader.GetInt32(3),
            Id = reader.GetInt32(4)
        };
    }
}