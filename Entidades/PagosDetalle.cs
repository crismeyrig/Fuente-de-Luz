using System.ComponentModel.DataAnnotations;

namespace Fuente_de_Luz.Entidades
{
    public class PagosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int CuotaId { get; set; }

        public float Monto { get; set; }

        public float Balance{get; set;} 

        public float Descuento{get; set;}

        public int NumCuotas{get; set;}

        public float Total{get; set;}

        public PagosDetalle(){

        } 

        public PagosDetalle(int id,int CuotaId,float Monto,float Balance,float Descuento,int NumCuotas,float Total){
            this.Id = id;
            this.CuotaId = CuotaId;
            this.Monto = Monto;
            this.Balance = Balance;
            this.Descuento  = Descuento;
            this.NumCuotas = NumCuotas;
            this.Total = Total;
        }
    }
}