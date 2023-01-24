using FilmDB.Classes;
using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private FilmManager filmManager = new FilmManager();
        public IActionResult Index()
        {
            return View(filmManager.GetFilms());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(FilmModel fm)
        {
            filmManager.AddFilm(fm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            FilmModel film = filmManager.GetFilm(id);
            return View(film);
        }
        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            filmManager.RemoveFilm(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FilmModel film = filmManager.GetFilm(id);
            return View(film);
        }
        [HttpPost]
        public IActionResult Edit(FilmModel film)
        {
            filmManager.UpdateFilm(film);
            return RedirectToAction("Index");
        }
    }
}
