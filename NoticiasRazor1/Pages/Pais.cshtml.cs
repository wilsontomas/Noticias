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
        public IActionResult OnGet(int PaisId)
        {
            if (PaisId == 0) { return RedirectToPage("Index"); }
            var parametros = new { @idpais = PaisId };
            List<NoticiasModel> ListaPorPais = new List<NoticiasModel>();
            try
            {
                ListaPorPais = _conexion.Query<NoticiasModel>("ObtenerNoticiasPorPais", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e) {
                return RedirectToPage("Index");
            }
            if (ListaPorPais.Count ==0) { return RedirectToPage("Index"); }
            ListaNoticias = ListaPorPais;
            return Page();
        }

    }
}
