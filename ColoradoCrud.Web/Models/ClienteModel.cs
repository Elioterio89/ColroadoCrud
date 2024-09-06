using System.Text.Json.Serialization;

namespace ColoradoCrud.Web.Models
{
    public class ClienteModel
    {
        [JsonPropertyName("codigoCliente")]
        public int CodigoCliente { get; set; }

        [JsonPropertyName("razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonPropertyName("nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonPropertyName("tipoPessoa")]
        public string TipoPessoa { get; set; }

        [JsonPropertyName("documento")]
        public string Documento { get; set; }

        [JsonPropertyName("endereco")]
        public string Endereco { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("cep")]
        public string CEP { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; }

        [JsonPropertyName("dataInsercao")]
        public DateTime DataInsercao { get; set; }

        [JsonPropertyName("usuarioInsercao")]
        public string UsuarioInsercao { get; set; }
    }
}
