using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IGenreService
{
    ICollection<Genre> GetAllGenres();
    ICollection<String> GetAllGenresNames();
    Task AddNewGenre(GenreDto genreDto);

}