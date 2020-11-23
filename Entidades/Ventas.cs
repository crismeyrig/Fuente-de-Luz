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

        public DateTime Fecha{get; set;}
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }

        public int PropiedadId{get; set;}

        public decimal Descuento {get; set;}

        public int Cuotas{get; set;}

        public int ValorInicial{get; set;}

        public String Comentario{get; set;}

        public DateTime FechaPrimerPago {get; set;}

        public String TipoNegocio{get; set;}

        public String NombreFallecido {get; set;}

        public String ApellidoFallecido{get; set;}

        public DateTime FechaFallecido{get; set;}


        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentasDetalle { get; set; }

       

        
        
    }
}