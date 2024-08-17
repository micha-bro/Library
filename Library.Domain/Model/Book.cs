using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int GenreId { get; set; }
        public int AuthorId { get { return Author.Id; } set { Author.Id = value;  } }
        public string AuthorName { get { return Author.FirstName + " " + Author.LastName; } }
        public Author Author { get; set; } = new Author();
    }
}
