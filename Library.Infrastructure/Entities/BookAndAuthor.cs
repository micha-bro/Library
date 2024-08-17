using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Entities
{
    public class BookAndAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string WritingLanguage { get; set; } = null!;
    }
}
