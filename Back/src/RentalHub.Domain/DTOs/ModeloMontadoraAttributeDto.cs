namespace RentalHub.Domain.DTOs
{
    public class ModeloMontadoraAttributeDto
    {
        public string Nome { get; set; }
        public IEnumerable<VeiculoModeloAttributeDto> Veiculos { get; set; }
    }
}
