using System;
using System.Collections.Generic;

namespace Project_PRN.Models;

public partial class Food
{
    public Food(string name, int idCategory, double price)
    {
        Name = name;
        IdCategory = idCategory;
        Price = price;
    }

    public Food(int id, string name, int idCategory, double price)
    {
        Id = id;
        Name = name;
        IdCategory = idCategory;
        Price = price;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCategory { get; set; }

    public double Price { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; } = new List<BillDetail>();

    public virtual FoodCategory IdCategoryNavigation { get; set; } = null!;
}
