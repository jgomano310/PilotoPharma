using Microsoft.AspNetCore.Mvc;
using Npgsql;
using PilotoPharma.Models;
using PilotoPharma.Models.Conexiones;
using PilotoPharma.Models.Consultas;
using PilotoPharma.Models.DTO;
using PilotoPharma.Util;
using System.Diagnostics;

namespace PilotoPharma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexiónProductos conexionPostgreSQL)
        {
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexión.HOST;
            const string PORT = VariablesConexión.PORT;
            const string USER = VariablesConexión.USER;
            const string PASS = VariablesConexión.PASS;
            const string DB = VariablesConexión.DB;

            //Se genera una conexión a PostgreSQL
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            List<ProductosDTO> ListaProductos = new List<ProductosDTO>();
            

            //NpgsqlCommand consulta = new NpgsqlCommand();
            conexionGenerada = ConexiónProductos.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("Estado conexión generada: " + estadoGenerada);

            //Se realiza la consulta y se guarda una lista de ProductosDTO
            
            ListaProductos = ConsultaProductos.ConsultaProductosSql(conexionGenerada);
            
            foreach (ProductosDTO asign in ListaProductos)
            {
                Console.WriteLine(asign.md_uuid + " " + asign.md_fch + " " + asign.id_producto + asign.cod_producto+
                   asign.nombre_producto + " " + asign.tipo_producto_origen+ " " +asign.tipo_producto_clase+" "+asign.des_producto+" "+
                   asign.fch_alta_producto+" "+ asign.fch_baja_producto);
                /* md_uuid = Md_uuid;
            md_fch = Md_fch;
            id_producto = Id_producto;
            cod_producto = Cod_producto;
            nombre_producto = Nombre_producto;
            tipo_producto_origen = Tipo_producto_origen;
            tipo_producto_clase = Tipo_producto_clase;
            des_producto = Des_producto;
            fch_alta_producto = Fch_alta_producto;
            fch_baja_producto = Fch_baja_producto;*/

            }
            conexionGenerada.Close();

            int cont = ListaProductos.Count();


            return View();
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