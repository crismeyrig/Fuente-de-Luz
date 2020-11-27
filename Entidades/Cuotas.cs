using System;
using System.ComponentModel.DataAnnotations;


namespace Fuente_de_Luz.Entidades
{
    public class Cuotas
    {
        [Key]
        public int CuotaId { get; set; }

        public int UsuarioId { get; set; }

        public int VentaId { get; set; }

        public DateTime Fecha{get; set;}

         public int NumCuota { get; set; }
         public int Valor { get; set; }  

        public decimal Monto { get; set; }        

        public decimal Balence { get; set; }

        

        

        
        
        
        
    }       
}