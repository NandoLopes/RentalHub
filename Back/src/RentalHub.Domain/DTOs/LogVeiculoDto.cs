namespace RentalHub.Domain.DTOs
{
    public class LogVeiculoDto : BaseEntity
    {
        public int VeiculoId { get; set; }
        public int LocadoraId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
