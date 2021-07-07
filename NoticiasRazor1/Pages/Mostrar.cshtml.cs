using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoticiasMVC.Models;

namespace NoticiasRazor1.Pages
{
    public class MostrarModel : PageModel
    {
        private SqlConnection _conexion;
        public MostrarModel() {
            var cn = new Conexion();
            _conexion = cn.conexion;
        }
        public NoticiasModel Noticia { get; set; }
        public void OnGet(int NoticiaId)
        {
            var parametros = new { @IdNoticia= NoticiaId };
           var noticiaUnica = _conexion.QuerySingle<NoticiasModel>("ObtenerNoticiaPorId", parametros, commandType: CommandType.StoredProcedure);
            Noticia = noticiaUnica;
        }
    }
}
