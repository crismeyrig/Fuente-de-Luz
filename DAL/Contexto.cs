using System;
using Fuente_de_Luz.Entidades; 
using Microsoft.EntityFrameworkCore; 

namespace Fuente_de_Luz.DAL
{
    
    public class Contexto : DbContext  
    {
        public DbSet<Usuarios> Usuarios { get; set; } 
        public DbSet<Clientes> Clientes { get; set; } 
        public DbSet<Propiedad> Propiedad { get; set; } 
        public DbSet<Cuotas> Cuotas { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Pagos> Pagos{ get; set; }

        public DbSet<Representantes> Representantes{ get; set; }

        public DbSet<Referidos> Referidos{ get; set; }

        
        
        

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\FuenteLuz.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Hudelsis",
                Apellidos = "Antigua",
                Email = "Admin@outlook.com",
                FechaCreacion = new DateTime(2020, 11, 20),
                NombreUsuario = "admin",
                Contrasena = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5"
            });

            


        }
    }
}