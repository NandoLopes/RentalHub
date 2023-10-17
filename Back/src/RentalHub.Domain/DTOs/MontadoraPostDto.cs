namespace RentalHub.Domain.DTOs
{
    public class MontadoraPostDto : BasePostDto
    {
        public string Nome { get; set; }
        public IEnumerable<ModeloMontadoraAttributeDto>? Modelos { get; set; }
    }
}
