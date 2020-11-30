using System;
using System.ComponentModel.DataAnnotations;

namespace Fuente_de_Luz.Entidades
{
    public class Propiedad
    {
        [Key]
        public int PropiedadId { get; set; }
    
        public String Nombre { get; set; }

        public String Descripcion { get; set; }
        public float Precio { get; set; } 
        public String Ubicacion{get; set;}
        public int NumPropiedad{get; set;}

        public String Seccion{ get; set;}

        public int UsuarioId{get; set;}

        

      
 
       

        
    }
}