using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskApplication.Data;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MegaDeskApplication.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskApplication.Data.MegaDeskApplicationContext _context;

        public IndexModel(MegaDeskApplication.Data.MegaDeskApplicationContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.CustomerName.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
