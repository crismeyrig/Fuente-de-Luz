using System;
using System.Collections.Generic;
using System.Windows;
using Fuente_de_Luz.BLL;
using Fuente_de_Luz.Entidades;

namespace Fuente_de_Luz.UI.Consultas
{
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                   case 0: 
                        listado = VentasBLL.GetList(e => e.VentaId == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = VentasBLL.GetList(e => e.UsuarioId == int.Parse(CriterioTextBox.Text));
                        break;
                    case 2:                       
                        listado = VentasBLL.GetList(e => e.ClienteId== int.Parse(CriterioTextBox.Text));
                        break;
                    case 3:                       
                        listado = VentasBLL.GetList(e => e.PropiedadId == int.Parse(CriterioTextBox.Text));
                        break;   
                     
                   

                    
                    case 4:                       
                        listado = VentasBLL.GetList(e => e.Descuento == float.Parse(CriterioTextBox.Text));
                        break;    
                    case 5:                       
                        listado = VentasBLL.GetList(e => e.TipoNegocio.Contains(CriterioTextBox.Text));
                        break;  
                    case 9:                       
                        listado = VentasBLL.GetList(e => e.Monto == float.Parse(CriterioTextBox.Text));
                        break; 
                    case 6:                       
                        listado = VentasBLL.GetList(e => e.Valor == int.Parse(CriterioTextBox.Text));
                        break; 
                    case 7:                       
                        listado = VentasBLL.GetList(e => e.NumCuotas == int.Parse(CriterioTextBox.Text));
                        break; 
                    
                       
                }
            }
            else
            {
                listado = VentasBLL.GetList(c => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}