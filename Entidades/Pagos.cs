using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fuente_de_Luz.Entidades
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public DateTime Fecha { get; set; }
        public int VentaId { get; set; }
        public float BalanceAnterior { get; set; }
        public float Monto { get; set; }        
        public float Descuento { get; set; }

        public String Observacion{get; set;}

        public float Valor{get; set;}

        

        public int UsuarioId{ get; set; }



        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagosDetalle { get; set; }

        public Pagos(){ 
            this.PagosDetalle = new List<PagosDetalle>();
        }

    }       
}