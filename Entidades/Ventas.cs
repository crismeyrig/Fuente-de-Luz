using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public String TipoNegocio{get; set;}
        public int Valor{get; set;}
        public float Monto { get; set; }
        public float Balance { get; set;} 
        public float Descuento {get; set;}
        public DateTime FechaPrimerPago {get; set;}
        

        public List<Cuotas> Cuotas{get;set;}
        
        public Ventas(){
            Cuotas  = new List<Cuotas>();
        }                
    }
}