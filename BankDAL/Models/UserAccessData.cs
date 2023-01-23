using System;
using System.Collections.Generic;

namespace BankDAL.Models;

public partial class UserAccessData
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual UserData User { get; set; } = null!;
}
