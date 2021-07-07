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
    public class PaisModel : PageModel
    {
        private SqlConnection _conexion;
        public PaisModel()
        {
            var cn = new Conexion();
            _conexion = cn.conexion;
        }
        public List<NoticiasModel> ListaNoticias { get; set; }
        public void OnGet(int PaisId)
        {
            var parametros = new { @idpais = PaisId };
            var ListaPorCategoria = _conexion.Query<NoticiasModel>("ObtenerNoticiasPorPais", parametros, commandType: CommandType.StoredProcedure).ToList();
            ListaNoticias = ListaPorCategoria;
        }
    }
}
