using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelos
{
    public class UsuarioNegocio
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Localizacion { get; set; }

        public Image Foto { get; set; }


        public UsuarioNegocio() { }
        public override string ToString()
        {
            return Nombre; 
        }
    }


}
