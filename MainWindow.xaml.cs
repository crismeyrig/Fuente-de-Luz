using System;
using System.Windows;
using Fuente_de_Luz.UI.Registros;
using Fuente_de_Luz.UI.Consultas;

namespace Fuente_de_Luz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
         private void rUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios ventana = new rUsuarios();
            ventana.Show();
        }
        private void rClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rClientes  ventana = new rClientes ();
            ventana.Show();
        }
        private void rReferidosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rReferidos  ventana = new rReferidos ();
            ventana.Show();
        }
        private void rRepresentantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRepresentantes  ventana = new rRepresentantes ();
            ventana.Show();
        }
        private void rVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVentas  ventana = new rVentas ();
            ventana.Show();
        }
        
        private void rPagosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPagos  ventana = new rPagos ();
            ventana.Show();
        }
        private void rPropiedadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPropiedades  ventana = new rPropiedades ();
            ventana.Show();
        }
        
        private void cUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios ventana = new cUsuarios();
            ventana.Show();
        }
        private void cClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cClientes ventana = new cClientes();
            ventana.Show();
        }
        private void cReferidosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cReferidos ventana = new cReferidos();
            ventana.Show();
        }
        private void cRepresentantesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cRepresentantes ventana = new cRepresentantes();
            ventana.Show();
        }
        private void cVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVentas  ventana = new cVentas ();
            ventana.Show();
        }
        private void cPropiedadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPropiedad  ventana = new cPropiedad ();
            ventana.Show();
        }
        private void cPagosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPagos  ventana = new cPagos ();
            ventana.Show();
        }
        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
