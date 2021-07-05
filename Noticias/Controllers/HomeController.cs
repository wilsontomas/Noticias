using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Noticias.Models;
using NoticiasMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Noticias.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public NoticiasContext _noticiasContext;
        private readonly Conexion _conexion;
        public HomeController(ILogger<HomeController> logger)
        {
            _conexion = new Conexion();
           // _noticiasContext = NoticiasContext;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            List<NoticiasModel> noticias = _conexion.conexion.Query<NoticiasModel>("ObtenerNoticiasModel", null, commandType: CommandType.StoredProcedure).ToList();
            List<Pais> pais =  _conexion.conexion.Query<Pais>("ObtenerPais", null, commandType: CommandType.StoredProcedure).ToList();
            List<Categoria> categorias = _conexion.conexion.Query<Categoria>("ObtenerCategoria", null, commandType: CommandType.StoredProcedure).ToList();

            var Registros = new RegistrosDto();
            Registros.noticiasModel = noticias;
            Registros.categoria = categorias;
            Registros.pais = pais;
            return View(Registros);
        }
        [HttpPost]
        public IActionResult AgregarNoticia(ArticulosNoticias articulosNoticias) {
            articulosNoticias.Fecha = DateTime.Now;
            var parametros = new { @Titulo= articulosNoticias.Titulo, @Articulo = articulosNoticias.Articulo, @CategoriaId = articulosNoticias.CategoriaId, @PaisId = articulosNoticias.PaisId };
            _conexion.conexion.Query("InsertarNoticia", parametros, commandType: CommandType.StoredProcedure).ToList();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EliminarNoticia(int Id) {
            var parametros = new { @IdNoticia=Id };
            _conexion.conexion.Query("EditarNoticia", parametros, commandType: CommandType.StoredProcedure).ToList();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditarNoticia(int Id)
        {
            var parametros = new { @IdNoticia = Id };
            var noticia = _conexion.conexion.Query<ArticulosNoticias>("ObtenerNoticiaPorId", parametros, commandType: CommandType.StoredProcedure).ToList();

            if (noticia.Count !=1) { return RedirectToAction("Index"); }

            List<Pais> pais = _conexion.conexion.Query<Pais>("ObtenerPais", null, commandType: CommandType.StoredProcedure).ToList();
            List<Categoria> categorias = _conexion.conexion.Query<Categoria>("ObtenerCategoria", null, commandType: CommandType.StoredProcedure).ToList();
            var Registros = new EdicionModel();
            Registros.articulosNoticias = noticia;
            Registros.categoria = categorias;
            Registros.pais = pais;
            return View(Registros);
        }

        [HttpPost]
        public IActionResult Editar(ArticulosNoticias articulosNoticias)
        {
            var parametros = new
            {
                @IdNoticias = articulosNoticias.IdNoticias,
                @Titulo = articulosNoticias.Titulo,
                @Articulo = articulosNoticias.Articulo,
                @CategoriaId = articulosNoticias.CategoriaId,
                @PaisId = articulosNoticias.PaisId
            };
            _conexion.conexion.Query("EditarNoticia", parametros, commandType: CommandType.StoredProcedure).ToList();

            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
