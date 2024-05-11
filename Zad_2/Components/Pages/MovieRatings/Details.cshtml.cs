using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zad_2.Data;

namespace Zad_2.Components.Pages.MovieRatings
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        [BindProperty]
        public float NewRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var movieToUpdate = await _context.Movie.FindAsync(Movie.Id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (movieToUpdate.Rate.HasValue)
            {
                movieToUpdate.Rate = (movieToUpdate.Rate + NewRate) / 2;
            }
            else
            {
                movieToUpdate.Rate = NewRate;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage(new { id = movieToUpdate.Id });
        }
    }
}