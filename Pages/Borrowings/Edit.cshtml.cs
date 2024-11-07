using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Constantin_Cristina_Stefana_Lab2.Data;
using Constantin_Cristina_Stefana_Lab2.Models;

namespace Constantin_Cristina_Stefana_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context _context;

        public EditModel(Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
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
                                        .FirstOrDefault(m => m.ID == id); if (borrowing == null)
            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;

            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName", borrowing.MemberID);
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title", borrowing.BookID);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
