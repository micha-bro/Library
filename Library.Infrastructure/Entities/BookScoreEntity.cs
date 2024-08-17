using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Entities;

public partial class BookScoreEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public int Score { get; set; }

    public virtual BookEntity Book { get; set; } = null!;

    public virtual UserEntity User { get; set; } = null!;
}
