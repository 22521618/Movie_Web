using System;
using System.Collections.Generic;

namespace Movie_Web.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public bool Active { get; set; }

    public string? FullName { get; set; }

    public int? RoleId { get; set; }

    public DateOnly? LastLogin { get; set; }

    public DateOnly? CreateDate { get; set; }

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

    public virtual Role? Role { get; set; }
}
