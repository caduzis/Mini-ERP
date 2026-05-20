using Mini_ERP.Data;
using Mini_ERP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MiniERP.Data.Repository;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client> AddClientAsync(Client client);
    Task<Client?> GetClientByIdAsync(int id);
    Task<Client> PutClientAsync(Client client);
    Task<Client> DeleteClientAsync(Client client);
}

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        var result = await _context.Clients.ToListAsync();
        return result;
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        var result = await _context.Clients.FindAsync(id);

        return result;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        var result = await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Client> PutClientAsync(Client client)
    {
        var result = _context.Clients.Update(client);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Clients.Any(e => e.Id == client.Id))
            {
                throw new KeyNotFoundException("O cliente não foi encontrado. Talvez tenha sido excluído por outro usuário.");// Erros não fazem sentidos
            }
            else
            {
                throw new Exception("O registro foi modificado por outro usuário ao mesmo tempo. Tente novamente.");// Erros não fazem sentidos
            }
        }
        return result.Entity;

    }

    public async Task<Client> DeleteClientAsync(Client client)
    {
        
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        
        return client;
        
    }

}
