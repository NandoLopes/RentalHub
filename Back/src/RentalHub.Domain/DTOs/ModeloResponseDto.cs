namespace RentalHub.Domain.DTOs
{
    public class ModeloResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MontadoraId { get; set; }
        public MontadoraAttributeDto Montadora { get; set; }
        public IEnumerable<VeiculoModeloAttributeDto> Veiculos { get; set; }
    }
}
