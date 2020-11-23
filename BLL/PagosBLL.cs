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
    class PagosBLL
    {
        public static bool Guardar(Pagos pagos)
        {
            if (!Existe(pagos.PagoId))
                return Insertar(pagos);

            else
                return Modificar(pagos);
        }

        private static bool Existe(object pagoId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Pagos pagos)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Pagos.Add(pagos);
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

        public static bool Modificar(Pagos pagos)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(pagos).State = EntityState.Modified;
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
                var pagos = context.Pagos.Find(id);

                if (pagos != null)
                {
                    context.Pagos.Remove(pagos);
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
        public static Pagos Buscar(int id)
        {
            Pagos pagos;
            Contexto context = new Contexto();

            try
            {
                pagos = (Pagos)context.Pagos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return pagos;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Pagos.Find(id) != null;
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
        
        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio)
        {
            List<Pagos> lista = new List<Pagos>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Pagos.Where(criterio).ToList();
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
