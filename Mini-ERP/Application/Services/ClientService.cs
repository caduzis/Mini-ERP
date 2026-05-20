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
    
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        var response = await _clientRepository.GetAllClientsAsync();
        return response;
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        var response = await _clientRepository.GetClientByIdAsync(id);

        if (response == null)
        {
            throw new Exception("Client not found"); // Erros não fazem sentidos
        }

        return response;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        if (String.IsNullOrEmpty(client.Cpf))
            return new Client();

        var response = await _clientRepository.AddClientAsync(client);

        return response;
    }

    public async Task<Client> PutClientAsync(int id, Client client)
    {
        var existingClient = await _clientRepository.GetClientByIdAsync(id);

        if (existingClient == null)
        {
            throw new Exception("Client not found");// Erros não fazem sentidos
        }

        existingClient.Name = client.Name;
        existingClient.Email = client.Email;
        existingClient.Cpf = client.Cpf;

        var updatedClient = await _clientRepository.PutClientAsync(existingClient);

        return existingClient;
        
        }

    public async Task<Client> DeleteClientAsync(int id)
    {
        var toBeDeletedClient = await _clientRepository.GetClientByIdAsync(id);

        if (toBeDeletedClient == null)
        {
            throw new Exception("Client not found");// Erros não fazem sentidos
        }

        await _clientRepository.DeleteClientAsync(toBeDeletedClient);
        return toBeDeletedClient;

    }



}
