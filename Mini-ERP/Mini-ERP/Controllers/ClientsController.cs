using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        var result = await _clientService.GetAllClientsAsync();
        return Ok(result);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client?>> GetClient(int id)
    {
        try
        {
            var result = await _clientService.GetClientByIdAsync(id);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);//not found não faz sentido
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> PostClient(Client client)
    {
        var result = await _clientService.AddClientAsync(client);

        return result.Id;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, Client client)
    {
        try
        {
            var result = await _clientService.PutClientAsync(id, client);
            return Ok(result);
        }
        catch (KeyNotFoundException ex) // Erros não fazem sentidos
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex) // Erros não fazem sentidos
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            await _clientService.DeleteClientAsync(id);

            return NoContent();
        }

        catch (Exception ex) // Erros não fazem sentidos
        {
            return NotFound(ex.Message);
        }

    }

}




