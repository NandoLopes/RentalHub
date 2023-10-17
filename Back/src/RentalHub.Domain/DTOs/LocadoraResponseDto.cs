namespace RentalHub.Domain.DTOs
{
    public class LocadoraResponseDto : BaseEntity
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<VeiculoLocadoraAttributeDto> Veiculos { get; set; }
    }
}
