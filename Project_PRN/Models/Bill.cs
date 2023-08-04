using System;
using System.Collections.Generic;

namespace Project_PRN.Models;

public partial class Bill
{
    public Bill(DateTime dateCheckIn, DateTime? dateCheckOut, int idTable)
    {
        DateCheckIn = dateCheckIn;
        DateCheckOut = dateCheckOut;
        IdTable = idTable;
    }

    public int Id { get; set; }

    public DateTime DateCheckIn { get; set; }

    public DateTime? DateCheckOut { get; set; }

    public int IdTable { get; set; }

    public int Status { get; set; }

    public int Discount { get; set; }

    public int TotalPrice { get; set; }
    public virtual ICollection<BillDetail> BillDetails { get; } = new List<BillDetail>();

    public virtual Table IdTableNavigation { get; set; } = null!;
}
