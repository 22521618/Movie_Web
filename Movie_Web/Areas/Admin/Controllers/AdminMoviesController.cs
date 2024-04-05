using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Web.Models;

namespace Movie_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMoviesController : Controller
    {
        private readonly MoviesContext _context;

        public AdminMoviesController(MoviesContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminMovies
        public async Task<IActionResult> Index()
        {
            var moviesContext = _context.Movies.Include(m => m.Country).Include(m => m.Type);
            return View(await moviesContext.ToListAsync());
        }

        // GET: Admin/AdminMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Country)
                .Include(m => m.Type)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Admin/AdminMovies/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName");
            return View();
        }

        // POST: Admin/AdminMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,Image,Description,Time,PublishedYear,MovieLink,TypeId,Episode,Viewed,Status,CountryId,Director,MovieLinkContingency,MovieLinkTrailer,ImageSlider,Alias,EpisodeLimit,DirectorAlias")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", movie.CountryId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", movie.TypeId);
            return View(movie);
        }

        // GET: Admin/AdminMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", movie.CountryId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", movie.TypeId);
           
            return View(movie);
        }

        public async Task<IActionResult> AddActors(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
           
            ViewData["DienVien"] = new SelectList(_context.Actors, "ActorId", "ActorName");
            var max_actor_movie1 = _context.Parameters.FirstOrDefault(x => x.ParameterName == "Max_Actor_Movie").Value;
            int max_actor_movie = max_actor_movie1 == null ? 8 : max_actor_movie1.Value;
            ViewBag.Max_Actor_Movie = max_actor_movie;
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddActors(int id, [Bind("MovieId,MovieName,Image,Description,Time,PublishedYear,MovieLink,TypeId,Episode,Viewed,Status,CountryId,Director,MovieLinkContingency,MovieLinkTrailer,ImageSlider,Alias,EpisodeLimit,DirectorAlias")] Movie movie, int Actors_1, int Actors_2, int Actors_3, int Actors_4, int Actors_5, int Actors_6, int Actors_7, int Actors_8)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(Actors_1 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_1);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_2 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_2);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_3 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_3);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_4 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_4);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_5 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_5);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_6 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_6);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_7 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_7);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }
                    if (Actors_8 != 0)
                    {
                        var actor = _context.Actors.FirstOrDefault(x => x.ActorId == Actors_8);
                        if (actor != null)
                        {
                            movie.Actors.Add((Actor)actor);
                        }
                    }

                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DienVien"] = new SelectList(_context.Actors, "ActorId", "ActorName", movie.Actors);
            
            return View(movie);
        }

        public async Task<IActionResult> AddCat(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            var max_cat_movie1 = _context.Parameters.FirstOrDefault(x => x.ParameterName == "Max_Cat_Movie").Value;
            int max_cat_movie = max_cat_movie1 == null ? 8 : max_cat_movie1.Value;
            ViewBag.Max_Cat_Movie = max_cat_movie;
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCat(int id, [Bind("MovieId,MovieName,Image,Description,Time,PublishedYear,MovieLink,TypeId,Episode,Viewed,Status,CountryId,Director,MovieLinkContingency,MovieLinkTrailer,ImageSlider,Alias,EpisodeLimit,DirectorAlias")] Movie movie, int Cat_1, int Cat_2, int Cat_3, int Cat_4, int Cat_5, int Cat_6, int Cat_7, int Cat_8)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Cat_1 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_1);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_2 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_2);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_3 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_3);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_4 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_4);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_5 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_5);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_6 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_6);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_7 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_7);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }
                    if (Cat_8 != 0)
                    {
                        var cat = _context.Categories.FirstOrDefault(x => x.CategoryId == Cat_8);
                        if (cat != null)
                        {
                            movie.Categories.Add((Category)cat);
                        }
                    }

                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", movie.Categories);

            return View(movie);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,Image,Description,Time,PublishedYear,MovieLink,TypeId,Episode,Viewed,Status,CountryId,Director,MovieLinkContingency,MovieLinkTrailer,ImageSlider,Alias,EpisodeLimit,DirectorAlias")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", movie.CountryId);
            ViewData["TypeId"] = new SelectList(_context.Types, "TypeId", "TypeName", movie.TypeId);
            return View(movie);
        }

        // POST: Admin/AdminMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        // GET: Admin/AdminMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Country)
                .Include(m => m.Type)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Admin/AdminMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
