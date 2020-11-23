using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows;

namespace Fuente_de_Luz.Entidades
{
    public class  TipoPropiedad
    {
        [Key]
        public int TipoPropiedadId { get; set; }

        public String Nombre{ get; set; }
        

      
 
       


        
    }
}