using CinemaProject.Models;
using CinemaProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FilmDBManager filmDBManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            filmDBManager = new FilmDBManager();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FilmIndex()
        {
            return View(filmDBManager.GetAllFilm());
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