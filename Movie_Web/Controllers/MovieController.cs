using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Web.Models;
using System.Security.Claims;
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
            var taikhoanID = HttpContext.Session.GetString("AccountId");

            if (taikhoanID != null)
            {
                var fullNameClaim = User.FindFirst(ClaimTypes.Name);
                string fullName = fullNameClaim != null ? fullNameClaim.Value : "";
                ViewBag.FullName = fullName;
            }
            else
            {
                ViewBag.FullName = null;
            }

            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }
            var models = _context.Movies.Include(a => a.Country).Include(x => x.Type).Include(y => y.Categories).Include(z => z.Actors).Include(x => x.Rates).FirstOrDefault(x => x.Alias == Alias);
            
            if (models == null)
            {
                return NotFound();
            }
            else
            {
                string alias_phim = Alias;
                string[] parts = alias_phim.Split('-');
                string lastPart = parts[parts.Length - 1];

                string aliasTenPhim = alias_phim.Replace(lastPart, "");

                
               
                
                int Count = (_context.Movies.Where(x => x.Alias.StartsWith(aliasTenPhim))).Count();

                ViewBag.CountPhim = Count;
                ViewBag.AliasTenPhim = aliasTenPhim;
            }

            List<Movie> listMovieHot = _context.Movies.Include(a => a.Categories).Where(a => a.Episode == 1 && a.Status == true).AsNoTracking().ToList();
            ViewBag.MovieHot = listMovieHot;

            List<Country> listCountry = _context.Countries.Take(9).AsNoTracking().ToList();
            List<Category> listCategory = _context.Categories.Take(15).AsNoTracking().ToList();
            ViewBag.Cat = listCategory;
            ViewBag.Country = listCountry;
            return View(models);
        }

        [Route("xemphim/{Alias}")]
        public IActionResult XemPhim(string Alias)
        {
            var taikhoanID = HttpContext.Session.GetString("AccountId");

            if (taikhoanID != null)
            {
                var fullNameClaim = User.FindFirst(ClaimTypes.Name);
                string fullName = fullNameClaim != null ? fullNameClaim.Value : "";
                ViewBag.FullName = fullName;
            }
            else
            {
                ViewBag.FullName = null;
            }

            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }
            var model = _context.Movies.Include(a => a.Type).FirstOrDefault(x => x.Alias == Alias);
            if (model == null)
            {
                return NotFound();
            }

            string alias_phim = Alias;
            string[] parts = alias_phim.Split('-');
            string lastPart = parts[parts.Length - 1];

            string aliasTenPhim = alias_phim.Replace(lastPart, "");

           

            int Count = _context.Movies.Where(x => x.Alias.StartsWith(aliasTenPhim)).Count();

            string aliasPhimTap1 = aliasTenPhim + "1";

            ViewBag.CountPhim = Count;
            ViewBag.TapHienTai = int.Parse(lastPart);
            ViewBag.aliasTenPhim = aliasTenPhim;
            ViewBag.aliasPhimTap1 = aliasPhimTap1;

            List<Movie> listMovieHot = _context.Movies.Include(a => a.Categories).Where(a => a.Episode == 1 && a.Status == true).AsNoTracking().ToList();
            ViewBag.MovieHot = listMovieHot;

            List<Country> listCountry = _context.Countries.Take(9).AsNoTracking().ToList();
            List<Category> listCategory = _context.Categories.Take(15).AsNoTracking().ToList();
            ViewBag.Cat = listCategory;
            ViewBag.Country = listCountry;

            return View(model);
        }
    }
}
