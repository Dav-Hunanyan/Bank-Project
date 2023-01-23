using System;
using System.Collections.Generic;

namespace BankDAL.Models;

public partial class UserData
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Region { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<BankAccount> BankAccounts { get; } = new List<BankAccount>();

    public virtual ICollection<UserAccessData> UserAccessData { get; } = new List<UserAccessData>();
}
