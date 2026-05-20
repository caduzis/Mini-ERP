using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_ERP.Data;
using Mini_ERP.Data.Models;

namespace Mini_ERP.Controllers;

[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SalesController(AppDbContext context)
    {
        _context = context;
    }

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
//    {
        
//        return await _context.Sales
//            .Include(s => s.Client)
//            .Include(s => s.Items)
//            .ThenInclude(i => i.Product)
//            .ToListAsync();
//    }

    
//    [HttpPost]
//    public async Task<ActionResult<Sale>> PostSale(Sale sale)
//    {
        
//        sale.TotalAmount = 0;
//        sale.SaleDate = DateTime.Now;

        
//        var client = await _context.Clients.FindAsync(sale.ClientId);
//        if (client == null)
//        {
//            return BadRequest("Cliente não encontrado.");
//        }

        
//        foreach (var item in sale.Items)
//        {
            
//            var product = await _context.Products.FindAsync(item.ProductId);
//            if (product == null)
//            {
//                return BadRequest($"Produto com ID {item.ProductId} não encontrado.");
//            }

            
//            if (product.StockQuantity < item.Quantity)
//            {
//                return BadRequest($"Estoque insuficiente para o produto {product.Name}. Estoque atual: {product.StockQuantity}.");
//            }

            
//            product.StockQuantity -= item.Quantity;

            
//            item.UnitPrice = product.Price;

            
//            sale.TotalAmount += item.Quantity * item.UnitPrice;
//        }

        
//        _context.Sales.Add(sale);
//        await _context.SaveChangesAsync();

//        return Ok(sale); 
//}
}
