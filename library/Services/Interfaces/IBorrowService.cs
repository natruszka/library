using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IBorrowService
{
    IList<Borrow> GetAllBorrows();
    Task AddNewBorrow(BorrowDto borrowDto);
    ICollection<BorrowView> GetBorrowViews();
    Borrow GetBorrowById(int borrowId);
}