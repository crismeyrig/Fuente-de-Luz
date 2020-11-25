using System.Windows;
using Fuente_de_Luz.BLL;
using Fuente_de_Luz.Entidades;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rPagos : Window
    {
        private Pagos Pagos = new Pagos();
        public rPagos()
        {
            InitializeComponent();
            this.DataContext = Pagos;

         
        }
        //——————————————————————————————————————————————————————————————[ Cargar ]———————————————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Pagos;
        }
        //——————————————————————————————————————————————————————————————[ Limpiar ]——————————————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.Pagos = new Pagos();
            this.DataContext = Pagos;
        }
        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (PagoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Indique el Id Pago", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Pagos encontrado = PagosBLL.Buscar(Utilidades.ToInt(PagoIdTextBox.Text));

            if (encontrado != null)
            {
                this.Pagos = encontrado;
                Cargar();
            }
            else
            {
                this.Pagos = new Pagos();
                this.DataContext = this.Pagos;
                MessageBox.Show($"Este Id Pago no fue encontrado.\n\nAsegúrese que existe.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                PagoIdTextBox.SelectAll();
                PagoIdTextBox.Focus();
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

                //———————————————————————————————————————————————————————[ VALIDAR SI ESTA VACIO ]———————————————————————————————————————————————————————
                //—————————————————————————————————[ Pago Id ]—————————————————————————————————
                if (PagoIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Pago Id) está vacío.\n\nAsigne un Id al Pago.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PagoIdTextBox.Text = "0";
                    PagoIdTextBox.Focus();
                    PagoIdTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Venta  Id ]—————————————————————————————————
                if (VentaIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (venta Id) está vacío.\n\nPorfavor, Seleccione su Venta Id.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VentaIdComboBox.IsDropDownOpen = true;
                    return;
                }
               
               
               
                //—————————————————————————————————[ Fecha ]—————————————————————————————————
                if (FechaDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show($"El Campo (Fecha) está vacío.\n\nSeleccione una fecha.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaDatePicker.Focus();
                    return;
                }
                //—————————————————————————————————[ Monto ]—————————————————————————————————
                if (MontoTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Monto) está vacío.\n\nDebe Indicar el Monto Pagado.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    MontoTextBox.Text = "0";
                    MontoTextBox.Focus();
                    MontoTextBox.SelectAll();
                    return;
                }
                //———————————————————————————————————————————————————————[ VALIDAR SI ESTA VACIO - FIN ]———————————————————————————————————————————————————————
                var paso = PagosBLL.Guardar(Pagos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————————————————————[ Eliminar ]———————————————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PagosBLL.Eliminar(Utilidades.ToInt(PagoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       

        
       
            
        
    }
}
    