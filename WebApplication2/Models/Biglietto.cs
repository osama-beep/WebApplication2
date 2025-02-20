namespace WebApplication2.Models
{
    public class Biglietto
    {
        public int NumeroBiglietto { get; set; }

        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        public required string Sala { get; set; }
        public bool IsRidotto { get; set; }
    }
}

