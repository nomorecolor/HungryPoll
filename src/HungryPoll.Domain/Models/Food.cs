using System;
using System.Collections.Generic;

namespace HungryPoll.Domain.Models;

public partial class Food
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CreatedByUserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? UpdatedByUserId { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual User? UpdatedByUser { get; set; }
}
