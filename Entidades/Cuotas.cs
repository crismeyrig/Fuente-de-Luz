using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fuente_de_Luz.Entidades
{
    public class Cuotas
    {
        [Key]
        public int CuotaId { get; set; }

        public int VentaId { get; set; }

        public DateTime Fecha{get; set;}

        public decimal Monto { get; set; }        

        public decimal Balence { get; set; }

        public decimal Descuento { get; set; }
        
        
        
    }       
}