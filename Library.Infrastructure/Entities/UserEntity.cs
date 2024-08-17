using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Entities;

public partial class UserEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? Birth { get; set; }

    public virtual ICollection<BookScoreEntity> BookScores { get; set; } = new List<BookScoreEntity>();
}
