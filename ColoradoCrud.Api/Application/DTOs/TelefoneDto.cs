namespace ColoradoCrud.Api.Application.DTOs
{
    public class TelefoneDto
    {
        public int CodigoCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string NumeroTelefone { get; set; }
        public int CodigoTipoTelefone { get; set; }
        public string? DescricaoTipoTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInsercao { get; set; }
        public string UsuarioInsercao { get; set; }
    }

}
