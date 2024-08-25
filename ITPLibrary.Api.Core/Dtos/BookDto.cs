using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
 
        public string? AuthorName { get; set; }
        
        public string? CategoryName { get; set; }
    }
}
