

using ColoradoCrud.Api.Application.DTOs;

namespace ColoradoCrud.Api.Application.Interfaces
{
    public interface ITipoTelefoneService
    {
        Task<IEnumerable<TipoTelefoneDto>> GetAllTiposTelefoneAsync();
        Task<TipoTelefoneDto> GetTipoTelefoneByIdAsync(int id);
        Task AddTipoTelefoneAsync(TipoTelefoneDto dto);
        Task UpdateTipoTelefoneAsync(TipoTelefoneDto dto);
        Task DeleteTipoTelefoneAsync(int id);
    }
}
