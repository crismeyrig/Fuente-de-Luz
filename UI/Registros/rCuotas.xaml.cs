using System.Windows;
using System.Windows.Controls;
using Fuente_de_Luz.Entidades;
using Fuente_de_Luz.BLL;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rCuotas : Window
    {
        private Cuotas cuotas = new Cuotas();
        public rCuotas()
        {
            InitializeComponent();
            this.DataContext = cuotas;
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";
        }
       
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = cuotas;
        }
        
        private void Limpiar()
        {
            this.cuotas = new Cuotas();
            this.DataContext = cuotas;
            CuotaIdTextBox.Focus();
            CuotaIdTextBox.SelectAll();
        }
        
        private bool Validar()
        {
            bool Validado = true;
            if (CuotaIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Cuotas encontrado = CuotasBLL.Buscar(Utilidades.ToInt(CuotaIdTextBox.Text));

            if (encontrado != null)
            {
                this.cuotas = encontrado;
                Cargar();
            }
            else
            {
                this.cuotas = new Cuotas();
                this.DataContext = this.cuotas;
                MessageBox.Show($"Este Cuota no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                CuotaIdTextBox.SelectAll();
                CuotaIdTextBox.Focus();
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
                if (CuotaIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Cuota Id) está vacío.\n\nAsigne un Id a la Cuota.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CuotaIdTextBox.Text = "0";
                    CuotaIdTextBox.Focus();
                    CuotaIdTextBox.SelectAll();
                    return;
                }
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                }
                if (FechaDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Fecha Cuota) está vacío.\n\nAsigne una Fecha de Cuota.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaDatePicker.Focus();
                    return;
                }
                var paso = CuotasBLL.Guardar(cuotas);
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
                if (CuotasBLL.Eliminar(Utilidades.ToInt(CuotaIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo Eliminar el Registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void CuotaIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (CuotaIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(CuotaIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Cuota Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CuotaIdTextBox.Text = "0";
                CuotaIdTextBox.Focus();
                CuotaIdTextBox.SelectAll();
            }
        }
        
       
    }
}

    
    