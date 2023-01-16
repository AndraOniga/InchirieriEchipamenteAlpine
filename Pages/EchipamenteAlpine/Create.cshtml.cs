using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace InchirieriEchipamenteAlpine.Pages.EchipamenteAlpine
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : CategoriiEchipamentePageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public CreateModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()

        {
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID",
"NumeDistribuitor");
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID",
"NumeProducator");
            var echipamentAlpin = new EchipamentAlpin();
            echipamentAlpin.CategoriiEchipamente = new List<CategorieEchipament>();
            PopulateAssignedCategoryData(_context, echipamentAlpin);
            return Page();
        }

        [BindProperty]
        public EchipamentAlpin EchipamentAlpin { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var echipamentNou =  EchipamentAlpin;
            if (selectedCategories != null)
            {
                echipamentNou.CategoriiEchipamente = new List<CategorieEchipament>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieEchipament
                    {
                        CategorieID = int.Parse(cat)
                    };
                    echipamentNou.CategoriiEchipamente.Add(catToAdd);
                }
            }
            //EchipamentAlpin.CategoriiEchipamente = echipamentNou.CategoriiEchipamente;
            _context.EchipamentAlpin.Add(echipamentNou);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, echipamentNou);
            return Page();
        }
        
    }

}
