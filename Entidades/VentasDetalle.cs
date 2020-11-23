using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fuente_de_Luz.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int VentasDetalleId { get; set; }
        public int VentaId { get; set; }
        public int PoductoId { get; set; }
        public Decimal Costo  { get; set; }
        public decimal Precio { get; set; }

       
    }
}