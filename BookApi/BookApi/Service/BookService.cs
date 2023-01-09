using BookApi.Models;

namespace BookApi.Service;

public class BookService
{
    private BookRepository bookRepository;

    public BookService(BookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<IList<Book>> GetAllBooks()
    {
        return await bookRepository.GetAllBooks();
    }
    public async Task<Book> CreateBook(string title, int pageCount)
    {
        return await bookRepository.CreateBook(title, pageCount);
    }
    
    public async Task<IList<Book>> DeleteAllBooks()
    {
        return await bookRepository.DeleteAllBooks();
    }
    
    public async Task<Book> UpdatePageCountOfBook(Guid id, int newPageCount)
    {
        return await bookRepository.UpdatePageCountOfBook(id, newPageCount);
    }
}
