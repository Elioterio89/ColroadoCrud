

using ColoradoCrud.Api.Application.DTOs;

namespace ColoradoCrud.Api.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllClientesAsync();
        Task<ClienteDto> GetClienteByIdAsync(int id);
        Task AddClienteAsync(ClienteDto dto);
        Task UpdateClienteAsync(ClienteDto dto);
        Task DeleteClienteAsync(int id);
    }
}
