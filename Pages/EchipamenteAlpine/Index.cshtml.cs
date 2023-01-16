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
    public class IndexModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public IndexModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IList<EchipamentAlpin> EchipamentAlpin { get; set; } = default!;

        public EchipamentAlpinData EchipamentAlpinD { get; set; }
        public int EchipamentAlpinID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            EchipamentAlpinD = new EchipamentAlpinData();
            EchipamentAlpinD.EchipamenteAlpine = await _context.EchipamentAlpin
            .Include(b => b.Producator)
            .Include(b => b.Distribuitor)
            .Include(b => b.CategoriiEchipamente)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                EchipamentAlpinID = id.Value;
                EchipamentAlpin echipamentAlpin = EchipamentAlpinD.EchipamenteAlpine
                .Where(i => i.ID == id.Value).Single();
                EchipamentAlpinD.Categorii = echipamentAlpin.CategoriiEchipamente.Select(s => s.Categorie);
            }
            

        }
    }
}