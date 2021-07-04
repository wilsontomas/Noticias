using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasMVC.Models
{
    public class NoticiasContext:DbContext
    {
        public NoticiasContext(DbContextOptions<NoticiasContext> options):base(options) { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<ArticulosNoticias> articulosNoticias { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Pais> pais { get; set; }
    }
}
