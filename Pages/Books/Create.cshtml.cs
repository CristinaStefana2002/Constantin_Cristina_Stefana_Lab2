﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Constantin_Cristina_Stefana_Lab2.Data;
using Constantin_Cristina_Stefana_Lab2.Models;

namespace Constantin_Cristina_Stefana_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context _context;

        public CreateModel(Constantin_Cristina_Stefana_Lab2.Data.Constantin_Cristina_Stefana_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            var authors = _context.Author.Select(a => new
            {
                a.ID,
                Name = a.FirstName + " " + a.LastName  
            }).ToList();

            ViewData["AuthorID"] = new SelectList(authors, "ID", "Name");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
"PublisherName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();

            PopulateAssignedCategoryData(_context, book);
            return Page();
        }


        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
