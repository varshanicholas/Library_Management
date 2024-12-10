//using Library_Management.Model;
//using System.Collections.Generic;
//using System.Linq;

//namespace LibraryManagement.Repositories
//{
//    public class ReportRepository : IReportRepository
//    {
//        private readonly LibraryManagementContext _context;

//        public ReportRepository(LibraryManagementContext context)
//        {
//            _context = context;
//        }

//        // Method to get book overview including title, author, category, and available copies
//        public IEnumerable<BookOverview> GetBooksOverview()
//        {
//            return _context.Books
//                .Join(_context.Authors, book => book.AuthorId, author => author.AuthorId, (book, author) => new { book, author })
//                .Join(_context.Categories, bookAuthor => bookAuthor.book.CategoryId, category => category.CategoryId, (bookAuthor, category) => new BookOverview
//                {
//                    Title = bookAuthor.book.Title,
//                    Author = bookAuthor.author.Name,
//                    Category = category.Name,
//                    AvailableCopies = bookAuthor.book.AvailableCopies
//                })
//                .ToList();
//        }

//        // Method to get currently borrowed books
//        public IEnumerable<BorrowedBook> GetCurrentlyBorrowedBooks()
//        {
//            return _context.BorrowTransactions
//                .Where(transaction => transaction.IsReturned == false)
//                .Join(_context.Books, transaction => transaction.BookId, book => book.BookId, (transaction, book) => new { transaction, book })
//                .Join(_context.Members, transactionBook => transactionBook.transaction.MemberId, member => member.MemberId, (transactionBook, member) => new BorrowedBook
//                {
//                    MemberName = member.Name,
//                    BookTitle = transactionBook.book.Title,
//                    BorrowDate = transactionBook.transaction.BorrowDate
//                })
//                .ToList();
//        }
//    }
//}

using Library_Management.Model;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly LibraryManagementContext _context;

        public ReportRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        // Method to get book overview including title, author, category, and available copies
        public IEnumerable<object> GetBooksOverview()
        {
            return _context.Books
                .Join(_context.Authors, book => book.AuthorId, author => author.AuthorId, (book, author) => new { book, author })
                .Join(_context.Categories, bookAuthor => bookAuthor.book.CategoryId, category => category.CategoryId, (bookAuthor, category) => new
                {
                    Title = bookAuthor.book.Title,
                    Author = bookAuthor.author.Name,
                    Category = category.Name,
                    AvailableCopies = bookAuthor.book.AvailableCopies
                })
                .ToList();
        }

        // Method to get currently borrowed books
        public IEnumerable<object> GetCurrentlyBorrowedBooks()
        {
            return _context.BorrowTransactions
                .Where(transaction => transaction.IsReturned == false)
                .Join(_context.Books, transaction => transaction.BookId, book => book.BookId, (transaction, book) => new { transaction, book })
                .Join(_context.Members, transactionBook => transactionBook.transaction.MemberId, member => member.MemberId, (transactionBook, member) => new
                {
                    MemberName = member.Name,
                    BookTitle = transactionBook.book.Title,
                    BorrowDate = transactionBook.transaction.BorrowDate
                })
                .ToList();
        }
    }
}
