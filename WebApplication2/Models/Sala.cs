public class Sala
{
    public string Nome { get; set; }
    public int CapienzaMassima { get; set; }
    public int BigliettiVenduti { get; set; }
    public int BigliettiRidottiVenduti { get; set; }
    public int BigliettiInteriVenduti { get; set; }

    public int PostiDisponibili => CapienzaMassima - BigliettiVenduti;
}