using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;

namespace InchirieriEchipamenteAlpine.Pages.EchipamenteAlpine
{
    public class DetailsModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public DetailsModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

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
    }
}
