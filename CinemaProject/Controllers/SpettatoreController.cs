using CinemaProject.Models;
using CinemaProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaProject.Controllers
{
    public class SpettatoreController : Controller
    {
        private readonly ILogger<SpettatoreController> _logger;
        private SpettatoreDBManager spettatoreDBManager;
        

        public SpettatoreController(ILogger<SpettatoreController> logger)
        {
            _logger = logger;
            spettatoreDBManager = new SpettatoreDBManager();
            
        }

        public IActionResult SpettatoreIndex()
        {
            return View(spettatoreDBManager.GetAllSpettatori());
        }

        [HttpGet]
        public IActionResult AddSpettatore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpettatore(SpettatoreViewModel spettatore)
        {
            spettatoreDBManager.AddSpettatore(spettatore);
            return RedirectToAction("SpettatoreIndex");
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