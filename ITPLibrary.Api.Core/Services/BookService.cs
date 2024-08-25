using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data;
using ITPLibrary.Api.Data.Entities;
using ITPLibrary.Api.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace ITPLibrary.Api.Core.Services
{


    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task AddBookAsync(BookDto bookDto);
        Task<BookDto> GetBookByIdAsync(int id);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
        public async Task AddBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddBookAsync(book);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }
    }

}
