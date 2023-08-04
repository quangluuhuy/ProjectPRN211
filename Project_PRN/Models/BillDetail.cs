using System;
using System.Collections.Generic;

namespace Project_PRN.Models;

public partial class BillDetail
{
    public BillDetail(int idBill, int idfood, int count)
    {
        IdBill = idBill;
        Idfood = idfood;
        Count = count;
    }

    public int Id { get; set; }

    public int IdBill { get; set; }

    public int Idfood { get; set; }

    public int Count { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;

    public virtual Food IdfoodNavigation { get; set; } = null!;
}
