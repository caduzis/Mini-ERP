using Mini_ERP.Data.Models;
using MiniERP.Application.Interfaces.Services;
using MiniERP.Data.Repository;

namespace MiniERP.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
   

    public async Task<Client> AddClientAsync(Client client)
    {
        if (String.IsNullOrEmpty(client.Cpf))
            return new Client();

        var response = await _clientRepository.AddClientAsync(client);

        return response;
    }




}
