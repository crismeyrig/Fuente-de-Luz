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

        public float Monto { get; set; }        

        public float Balence { get; set; }

        public Cuotas(int UsuarioId,int VentaId,DateTime Fecha,int NumCuota,int Valor,float Monto,float Balence)
        {
           this.UsuarioId = UsuarioId;
           this.Fecha = Fecha;
           this.VentaId = VentaId;
           this.NumCuota = NumCuota;
           this.Valor = Valor;
           this.Monto = Monto;
           this.Balence = Balence;
        }   
        public Cuotas()
        { 
        }   
    }       
}