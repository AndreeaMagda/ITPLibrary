using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITPLibrary.Api.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
      
        public int AuthorId { get; set; }
        
        public Author? Author { get; set; } 
      
        public int CategoryId { get; set; }
  
        public Category? Category { get; set; }
    }
}
