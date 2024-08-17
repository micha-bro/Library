using Library.Domain.Mappers;
using Library.Domain.Model;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository
    {
        private LibraryContext _dbContext;
        private Mapper _mapper;

        public BookRepository(LibraryContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<Book> GetByTitleOrAuthor(string titleOrAuthor)
        {
            var queryResult = _dbContext.FindBooksByTitleOrAuthorProcedure(titleOrAuthor);
            foreach(var item in queryResult)
            {
                Book book = _mapper.Map<BookAndAuthor, Book>(item);
                book.Author = _mapper.Map<BookAndAuthor, Author>(item);
                yield return book;
            }
        }

        public Book Get(int id)
        {
            var bookEntity = _dbContext.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .SingleOrDefault(x => x.Id == id);
            if (bookEntity == null) throw new Exception("No book with given Id");
            Book book = _mapper.Map<BookEntity, Book>(bookEntity);
            book.Author = _mapper.Map<AuthorEntity, Author>(bookEntity.Author);
            book.Genre = bookEntity.Genre.Name;
            return book;
        }

        public void Edit(Book book)
        {
            BookEntity bookEntity = _mapper.Map<Book, BookEntity>(book);
            _dbContext.Books.Update(bookEntity);
            _dbContext.SaveChanges();
        }

        public void Add(Book book)
        {
            BookEntity bookEntity = _mapper.Map<Book, BookEntity>(book);
            _dbContext.Books.Add(bookEntity);
            _dbContext.SaveChanges();
        }   
    }
}
