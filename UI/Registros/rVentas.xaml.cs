using System.Windows;
using System;
using System.Windows.Input;
using System.Windows.Controls; 
using Fuente_de_Luz.Entidades;
using Fuente_de_Luz.BLL;
using System.Collections.Generic;

namespace Fuente_de_Luz.UI.Registros
{
    public partial class rVentas : Window
    {
        private Ventas venta = new Ventas();
        List<Cuotas> listadoCuotas;

        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";

            ClienteIdComboBox.ItemsSource = ClientesBLL.GetList(p => true);
            ClienteIdComboBox.SelectedValuePath = "ClienteId";
            ClienteIdComboBox.DisplayMemberPath = "Nombres"; 

            FechaPrimerPagoTextBox.Text = DateTime.Now.ToString();
            FechaTextBox.Text = DateTime.Now.ToString();
            listadoCuotas = new List<Cuotas>();
        }
       
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = venta;
        }
        
        private void Limpiar()
        {
            this.venta = new Ventas();
            this.DataContext = venta;
            VentaIdTextBox.Focus();
            VentaIdTextBox.SelectAll();
            listadoCuotas = new List<Cuotas>();
            DetalleDataGrid.ItemsSource = null;

            PropiedadIdTextBox.Text = string.Empty;
            PrecioPropiedadTextBox.Text = string.Empty;
            NombrePropiedadTextBox.Text = string.Empty;

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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas encontrado = VentasBLL.Buscar(Utilidades.ToInt(VentaIdTextBox.Text));

            if (encontrado != null)
            {
                this.venta = encontrado;
                Cargar();
                buscarPropiedad();   

                DetalleDataGrid.ItemsSource = null;
                DetalleDataGrid.ItemsSource = this.venta.Cuotas;  
            }
            else
            {
                this.venta = new Ventas();
                this.DataContext = this.venta;
                MessageBox.Show($"Este Venta no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
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

                //llenamos los valores del encabezado
                venta.VentaId = int.Parse(VentaIdTextBox.Text);
                venta.UsuarioId = int.Parse(UsuarioIdComboBox.SelectedValue.ToString());
                venta.ClienteId = int.Parse(ClienteIdComboBox.SelectedValue.ToString());
                venta.PropiedadId = int.Parse(PropiedadIdTextBox.Text);                
                venta.Fecha = DateTime.Parse(FechaTextBox.Text);               
                venta.FechaPrimerPago = DateTime.Parse(FechaPrimerPagoTextBox.Text);              
                venta.Descuento = float.Parse(DescuentoTextBox.Text);       
                venta.TipoNegocio = MejoraRadioButton.IsChecked == true ? "Mejora" : "Nuevo";
                venta.Monto = float.Parse(MontoTextBox.Text);   
                venta.Valor = int.Parse(ValorInicialTextBox.Text);
                venta.Balance = venta.Monto;
                venta.NumCuotas = int.Parse(CantCuotasTextBox.Text);
 
                var paso = VentasBLL.Guardar(venta);

                if (paso)
                {
                    //llenamos los valores del detalle, osea de la cuota...
                    venta.Cuotas.Clear();
                    foreach (Cuotas item in listadoCuotas)
                    {
                        item.VentaId = venta.VentaId;
                        item.UsuarioId = venta.UsuarioId; 
                        CuotasBLL.Guardar(item);
                    } 

                    Limpiar();
                    MessageBox.Show("Venta Realizada  (Guardado)"  , "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Venta Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show($"El valor digitado en el campo (Venta Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                VentaIdTextBox.Text = "0";
                VentaIdTextBox.Focus();
                VentaIdTextBox.SelectAll();
            }
        }

        Propiedad propiedad;
        private void buscarPropiedad(){ 
                propiedad = PropiedadBLL.Buscar(int.Parse(PropiedadIdTextBox.Text));
                if(propiedad.PropiedadId > 0){
                    NombrePropiedadTextBox.Text = propiedad.Nombre;
                    PrecioPropiedadTextBox.Text = propiedad.Precio.ToString();
                }else{
                    MessageBox.Show("Propiedad no encontrada", "Advertencia");
                }
        }

        private void Propiedad_OnKeyDownHandler(object sender, KeyEventArgs e){
            if(e.Key == Key.Enter){
                
                 buscarPropiedad();
            }
        } 
        
        private void Descuento_OnKeyDownHandler(object sender, KeyEventArgs e){
            if(e.Key == Key.Enter){
                
                if(propiedad.PropiedadId > 0){
                    float descuento = float.Parse(DescuentoTextBox.Text); 
                     MontoTextBox.Text = (propiedad.Precio - descuento).ToString();
                     ValorInicialTextBox.Focus();
                }else{
                    MessageBox.Show("Propiedad no encontrada", "Advertencia");
                }
            }
        }
        
        private void ValorInicial_OnKeyDownHandler(object sender, KeyEventArgs e){
            if(e.Key == Key.Enter){
                
                if(propiedad.PropiedadId > 0){ 
                     CantCuotasTextBox.Focus();
                }else{
                    MessageBox.Show("Propiedad no encontrada", "Advertencia");
                }
            }
        }

        private void CalcularCuotasButton_Click(object sender, RoutedEventArgs e)
        {
            if(propiedad.PropiedadId > 0){ 
                //total-inicial/cuotas
                Cuotas cuota;
                float total,inicial,cantCuotas, montoxCuota;

                total = float.Parse(MontoTextBox.Text);
                inicial = float.Parse(ValorInicialTextBox.Text);
                cantCuotas = float.Parse(CantCuotasTextBox.Text);

                if(inicial <= 0){
                    MessageBox.Show("El inicial debe ser mayor que cero", "Advertencia");
                    return;
                }
                
                if(cantCuotas <= 0){
                    MessageBox.Show("Las cuotas deben ser mayor que cero", "Advertencia");
                    return;
                }

                if(inicial >= total){
                    MessageBox.Show("El inicial no puede ser mayor o igual al total", "Advertencia");
                    return;
                }

                montoxCuota = (total - inicial)  / cantCuotas;

                listadoCuotas = new List<Cuotas>();
                for (int i = 1; i < cantCuotas +1; i++)
                {
                    cuota = new Cuotas(0,0,DateTime.Now ,i,0,montoxCuota,montoxCuota);
                    cuota.Fecha.AddMonths(i);
                    listadoCuotas.Add(cuota);
                }    

                DetalleDataGrid.ItemsSource = null;
                DetalleDataGrid.ItemsSource = listadoCuotas;  
            }else{
                MessageBox.Show("Propiedad no encontrada", "Advertencia");
            }
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        { 
            


        }
    }
}
