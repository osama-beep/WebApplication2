using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Diagnostics;

namespace WebApplication2.Controllers
{
    public class BiglietteriaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TotaleBiglietti = CinemaData.GetTotaleBigliettiVenduti();
            ViewBag.BigliettiRidotti = CinemaData.GetTotaleBigliettiRidotti();

            Debug.WriteLine($"Index: Totale biglietti: {ViewBag.TotaleBiglietti}, Ridotti: {ViewBag.BigliettiRidotti}");

            return View(CinemaData.Sale);
        }

        [HttpPost]
        public IActionResult VendiBiglietto(Biglietto biglietto)
        {
            Debug.WriteLine($"Richiesta vendita biglietto: Sala {biglietto.Sala}, Ridotto: {biglietto.IsRidotto}");

            if (ModelState.IsValid)
            {
                if (CinemaData.VendiBiglietto(biglietto))
                {
                    TempData["Message"] = "Biglietto venduto con successo!";
                    Debug.WriteLine("Biglietto venduto con successo");
                }
                else
                {
                    TempData["Error"] = "Impossibile vendere il biglietto. La sala potrebbe essere piena.";
                    Debug.WriteLine("Impossibile vendere il biglietto");
                }
            }
            else
            {
                Debug.WriteLine("ModelState non valido");
            }

            return RedirectToAction("Index");
        }
        public IActionResult DettagliBiglietti()
        {
            var biglietti = CinemaData.BigliettiVenduti;
            return View(biglietti);
        }
    }

}