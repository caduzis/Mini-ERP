using Mini_ERP.Data;
using Mini_ERP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniERP.Data.Repository;

public interface ISalesRepository
{
    Task<IEnumerable<Sale>> GetAllSalesAsync();
    Task<Sale?> GetSaleByIdAsync(int id);
    Task<Sale> AddSaleAsync(Sale sale);
    Task<Sale> PutSaleAsync(Sale sale);
    Task<Sale> DeleteSaleAsync(Sale sale);
}

public class SalesRepository : ISalesRepository
{   
    private readonly AppDbContext _context;
    
    public SalesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sale>> GetAllSalesAsync()
    {
        return await _context.Sales
        .Include(s => s.Items)
        .ToListAsync();

        //var result = await _context.Sales.ToListAsync();
        //return result;
    }

    public async Task<Sale?> GetSaleByIdAsync(int id)
    {
        return await _context.Sales
        .Include(s => s.Items)
        .FirstOrDefaultAsync(s => s.Id == id);
        //var result = await _context.Sales.FindAsync(id);
        //return result;
    }

    public async Task<Sale> AddSaleAsync(Sale sale)
    {
        var result = await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Sale> PutSaleAsync(Sale sale)
    {
        var result = _context.Sales.Update(sale);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sales.Any(e => e.Id == sale.Id))
            {
                throw new KeyNotFoundException($"Sale with id {sale.Id} not found.");

            }
            else
            {
                throw new NotImplementedException();
            }
        }
        return result.Entity;
    }

    public async Task<Sale> DeleteSaleAsync(Sale sale)
    {
        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();

        return sale;
    }
}