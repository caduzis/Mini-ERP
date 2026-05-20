using Mini_ERP.Data;
using Mini_ERP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniERP.Data.Repository;

public interface IClientRepository
{
    Task<Client> AddClientAsync(Client client);
    Task<Client> GetClientByIdAsync(int id);
    
}

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        var result = await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        var response = await _context.GetClientByIdAsync(id);
        return response;
    }

}
