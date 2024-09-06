using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColoradoCrud.Api.Domain.Entities
{
    public class Telefone
    {

        [Key] 
        public string NumeroTelefone { get; set; }

        [Required] 
        public int CodigoCliente { get; set; }
       
        [ForeignKey("CodigoCliente")]
        public Cliente Cliente { get; set; }
      
        public int CodigoTipoTelefone { get; set; }
      
        [ForeignKey("CodigoTipoTelefone")]
        public TipoTelefone TipoTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }       
        public DateTime DataInsercao { get; set; }       
        public string UsuarioInsercao { get; set; }
    }
}
