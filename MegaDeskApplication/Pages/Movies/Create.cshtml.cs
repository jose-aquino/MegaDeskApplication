using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskApplication.Data;
using RazorPagesMovie.Models;

namespace MegaDeskApplication.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskApplication.Data.MegaDeskApplicationContext _context;
        //constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;
        private const decimal OAK_COST = 200.00M;
        private const decimal LAMINATE_COST = 100.00M;
        private const decimal PINE_COST = 50.00M;
        private const decimal ROSEWOOD_COST = 300.00M;
        private const decimal VENNER_COST = 125.00M;

        public CreateModel(MegaDeskApplication.Data.MegaDeskApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Movie.QuotePrice = GetQuotePrice(Movie);
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private decimal GetQuotePrice(Movie movie)
        {
            // return value
            decimal quotePrice = BASE_DESK_PRICE;

            // surface area
            decimal surfaceArea = movie.Length * movie.Width;

            // surface price
            decimal surfacePrice = 0.00M;

            if (surfaceArea > 1000)
            {
                surfacePrice = (surfaceArea - 1000) * SURFACE_AREA_COST;
            }

            // drawers
            switch (movie.Drawers)
            {
                case 1:
                    quotePrice += 50;
                    break;
                case 2:
                    quotePrice += 100;
                    break;
                case 3:
                    quotePrice += 150;
                    break;
                case 4:
                    quotePrice += 200;
                    break;
                case 5:
                    quotePrice += 250;
                    break;
                case 6:
                    quotePrice += 300;
                    break;
                case 7:
                    quotePrice += 350;
                    break;
            }
            // Surface Material
            decimal surfaceMaterialPrice = 0.00M;

            switch (movie.DesktopMaterial.ToUpper())
            {
                case "LAMINATE":
                    surfaceMaterialPrice = LAMINATE_COST;
                    break;
                case "OAK":
                    surfaceMaterialPrice = OAK_COST;
                    break;
                case "PINE":
                    surfaceMaterialPrice = PINE_COST;
                    break;
                case "ROSEWOOD":
                    surfaceMaterialPrice = ROSEWOOD_COST;
                    break;
                case "VENEER":
                    surfaceMaterialPrice = VENNER_COST;
                    break;
            }
            //3 days
            if (String.Equals(movie.Delivery, "3days"))
            {
                if (surfaceArea < 1000)
                {
                    quotePrice += 60;
                }
                else if (1000 <= surfaceArea && surfaceArea <= 2000)
                {
                    quotePrice += 70;
                }
                else if (surfaceArea > 2000)
                {
                    quotePrice += 80;
                }
            }
            // 5 days
            if (String.Equals(movie.Delivery, "5days"))
            {
                if (surfaceArea < 1000)
                {
                    quotePrice += 40;
                }
                else if (1000 <= surfaceArea && surfaceArea <= 2000)
                {
                    quotePrice += 50;
                }
                else if (surfaceArea > 2000)
                {
                    quotePrice += 60;
                }
            }
            if (String.Equals(movie.Delivery, "7days"))
            {
                if (surfaceArea < 1000)
                {
                    quotePrice += 30;
                }
                else if (1000 <= surfaceArea && surfaceArea <= 2000)
                {
                    quotePrice += 35;
                }
                else if (surfaceArea > 2000)
                {
                    quotePrice += 40;
                }
            }
            //TODO:
            return quotePrice + surfaceMaterialPrice + surfacePrice;
        }
    }
}
