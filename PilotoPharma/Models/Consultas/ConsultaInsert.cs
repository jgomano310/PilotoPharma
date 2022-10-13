using Npgsql;
using PilotoPharma.Models.DTO;

namespace PilotoPharma.Models.Consultas
{
    public class ConsultaInsert
    {
        public static void ConsultaInsertSql(NpgsqlConnection conexionGenerada)
        {
            List<ProductosDTO> listaAsignaturas = new List<ProductosDTO>();
            try
            {
                //Se define y se ejectua
                NpgsqlCommand consulta = new NpgsqlCommand("INSERT INTO \"dlk_operacional_productos\".\"opr_cat_productos\" " +
                    "( md_fch, id_producto, cod_producto,nombre_producto,tipo_producto_origen,tipo_producto_clase,des_producto,fch_alta_producto,fch_baja_producto) VALUES" +
                    " ('1', '1', '123','10','213','456','34563',34631','2364',346236'");
                

                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //se convierte a lista de alumnoDTO
               

                
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            
        }
    }
}
