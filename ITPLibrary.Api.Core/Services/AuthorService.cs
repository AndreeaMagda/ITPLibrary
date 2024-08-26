using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data;
using ITPLibrary.Api.Data.Entities;
using ITPLibrary.Api.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{

    public interface IAuthorService
    {
        
        Task<AuthorDto> AddAuthorAsync(AuthorDto authorDto);
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task UpdateAuthorAsync(AuthorDto authorDto);
        Task DeleteAuthorAsync(int id);

    }
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }




        public async Task<AuthorDto> AddAuthorAsync(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.AddAuthorAsync(author);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task UpdateAuthorAsync(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepository.DeleteAuthorAsync(id);
        }

    }
}
