using library.DTOs;

namespace library.Services.Interfaces;

public interface IBookService
{
    ICollection<BookView> GetAllBooks();
    Task AddNewBook(BookDto bookDto);
}