using System;
using System.Collections.Generic;

namespace Mini_ERP.Data.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.Now;
    
    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public decimal TotalAmount { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
}
