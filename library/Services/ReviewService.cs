using library.Database;
using library.DTOs;
using library.Entities;
using Npgsql;

namespace library.Services;

public class ReviewService
{
    private readonly DbContext _dbContext;

    public ReviewService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<Review> GetAllReviews()
    {
        var command = new NpgsqlCommand("SELECT * FROM recenzje", _dbContext.GetConnection());
        var result = new List<Review>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Review()
            {
                Id = reader.GetInt32(0),
                MemberId = reader.GetInt32(1),
                Rating = reader.GetInt32(2),
                ReviewText = reader.GetString(3),
                ReviewDate = reader.GetDateTime(4),
                BookIsbn = reader.GetString(5)
            });
        }
        return result;
    }

    public async Task AddNewReview(ReviewDto reviewDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO recenzje" +
                                        $"(uzytkownik_id, ocena, recenzja_tekst, recenzja_data, isbn)" +
                                        $"VALUES ({reviewDto.MemberId}, {reviewDto.Rating}, '{reviewDto.ReviewText}', '{reviewDto.ReviewDate}', '{reviewDto.Isbn}');",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
}