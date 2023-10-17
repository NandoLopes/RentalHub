namespace RentalHub.Domain.DTOs
{
    public class LocadoraGetDto : BaseEntity
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public int EnderecoId { get; set; }
    }
}
