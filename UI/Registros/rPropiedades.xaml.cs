using System.Windows;
using Fuente_de_Luz.Entidades;
using Fuente_de_Luz.BLL;
using System.Windows.Controls;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rPropiedades : Window
    {
        private Propiedad Propiedades = new Propiedad();
        public rPropiedades()
        {
            InitializeComponent();
            this.DataContext = Propiedades;

            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuariO";

        }
       
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Propiedades;
        }
        
        private void Limpiar()
        {
            this.Propiedades = new Propiedad();
            this.DataContext = Propiedades;
            PropiedadIdTextBox.Focus();
            PropiedadIdTextBox.SelectAll();
        }
        
        private bool Validar()
        {
            bool Validado = true;
            if (PropiedadIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Propiedad encontrado = PropiedadBLL.Buscar(Utilidades.ToInt(PropiedadIdTextBox.Text));

            if (encontrado != null)
            {
                this.Propiedades = encontrado;
                Cargar();
            }
            else
            {
                this.Propiedades = new Propiedad();
                this.DataContext = this.Propiedades;
                MessageBox.Show($"Este Cliente no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                PropiedadIdTextBox.SelectAll();
                PropiedadIdTextBox.Focus();
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
                if (PropiedadIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Propiedad Id) está vacío.\n\nAsigne un Id a l propiedad.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PropiedadIdTextBox.Text = "0";
                    PropiedadIdTextBox.Focus();
                    PropiedadIdTextBox.SelectAll();
                    return;
                }
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                } /*
                if (PropiedadTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre) está vacío.\n\nAsigne un Nombre a la propiedad.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PropiedadTextBox.Focus();
                    return;
                }
                if (DescripcionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Descripcion) está vacío.\n\nAsigne una Cedula al Cedula.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DescripcionTextBox.Text = "0";
                    DescripcionTextBox.Focus();
                    DescripcionTextBox.SelectAll();
                    return;
                }
                
               if (UbicacionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Ubicacion) está vacío.\n\nAsigne una Dirección al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UbicacionTextBox.Clear();
                    UbicacionTextBox.Focus();
                    return;
                }
                if (SeccionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Seccion) está vacío.\n\nAsigne una Dirección al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    SeccionTextBox.Clear();
                    SeccionTextBox.Focus();
                    return;
                }
                if (NumPropiedadTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (NumPropiedad) está vacío.\n\nAsigne una Dirección al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NumPropiedadTextBox.Clear();
                    NumPropiedadTextBox.Focus();
                    return;
                }
                if (PrecioTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Precio) está vacío.\n\nAsigne una Dirección al Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PrecioTextBox.Clear();
                    PrecioTextBox.Focus();
                    return;
                }*/
                var paso = PropiedadBLL.Guardar(Propiedades);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Propiedad Registrada", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se ha podido registrar, verifique los datos e intente de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PropiedadBLL.Eliminar(Utilidades.ToInt(PropiedadIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo Eliminar el Registro por que no Existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
         private void PropiedadIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (PropiedadIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(PropiedadIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Propiedad Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PropiedadIdTextBox.Text = "0";
                PropiedadIdTextBox.Focus();
                PropiedadIdTextBox.SelectAll();
            }
        }

       
    }
}
        
        
        
    
    


    
    