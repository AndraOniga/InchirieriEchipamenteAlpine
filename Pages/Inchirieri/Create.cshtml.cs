using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;
using Microsoft.EntityFrameworkCore;

namespace InchirieriEchipamenteAlpine.Pages.Inchirieri
{
    public class CreateModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public CreateModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        { 
       var echipamentealpine = _context.EchipamentAlpin.Include(b => b.Producator).Select(x => new { x.ID, Nume = x.Denumire });
        ViewData["EchipamentAlpinID"] = new SelectList(echipamentealpine, "ID", "Nume");
        ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "FullName");
        return Page();
    }

    [BindProperty]
        public Inchiriere Inchiriere { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inchiriere.Add(Inchiriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
