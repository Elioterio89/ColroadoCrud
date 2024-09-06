using ColoradoCrud.Api.Domain.Entities;
using ColoradoCrud.Api.Domain.Interfaces;
using ColoradoCrud.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ColoradoCrud.Api.Infrastructure.Repositories
{
    public class TipoTelefoneRepository : ITipoTelefoneRepository
    {
        private readonly ColoradoCrudContext _context;

        public TipoTelefoneRepository(ColoradoCrudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoTelefone>> GetAllTiposTelefoneAsync()
        {
            return await _context.TiposTelefone.ToListAsync();
        }

        public async Task<TipoTelefone> GetTipoTelefoneByIdAsync(int id)
        {
            return await _context.TiposTelefone.FindAsync(id);
        }

        public async Task AddTipoTelefoneAsync(TipoTelefone tipoTelefone)
        {
            _context.TiposTelefone.Add(tipoTelefone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTipoTelefoneAsync(TipoTelefone tipoTelefone)
        {
            _context.TiposTelefone.Update(tipoTelefone);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTipoTelefoneAsync(int id)
        {
            var tipoTelefone = await _context.TiposTelefone.FindAsync(id);
            if (tipoTelefone != null)
            {
                _context.TiposTelefone.Remove(tipoTelefone);
                await _context.SaveChangesAsync();
            }
        }
    }

}
