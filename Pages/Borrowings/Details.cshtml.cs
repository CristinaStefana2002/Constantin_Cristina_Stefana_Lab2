using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Constantin_Cristina_Stefana_Lab2.Data;
using Constantin_Cristina_Stefana_Lab2.Models;

namespace Constantin_Cristina_Stefana_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context _context;

        public DetailsModel(Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var borrowing = _context.Borrowing
                            .Include(b => b.Member)
                            .Include(b => b.Book)
                            .ThenInclude(book => book.Author)
                            .FirstOrDefault(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
