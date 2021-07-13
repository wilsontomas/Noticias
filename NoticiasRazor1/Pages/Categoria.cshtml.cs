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
        public IActionResult OnGet(int CategoriaId)
        {
            if (CategoriaId ==0) { return RedirectToPage("Index"); }
            var parametros = new { @idcategoria= CategoriaId };
            List<NoticiasModel> ListaPorCategoria = new List<NoticiasModel>(); 
            
            try { 
            ListaPorCategoria = _conexion.Query<NoticiasModel>("ObtenerNoticiasPorCategoria", parametros, commandType: CommandType.StoredProcedure).ToList();

            } catch (Exception e) {
                return RedirectToPage("Index");
            }
            if (ListaPorCategoria.Count == 0) { return RedirectToPage("Index"); }
            ListaNoticias = ListaPorCategoria;
            return Page();
        }
    }
}
