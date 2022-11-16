using BookApi.Models;
using BookApi.Service;

namespace BookApi;

public class BookRepository 
{
    private dataService DataService;

    public BookRepository(dataService dataService)
    {
        this.DataService = dataService;
    }

    public List<Book> GetAllBooks()
    {
        return this.DataService.books;

    }
    
    public Book CreateBook(string title, int pageCount)
    {
        var book = new Book(title)
        {
            PageCount = pageCount
        };

        this.DataService.books.Add(book);

        return book;
    }
    
    public List<Book> DeleteAllBooks()
    {
        this.DataService.books.Clear();
        

        return this.DataService.books;
    }
    
    public Book UpdatePageCountOfBook(string title, int newPageCount)
    {
        var bookToUpdate = this.DataService.books.Where(book => book.Title == title).FirstOrDefault();

        if (bookToUpdate == null)
        {
            throw new Exception("Das Buch ist nicht vorhanden!");
        }
        bookToUpdate!.PageCount = newPageCount;

        return bookToUpdate;
    }
    
}