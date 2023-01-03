using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi;

public class BookRepository
{
    private BookContext bookContext;

    public BookRepository(BookContext bookContext)
    {
        this.bookContext = bookContext;
    }

    public async Task<IList<Book>> GetAllBooks()
    {
        
        return await bookContext.Books.ToListAsync();
    }
    
    public async Task<Book> CreateBook(string title, int pageCount)
    {
        var book = new Book(title)
        {
            PageCount = pageCount
        };
        
        await this.bookContext.Books.AddAsync(book);
        await bookContext.SaveChangesAsync();

        return book;
    }
    
    public async Task<IList<Book>> DeleteAllBooks()
    {
        this.bookContext.Books.RemoveRange(bookContext.Books);
        await bookContext.SaveChangesAsync();

        return await bookContext.Books.ToListAsync();
    }
    
    public async Task<Book> UpdatePageCountOfBook(Guid id, int newPageCount)
    {
        var bookToUpdate = await bookContext.Books
            .Where(book => book.Id == id)
            .FirstOrDefaultAsync();

        if (bookToUpdate == null)
        {
            throw new Exception("Das Buch ist nicht vorhanden!");
        }
        bookToUpdate!.PageCount = newPageCount;
        await bookContext.SaveChangesAsync();
        

        return bookToUpdate;
    }
    
}
