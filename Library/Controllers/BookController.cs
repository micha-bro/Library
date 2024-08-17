using Library.Domain.Model;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Entities;
using Library.Dtos;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Mappers;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private BookRepository _bookRepository;
        private Mapper _mapper;
        public BookController(BookRepository bookRepository, Mapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("{query}")]
        public IEnumerable<BookDetailsDto> Find(string query)
        {
            var books = _bookRepository.GetByTitleOrAuthor(query);
            return _mapper.Map<Book, BookDetailsDto>(books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDetailsDto> Get(int id)
        {
            Book book = _bookRepository.Get(id);
            return _mapper.Map<Book,BookDetailsDto>(book);
        }        
                
        [HttpPut]
        public ActionResult Edit(BookDto book)
        {
            _bookRepository.Edit(_mapper.Map<BookDto, Book>(book));
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(BookDto book)
        {
            _bookRepository.Add(_mapper.Map<BookDto, Book>(book));
            return CreatedAtAction("Add","Book", new {titel = book.Title}, book);
        }
    }
}
