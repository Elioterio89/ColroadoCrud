using ColoradoCrud.Api.Domain.Entities;

namespace ColoradoCrud.Api.Domain.Interfaces
{
    public interface ITipoTelefoneRepository
    {
        Task<IEnumerable<TipoTelefone>> GetAllTiposTelefoneAsync();
        Task<TipoTelefone> GetTipoTelefoneByIdAsync(int id);
        Task AddTipoTelefoneAsync(TipoTelefone tipoTelefone);
        Task UpdateTipoTelefoneAsync(TipoTelefone tipoTelefone);
        Task DeleteTipoTelefoneAsync(int id);
    }
}
