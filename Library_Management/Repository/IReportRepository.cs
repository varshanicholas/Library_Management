
using System.Collections.Generic;

namespace LibraryManagement.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<object> GetBooksOverview();
        IEnumerable<object> GetCurrentlyBorrowedBooks();
    }
}
