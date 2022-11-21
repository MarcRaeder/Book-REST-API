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

        try
        {
            await this.bookContext.Books.AddAsync(book);
            await bookContext.SaveChangesAsync();

            return book;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<IList<Book>> DeleteAllBooks()
    {
        this.bookContext.Books.RemoveRange(bookContext.Books);
        await bookContext.SaveChangesAsync();

        return await bookContext.Books.ToListAsync();
    }
    
    public async Task<Book> UpdatePageCountOfBook(string title, int newPageCount)
    {
        var bookToUpdate = await bookContext.Books
            .Where(book => book.Title == title)
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
