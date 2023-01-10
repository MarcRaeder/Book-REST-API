using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Service;

namespace BookApi.Controllers
{
    [Route("")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public async Task<IList<Book>> GetAllBooks()
        {
            return await bookService.GetAllBooks();
        }
        
        [HttpPost("create-book")]
        public async Task<Book> CreateBook(string title, int pageCount)
        {
            return await bookService.CreateBook(title, pageCount);
        }

        [HttpDelete("delete-all-books")]
        public async Task<IList<Book>> DeleteAllBooks()
        {
            return await bookService.DeleteAllBooks();
        }

        [HttpPut("update-page-count-of-book")]
        public async Task<Book> UpdatePageCountOfBook(Guid id, int newPageCount)
        {
            return await bookService.UpdatePageCountOfBook(id, newPageCount);
        }

    }
}
