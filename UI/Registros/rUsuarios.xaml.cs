using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Fuente_de_Luz.BLL; 
using Fuente_de_Luz.Entidades; 

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }
         private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
            ContrasenaPasswordBox.Password = string.Empty;
            ConfirmarContrasenaPasswordBox.Password = string.Empty;
        }
        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;
            ContrasenaPasswordBox.Password = string.Empty;
            ConfirmarContrasenaPasswordBox.Password = string.Empty;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (UsuarioIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios encontrado = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (encontrado != null)
            {
                this.usuarios = encontrado;
                Cargar();
            }
            else
            {
                this.usuarios = new Usuarios();
                this.DataContext = this.usuarios;
                MessageBox.Show($"Este Usuario no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                UsuarioIdTextBox.SelectAll();
                UsuarioIdTextBox.Focus();
            }
            if (UsuarioIdTextBox.Text == "1")
            {
                EliminarButton.IsEnabled = false;
            }
            else
            {
                EliminarButton.IsEnabled = true;
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            EliminarButton.IsEnabled = true;
        }
         private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                if (UsuarioIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nAsigne un Id al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdTextBox.Text = "0";
                    UsuarioIdTextBox.Focus();
                    UsuarioIdTextBox.SelectAll();
                    return;
                }
                if (NombresTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombres) está vacío.\n\nEscriba sus Nombres.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombresTextBox.Clear();
                    NombresTextBox.Focus();
                    return;
                }
                if (ApellidosTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Apellidos) está vacío.\n\nEscriba sus Apellidos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ApellidosTextBox.Clear();
                    ApellidosTextBox.Focus();
                    return;
                }
                if (FechaCreacionDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show($"El Campo (Fecha Creación) está vacío.\n\nSeleccione una fecha.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaCreacionDatePicker.Focus();
                    return;
                }
                if (NombreUsuarioTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Usuario) está vacío.\n\nAsigne un Nombre al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreUsuarioTextBox.Focus();
                    NombreUsuarioTextBox.SelectAll();
                    return;
                }
                if (NombreUsuarioTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Usuario) está vacío.\n\nAsigne un Nombre al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreUsuarioTextBox.Focus();
                    NombreUsuarioTextBox.SelectAll();
                    return;
                }
                if (ContrasenaPasswordBox.Password == string.Empty)
                {
                    MessageBox.Show("El Campo (Contraseña) está vacío.\n\nAsigne una Contraseña al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ContrasenaPasswordBox.Focus();
                    ContrasenaPasswordBox.SelectAll();
                    return;
                }
                if (ConfirmarContrasenaPasswordBox.Password == string.Empty)
                {
                    MessageBox.Show("El Campo (Confirmar Contraseña) está vacío.\n\nConfirme la Contraseña del Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ConfirmarContrasenaPasswordBox.Focus();
                    ConfirmarContrasenaPasswordBox.SelectAll();
                    return;
                }
                if (ConfirmarContrasenaPasswordBox.Password != ContrasenaPasswordBox.Password)
                {
                    MessageBox.Show("Las Contraseñas Escritas no Coinciden", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ContrasenaPasswordBox.Clear();
                    ConfirmarContrasenaPasswordBox.Clear();
                    ContrasenaPasswordBox.Focus();
                    return;
                }

                var paso = UsuariosBLL.Guardar(usuarios);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (UsuarioIdTextBox.Text == "1")
            {
                MessageBox.Show("No se pudo Eliminar este Usuario.\n\nNo puede Eliminar este Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                UsuarioIdTextBox.Focus();
                UsuarioIdTextBox.SelectAll();
                return;
            }

            if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo Eliminar el Registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}