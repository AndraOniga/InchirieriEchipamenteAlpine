using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;

namespace InchirieriEchipamenteAlpine.Pages.Producatori
{
    public class DetailsModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public DetailsModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

      public Producator Producator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }

            var producator = await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);
            if (producator == null)
            {
                return NotFound();
            }
            else 
            {
                Producator = producator;
            }
            return Page();
        }
    }
}
