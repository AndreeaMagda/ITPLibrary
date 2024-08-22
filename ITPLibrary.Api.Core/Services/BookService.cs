using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data;
using Microsoft.EntityFrameworkCore;


namespace ITPLibrary.Api.Core.Services
{


    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
    }

    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }

}
