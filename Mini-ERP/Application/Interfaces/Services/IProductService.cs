using System;
using System.Collections.Generic;
using System.Text;
using Mini_ERP.Data.Models;

namespace MiniERP.Application.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> AddProductAsync(Product product);
    Task<Product> PutProductAsync(int id, Product product);
    Task<Product> DeleteProductAsync(int id);
}