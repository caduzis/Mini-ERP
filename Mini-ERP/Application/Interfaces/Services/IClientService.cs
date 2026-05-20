using Mini_ERP.Data.Models;

namespace MiniERP.Application.Interfaces.Services;

public interface IClientService
{
    Task<Client> AddClientAsync(Client client);

}
