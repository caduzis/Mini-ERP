using Microsoft.Extensions.Options;
using Mini_ERP.Data.Models;
using MiniERP.Application.Interfaces.Services;
using MiniERP.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniERP.Application.Services;

public class SaleService  : ISaleService
{
    private readonly ISalesRepository _saleRepository;
    private readonly IProductRepository _productRepository;

    public SaleService(ISalesRepository saleRepository, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }



    public  async Task<IEnumerable<Sale>> GetAllSalesAsync()
    {
        var response = await _saleRepository.GetAllSalesAsync();
        return response;
    }
    
    public async Task<Sale?> GetSaleByIdAsync(int id)
    {
        var response = await _saleRepository.GetSaleByIdAsync(id);
        if (response == null)
        {
            throw new Exception($"Sale with ID {id} not found.");
        }
        return response;
    }

    public async Task<Sale> AddSaleAsync(Sale sale)
    {
        if (sale.SaleDate == default)
        {
            sale.SaleDate = DateTime.Now;   
        }
        foreach (var item in sale.Items)
        {
            item.Id = 0;
            var product = await _productRepository.GetProductbyIdAsync(item.ProductId);
            if (product == null)
            {   
                throw new Exception($"Product with ID {item.ProductId} not found.");
            }
            item.UnitPrice = product.Price;
            sale.TotalAmount += (item.Quantity * item.UnitPrice);
            
            
        }
        var response = await _saleRepository.AddSaleAsync(sale);
        return response;
    }

    public async Task<Sale> PutSaleAsync(int id, Sale sale)
    {
        var existingSale = await _saleRepository.GetSaleByIdAsync(sale.Id);

        if(existingSale == null)
        {
            throw new Exception($"Sale with ID {sale.Id} not found.");
        }

        existingSale.SaleDate = sale.SaleDate;
        // existingSale.TotalValue = sale.TotalValue;
        // existingSale.ClientId = sale.ClientId;
        

        var updatedProduct = await _saleRepository.PutSaleAsync(existingSale);
        return updatedProduct;
    }
    
    public async Task<Sale> DeleteSaleAsync(int id)
    {
        var toBeDeletedSale = await _saleRepository.GetSaleByIdAsync(id);

        if (toBeDeletedSale == null)
        {
            throw new Exception("Sale is not found"); /// Devo rever este erro.
        }
        await _saleRepository.DeleteSaleAsync(toBeDeletedSale);
        return toBeDeletedSale;
    }
}