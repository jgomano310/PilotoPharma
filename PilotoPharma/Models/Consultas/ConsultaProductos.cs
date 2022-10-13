using Npgsql;
using PilotoPharma.Models.DTO;

namespace PilotoPharma.Models.Consultas
{
    public class ConsultaProductos
    {
        public static List<ProductosDTO> ConsultaProductosSql(NpgsqlConnection conexionGenerada)
        {
            List<ProductosDTO> listaAsignaturas = new List<ProductosDTO>();
            try
            {
                //Se define y se ejectua

                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"opr_cat_productos\"", conexionGenerada);
                


               
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //se convierte a lista de alumnoDTO
                listaAsignaturas = DTO.ADTO.ListaProductos.LeeProductos(resultadoConsulta);
                int cont = listaAsignaturas.Count();
                System.Console.WriteLine("[INFORMACIÓN-Consultas-ConsultaProductos] Lista compuesta por: " + cont + " productos");

                System.Console.WriteLine("[INFORMACIÓN-Consultas-ConsultaProductos] Cierre conexión y conjunto de datos");
                conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listaAsignaturas;
        }
    }
}
