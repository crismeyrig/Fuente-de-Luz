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
    class CuotasBLL
    {
        public static bool Guardar(Cuotas cuotas)
        {
            if (!Existe(cuotas.CuotaId))
                return Insertar(cuotas);

            else
                return Modificar(cuotas);
        }

        private static bool Existe(object cuotaId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Cuotas cuotas)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Cuotas.Add(cuotas);
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

        public static bool Modificar(Cuotas cuotas)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(cuotas).State = EntityState.Modified;
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
                var cuotas = context.Cuotas.Find(id);

                if (cuotas != null)
                {
                    context.Cuotas.Remove(cuotas);
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
        public static Cuotas Buscar(int id)
        {
            Cuotas cuotas;
            Contexto context = new Contexto();

            try
            {
                cuotas = (Cuotas)context.Cuotas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return cuotas;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Cuotas.Find(id) != null;
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
        
        public static List<Cuotas> GetList(Expression<Func<Cuotas, bool>> criterio)
        {
            List<Cuotas> lista = new List<Cuotas>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Cuotas.Where(criterio).ToList();
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
