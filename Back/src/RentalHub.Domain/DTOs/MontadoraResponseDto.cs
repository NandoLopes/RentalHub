namespace RentalHub.Domain.DTOs
{
    public class MontadoraResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<ModeloMontadoraAttributeDto> Modelos { get; set; }
    }
}