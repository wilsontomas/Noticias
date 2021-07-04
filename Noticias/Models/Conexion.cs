using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasMVC.Models
{
    public class Conexion
    {
        private SqlConnection _conexion { get; set; }

        public SqlConnection conexion { get {
                if (this._conexion == null) { this._conexion = new SqlConnection("Data Source=DESKTOP-V32QJTJ\\SQLEXPRESS;Initial Catalog=Noticias;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); }
                return this._conexion;
            } }

    }
}
