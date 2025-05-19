using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio.Modelos;
using Negocio.Servicios;

namespace TPV.Views.Usuarios
{
    public partial class MostrarUsuarios : Form
    {
        private UsuarioServicio usuarioServicio;
        private DataTable tablaUsuarios;
        private UsuarioNegocio usu;
        /// <summary>
        /// Constructor del formulario. Inicializa los controles y carga la lista de usuarios.
        /// </summary>
        /// <param name="user">Usuario autenticado que accede al formulario.</param>
        public MostrarUsuarios(UsuarioNegocio user)
        {
            usu = user;
            InitializeComponent();
            usuarioServicio = new UsuarioServicio();
            dgUsuarios.AllowUserToAddRows = false;
            dgUsuarios.AllowUserToDeleteRows = true;
            dgUsuarios.ReadOnly = false;
            dgUsuarios.CellContentClick += dgUsuarios_CellContentClick;
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            txbxNombre.TextChanged -= txbxNombre_TextChanged;
            CargarUsuarios();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            txbxNombre.TextChanged += txbxNombre_TextChanged;
        }

        /// <summary>
        /// Carga los usuarios desde el servicio y los muestra en el DataGridView.
        /// También carga los roles de los usuarios en el comboBox.
        /// </summary>
        private void CargarUsuarios()
        {
            HashSet<string> rolesUnicos = new HashSet<string>();
            rolesUnicos.Add("Todos"); 
            var usuarios = usuarioServicio.ObtenerUsuarios();
            tablaUsuarios = new DataTable();
            tablaUsuarios.Columns.Add("ID", typeof(int));
            tablaUsuarios.Columns.Add("Nombre", typeof(string));
            tablaUsuarios.Columns.Add("Correo", typeof(string));
            tablaUsuarios.Columns.Add("Rol", typeof(string));
            tablaUsuarios.Columns.Add("Localización", typeof(string));
            tablaUsuarios.Columns.Add("Foto", typeof(Image));

            tablaUsuarios.PrimaryKey = new DataColumn[] { tablaUsuarios.Columns["ID"] };

            foreach (var usuario in usuarios)
            {
                if (usuario.Id == null) continue;
                if (usuario.Correo != usu.Correo)
                {
                    var fila = tablaUsuarios.NewRow();
                    fila["ID"] = usuario.Id;
                    fila["Nombre"] = usuario.Nombre;
                    fila["Correo"] = usuario.Correo;
                    fila["Rol"] = usuario.Rol;
                    rolesUnicos.Add(usuario.Rol);
                    fila["Localización"] = usuario.Localizacion ?? "";
                    fila["Foto"] = usuario.Foto ?? Properties.Resources.usernophoto;
                    tablaUsuarios.Rows.Add(fila);
                }
            }

            comboBox1.DataSource = rolesUnicos.ToList();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            dgUsuarios.DataSource = tablaUsuarios;
            if (dgUsuarios.Columns["ID"] != null) dgUsuarios.Columns["ID"].Visible = false;

            if (dgUsuarios.Columns["Foto"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
        }

        /// <summary>
        /// Elimina un usuario seleccionado del DataGridView.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgUsuarios.SelectedRows[0];
            string nombre = fila.Cells["Nombre"].Value.ToString();
            string correo = fila.Cells["Correo"].Value.ToString();

            var confirm = MessageBox.Show($"¿Está seguro de eliminar a {nombre} ({correo})?", "Confirmación",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool eliminado = usuarioServicio.EliminarUsuario(correo);
                if (eliminado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios(); 
                }
                else
                {
                    MessageBox.Show("Error al eliminar usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Guarda los cambios realizados en los usuarios del DataGridView.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgUsuarios.Rows)
            {
                if (fila.IsNewRow) continue;

                string rol = fila.Cells["Rol"].Value?.ToString().ToLower();
                if (rol != "admin" && rol != "empleado")
                {
                    MessageBox.Show($"El rol debe ser 'admin' o 'empleado'. Rol ingresado: '{rol}'",
                                    "Rol inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                UsuarioNegocio usuneg = new UsuarioNegocio
                {
                    Id = Convert.ToInt32(fila.Cells["ID"].Value),
                    Nombre = fila.Cells["Nombre"].Value.ToString(),
                    Correo = fila.Cells["Correo"].Value.ToString(),
                    Rol = rol,
                    Localizacion = fila.Cells["Localización"].Value?.ToString(),
                    Foto = fila.Cells["Foto"].Value as Image
                };

                bool actualizado = usuarioServicio.ActualizarUsuario(usuneg);

                if (!actualizado)
                {
                    MessageBox.Show($"Error al guardar los cambios para el usuario {usuneg.Nombre}.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
        }


        /// <summary>
        /// Evento que maneja la selección de la celda en el DataGridView.
        /// Permite cambiar la foto del usuario seleccionando una nueva imagen.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.ColumnIndex == dgUsuarios.Columns["Foto"].Index && e.RowIndex >= 0)
            {
           
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    string filePath = openFileDialog.FileName;
                    Image newImage = Image.FromFile(filePath);

                    dgUsuarios.Rows[e.RowIndex].Cells["Foto"].Value = newImage;
                }
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Atrás". Cierra el formulario actual.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Refresh". Recarga la lista de usuarios.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        /// <summary>
        /// Evento que maneja el cambio en el campo de texto para filtrar usuarios por nombre.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de texto cambiado.</param>
        private void txbxNombre_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        /// <summary>
        /// Evento que maneja el cambio de selección en el comboBox para filtrar por rol de usuario.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de cambio de selección.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        /// <summary>
        /// Aplica los filtros de búsqueda por nombre y rol sobre la tabla de usuarios.
        /// </summary>
        private void AplicarFiltros()
        {
            DataTable tabla = dgUsuarios.DataSource as DataTable;
            if (tabla == null) return;

            string filtroNombre = txbxNombre.Text.Trim().Replace("'", "''");
            string filtroRol = comboBox1.SelectedItem?.ToString();

            List<string> condiciones = new List<string>();

            if (!string.IsNullOrEmpty(filtroNombre))
                condiciones.Add($"Nombre LIKE '%{filtroNombre}%'");

            if (!string.IsNullOrEmpty(filtroRol) && filtroRol != "Todos")
                condiciones.Add($"Rol = '{filtroRol.Replace("'", "''")}'");

            string filtroFinal = string.Join(" AND ", condiciones);
            tabla.DefaultView.RowFilter = filtroFinal;
        }
    }
}