using Mini_ERP.Data.Models;

namespace MiniERP.Application.Interfaces.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client> AddClientAsync(Client client);
    Task<Client?> GetClientByIdAsync(int id);
    Task<Client> PutClientAsync(int id, Client client);
    Task<Client> DeleteClientAsync(int id);
}
