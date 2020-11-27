using System;
using System.ComponentModel.DataAnnotations;


namespace Fuente_de_Luz.Entidades
{
    public class Representantes
    {
        [Key]
        public int RepresentanteId { get; set; }

        public int UsuarioId { get; set; }

        public int ClienteId { get; set; }

        public String Nombre{get; set;}

        public String Cedula{ get; set; }        

        public String Direccion{ get; set; }

        

       
        
        
        
    }       
}