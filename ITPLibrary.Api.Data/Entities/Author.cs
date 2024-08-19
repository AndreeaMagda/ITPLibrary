using System.ComponentModel.DataAnnotations;

namespace ITPLibrary.Api.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
