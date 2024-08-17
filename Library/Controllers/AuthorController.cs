using Library.Dtos;
using Library.Domain.Model;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Mappers;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorController : Controller
    {
        private AuthorRepository _authorRepository;
        private Mapper _mapper;
        public AuthorController(AuthorRepository authorRepository, Mapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> Get(int id)
        {
            Author author = _authorRepository.Get(id);
            return _mapper.Map<Author, AuthorDto>(author);
        }

        [HttpPut]
        public ActionResult Edit(AuthorDto author)
        {
            _authorRepository.Edit(_mapper.Map<AuthorDto, Author>(author));
            return NoContent();
        }

        [HttpPost]
        public ActionResult Add(AuthorDto author)
        {
            _authorRepository.Add(_mapper.Map<AuthorDto, Author>(author));
            return CreatedAtAction("Add", "Author", new { authorName = author.LastName}, author);
        }
    }
}
