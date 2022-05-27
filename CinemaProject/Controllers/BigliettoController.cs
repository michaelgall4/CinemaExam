using CinemaProject.Models;
using CinemaProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaProject.Controllers
{
    public class BigliettoController : Controller
    {
        private readonly ILogger<BigliettoController> _logger;
        private BigliettoDBManager bigliettoDBManager;


        public BigliettoController(ILogger<BigliettoController> logger)
        {
            _logger = logger;
            bigliettoDBManager = new BigliettoDBManager();

        }

        public IActionResult BigliettoIndex()
        {
            return View(bigliettoDBManager.GetAllBiglietti());
        }

        [HttpGet]
        public IActionResult AddBiglietto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBiglietto(BigliettoViewModel biglietto)
        {
            bigliettoDBManager.AddBiglietto(biglietto);
            return RedirectToAction("BigliettoIndex");
        }

        [HttpGet]
        public IActionResult DetailsBiglietto(int id)
        {
            var biglietto = bigliettoDBManager.GetAllBiglietti().Where(x => x.IdBiglietto == id).FirstOrDefault();
            return View(biglietto);
        }

        [HttpPost]
        public IActionResult DetailsBiglietto(BigliettoViewModel biglietto)
        {
            var res = bigliettoDBManager.GetAllBiglietti().Where(x => x.IdBiglietto == biglietto.IdBiglietto).FirstOrDefault();
            if (res != null)
                bigliettoDBManager.DetailsBiglietto(biglietto);
            return RedirectToAction("BigliettoIndex");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
 
    }
}
