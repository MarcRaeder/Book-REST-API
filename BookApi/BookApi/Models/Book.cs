using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApi.Models;

[Table("Books")]
public class Book
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    public int? PageCount { get; set; }

    public Book(string title)
    {
        Id = new Guid();
        Title = title;
    }
}