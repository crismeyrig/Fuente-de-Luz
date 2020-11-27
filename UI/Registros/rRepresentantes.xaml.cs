using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Fuente_de_Luz.Entidades;
using Fuente_de_Luz.BLL;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rRepresentantes : Window
    {
        private Representantes representantes = new Representantes();
        public rRepresentantes()
        {
            InitializeComponent();
            this.DataContext = representantes;
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";


            ClienteIdComboBox.ItemsSource = ClientesBLL.GetList(p => true);
            ClienteIdComboBox.SelectedValuePath = "ClienteId";
            ClienteIdComboBox.DisplayMemberPath = "Nombres";
        }
       
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = representantes;
        }
        
        private void Limpiar()
        {
            this.representantes = new Representantes();
            this.DataContext = representantes;
            RepresentanteIdTextBox.Focus();
            RepresentanteIdTextBox.SelectAll();
        }
        
        private bool Validar()
        {
            bool Validado = true;
            if (RepresentanteIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Representantes encontrado = RepresentantesBLL.Buscar(Utilidades.ToInt(RepresentanteIdTextBox.Text));

            if (encontrado != null)
            {
                this.representantes = encontrado;
                Cargar();
            }
            else
            {
                this.representantes = new Representantes();
                this.DataContext = this.representantes;
                MessageBox.Show($"Este Cliente no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                RepresentanteIdTextBox.SelectAll();
                RepresentanteIdTextBox.Focus();
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
                if (RepresentanteIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Cliente Id) está vacío.\n\nAsigne un Id al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    RepresentanteIdTextBox.Text = "0";
                    RepresentanteIdTextBox.Focus();
                    RepresentanteIdTextBox.SelectAll();
                    return;
                }
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                }
                if (NombreTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombres) está vacío.\n\nAsigne un Nombre al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreTextBox.Clear();
                    NombreTextBox.Focus();
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
                
               if (DireccionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Dirección) está vacío.\n\nAsigne una Dirección al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DireccionTextBox.Clear();
                    DireccionTextBox.Focus();
                    return;
                }
                var paso = RepresentantesBLL.Guardar(representantes);
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
                if (RepresentantesBLL.Eliminar(Utilidades.ToInt(RepresentanteIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo Eliminar el Registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void RepresentanteIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (RepresentanteIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(RepresentanteIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Cliente Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                RepresentanteIdTextBox.Text = "0";
                RepresentanteIdTextBox.Focus();
                RepresentanteIdTextBox.SelectAll();
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
        
        
        
    }
}

    
    