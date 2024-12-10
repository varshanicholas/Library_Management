using Library_Management.Model;
using Library_Management.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Repository
{
    public interface IBookRepository
    {
        // #region 1-Get all employees
        // public Task<ActionResult<IEnumerable<Book>>> GetBooksDetails();

        // #endregion

        // //#region 2- Get All Books details using ViewModel

        // //public Task<ActionResult<IEnumerable<BookAuthorViewModel>>> GetViewModelBooks();


        // //#endregion

        // #region -3 Get an Book based on id

        // //Get a Book based on Id
        // public Task<ActionResult<Book>> GetBookById(int id);
        // #endregion

        // ////4--insert a NEW BOOK-return Book details record
        // public Task<ActionResult<Book>> PostbookReturnRecord(Book  book);

        // ////5--insert a b-reookturn employee id
        // public Task<ActionResult<int>> PostbookReturnId(Book Book);


        // //6--update an employee with id and employee
        //public Task<ActionResult<Book>> PutBook(int id, Book book);


        ////7--delete an book


        // public JsonResult Deletebook(int id);


        public Task<ActionResult<IEnumerable<Book>>> GetAllBooks();

        public Task<ActionResult<Book>> GetBookById(int id);

        public Task<ActionResult<Book>> postBookReturnRecord(Book book);

        public Task<ActionResult<int>> postbookReturnId(Book book);

        public Task<ActionResult<Book>> putbook(int id, Book book);

        public JsonResult Deletebook(int id);





    }
}
