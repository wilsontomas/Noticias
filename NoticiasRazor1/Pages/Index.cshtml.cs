using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NoticiasMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasRazor1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private SqlConnection _conexion;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var cn = new Conexion();
            _conexion = cn.conexion;
        }
        public List<NoticiasModel> ListaNoticias { get; set; }
        public void OnGet()
        {
           var noticias = _conexion.Query<NoticiasModel>("ObtenerNoticiasModel", null, commandType: CommandType.StoredProcedure).ToList();
            ListaNoticias = noticias;
        }
    }
}
