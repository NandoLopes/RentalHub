namespace RentalHub.Domain
{
    public class LogVeiculo : BaseEntity
    {
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int LocadoraId { get; set; }
        public Locadora Locadora { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
