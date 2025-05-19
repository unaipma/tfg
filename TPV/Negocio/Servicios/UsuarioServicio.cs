using Datos.AccesoDatos;
using Datos.Conexiones;
using Datos.Modelos;
using Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Negocio.Servicios
{
    /// <summary>
    /// Servicio que gestiona la lógica de negocio relacionada con los usuarios.
    /// </summary>
    public class UsuarioServicio
    {
        private readonly UsuarioMetodos usuario;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de usuarios.
        /// </summary>
        public UsuarioServicio()
        {
            usuario = new UsuarioMetodos();
        }

        /// <summary>
        /// Verifica las credenciales del usuario y permite iniciar sesión.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <param name="contrasena">Contraseña en texto plano.</param>
        /// <returns>True si la autenticación es correcta; false en caso contrario.</returns>
        public bool IniciarSesion(string correo, string contrasena)
        {
            string storedHash = usuario.ObtenerHashUsuario(correo);
            if (string.IsNullOrEmpty(storedHash))
                return false;

            return Hasher.VerifyPassword(contrasena, storedHash);
        }

        /// <summary>
        /// Obtiene todas las ubicaciones únicas registradas por los usuarios.
        /// </summary>
        /// <returns>Lista de nombres de ubicaciones.</returns>
        public List<string> ObtenerUbicaciones()
        {
            Migrador migrador = new Migrador();
            migrador.MigrarProductos();
            migrador.MigrarUsuarios();
            return usuario.ObtenerUbicacionesDesdeUsuarios();
        }

        /// <summary>
        /// Obtiene todos los usuarios del sistema.
        /// </summary>
        /// <returns>Lista de objetos <see cref="UsuarioNegocio"/>.</returns>
        public List<UsuarioNegocio> ObtenerUsuarios()
        {
            List<UsuarioNegocio> listanegocio = new List<UsuarioNegocio>();
            List<UsuarioDatos> lista = usuario.ObtenerUsuarios();
            foreach (var item in lista)
            {
                UsuarioNegocio u = new UsuarioNegocio
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Rol = item.Rol,
                    Correo = item.Correo,
                    Localizacion = item.Localizacion,
                    Foto = parseByteImage(item.Foto)
                };
                listanegocio.Add(u);
            }
            return listanegocio;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">Objeto de usuario en formato de negocio.</param>
        /// <returns>True si se registró correctamente; false en caso contrario.</returns>
        public bool RegistrarUsuario(UsuarioNegocio usuario)
        {
            UsuarioDatos usuarioDatos = new UsuarioDatos
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol,
                Localizacion = usuario.Localizacion,
                Foto = parseImageBytea(usuario.Foto)
            };

            if (usuario.Rol == "admin")
            {
                usuarioDatos.Contraseña = Hasher.HashPassword(usuario.Contraseña);
            }

            return this.usuario.RegistrarUsuario(usuarioDatos);
        }

        /// <summary>
        /// Obtiene un usuario por su correo electrónico.
        /// </summary>
        /// <param name="correo">Correo del usuario.</param>
        /// <returns>Objeto <see cref="UsuarioNegocio"/> o null si no se encuentra.</returns>
        public UsuarioNegocio obtenerusuario(string correo)
        {
            var datos = usuario.ObtenerUsuario(correo);
            return datos != null ? parsetoNegocio(datos) : null;
        }

        /// <summary>
        /// Convierte un objeto <see cref="UsuarioDatos"/> a <see cref="UsuarioNegocio"/>.
        /// </summary>
        /// <param name="usudatos">Usuario en formato de datos.</param>
        /// <returns>Usuario en formato de negocio.</returns>
        public UsuarioNegocio parsetoNegocio(UsuarioDatos usudatos)
        {
            return new UsuarioNegocio
            {
                Id = usudatos.Id,
                Nombre = usudatos.Nombre,
                Rol = usudatos.Rol,
                Correo = usudatos.Correo,
                Localizacion = usudatos.Localizacion,
                Foto = parseByteImage(usudatos.Foto)
            };
        }

        /// <summary>
        /// Convierte una imagen en un arreglo de bytes.
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
        /// Convierte un arreglo de bytes en una imagen.
        /// </summary>
        /// <param name="byteArray">Arreglo de bytes.</param>
        /// <returns>Imagen resultante o null si el arreglo es null.</returns>
        public Image parseByteImage(byte[] byteArray)
        {
            if (byteArray == null) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        

        /// <summary>
        /// Convierte un objeto <see cref="UsuarioNegocio"/> a <see cref="UsuarioDatos"/>.
        /// </summary>
        /// <param name="usuario">Usuario en formato de negocio.</param>
        /// <returns>Usuario en formato de datos.</returns>
        public UsuarioDatos parsetodatos(UsuarioNegocio usuario)
        {
            return new UsuarioDatos
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol,
                Localizacion = usuario.Localizacion,
                Foto = usuario.Foto != null ? parseImageBytea(usuario.Foto) : null
            };
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="usuario">Usuario en formato de negocio.</param>
        /// <returns>True si se actualizó correctamente; false en caso de error.</returns>
        public bool ActualizarUsuario(UsuarioNegocio usuario)
        {
            try
            {
                UsuarioDatos usuarioDatos = parsetodatos(usuario);
                return this.usuario.ActualizarUsuario(usuarioDatos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario {usuario.Nombre}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un usuario del sistema.
        /// </summary>
        /// <param name="correo">Correo del usuario a eliminar.</param>
        /// <returns>True si se eliminó correctamente; false en caso de error.</returns>
        public bool EliminarUsuario(string correo)
        {
            try
            {
                return usuario.EliminarUsuario(correo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                return false;
            }
        }
    }
}
