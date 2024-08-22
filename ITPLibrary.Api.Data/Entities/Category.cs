using System.ComponentModel.DataAnnotations;

namespace ITPLibrary.Api.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
        public static implicit operator Category(string v)
        {
            throw new NotImplementedException();
        }
    }
}
