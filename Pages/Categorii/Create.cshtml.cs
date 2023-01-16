using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;

namespace InchirieriEchipamenteAlpine.Pages.Categorii
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
            return Page();
        }

        [BindProperty]
        public Categorie Categorie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categorie.Add(Categorie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
