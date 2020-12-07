using Microsoft.EntityFrameworkCore;
using Fuente_de_Luz.DAL;
using Fuente_de_Luz.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Fuente_de_Luz.BLL
{
    class PagosDetalleBLL
    {
        public static bool Guardar(PagosDetalle pagosDetalle)
        {
            if (!Existe(pagosDetalle.Id))
                return Insertar(pagosDetalle);

            else
                return Modificar(pagosDetalle);
        }

        

        private static bool Existe(object Id)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(PagosDetalle pagosDetalle)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.PagosDetalle.Add(pagosDetalle);
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

        public static bool Modificar(PagosDetalle pagosDetalle)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(pagosDetalle).State = EntityState.Modified;
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
                var pagosDetalle = context.PagosDetalle.Find(id);

                if (pagosDetalle != null)
                {
                    context.PagosDetalle.Remove(pagosDetalle);
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
        public static PagosDetalle Buscar(int id)
        {
            PagosDetalle pagosDetalle;
            Contexto context = new Contexto();

            try
            {
                pagosDetalle = (PagosDetalle)context.PagosDetalle.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return pagosDetalle;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.PagosDetalle.Find(id) != null;
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
        
        public static List<PagosDetalle> GetList(Expression<Func<PagosDetalle, bool>> criterio)
        {
            List<PagosDetalle> lista = new List<PagosDetalle>();
            Contexto context = new Contexto();

            try
            {
                lista = context.PagosDetalle.Where(criterio).ToList();
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
