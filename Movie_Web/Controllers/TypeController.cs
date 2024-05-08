using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Movie_Web.Models;
using PagedList.Core;

namespace Movie_Web.Controllers
{
    public class TypeController : Controller
    {
      
        private readonly MoviesContext _context;
        public TypeController(MoviesContext context)
        {
            _context = context;
        }

        [Route("{Alias}", Name = "KieuPhim")]
        public IActionResult Index(string Alias, int? page)
        {
            if(string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }
            if (Alias == "Admin")
            {
                return Redirect("~/Admin/Home");
            }

            // Chi dua ra Alias o tap 1 thoi
            var kieuphim = _context.Types.FirstOrDefault(x => x.TypeAlias == Alias);
            List<Movie> lsMovies = new List<Movie>();
            if(kieuphim != null)
            {
                lsMovies = _context.Movies.Include(x => x.Type).Where(x => x.Type.TypeAlias == Alias && x.Episode == 1).AsNoTracking().ToList();
            }
            else { 
                        return NotFound();
                        //return RedirectToAction("Index", "Home");
               
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize1 = _context.Parameters.FirstOrDefault(x => x.ParameterName == "Page_Size").Value;
            int pageSize = pageSize1 == null ? 1 : pageSize1.Value;

          
            PagedList<Movie> models = new PagedList<Movie>(lsMovies.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            
            return View(models);
        }

        [Route("the-loai/{Alias}", Name = "TheLoai")]
        public IActionResult TheLoai(string Alias, int? page)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }
           
            
            List<Movie> lsMovies = new List<Movie>();
            
            var theloai = _context.Categories.FirstOrDefault(x => x.CategoriesAlias == Alias);
            if (theloai != null)
            {
                lsMovies = _context.Movies.Include(x => x.Categories).Where(x => x.Episode == 1 &&  x.Categories.Any(y => y.CategoriesAlias == Alias)).ToList();
            }
            else
            {
                return NotFound();
                //return RedirectToAction("Index", "Home");
            }

          

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize1 = _context.Parameters.FirstOrDefault(x => x.ParameterName == "Page_Size").Value;
            int pageSize = pageSize1 == null ? 1 : pageSize1.Value;


            PagedList<Movie> models = new PagedList<Movie>(lsMovies.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(models);
        }
        [Route("quoc-gia/{Alias}", Name = "QuocGia")]
        public IActionResult QuocGia(string Alias, int? page)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return RedirectToAction("Index", "Home");
            }


            List<Movie> lsMovies = new List<Movie>();

            var quocgia = _context.Countries.FirstOrDefault(x => x.CountryAlias == Alias);
            if (quocgia != null)
            {
                lsMovies = _context.Movies.Include(x => x.Country).Where(x => x.Country.CountryAlias == Alias && x.Episode == 1).AsNoTracking().ToList();
            }
            else
            {
                return NotFound();
                //return RedirectToAction("Index", "Home");
            }



            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize1 = _context.Parameters.FirstOrDefault(x => x.ParameterName == "Page_Size").Value;
            int pageSize = pageSize1 == null ? 1 : pageSize1.Value;


            PagedList<Movie> models = new PagedList<Movie>(lsMovies.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(models);
        }
    }
}