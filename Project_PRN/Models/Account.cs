using System;
using System.Collections.Generic;

namespace Project_PRN.Models;

public partial class Account
{
    public Account(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public Account(string userName, string displayName, string password, int type)
    {
        UserName= userName;
        DisplayName= displayName;
        Password = password;
        Type = type;
    }

    public Account(string userName, string displayName, int type) 
    {
        UserName= userName;
        DisplayName= displayName;
        Type = type;
    }

    public string UserName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Type { get; set; }
}
