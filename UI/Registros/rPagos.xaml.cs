using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using Fuente_de_Luz.BLL;
using Fuente_de_Luz.Entidades;
using System.Collections.Generic;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rPagos : Window
    {
        private Pagos pago = new Pagos();
        private Ventas venta = new Ventas();
        List<PagosDetalle> listado = new List<PagosDetalle>();

        public rPagos()
        {
            InitializeComponent();
            this.DataContext = pago;
            
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";

            FechaTextBox.Text = DateTime.Now.ToString();
            listado = new List<PagosDetalle>();
        }
        
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = pago;
        }
       
        private void Limpiar()
        {
            this.pago = new Pagos();
            this.DataContext = pago;
            PagoIdTextBox.Focus();
            PagoIdTextBox.SelectAll();
            listado = new List<PagosDetalle>();
            DetalleDataGrid.ItemsSource = null;

            ValoraAplicarTextBox.Text = string.Empty;
            TotalPendienteTextBox.Text = string.Empty;
            TotalTextBox.Text= string.Empty;
            


        }
        
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
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           Pagos encontrado = PagosBLL.Buscar(pago.PagoId);

            if (encontrado != null)
            {
                pago = encontrado;
                Cargar();
                mostrarTotales();

                DetalleDataGrid.ItemsSource = null;
                DetalleDataGrid.ItemsSource = this.pago.PagosDetalle; 
            }
            else
            {
                this.pago = new Pagos();
                this.DataContext = this.pago;
                MessageBox.Show($"Este Pago no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                PagoIdTextBox.SelectAll();
                PagoIdTextBox.Focus();
            }
        }
       
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                    pago.PagosDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
          
                    Cargar();
                }
            }
            catch
            {
                MessageBox.Show("No has seleccionado ninguna Fila\n\nSeleccione la Fila a Remover.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
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

                
                /*if (PagoIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Pago Id) está vacío.\n\nAsigne un Id al Pago.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PagoIdTextBox.Text = "0";
                    PagoIdTextBox.Focus();
                    PagoIdTextBox.SelectAll();
                    return;
                }*/
                
                if (VentaIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Venta Id) está vacío.\n\nAsigne un Id de Venta.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                
                Ventas venta  = VentasBLL.Buscar(pago.VentaId);

                if(venta.Balance == 0){
                    MessageBox.Show("Esta venta ha sido saldada...", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;    
                }

                pago.PagoId = int.Parse(PagoIdTextBox.Text);
                pago.UsuarioId = int.Parse(UsuarioIdComboBox.SelectedValue.ToString());
                pago.VentaId = int.Parse(VentaIdTextBox.Text);
                pago.Fecha = DateTime.Parse(FechaTextBox.Text);               
                pago.Descuento = float.Parse(DescuentoTextBox.Text);       
                pago.Monto = float.Parse(MontoTextBox.Text);   
                pago.BalanceAnterior = float.Parse(TotalPendienteTextBox.Text);
  
                var paso = PagosBLL.Guardar(this.pago);
                if (paso)
                {
                    venta.Descuento += pago.Descuento;
                    venta.Balance -= (pago.Monto + pago.Descuento);
                    VentasBLL.Modificar(venta);

                    pago.PagosDetalle.Clear();
                    Cuotas cuota;
                    
                    foreach (PagosDetalle item in listado)
                    { 
                        item.PagoId = pago.PagoId; 
                        PagosDetalleBLL.Guardar(item);

                        cuota = new Cuotas();
                        cuota = CuotasBLL.Buscar(item.CuotaId);
                        cuota.Balence = item.Balance;
                        CuotasBLL.Modificar(cuota);
                    }

                    Limpiar();
                    MessageBox.Show("Pago Realizado (Guardado)", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Verifique los datos introcidos e intetelo de nuevo", "Datos no válido", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }
        
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
        private void VentaBuscarButton_Click (object sender, RoutedEventArgs e)
        {
            float total = 0;
            if(VentaIdTextBox.Text.Length >0){
                venta = VentasBLL.Buscar(int.Parse(VentaIdTextBox.Text));

                if(venta.VentaId > 0){
                    //busca las cuotas pendientes y la muestra en el grid...
                    listado = new List<PagosDetalle>();
                    var item = venta.Cuotas.FindAll(e => e.Balence > 0);

                    foreach (Cuotas cuota in item)
                    {
                        listado.Add(new PagosDetalle(0,cuota.CuotaId,cuota.Monto,cuota.Balence,0,cuota.NumCuota,0));
                        total += cuota.Balence;
                    }

                    DetalleDataGrid.ItemsSource = null;
                    DetalleDataGrid.ItemsSource = listado;
                    TotalPendienteTextBox.Text = total.ToString();
                }
            }else{
                 MessageBox.Show($"Debe colocar el numero de la venta", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        } 
        private void AplicarValorButton_OnKeyDownHandler(object sender, KeyEventArgs e){ 
            if(e.Key == Key.Enter){
                AplicarValorButton_Click(null,null);
            }
        }

        private void AplicarValorButton_Click(object sender, RoutedEventArgs e)
        { 
            float monto = float.Parse(ValoraAplicarTextBox.Text); 
            float residuo = monto; 

            if(ValoraAplicarTextBox.Text.Length > 0){
                foreach(PagosDetalle item in listado)
                { 
                    if(residuo > 0){
                        if(item.Balance >= monto){
                            item.Total = monto;
                            item.Balance = item.Balance - monto; 
                            residuo = 0;   

                            if(residuo > 0)
                                monto = residuo; 
                            continue; 
                        }
                        
                        if(item.Balance < monto){
                            item.Total = item.Balance;
                            residuo = monto - item.Balance;
                            item.Balance = 0;

                            if(residuo > 0)
                                monto = residuo;  
                            continue;
                        }    
                    }  
                }

                DetalleDataGrid.ItemsSource = null;
                DetalleDataGrid.ItemsSource = listado;

                MontoTextBox.Text = ValoraAplicarTextBox.Text;
                DescuentoTextBox.Focus();
            } 
        }

        public void mostrarTotales(){
            float monto,descuento;
                monto = float.Parse(MontoTextBox.Text);
                descuento = float.Parse(DescuentoTextBox.Text);

                if(monto > descuento){
                    TotalTextBox.Text = (monto - descuento).ToString();
                } 
        }
         
        private void Descuento_OnKeyDownHandler(object sender, KeyEventArgs e){ 
            if(e.Key == Key.Enter){ 
                mostrarTotales();
                ObservacionTextBox.Focus();
            }
        }
    } 
}