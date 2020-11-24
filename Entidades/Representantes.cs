using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fuente_de_Luz.Entidades
{
    public class Representantes
    {
        [Key]
        public int RepresentanteId { get; set; }

        public int VentaId { get; set; }

        public String Nombre{get; set;}

        public int Cedula{ get; set; }        

        public String Direccion{ get; set; }

        public int UsuarioId { get; set; }

       
        
        
        
    }       
}