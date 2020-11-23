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
        public decimal BalanceAnterio { get; set; }

        public decimal Monto { get; set; }        
        public decimal Descuento { get; set; }

        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagosDetalle { get; set; }

    }       
}