using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelos
{
    public class ProductoNegocio
    {
        public int Id { get; set; }
        public Image Imagen { get; set; }  // Se almacena la imagen como un array de bytes
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
