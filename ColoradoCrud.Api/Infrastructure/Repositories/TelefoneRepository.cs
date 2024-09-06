using ColoradoCrud.Api.Domain.Entities;
using ColoradoCrud.Api.Domain.Interfaces;
using ColoradoCrud.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ColoradoCrud.Api.Infrastructure.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ColoradoCrudContext _context;

        public TelefoneRepository(ColoradoCrudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefone>> GetAllTelefonesAsync()
        {
            return await _context.Telefones.Include(t => t.Cliente)
                                           .Include(t => t.TipoTelefone)
                                           .ToListAsync();
        }

        public async Task<Telefone> GetTelefoneByIdAsync(string numero)
        {
            return await _context.Telefones.Include(t => t.Cliente)
                                           .Include(t => t.TipoTelefone)
                                           .FirstOrDefaultAsync(t => t.NumeroTelefone == numero);
        }

        public async Task AddTelefoneAsync(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTelefoneAsync(Telefone telefone)
        {
            _context.Telefones.Update(telefone);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelefoneAsync(string numero)
        {
            var telefone = await _context.Telefones.Where(t=>t.NumeroTelefone.Equals(numero)).FirstOrDefaultAsync();
            if (telefone != null)
            {
                _context.Telefones.Remove(telefone);
                await _context.SaveChangesAsync();
            }
        }
    }
}
