using ColoradoCrud.Api.Domain.Entities;

namespace ColoradoCrud.Api.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> GetAllTelefonesAsync();
        Task<Telefone> GetTelefoneByIdAsync(string numero);
        Task AddTelefoneAsync(Telefone telefone);
        Task UpdateTelefoneAsync(Telefone telefone);
        Task DeleteTelefoneAsync(string numero);
    }
}
