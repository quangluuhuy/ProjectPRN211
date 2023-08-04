using System;
using System.Collections.Generic;

namespace Project_PRN.Models;

public partial class FoodCategory
{
    public FoodCategory()
    {
    }

    public FoodCategory(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public FoodCategory(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; } = new List<Food>();
}
