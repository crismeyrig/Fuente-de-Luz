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
using Fuente_de_Luz.Entidades;
using Fuente_de_Luz.BLL;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rClientes : Window
    {
        private Clientes clientes = new Clientes();
        public rClientes()
        {
            InitializeComponent();
            this.DataContext = clientes;
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";
        }
       
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }
        
        private void Limpiar()
        {
            this.clientes = new Clientes();
            this.DataContext = clientes;
            ClienteIdTextBox.Focus();
            ClienteIdTextBox.SelectAll();
        }
        
        private bool Validar()
        {
            bool Validado = true;
            if (ClienteIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes encontrado = ClientesBLL.Buscar(Utilidades.ToInt(ClienteIdTextBox.Text));

            if (encontrado != null)
            {
                this.clientes = encontrado;
                Cargar();
            }
            else
            {
                this.clientes = new Clientes();
                this.DataContext = this.clientes;
                MessageBox.Show($"Este Cliente no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                ClienteIdTextBox.SelectAll();
                ClienteIdTextBox.Focus();
            }
        }
       
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
         
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;
                if (ClienteIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Cliente Id) está vacío.\n\nAsigne un Id al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ClienteIdTextBox.Text = "0";
                    ClienteIdTextBox.Focus();
                    ClienteIdTextBox.SelectAll();
                    return;
                }
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                }
                if (NombresTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombres) está vacío.\n\nAsigne un Nombre al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombresTextBox.Clear();
                    NombresTextBox.Focus();
                    return;
                }
                
                if (ApellidoTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Apellidos) está vacío.\n\nAsigne un Apellidos al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ApellidoTextBox.Clear();
                    ApellidoTextBox.Focus();
                    return;
                }
                
                if (CedulaTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Cédula) está vacío.\n\nAsigne una Cedula al Cedula.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CedulaTextBox.Text = "0";
                    CedulaTextBox.Focus();
                    CedulaTextBox.SelectAll();
                    return;
                }
                if (CedulaTextBox.Text.Length != 11)
                {
                    MessageBox.Show($"La Cédula ({CedulaTextBox.Text}) no es válida.\n\nLa cedula debe tener 11 dígitos (0-9).", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CedulaTextBox.Focus();
                    return;
                }
                
                if (FemeninoRadioButton.IsChecked.Value == false && MasculinoRadioButton.IsChecked.Value == false)
                {
                    MessageBox.Show("El Campo (Género) está vacío.\n\nAsigne un Genero al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FemeninoRadioButton.Focus();
                    return;
                }
                
                if (TelefonoTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Teléfono) está vacío.\n\nAsigne un Teléfono al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TelefonoTextBox.Text = "0";
                    TelefonoTextBox.Focus();
                    TelefonoTextBox.SelectAll();
                    return;
                }
                if (TelefonoTextBox.Text.Length != 10)
                {
                    MessageBox.Show($"El Teféfono ({TelefonoTextBox.Text}) no es válido.\n\nEl Teléfono debe tener 10 dígitos (0-9).", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TelefonoTextBox.Focus();
                    return;
                }
                
                if (FechaDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Fecha Nacimiento) está vacío.\n\nAsigne una Fecha de Nacimiento al Nacimiento.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaDatePicker.Focus();
                    return;
                }
               
                if (DireccionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Dirección) está vacío.\n\nAsigne una Dirección al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DireccionTextBox.Clear();
                    DireccionTextBox.Focus();
                    return;
                }
                
                if (EmailTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Email) está vacío.\n\nAsigne una Correo al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EmailTextBox.Clear();
                    EmailTextBox.Focus();
                    return;
                }

                if (EstadoCivilTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Estado Civil) está vacío.\n\nAsigne un Estado Civil al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EstadoCivilTextBox.Clear();
                    EstadoCivilTextBox.Focus();
                    return;
                }
                 if (OcupacionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Ocupacion) está vacío.\n\nAsigne un Ocupacion al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    OcupacionTextBox.Clear();
                    OcupacionTextBox.Focus();
                    return;
                }
                 if (ReligionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Religion) está vacío.\n\nAsigne un Religion al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ReligionTextBox.Clear();
                    ReligionTextBox.Focus();
                    return;
                }
                
                var paso = ClientesBLL.Guardar(clientes);
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
            {
                if (ClientesBLL.Eliminar(Utilidades.ToInt(ClienteIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo Eliminar el Registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void ClienteIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ClienteIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(ClienteIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Cliente Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClienteIdTextBox.Text = "0";
                ClienteIdTextBox.Focus();
                ClienteIdTextBox.SelectAll();
            }
        }
        
        private void CedulaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (CedulaTextBox.Text.Trim() != string.Empty)
                {
                    long.Parse(CedulaTextBox.Text);
                }

                if (CedulaTextBox.Text.Length != 11)
                {
                    CedulaTextBox.Foreground = Brushes.Red;
                }
                else
                {
                    CedulaTextBox.Foreground = Brushes.Black;
                }
            }
            catch
            {
                MessageBox.Show("El valor digitado en el campo (Cedula) no es un número.\n\nPor favor, digite números (0-9).", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Text = "0";
                CedulaTextBox.Focus();
                CedulaTextBox.SelectAll();
            }
        }
        
        private void TelefonoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TelefonoTextBox.Text.Trim() != string.Empty)
                {
                    long.Parse(TelefonoTextBox.Text);
                }

                if (TelefonoTextBox.Text.Length != 10)
                {
                    TelefonoTextBox.Foreground = Brushes.Red;
                }
                else
                {
                    TelefonoTextBox.Foreground = Brushes.Black;
                }
            }
            catch
            {
                MessageBox.Show("El valor digitado en el campo (Teléfono) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Text = "0";
                TelefonoTextBox.Focus();
                TelefonoTextBox.SelectAll();
            }
        }
    }
}

    
    