using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class FacPosDatos
    {
        public int Id { get; set; }
        public decimal Ganancias { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public string Ubicacion { get; set; }

      
        public FacPosDatos(int id, decimal ganancias, DateTime fecha, string concepto, string ubicacion)
        {
            Id = id;
            Ganancias = ganancias;
            Fecha = fecha;
            Concepto = concepto;
            Ubicacion = ubicacion;
        }

        public FacPosDatos()
        {
        }
    }
}
