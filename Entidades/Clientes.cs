using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Fuente_de_Luz.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public String Nombres { get; set; }
        public String Apellido { get; set; }
        public String Cedula { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        public String Genero { get; set; }
        public String EstadoCivil { get; set; }
        public String Ocupacion { get; set; }
        public String Religion { get; set; }



        [ForeignKey("UsuarioId")]
        public Usuarios usuarios { get; set; }
        
        
        
        
    }   
}