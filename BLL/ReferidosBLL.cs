using Microsoft.EntityFrameworkCore;
using Fuente_de_Luz.DAL;
using Fuente_de_Luz.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Fuente_de_Luz.BLL
{
    class ReferidosBLL
    {
        public static bool Guardar(Referidos referidos)
        {
            if (!Existe(referidos.ReferidoId))
                return Insertar(referidos);

            else
                return Modificar(referidos);
        }

        private static bool Existe(object referidoId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Referidos referidos)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Referidos.Add(referidos);
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

        public static bool Modificar(Referidos referidos)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(referidos).State = EntityState.Modified;
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
                var referidos = context.Referidos.Find(id);

                if (referidos != null)
                {
                    context.Referidos.Remove(referidos);
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
        public static Referidos Buscar(int id)
        {
            Referidos referidos;
            Contexto context = new Contexto();

            try
            {
                referidos = (Referidos)context.Referidos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return referidos;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Referidos.Find(id) != null;
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
        
        public static List<Referidos> GetList(Expression<Func<Referidos, bool>> criterio)
        {
            List<Referidos> lista = new List<Referidos>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Referidos.Where(criterio).ToList();
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
