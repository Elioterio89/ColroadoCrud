using System.ComponentModel.DataAnnotations;

namespace ColoradoCrud.Api.Domain.Entities
{
    public class TipoTelefone
    {
        [Key]
        public int CodigoTipoTelefone { get; set; }
        public string DescricaoTipoTelefone { get; set; }
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
    }
}
