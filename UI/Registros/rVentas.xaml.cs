using System.Windows;
using System.Windows.Controls;
using Fuente_de_Luz.Entidades;
using Fuente_de_Luz.BLL;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rVentas : Window
    {
        private Ventas ventas = new Ventas();
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = ventas;
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
            this.DataContext = ventas;
        }
        
        private void Limpiar()
        {
            this.ventas = new Ventas();
            this.DataContext = ventas;
            VentaIdTextBox.Focus();
            VentaIdTextBox.SelectAll();
        }
        
        private bool Validar()
        {
            bool Validado = true;
            if (VentaIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas encontrado = VentasBLL.Buscar(Utilidades.ToInt(VentaIdTextBox.Text));

            if (encontrado != null)
            {
                this.ventas = encontrado;
                Cargar();
            }
            else
            {
                this.ventas = new Ventas();
                this.DataContext = this.ventas;
                MessageBox.Show($"Este Cliente no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                VentaIdTextBox.SelectAll();
                VentaIdTextBox.Focus();
            }
        }
       
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
         
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
            {
                if (!Validar())
                    return;
                if (VentaIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Cliente Id) está vacío.\n\nAsigne un Id al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VentaIdTextBox.Text = "0";
                    VentaIdTextBox.Focus();
                    VentaIdTextBox.SelectAll();
                    return;
                }
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                }
                var paso = VentasBLL.Guardar(ventas);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
                if (VentasBLL.Eliminar(Utilidades.ToInt(VentaIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo Eliminar el Registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        private void VentaIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (VentaIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(VentaIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Cliente Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                VentaIdTextBox.Text = "0";
                VentaIdTextBox.Focus();
                VentaIdTextBox.SelectAll();
            }
        }

        /*private void OnKeyDownHandler(object sender, KeyEventArgs e){
            if(e.Key == Key.Enter){
                //tu codigo...
                 
                Propiedad propiedad = PropiedadBLL.Buscar(int.Parse(PropiedadIdTextBox.Text));
                if(propiedad.PropiedadId > 0){
                    NombrePropiedadTextBox.Text = propiedad.Nombres;
                    PrecioPropiedadTextBox.Text = propiedad.Precio.ToString();
                }else{
                    MessageBox.Show("Propiedad no encontrada", "Advertencia");
                }
            }
        }  */
    }
}
