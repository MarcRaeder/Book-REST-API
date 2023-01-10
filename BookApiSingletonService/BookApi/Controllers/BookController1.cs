using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Service;

namespace BookApi.Controllers
{
    [Route("")]
    [ApiController]
    public class BookController1 : ControllerBase
    {
        private BookService bookService;

        public BookController1(BookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("getAllBooks")]
        public List<Book> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }
        
        [HttpPost("createBook")]
        public Book CreateBook(string title, int pageCount)
        {
            return bookService.CreateBook(title, pageCount);
        }
        
        [HttpDelete("deleteAllBooks")]
        public List<Book> DeleteAllBooks()
        {
            return  bookService.DeleteAllBooks();
        }

        [HttpPut("updatePageCountOfBook")]
        public Book UpdatePageCountOfBook(string title, int newPageCount)
        {
            return bookService.UpdatePageCountOfBook(title, newPageCount);
        }

    }
}
