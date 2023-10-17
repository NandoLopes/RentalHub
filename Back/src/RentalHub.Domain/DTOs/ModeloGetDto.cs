namespace RentalHub.Domain.DTOs
{
    public class ModeloGetDto : BaseEntity
    {
        public string Nome { get; set; }
        public int MontadoraId { get; set; }
        public string NomeMontadora { get; set; }
    }
}
