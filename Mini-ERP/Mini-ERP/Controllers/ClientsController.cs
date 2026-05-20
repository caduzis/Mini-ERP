using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_ERP.Data.Models;
using MiniERP.Application.Interfaces.Services;

namespace Mini_ERP.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Client>>> GetClients() 
    //{ 
    //    return await _context.Clients.ToListAsync();
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<Client>> GetClient(int id) 
    //{
    //    var client = await _context.Clients.FindAsync(id);

    //    if (client == null)
    //    {
    //        return NotFound("Cliente não encontrado.");
    //    }
    //    return client;
    //}

    [HttpPost]
    public async Task<ActionResult<int>> PostClient(Client client)
    {
        var result = await _clientService.AddClientAsync(client);

        return result.Id;
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutClient(int id, Client client)
    //{
    //    if (id != client.Id)
    //    {
    //        return BadRequest("O ID informado não confere");
    //    }
    //    _context.Entry(client).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!_context.Clients.Any(e => e.Id == id))
    //        {
    //            return NotFound("Cliente não encontrado.");

    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }
    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteClient(int id)
    //{
    //    var client = await _context.Clients.FindAsync(id);
    //    if (client == null)
    //    {
    //        return NotFound("Cliente não encontrado.");
    //    }
    //    _context.Clients.Remove(client);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

}

    
    
        
 