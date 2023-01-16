﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;

namespace InchirieriEchipamenteAlpine.Pages.Inchirieri
{
    public class DetailsModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public DetailsModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

      public Inchiriere Inchiriere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }

            var inchiriere = await _context.Inchiriere.FirstOrDefaultAsync(m => m.ID == id);
            if (inchiriere == null)
            {
                return NotFound();
            }
            else 
            {
                Inchiriere = inchiriere;
            }
            return Page();
        }
    }
}
