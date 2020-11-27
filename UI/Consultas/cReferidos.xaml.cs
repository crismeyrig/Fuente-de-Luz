using System;
using System.Collections.Generic;
using System.Windows;
using Fuente_de_Luz.BLL;
using Fuente_de_Luz.Entidades;

namespace Fuente_de_Luz.UI.Consultas
{
    public partial class cReferidos : Window
    {
        public cReferidos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Referidos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                   case 0: 
                        listado = ReferidosBLL.GetList(e => e.ReferidoId == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = ReferidosBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    
                    case 2:                       
                        listado = ReferidosBLL.GetList(e => e.Cedula.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;   
                     
                    case 3:                       
                        listado = ReferidosBLL.GetList(e => e.Direccion.Contains(CriterioTextBox.Text));
                        break; 

                       
                    
                       
                }
            }
            else
            {
                listado = ReferidosBLL.GetList(c => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}