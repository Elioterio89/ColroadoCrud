using System.Text.Json.Serialization;

namespace ColoradoCrud.Web.Models
{
    public class TelefoneModel
    {
        [JsonPropertyName("codigoCliente")]
        public int CodigoCliente { get; set; }

        [JsonPropertyName("nomeCliente")]
        public string? NomeCliente { get; set; }        

        [JsonPropertyName("numeroTelefone")]
        public string NumeroTelefone { get; set; }

        [JsonPropertyName("codigoTipoTelefone")]
        public int CodigoTipoTelefone { get; set; }

        [JsonPropertyName("operadora")]
        public string Operadora { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }

        [JsonPropertyName("dataInsercao")]
        public DateTime DataInsercao { get; set; }

        [JsonPropertyName("usuarioInsercao")]
        public string UsuarioInsercao { get; set; }

        [JsonPropertyName("tipoTelefone")]
        public TipoTelefoneModel TipoTelefone { get; set; }

        [JsonPropertyName("descricaoTipoTelefone")]
        public string? DescricaoTipoTelefone { get; set; }
    }
}
