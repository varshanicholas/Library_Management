using LibraryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // GET /api/reports/books-overview
        [HttpGet("books-overview")]
        public IActionResult GetBooksOverview()
        {
            var booksOverview = _reportRepository.GetBooksOverview();
            return Ok(booksOverview);
        }

        // GET /api/reports/current-borrowed
        [HttpGet("current-borrowed")]
        public IActionResult GetCurrentBorrowedBooks()
        {
            var currentlyBorrowedBooks = _reportRepository.GetCurrentlyBorrowedBooks();
            return Ok(currentlyBorrowedBooks);
        }
    }
}
