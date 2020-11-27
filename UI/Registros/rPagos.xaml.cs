using System.Windows;
using System.Windows.Controls;
using Fuente_de_Luz.BLL;
using Fuente_de_Luz.Entidades;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rPagos : Window
    {
        private Pagos pagos = new Pagos();
        public rPagos()
        {
            InitializeComponent();
            this.DataContext = pagos;
            //—————————————————————————————————————[ ComboBox UsuarioId ]—————————————————————————————————————
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombresUsuario";

        }
        //——————————————————————————————————————————————————————————————[ Cargar ]———————————————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = pagos;
        }
        //——————————————————————————————————————————————————————————————[ Limpiar ]——————————————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.pagos = new Pagos();
            this.DataContext = pagos;
            PagoIdTextBox.Focus();
            PagoIdTextBox.SelectAll();
        }
        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (PagoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Debe indicar el Id Pago", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           Pagos encontrado = PagosBLL.Buscar(pagos.PagoId);

            if (encontrado != null)
            {
                pagos = encontrado;
                Cargar();
            }
            else
            {
               /* this.pagos = new Pagos();
                this.DataContext = this.pagos; */
                MessageBox.Show($"Este Pago no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                PagoIdTextBox.SelectAll();
                PagoIdTextBox.Focus();
            }
        }
        //——————————————————————————————————————————————————————————————[ Agregar Fila ]———————————————————————————————————————————————————————————————
       private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            //—————————————————————————————————[ Cuota Id ]—————————————————————————————————
            if (CuotaIdTextBox.Text.Length == 0)
            {
                MessageBox.Show("El Campo (Cuota Id) está vacío.\n\nPorfavor, Seleccione la Cuota.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                
                return;
            }
            var filaDetalle = new PagosDetalle
            {
                Id = this.pagos.PagoId,

            };
            
            this.pagos.PagosDetalle.Add(filaDetalle);
            Cargar();
           
            
        }
        //——————————————————————————————————————————————————————————————[ Remover Fila ]———————————————————————————————————————————————————————————————
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                    pagos.PagosDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
          
                    Cargar();
                }
            }
            catch
            {
                MessageBox.Show("No has seleccionado ninguna Fila\n\nSeleccione la Fila a Remover.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //——————————————————————————————————————————————————————————————[ Nuevo ]———————————————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        
        }
        //——————————————————————————————————————————————————————————————[ Guardar ]———————————————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                //—————————————————————————————————[ Pago Id ]—————————————————————————————————
                if (PagoIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Pago Id) está vacío.\n\nAsigne un Id al Pago.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PagoIdTextBox.Text = "0";
                    PagoIdTextBox.Focus();
                    PagoIdTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Venta Id ]—————————————————————————————————
                if (VentaIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Venta Id) está vacío.\n\nAsigne un Id de Venta.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VentaIdTextBox.Text = "0";
                    VentaIdTextBox.Focus();
                    VentaIdTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Usuario Id ]—————————————————————————————————
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                }
                var paso = PagosBLL.Guardar(this.pagos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show(" Pago Realizado (Guardado)", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Verifique los datos introcidos e intetelo de nuevo", "Datos no válido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————————————————————[ Eliminar ]———————————————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PagosBLL.Eliminar(Utilidades.ToInt(PagoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro de Pago Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 
        private void PagoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (PagoIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(PagoIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Pago Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PagoIdTextBox.Text = "0";
                PagoIdTextBox.Focus();
                PagoIdTextBox.SelectAll();
            }
        }
    } 
}