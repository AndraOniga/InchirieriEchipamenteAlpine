using System;
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
    public class IndexModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public IndexModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IList<Inchiriere> Inchiriere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inchiriere != null)
            {
                Inchiriere = await _context.Inchiriere
                .Include(i => i.EchipamentAlpin)
                .ThenInclude(b => b.Producator)
                .Include(i => i.Membru).ToListAsync();
            }
        }
    }
}
