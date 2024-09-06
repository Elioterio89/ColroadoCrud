

using ColoradoCrud.Api.Application.DTOs;

namespace ColoradoCrud.Api.Application.Interfaces
{
    public interface ITelefoneService
    {
        Task<IEnumerable<TelefoneDto>> GetAllTelefonesAsync();
        Task<TelefoneDto> GetTelefoneByIdAsync(string numero);
        Task AddTelefoneAsync(TelefoneDto dto);
        Task UpdateTelefoneAsync(TelefoneDto dto);
        Task DeleteTelefoneAsync(string numero);
        Task<bool> GetExiste(string numero);
    }
}
