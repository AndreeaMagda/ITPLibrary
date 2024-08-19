using Microsoft.EntityFrameworkCore;


namespace ITPLibrary.Api.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {



        }
    }
    }
