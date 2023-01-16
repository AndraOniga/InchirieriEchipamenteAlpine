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
    public class DeleteModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public DeleteModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EchipamentAlpin EchipamentAlpin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EchipamentAlpin == null)
            {
                return NotFound();
            }

            var echipamentalpin = await _context.EchipamentAlpin.FirstOrDefaultAsync(m => m.ID == id);

            if (echipamentalpin == null)
            {
                return NotFound();
            }
            else 
            {
                EchipamentAlpin = echipamentalpin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EchipamentAlpin == null)
            {
                return NotFound();
            }
            var echipamentalpin = await _context.EchipamentAlpin.FindAsync(id);

            if (echipamentalpin != null)
            {
                EchipamentAlpin = echipamentalpin;
                _context.EchipamentAlpin.Remove(EchipamentAlpin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
