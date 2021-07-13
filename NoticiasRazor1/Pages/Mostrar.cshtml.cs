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
        public IActionResult OnGet(int NoticiaId)
        {
            if (NoticiaId == 0) { return RedirectToPage("Index"); }
            var parametros = new { @IdNoticia= NoticiaId };
            NoticiasModel noticiaUnica = new NoticiasModel();
            try { 
            noticiaUnica = _conexion.QuerySingle<NoticiasModel>("ObtenerNoticiaPorId", parametros, commandType: CommandType.StoredProcedure);
           
            } catch (Exception error) {
             return RedirectToPage("Index");
            }
             if (noticiaUnica ==null) { return RedirectToPage("Index"); }
            Noticia = noticiaUnica;
            return Page();
        }
    }
}
