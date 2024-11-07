using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Constantin_Cristina_Stefana_Lab2.Models;

namespace Constantin_Cristina_Stefana_Lab2.Data
{
    public class Constantin_Cristina_Stefana_Lab2Context : DbContext
    {
        public Constantin_Cristina_Stefana_Lab2Context (DbContextOptions<Constantin_Cristina_Stefana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.BookCategory> BookCategory { get; set; } = default!;
        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
        public DbSet<Constantin_Cristina_Stefana_Lab2.Models.Member> Member { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.Borrowings)
                .HasForeignKey(b => b.BookID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Borrowings)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

