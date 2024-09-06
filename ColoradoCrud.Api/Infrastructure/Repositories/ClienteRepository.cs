using ColoradoCrud.Api.Domain.Entities;
using ColoradoCrud.Api.Domain.Interfaces;
using ColoradoCrud.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ColoradoCrud.Api.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ColoradoCrudContext _context;
        public ClienteRepository(ColoradoCrudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes.Include(c => c.Telefones).ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.Include(c => c.Telefones)
                                          .FirstOrDefaultAsync(c => c.CodigoCliente == id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
