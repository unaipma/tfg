using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class UsuarioDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Localizacion { get; set; }
        public byte[] Foto { get; set; }

        public UsuarioDatos() { }
    }
}
