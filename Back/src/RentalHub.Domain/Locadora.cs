namespace RentalHub.Domain
{
    public class Locadora : BaseEntity
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Veiculo> Veiculos { get; set; }
        public IEnumerable<LogVeiculo> Logs { get; set; }
    }
}
