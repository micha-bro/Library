using Library.Domain.Mappers;
using Library.Domain.Model;
using Library.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository
    {
        private LibraryContext _dbContext;
        private Mapper _mapper;

        public AuthorRepository(LibraryContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Author Get(int id)
        {
            var authorEntity = _dbContext.Authors.Find(id);
            if (authorEntity == null) throw new Exception("No author with given Id");
            var author = _mapper.Map<AuthorEntity, Author>(authorEntity);
            return author;
        }
        
        public void Edit(Author author)
        {
            AuthorEntity bookEntity = _mapper.Map<Author, AuthorEntity>(author);
            _dbContext.Authors.Update(bookEntity);
            _dbContext.SaveChanges();
        }

        public void Add(Author author)
        {
            AuthorEntity authorEntity = _mapper.Map<Author, AuthorEntity>(author);
            _dbContext.Authors.Add(authorEntity);
            _dbContext.SaveChanges();
        }
    }
}
