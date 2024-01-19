using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IBorrowService
{
    Task AddNewBorrow(int userId, string isbn);
    ICollection<BorrowView> GetBorrowViews();
    Task ReturnBook(int bookId);
    ICollection<UserBorrowView> GetUsersBorrow(int userId);
}