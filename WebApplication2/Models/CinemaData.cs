using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebApplication2.Models
{
    public static class CinemaData
    {
        public static List<Biglietto> BigliettiVenduti = new List<Biglietto>();
        public static List<Sala> Sale = new List<Sala>
        {
            new Sala { Nome = "SALA NORD", CapienzaMassima = 120 },
            new Sala { Nome = "SALA EST", CapienzaMassima = 120 },
            new Sala { Nome = "SALA SUD", CapienzaMassima = 120 }
        };

        public static bool VendiBiglietto(Biglietto biglietto)
        {
            var sala = Sale.FirstOrDefault(s => s.Nome == biglietto.Sala);
            if (sala == null || sala.BigliettiVenduti >= sala.CapienzaMassima)
            {
                return false;
            }

            biglietto.NumeroBiglietto = BigliettiVenduti.Count + 1; 
            BigliettiVenduti.Add(biglietto);
            sala.BigliettiVenduti++;
            if (biglietto.IsRidotto)
            {
                sala.BigliettiRidottiVenduti++;
            }
            else
            {
                sala.BigliettiInteriVenduti++;
            }
            return true;
        }
        public static int GetTotaleBigliettiVenduti()
        {
            return BigliettiVenduti.Count;
        }

        public static int GetTotaleBigliettiRidotti()
        {
            return BigliettiVenduti.Count(b => b.IsRidotto);
        }

    }
}