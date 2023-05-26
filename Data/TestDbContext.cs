using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestDb.Models;

namespace TestDb.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext (DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }
        
       

        public DbSet<TestDb.Models.Editorial> Editorial { get; set; } = default!;

        public DbSet<TestDb.Models.Libro>? Libro { get; set; } = default!;

        public DbSet<TestDb.Models.Autor>? Autor { get; set; } = default!;

        public DbSet<TestDb.Models.Usuario>? Usuario { get; set; }

        public DbSet<TestDb.Models.Prestamo>? Prestamo { get; set; }

        public DbSet<TestDb.Models.PrestamoInfo>? PrestamoInfo { get; set; }


    }
}
