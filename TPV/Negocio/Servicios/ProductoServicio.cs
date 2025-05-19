using Datos.Modelos;
using Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Negocio.Servicios
{
    /// <summary>
    /// Servicio que gestiona la lógica de negocio relacionada con productos.
    /// </summary>
    public class ProductoServicio
    {
        private readonly ProductoMétodos pmetodos = new ProductoMétodos();

        /// <summary>
        /// Convierte un arreglo de bytes en una imagen <see cref="Image"/>.
        /// </summary>
        /// <param name="byteArray">Arreglo de bytes que representa la imagen.</param>
        /// <returns>Imagen convertida o null si el arreglo es null.</returns>
        public Image parseByteImage(byte[] byteArray)
        {
            if (byteArray == null) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Convierte una imagen en un arreglo de bytes en formato PNG.
        /// </summary>
        /// <param name="image">Imagen a convertir.</param>
        /// <returns>Arreglo de bytes o null si la imagen es null.</returns>
        public byte[] parseImageBytea(Image image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Obtiene todos los productos almacenados.
        /// </summary>
        /// <returns>Lista de productos en formato <see cref="ProductoNegocio"/>.</returns>
        public List<ProductoNegocio> ObtenerProductos()
        {
            List<ProductoNegocio> productos = new List<ProductoNegocio>();
            foreach (ProductoDatos pdatos in pmetodos.ObtenerProductos())
            {
                productos.Add(toNegocio(pdatos));
            }
            return productos;
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="producto">Producto en formato de negocio.</param>
        /// <returns>True si se actualizó correctamente; false en caso contrario.</returns>
        public bool ActualizarProducto(ProductoNegocio producto)
        {
            return pmetodos.EditarProducto(toDatos(producto));
        }

        /// <summary>
        /// Elimina un producto según su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto a eliminar.</param>
        /// <returns>True si se eliminó correctamente; false en caso contrario.</returns>
        public bool EliminarProducto(int id)
        {
            return pmetodos.EliminarProducto(id);
        }

        /// <summary>
        /// Convierte una instancia de <see cref="ProductoDatos"/> a <see cref="ProductoNegocio"/>.
        /// </summary>
        /// <param name="pdatos">Producto en formato de datos.</param>
        /// <returns>Producto convertido al modelo de negocio.</returns>
        public ProductoNegocio toNegocio(ProductoDatos pdatos)
        {
            return new ProductoNegocio
            {
                Id = pdatos.Id,
                Nombre = pdatos.Nombre,
                Precio = pdatos.Precio,
                Categoria = pdatos.Categoria,
                Imagen = parseByteImage(pdatos.Imagen)
            };
        }

        /// <summary>
        /// Convierte una instancia de <see cref="ProductoNegocio"/> a <see cref="ProductoDatos"/>.
        /// </summary>
        /// <param name="producto">Producto en formato de negocio.</param>
        /// <returns>Producto convertido al modelo de datos.</returns>
        public ProductoDatos toDatos(ProductoNegocio producto)
        {
            return new ProductoDatos
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                Imagen = producto.Imagen != null ? parseImageBytea(producto.Imagen) : null
            };
        }

        /// <summary>
        /// Añade un nuevo producto al sistema.
        /// </summary>
        /// <param name="producto">Producto en formato de negocio.</param>
        /// <returns>True si se añadió correctamente; false en caso contrario.</returns>
        public bool AñadirProducto(ProductoNegocio producto)
        {
            return pmetodos.AñadirProducto(toDatos(producto));
        }
    }
}
