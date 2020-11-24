using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fuente_de_Luz.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }

        public int UsuarioId { get; set; }

        
        public int ClienteId { get; set; }

         public int PropiedadId{get; set;}

        public DateTime Fecha{get; set;}

        public int NumCuotas{get; set;}
        public int Valor{get; set;}
        public decimal Monto { get; set; }
        public decimal Balance { get; set;} 
        public decimal Descuento {get; set;}
        public DateTime FechaPrimerPago {get; set;}
        
        public String TipoNegocio{get; set;}
        public String Comentario{get; set;}

        

        

       
        


        
       

        
        
    }
}