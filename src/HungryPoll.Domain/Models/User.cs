using System;
using System.Collections.Generic;

namespace HungryPoll.Domain.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ExternalId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public virtual ICollection<Food> FoodCreatedByUsers { get; set; } = new List<Food>();

    public virtual ICollection<Food> FoodUpdatedByUsers { get; set; } = new List<Food>();
}
