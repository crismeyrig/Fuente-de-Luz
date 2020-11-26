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
        public decimal BalanceAnterior { get; set; }

        public decimal BalancePendiente { get; set; }

        public decimal Monto { get; set; }        
        public decimal Descuento { get; set; }

         public int UsuarioId{ get; set; }



        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagosDetalle { get; set; }

    }       
}