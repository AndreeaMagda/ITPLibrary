using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data;
using ITPLibrary.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> AddAuthorAsync(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> UpdateAuthorAsync(AuthorDto authorDto)
        {
            var author = await _context.Authors.FindAsync(authorDto.Id);
            if (author == null)
            {
                return null;
            }

            _mapper.Map(authorDto, author);
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
