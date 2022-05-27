using CinemaProject.Models;
using CinemaProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaProject.Controllers
{
    public class FilmController : Controller
    {
        private readonly ILogger<FilmController> _logger;
        private FilmDBManager filmDBManager;

        public FilmController(ILogger<FilmController> logger)
        {
            _logger = logger;
            filmDBManager = new FilmDBManager();
        }

        public IActionResult FilmIndex()
        {
            return View(filmDBManager.GetAllFilm());
        }

        [HttpGet]
        public IActionResult DetailsFilm(int id)
        {
            var film = filmDBManager.GetAllFilm().Where(x => x.IdFilm == id).FirstOrDefault();
            return View(film);
        }

        [HttpPost]
        public IActionResult DetailsFilm(FilmViewModel film)
        {
            var res = filmDBManager.GetAllFilm().Where(x => x.IdFilm == film.IdFilm).FirstOrDefault();
            if (res != null)
                filmDBManager.DetailsFilm(film);
            return RedirectToAction("FilmIndex");
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