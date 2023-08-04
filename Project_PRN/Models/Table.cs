using System;
using System.Collections.Generic;

namespace Project_PRN.Models;

public partial class Table
{
    public Table(int id, string? name, string? status)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public Table(string? name, string? status)
    {
        Name = name;
        Status = status;
    }

    public Table(int id, string? name)
    {
        Id = id;
        Name = name;
    }

    public Table()
    {
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Bill> Bills { get; } = new List<Bill>();
}
