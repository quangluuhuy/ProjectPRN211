using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class BillDetail
{
    public int Id { get; set; }

    public int IdBill { get; set; }

    public int Idfood { get; set; }

    public int Count { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;

    public virtual Food IdfoodNavigation { get; set; } = null!;
}
