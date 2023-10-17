namespace RentalHub.Domain.DTOs
{
    public class ModeloPostDto : BasePostDto
    {
        public string Nome { get; set; }
        public int MontadoraId { get; set; }
        public MontadoraAttributeDto? Montadora { get; set; }
    }
}