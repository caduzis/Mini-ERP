using Microsoft.AspNetCore.Mvc;
using Mini_ERP.Data.Models;
using MiniERP.Application.Interfaces.Services;

namespace Mini_ERP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<int>> GetProductbyId(int id)
    {
        try
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex) // Erros não fazem sentidos
        {
            return NotFound(ex.Message); 
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> PostProduct(Product product)
    {
        var result = await _productService.AddProductAsync(product);

        return result.Id;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        try
        {
            var result = await _productService.PutProductAsync(id, product);
            return Ok(result);
        }
        catch (KeyNotFoundException ex) // Erros não fazem sentidos
        {
            return NotFound(ex.Message); 
        }
        catch (Exception ex)    // Erros não fazem sentidos
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
        catch (Exception ex) // Erros não fazem sentidos
        {
            return NotFound(ex.Message);
        }
    }
}