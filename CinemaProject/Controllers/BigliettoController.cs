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

        public IActionResult SpettatoreIndex()
        {
            return View(bigliettoDBManager.GetAllBiglietti());
        }

        //[HttpGet]
        //public IActionResult AddSpettatore()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddSpettatore(SpettatoreViewModel spettatore)
        //{
        //    spettatoreDBManager.AddSpettatore(spettatore);
        //    return RedirectToAction("SpettatoreIndex");
        //}

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
