using ColoradoCrud.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ColoradoCrud.Api.Infrastructure.Data
{
    public class ColoradoCrudContext : IdentityDbContext<Usuario>
    {
        public ColoradoCrudContext(DbContextOptions<ColoradoCrudContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TiposTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Telefone>()
                .HasKey(t => t.NumeroTelefone);

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.CodigoCliente)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.TipoTelefone)
                .WithMany(tt => tt.Telefones)
                .HasForeignKey(t => t.CodigoTipoTelefone)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
