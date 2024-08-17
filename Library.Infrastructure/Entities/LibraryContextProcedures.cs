using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Entities
{
    public partial class LibraryContext : DbContext
    {
        public IEnumerable<BookAndAuthor> FindBooksByTitleOrAuthorProcedure(string query)
        {
            return Database
                .SqlQuery<BookAndAuthor>($"exec findBooksByTitleOrAuthor {query}");
        }
    }
}
