using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Bill
{
    public int Id { get; set; }

    public DateTime DateCheckIn { get; set; }

    public DateTime? DateCheckOut { get; set; }

    public int IdTable { get; set; }

    public int Status { get; set; }

    public int? Discount { get; set; }

    public int? TotalPrice { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; } = new List<BillDetail>();

    public virtual Table IdTableNavigation { get; set; } = null!;
}
