using System.Text.Json.Serialization;

namespace ColoradoCrud.Web.Models
{
    public class TipoTelefoneModel
    {
        [JsonPropertyName("codigoTipoTelefone")]
        public int CodigoTipoTelefone { get; set; }

        [JsonPropertyName("descricaoTipoTelefone")]
        public string DescricaoTipoTelefone { get; set; }

        [JsonPropertyName("dataInsercao")]
        public DateTime DataInsercao { get; set; }

        [JsonPropertyName("usuarioInsercao")]
        public string UsuarioInsercao { get; set; }
    }
}
