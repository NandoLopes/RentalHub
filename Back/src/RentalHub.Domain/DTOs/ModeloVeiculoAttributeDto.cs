namespace RentalHub.Domain.DTOs
{
    public class ModeloVeiculoAttributeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MontadoraId { get; set; }
        public MontadoraAttributeDto Montadora { get; set; }
    }
}
