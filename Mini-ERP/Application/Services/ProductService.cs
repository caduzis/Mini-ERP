using Mini_ERP.Data.Models;
using MiniERP.Application.Interfaces.Services;
using MiniERP.Data.Repository;

namespace MiniERP.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var response = await _productRepository.GetAllProductsAsync();
        return response;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var response = await _productRepository.GetProductbyIdAsync(id);

        if (response == null)
        {
            throw new Exception("Product not found");
        }
        return response;
    }   

    public async Task<Product> AddProductAsync(Product product)
    {
        var response = await _productRepository.AddProductAsync(product);
        return response;
    }

    public async Task<Product> PutProductAsync(int id, Product product)
    {
        var existingProduct = await _productRepository.GetProductbyIdAsync(id);

        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.StockQuantity = product.StockQuantity;

        var updatedProduct = await _productRepository.PutProductAsync(existingProduct);

        return updatedProduct;
    }

    public async Task<Product> DeleteProductAsync(int id)
    {
        var toBeDeletedProduct = await _productRepository.GetProductbyIdAsync(id);
        
        if (toBeDeletedProduct == null)
        {
            throw new Exception("Product not found");
        }

        await _productRepository.DeleteProductAsync(toBeDeletedProduct);
        return toBeDeletedProduct;

    }
}