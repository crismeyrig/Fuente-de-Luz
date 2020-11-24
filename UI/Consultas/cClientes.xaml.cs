using System;
using System.Collections.Generic;
using System.Windows;
using Fuente_de_Luz.BLL;
using Fuente_de_Luz.Entidades;

namespace Fuente_de_Luz.UI.Consultas
{
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                   case 0: 
                        listado = ClientesBLL.GetList(e => e.ClienteId == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = ClientesBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 2:                       
                        listado = ClientesBLL.GetList(e => e.Apellido.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 3:                       
                        listado = ClientesBLL.GetList(e => e.Cedula.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;   
                    case 4:                       
                        listado = ClientesBLL.GetList(e => e.Telefono.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;  
                    case 5:                       
                        listado = ClientesBLL.GetList(e => e.Direccion.Contains(CriterioTextBox.Text));
                        break; 

                    case 6:                       
                        listado = ClientesBLL.GetList(e => e.Celular.Contains(CriterioTextBox.Text));
                        break; 

                    case 7:                       
                        listado = ClientesBLL.GetList(e => e.Email.Contains(CriterioTextBox.Text));
                        break;     
                    
                       
                }
            }
            else
            {
                listado = ClientesBLL.GetList(c => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}