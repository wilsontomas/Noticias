using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasMVC.Models
{
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
    }
}
