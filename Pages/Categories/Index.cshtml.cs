using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Constantin_Cristina_Stefana_Lab2.Data;
using Constantin_Cristina_Stefana_Lab2.Models;
using Constantin_Cristina_Stefana_Lab2.Models.ViewModels;



namespace Constantin_Cristina_Stefana_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context _context;

        public IndexModel(Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context context)
        {
            _context = context;
        }
        public IList<Category> Category { get; set; } = default!;
        public CategoryIndex CategoryData { get; set; } 
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndex();

            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .AsNoTracking()
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                CategoryData.Category = CategoryData.Categories
                    .SingleOrDefault(c => c.ID == id.Value);

                CategoryData.Books = CategoryData.Category.BookCategories
                    .Select(bc => bc.Book)
                .Distinct();
            }
        }
    }
}
