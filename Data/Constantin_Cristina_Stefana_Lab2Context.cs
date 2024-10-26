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
    }
}
