using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fuente_de_Luz.Entidades
{
    public class Productos
    {
        [Key]

        public int  ProductoId{get; set;}
        public String Nombres { get; set; }
        public String Descripcion{ get; set; }
        public decimal Costo { get; set; }        
        public decimal Precio { get; set; }
        
        

    }       
}