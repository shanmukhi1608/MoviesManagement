using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Models;

namespace MoviesManagement.Controllers
{
    public class MoviesManagementsController : Controller
    {
        private readonly MoviesManagementContext _context;

        public MoviesManagementsController(MoviesManagementContext context)
        {
            _context = context;
        }

        // GET: MoviesManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: MoviesManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesManagement = await _context.Movies
                .FirstOrDefaultAsync(m => m.movie_id == id);
            if (moviesManagement == null)
            {
                return NotFound();
            }

            return View(moviesManagement);
        }

        // GET: MoviesManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoviesManagements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("movie_id,movie_title,movie_year,movie_language,movie_date_release,movie_ori_country")] Models.MoviesManagement moviesManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moviesManagement);
        }

        // GET: MoviesManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesManagement = await _context.Movies.FindAsync(id);
            if (moviesManagement == null)
            {
                return NotFound();
            }
            return View(moviesManagement);
        }

        // POST: MoviesManagements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("movie_id,movie_title,movie_year,movie_language,movie_date_release,movie_ori_country")] Models.MoviesManagement moviesManagement)
        {
            if (id != moviesManagement.movie_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesManagementExists(moviesManagement.movie_id))
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
            return View(moviesManagement);
        }

        // GET: MoviesManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesManagement = await _context.Movies
                .FirstOrDefaultAsync(m => m.movie_id == id);
            if (moviesManagement == null)
            {
                return NotFound();
            }

            return View(moviesManagement);
        }

        // POST: MoviesManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesManagement = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(moviesManagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesManagementExists(int id)
        {
            return _context.Movies.Any(e => e.movie_id == id);
        }
    }
}
