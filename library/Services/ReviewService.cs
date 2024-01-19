using library.Database;
using library.DTOs;
using library.Entities;
using library.Services.Interfaces;
using Npgsql;

namespace library.Services;

public class ReviewService : IReviewService
{
    private readonly DbContext _dbContext;

    public ReviewService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <summary>
    /// Dodaje recenzje książki
    /// </summary>
    /// <param name="reviewDto">Obiekt transferu danych dla recenzji</param>
    public async Task AddNewReview(ReviewDto reviewDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO recenzje" +
                                        $"(uzytkownik_id, ocena, recenzja_tekst, isbn)" +
                                        $"VALUES ({reviewDto.MemberId}, {reviewDto.Rating}, '{reviewDto.ReviewText}', '{reviewDto.Isbn}');",
            _dbContext.GetConnection());
        await command.ExecuteNonQueryAsync();
    }
    /// <summary>
    /// Pobiera wszystkie recenzje z bazy
    /// </summary>
    /// <returns>Kolekcja encji recenzji</returns>
    public ICollection<ReviewsView> GetAllReviewsViews()
    {
        var command = new NpgsqlCommand("SELECT * FROM recenzje_view", _dbContext.GetConnection());
        var result = new List<ReviewsView>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new ReviewsView()
            {
                ReviewId = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Title = reader.GetString(3),
                Rating = reader.GetInt32(4),
                Text = reader.IsDBNull(3)? String.Empty : reader.GetString(5),
                Date = reader.GetDateTime(6)
            });
        }
        return result;
    }
}