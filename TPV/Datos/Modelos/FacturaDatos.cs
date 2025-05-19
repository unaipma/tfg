using Datos.Modelos;
using System.Collections.Generic;
using System;

public class FacturaDatos
{
    public int Id { get; set; }
    public UsuarioDatos Vendedor { get; set; } // Usuario que realizó la venta
    public decimal Total { get; set; } // Monto total de la factura
    public DateTime FechaVenta { get; set; } // Fecha de la venta
    public List<ProductoDatos> ProductosVendidos { get; set; } // Lista de productos vendidos
    public bool Tarjeta { get; set; }
    public bool Guardada { get; set; } // Indica si la factura ha sido guardada en la base de datos

    // Constructor para inicializar los valores
    public FacturaDatos(int id, UsuarioDatos vendedor, decimal total, List<ProductoDatos> productosVendidos, bool tarjeta)
    {
        Id = id;
        Vendedor = vendedor;
        Total = total;
        FechaVenta = DateTime.Now;
        ProductosVendidos = productosVendidos ?? new List<ProductoDatos>();
        Tarjeta = tarjeta;
        // Por defecto, la factura no está guardada
    }
    public FacturaDatos(int id, UsuarioDatos vendedor, decimal total, List<ProductoDatos> productosVendidos, bool tarjeta,bool guardada)
    {
        Id = id;
        Vendedor = vendedor;
        Total = total;
        FechaVenta = DateTime.Now;
        ProductosVendidos = productosVendidos ?? new List<ProductoDatos>();
        Tarjeta = tarjeta;
        Guardada = guardada;
        // Por defecto, la factura no está guardada
    }

    public FacturaDatos() { }
}
