using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Web.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Movie_Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesContext _context;
        public MovieController(MoviesContext context)
        {
            _context = context;
        }

        [Route("demophim/{Alias}")]
        public IActionResult DemoPhim(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }
            var model = _context.Movies.Include(x => x.Type).Include(y => y.Categories).Include(z => z.Actors).Include(x => x.Rates).FirstOrDefault(x => x.Alias == Alias);
            
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                string alias_phim = Alias;
                string alias_phim_moi = alias_phim.Remove(alias_phim.Length - 1);
                
                int Count = (_context.Movies.Where(x => x.Alias.StartsWith(alias_phim_moi))).Count();

                ViewBag.CountPhim = Count;
            }
            

            return View(model);
        }

        [Route("xemphim/{Alias}")]
        public IActionResult XemPhim(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }
            var model = _context.Movies.FirstOrDefault(x => x.Alias == Alias);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
