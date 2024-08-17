using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? RealName { get; set; }
        public int? BirthYear { get; set; }
        public string Country { get; set; } = null!;
        public string WritingLanguage { get; set; } = null!;
    }
}
