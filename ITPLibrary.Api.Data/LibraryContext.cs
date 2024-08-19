using ITPLibrary.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ITPLibrary.Api.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
