using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Entities;

public partial class GenreEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}
