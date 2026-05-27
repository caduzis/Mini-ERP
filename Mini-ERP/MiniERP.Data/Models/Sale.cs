using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mini_ERP.Data.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    
    public int ClientId { get; set; }

    public decimal TotalAmount { get; set; }
    public ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();
}
