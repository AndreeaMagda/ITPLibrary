using ITPLibrary.Api.Core.Dtos;
using AutoMapper;

using ITPLibrary.Api.Data.Entities;


namespace ITPLibrary.Api.Core.Profiles
{
    public class BookMapper : Profile
    {
        public BookDto ToDto(Book book)
        {
            return new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name, 
                CategoryId = book.CategoryId,
                CategoryName = book.Category?.Name 
            };
        }

        public Book ToEntity(BookDto bookDto)
        {
            return new Book()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
             
                CategoryId =bookDto.CategoryId
            };
        }
    }
}
