using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IList<Book>> GetAllBooks()
        {
            return await bookService.GetAllBooks();
        }
        
        [HttpPost("createBook")]
        public async Task<Book> CreateBook(string title, int pageCount)
        {
            return await bookService.CreateBook(title, pageCount);
        }

        [HttpDelete("deleteAllBooks")]
        public async Task<IList<Book>> DeleteAllBooks()
        {
            return await bookService.DeleteAllBooks();
        }

        [HttpPut("updatePageCountOfBook")]
        public async Task<Book> UpdatePageCountOfBook(string title, int newPageCount)
        {
            return await bookService.UpdatePageCountOfBook(title, newPageCount);
        }

    }
}
