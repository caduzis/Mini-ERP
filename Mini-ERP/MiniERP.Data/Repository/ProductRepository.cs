using Mini_ERP.Data;
using Mini_ERP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MiniERP.Data.Repositorý;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductbyIdAsync(int id);
    Task<Product> AddProductAsync(Product product);
    Task<Product> PutProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);

}

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var result = await _context.Products.ToListAsync();
        return result;
    }

    public async Task<Product?> GetProductbyIdAsync(int id)
    {
        var result = await _context.Products.FindAsync(id);
        return result;

    }

    public async Task<Product> AddProductAsync(Product product)
    {
        var result = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return result.Entity;
    }
    
    public async Task<Product> PutProductAsync(Product product)
    {
        var result = _context.Products.Update(product);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(e => e.Id == product.Id))
            {
                throw new KeyNotFoundException($"O Produto com o id {product.Id} não foi encontrado.");
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        return result.Entity;
    }

    public async Task<Product> DeleteProductAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return product;
    }
}