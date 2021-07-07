using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasMVC.Models
{
    public class RegistrosDto
    {
        public List<Categoria> categoria { get; set; }
        public List<Pais> pais { get; set; }
        public List<NoticiasModel>  noticiasModel { get; set; }
    }
}
