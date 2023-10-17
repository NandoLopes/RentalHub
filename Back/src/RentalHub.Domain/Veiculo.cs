namespace RentalHub.Domain
{
    public class Veiculo : BaseEntity
    {
        public int NumeroPortas { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public string Cor { get; set; }
        public DateTime AnoModelo { get; set; }
        public DateTime AnoFabricacao { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public DateTime DataCadastro { get; set; }
        public int LocadoraId { get; set; }
        public Locadora Locadora { get; set; }
        public IEnumerable<LogVeiculo> Logs { get; set; }
    }
}
