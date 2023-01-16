using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Models;
using InchirieriEchipamenteAlpine.Models.ViewModels;

namespace InchirieriEchipamenteAlpine.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public IndexModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int EchipamentAlpinID { get; set; }

        public async Task OnGetAsync(int? id, int? EchipamentAlpinID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
                .Include(i => i.CategoriiEchipamente)
                .ThenInclude(i => i.EchipamentAlpin)
                .ThenInclude(i => i.Producator)
                .OrderBy(i => i.NumeCategorie)
                .ToListAsync();

            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii.Where(i => i.ID == id.Value).Single();
                CategorieData.CategoriiEchipamente = categorie.CategoriiEchipamente;

            }
        }
    }
}