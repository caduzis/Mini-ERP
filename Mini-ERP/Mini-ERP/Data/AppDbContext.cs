using Microsoft.EntityFrameworkCore;
using Mini_ERP.Models;

namespace Mini_ERP.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
    : base(options) 
    {
    }
     
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItem { get; set; }

}
