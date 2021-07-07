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
    public class CategoriaModel : PageModel
    {
        private SqlConnection _conexion;
        public CategoriaModel() {
            var cn = new Conexion();
            _conexion = cn.conexion;
        }
        public List<NoticiasModel> ListaNoticias { get; set; }
        public void OnGet(int CategoriaId)
        {
            var parametros = new { @idcategoria= CategoriaId };
            var ListaPorCategoria = _conexion.Query<NoticiasModel>("ObtenerNoticiasPorCategoria", parametros, commandType: CommandType.StoredProcedure).ToList();
            ListaNoticias = ListaPorCategoria;
        }
    }
}
