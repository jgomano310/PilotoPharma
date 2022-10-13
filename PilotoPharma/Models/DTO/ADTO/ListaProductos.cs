using Npgsql;

namespace PilotoPharma.Models.DTO.ADTO
{
    public class ListaProductos
    {
        public static List<ProductosDTO> LeeProductos(NpgsqlDataReader resultado)
        {
            List<ProductosDTO> lista = new List<ProductosDTO>();
            while (resultado.Read())
            {
                lista.Add(new ProductosDTO(
                   (int)resultado[0],
                   (int)resultado[1],
                    (int)resultado[2],
                    (int)resultado[3],
                    resultado[4].ToString(),
                    (int)resultado[5],
                    (int)resultado[6],
                    (int)resultado[7],
                    resultado[8].ToString(),
                    resultado[9].ToString()));
            }
            return lista;
        }
    }
}
