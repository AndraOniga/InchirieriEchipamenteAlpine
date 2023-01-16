using Microsoft.AspNetCore.Mvc.RazorPages;
using InchirieriEchipamenteAlpine.Data;
using InchirieriEchipamenteAlpine.Migrations;


namespace InchirieriEchipamenteAlpine.Models
{
    public class CategoriiEchipamentePageModel : PageModel
    {
        public List<CategoriePeEchipament> CategoriePeEchipamentDataList;
        public void PopulateAssignedCategoryData(InchirieriEchipamenteAlpineContext context,
        EchipamentAlpin echipamentAlpin)
        {
            var allCategories = context.Categorie;
            var equipmentCategories = new HashSet<int>(
            echipamentAlpin.CategoriiEchipamente.Select(c => c.CategorieID)); //
            CategoriePeEchipamentDataList = new List<CategoriePeEchipament>();
            foreach (var cat in allCategories)
            {
                CategoriePeEchipamentDataList.Add(new CategoriePeEchipament
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Selectat = equipmentCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateEquipmentCategories(InchirieriEchipamenteAlpineContext context,
        string[] selectedCategories, EchipamentAlpin equipmentToUpdate)
        {
            if (selectedCategories == null)
            {
                equipmentToUpdate.CategoriiEchipamente = new List<CategorieEchipament>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var equipmentCategories = new HashSet<int>
            (equipmentToUpdate.CategoriiEchipamente.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!equipmentCategories.Contains(cat.ID))
                    {
                        equipmentToUpdate.CategoriiEchipamente.Add(
                        new CategorieEchipament
                        {
                            EchipamentAlpinID = equipmentToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (equipmentCategories.Contains(cat.ID))
                    {
                        CategorieEchipament courseToRemove
                        = equipmentToUpdate
                        .CategoriiEchipamente
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
