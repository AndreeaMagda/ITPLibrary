using ITPLibrary.Api.Core.Services;
using ITPLibrary.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = (BookService?)bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }
    }
}
