using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Entities;

public partial class AuthorEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? RealName { get; set; }

    public int? BirthYear { get; set; }

    public string Country { get; set; } = null!;

    public string WritingLanguage { get; set; } = null!;

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}
