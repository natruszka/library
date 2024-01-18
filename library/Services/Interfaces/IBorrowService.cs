using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IBorrowService
{
    IList<Borrow> GetAllBorrows();
    Task AddNewBorrow(int userId, string isbn);
    ICollection<BorrowView> GetBorrowViews();
    Borrow GetBorrowById(int borrowId);
    Task ReturnBook(int bookId);
    ICollection<UserBorrowView> GetUsersBorrow(int userId);
}