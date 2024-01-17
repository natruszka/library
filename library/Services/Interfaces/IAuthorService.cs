using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IAuthorService
{
    ICollection<Author> GetAllAuthors();
    Task AddNewAuthor(AuthorDto authorDto);
    Author GetAuthorById(int authorId);
    ICollection<BookDto> GetAuthorDetailedInfo(int authorId);
}