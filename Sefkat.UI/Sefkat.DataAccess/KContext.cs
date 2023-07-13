using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sefkat.Entity;

namespace Sefkat.DataAccess
{
    public class KContext : DbContext
    { 
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-9PO64MS\SQLEXPRESS;Database=InsaatKatmanli;Trusted_Connection=True;");
            }
            public DbSet<Slider> Sliderlar { get; set; }
            public DbSet<Ayarlar> Ayarlar { get; set; }
            public DbSet<Blog> Bloglar { get; set; }
            public DbSet<Iletisimcs> Iletisimcs { get; set; }
            public DbSet<IsBasvuru> IsBasvuru { get; set; }
            public DbSet<Login> Login { get; set; }
            public DbSet<Ev> Ev { get; set; }
            public DbSet<Proje> Proje { get; set; }
    }
    }
