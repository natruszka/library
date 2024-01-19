using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IAuthorService
{
    ICollection<Author> GetAllAuthors();
    Task AddNewAuthor(AuthorDto authorDto);
}