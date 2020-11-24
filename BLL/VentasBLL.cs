using Microsoft.EntityFrameworkCore;
using Fuente_de_Luz.DAL;
using Fuente_de_Luz.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Fuente_de_Luz.BLL
{
    class VentasBLL
    {
        public static bool Guardar(Ventas ventas)
        {
            if (!Existe(ventas.VentaId))
                return Insertar(ventas);

            else
                return Modificar(ventas);
        }

        private static bool Existe(object ventaId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Ventas ventas)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Ventas.Add(ventas);
                paso = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();

            }
            return paso;


        }

        public static bool Modificar(Ventas ventas)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(ventas).State = EntityState.Modified;
                paso = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();

            }
            return paso;

        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto context = new Contexto();

            try
            {
                var ventas = context.Ventas.Find(id);

                if (ventas != null)
                {
                    context.Ventas.Remove(ventas);
                    paso = context.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return paso;

        }
        public static Ventas Buscar(int id)
        {
            Ventas ventas;
            Contexto context = new Contexto();

            try
            {
                ventas= (Ventas)context.Ventas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return ventas;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Ventas.Find(id) != null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return encontrado;

        }
        
        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Ventas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                context.Dispose();
            }
            return lista;

        }
    }
}
