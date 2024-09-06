using Microsoft.AspNetCore.Identity;

namespace ColoradoCrud.Api.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }    
        public DateTime DataNascimento { get; set; }
    }
}
