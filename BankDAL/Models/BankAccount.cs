using System;
using System.Collections.Generic;

namespace BankDAL.Models;

public partial class BankAccount
{
    public int Id { get; set; }

    public decimal CurrentAmount { get; set; }

    public DateTime CreationDate { get; set; }

    public int UserId { get; set; }

    public string Currency { get; set; } = null!;

    public virtual UserData User { get; set; } = null!;
}
