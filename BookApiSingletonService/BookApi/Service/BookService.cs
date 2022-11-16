using BookApi.Models;
using NuGet.Protocol.Core.Types;

namespace BookApi.Service;

public class BookService
{
    private BookRepository bookRepository;

    public BookService(BookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public List<Book> GetAllBooks()
    {
        return  bookRepository.GetAllBooks();
    }
    public Book CreateBook(string title, int pageCount)
    {
        return  bookRepository.CreateBook(title, pageCount);
    }
    public List<Book> DeleteAllBooks()
    {
        return  bookRepository.DeleteAllBooks();
    }
    
    public Book UpdatePageCountOfBook(string title, int newPageCount)
    {
        return  bookRepository.UpdatePageCountOfBook(title, newPageCount);
    }
}