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
    
        public String Nombre { get; set; }

        public String Descripcion { get; set; }
        public decimal Precio { get; set; } 
        public String Ubicacion{get; set;}
        public int NumPropiedad{get; set;}

        public String Seccion{ get; set;}

        public int UsuarioId{get; set;}

        

      
 
       

        
    }
}