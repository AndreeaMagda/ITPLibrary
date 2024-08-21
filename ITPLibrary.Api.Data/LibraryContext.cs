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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Non-Fiction" }
            );

           modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J K Rowling", Description = "British author" },
                new Author { Id = 2, Name = "Stephen King", Description = "American author" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter and the Chamber of Secrets", AuthorId=1,CategoryId=1},
                new Book { Id = 2, Title = "The Shining", AuthorId=2,CategoryId=1}
             );
        }
    
    }
}
