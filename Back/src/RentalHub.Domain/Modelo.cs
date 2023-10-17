namespace RentalHub.Domain
{
    public class Modelo : BaseEntity
    {
        public string Nome { get; set; }
        public int MontadoraId { get; set; }
        public Montadora Montadora { get; set; }
        public IEnumerable<Veiculo> Veiculos { get; set; }
    }
}