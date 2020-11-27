using System.ComponentModel.DataAnnotations;

namespace Fuente_de_Luz.Entidades
{
    public class PagosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int CuotaId { get; set; }

        public decimal Monto { get; set; }

        public decimal BalancePendiente{get; set;}

       
        
       

        
    }
}