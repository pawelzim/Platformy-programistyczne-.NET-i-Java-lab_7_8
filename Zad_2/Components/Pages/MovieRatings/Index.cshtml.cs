using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zad_2.Data;

namespace Zad_2.Components.Pages.MovieRatings
{
    public class IndexModel : PageModel
    {
        private readonly Zad_2.Data.ApplicationDbContext _context;

        public IndexModel(Zad_2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
