namespace RentalHub.Domain
{
    public class Montadora : BaseEntity
    {
        public string Nome { get; set; }
        public IEnumerable<Modelo> Modelos { get; set; }
    }
}