using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Entities;

public partial class BookEntity
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int GenreId { get; set; }

    public string Title { get; set; } = null!;

    public virtual AuthorEntity Author { get; set; } = null!;

    public virtual ICollection<BookScoreEntity> BookScores { get; set; } = new List<BookScoreEntity>();

    public virtual GenreEntity Genre { get; set; } = null!;
}
