using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelos
{
    public class FacturaNegocio
    {
        public int Id { get; set; }
        public UsuarioNegocio Vendedor { get; set; }
        public decimal Total { get; set; } 
        public DateTime FechaVenta { get; set; } 
        public List<ProductoNegocio> ProductosVendidos { get; set; } 

        public bool tarjeta{ get; set; }

        public bool Guardada { get; set; } 


        public FacturaNegocio(int Id,UsuarioNegocio vendedor, decimal total, List<ProductoNegocio> productosVendidos, bool tarjeta)
        {
            this.Id = Id;
            Vendedor = vendedor;
            Total = total;
            FechaVenta = DateTime.Now;
            ProductosVendidos = productosVendidos ?? new List<ProductoNegocio>(); 
            this.tarjeta = tarjeta;
          
        }
        public FacturaNegocio(int Id, UsuarioNegocio vendedor, decimal total, List<ProductoNegocio> productosVendidos, bool tarjeta,bool guardada)
        {
            this.Id = Id;
            Vendedor = vendedor;
            Total = total;
            FechaVenta = DateTime.Now;
            ProductosVendidos = productosVendidos ?? new List<ProductoNegocio>(); // Evita null
            this.tarjeta = tarjeta;
            Guardada = guardada;

        }
        public FacturaNegocio()
        {
        }
    }
}
