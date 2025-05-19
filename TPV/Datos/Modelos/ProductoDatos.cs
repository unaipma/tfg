using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class ProductoDatos
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }  // Se almacena la imagen como un array de bytes
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
