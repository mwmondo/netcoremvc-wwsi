using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Classes
{
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Add(filmModel);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    filmModel.Id = 0;
                    context.Add(filmModel);
                    context.SaveChanges();
                }
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {
                FilmModel? obj = context.Films.SingleOrDefault(f => f.Id == id);
                if (obj != null)
                {
                    context.Remove(obj);
                    context.SaveChanges();
                }
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                FilmModel? obj = context.Films.SingleOrDefault(f => f.Id == filmModel.Id);
                if (obj != null)
                {
                    obj.Title = filmModel.Title;
                    obj.Year = filmModel.Year;

                    context.SaveChanges();
                }
            }
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new FilmContext())
            {
                FilmModel? obj = context.Films.SingleOrDefault(f => f.Id == id);
                if (obj != null)
                {
                    obj.Title = string.IsNullOrEmpty(newTitle) ? "Brak Tytułu" : newTitle;

                    context.SaveChanges();
                }
            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            FilmModel? fm = null;
            using (var context = new FilmContext())
            {
                FilmModel? obj = context.Films.SingleOrDefault(f => f.Id == id);
                if (obj != null)
                {
                    fm = obj;
                }
            }

            if (fm != null)
                return fm;
            else
                throw new Exception("Not found");
        }

        public List<FilmModel> GetFilms()
        {
            List<FilmModel> output = new();
            using (var context = new FilmContext())
            {
                //if (context.Films != null)
                //{
                output = context.Films.ToList();
                //}
            }
            return output;
        }
    }
}
