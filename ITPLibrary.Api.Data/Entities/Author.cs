using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITPLibrary.Api.Data.Entities
{
    public class Author
    {
        [Key]
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Book> Books { get; set; }


        public static implicit operator Author(string v)
        {
            throw new NotImplementedException();
        }
    }
}
