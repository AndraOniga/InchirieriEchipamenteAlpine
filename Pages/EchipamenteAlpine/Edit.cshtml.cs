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
    public class EditModel : CategoriiEchipamentePageModel
    {
        private readonly InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext _context;

        public EditModel(InchirieriEchipamenteAlpine.Data.InchirieriEchipamenteAlpineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EchipamentAlpin EchipamentAlpin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EchipamentAlpin == null)
            {
                return NotFound();
            }

            EchipamentAlpin = await _context.EchipamentAlpin
 .Include(b => b.Producator)
 .Include(b => b.CategoriiEchipamente).ThenInclude(b => b.Categorie)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);
            if (EchipamentAlpin == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, EchipamentAlpin);

            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID",
"NumeDistribuitor");
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID",
"NumeProducator");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var equipmentToUpdate = await _context.EchipamentAlpin
            .Include(i => i.Producator)
            .Include(i => i.CategoriiEchipamente)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (equipmentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<EchipamentAlpin>(
            equipmentToUpdate,
            "EchipamentAlpin",
            i => i.Denumire, i => i.Producator,
            i => i.Pret, i => i.DataIntrareStoc, i => i.DistribuitorID))
            {
                UpdateEquipmentCategories(_context, selectedCategories, equipmentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateEquipmentCategories(_context, selectedCategories, equipmentToUpdate);
            PopulateAssignedCategoryData(_context, equipmentToUpdate);
            return Page();
        }
    }
}
