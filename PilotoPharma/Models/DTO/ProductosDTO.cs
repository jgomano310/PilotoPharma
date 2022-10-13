namespace PilotoPharma.Models.DTO
{
    public class ProductosDTO
    {
        public int md_uuid { get; private set; }
        
        public int md_fch { get; private set; }
        public int id_producto { get; private set; }
        public int cod_producto { get; private set; }

        public string nombre_producto { get; private set; }

        public int tipo_producto_origen { get; private set; }

        public int tipo_producto_clase { get; private set; }

        public int des_producto { get; private set; }

        public string fch_alta_producto { get; private set; }

        public string fch_baja_producto { get; private set; }

        //Constructor ProductosDTO 
        public ProductosDTO(int Md_uuid, int Md_fch, int Id_producto, int Cod_producto, string Nombre_producto, int Tipo_producto_origen,
            int Tipo_producto_clase, int Des_producto, string Fch_alta_producto, string Fch_baja_producto)
        { 
            md_uuid = Md_uuid;
            md_fch = Md_fch;
            id_producto = Id_producto;
            cod_producto = Cod_producto;
            nombre_producto = Nombre_producto;
            tipo_producto_origen = Tipo_producto_origen;
            tipo_producto_clase = Tipo_producto_clase;
            des_producto = Des_producto;
            fch_alta_producto = Fch_alta_producto;
            fch_baja_producto = Fch_baja_producto;
        }
    }
}
