using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasMVC.Models
{
    public class ArticulosNoticias
    {
        [Key] 
        public int IdNoticias { get; set; }
        public string Articulo { get; set; }
        public string Titulo  { get; set; }
        public int PaisId { get; set; }
        public DateTime Fecha { get; set; }
        public int CategoriaId { get; set; }
    }
}
