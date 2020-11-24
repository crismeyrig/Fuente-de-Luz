using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows;

namespace Fuente_de_Luz.Entidades
{
    public class Propiedad
    {
        [Key]
        public int PropiedadId { get; set; }
        public int Metros { get; set; }

        public String Nombres { get; set; }

        public String Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; } 
        public String Ubicacion{get; set;}
        public int NOPropiedad{get; set;}

        public String Seccion{ get; set;}

        public int UsuarioId{get; set;}

        

      
 
       

        
    }
}