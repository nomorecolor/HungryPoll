using System;
using System.Collections.Generic;

namespace HungryPoll.Domain.Models;

public partial class FoodVote
{
    public Guid FoodId { get; set; }

    public Guid UserId { get; set; }

    public virtual Food Food { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
