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
    class RepresentantesBLL
    {
        public static bool Guardar(Representantes representantes)
        {
            if (!Existe(representantes.RepresentanteId))
                return Insertar(representantes);

            else
                return Modificar(representantes);
        }

        private static bool Existe(object representanteId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Representantes representantes)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Representantes.Add(representantes);
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

        public static bool Modificar(Representantes representantes)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(representantes).State = EntityState.Modified;
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
                var representantes = context.Representantes.Find(id);

                if (representantes != null)
                {
                    context.Representantes.Remove(representantes);
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
        public static Representantes Buscar(int id)
        {
            Representantes representantes;
            Contexto context = new Contexto();

            try
            {
                representantes = (Representantes)context.Representantes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return representantes;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Representantes.Find(id) != null;
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
        
        public static List<Representantes> GetList(Expression<Func<Representantes, bool>> criterio)
        {
            List<Representantes> lista = new List<Representantes>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Representantes.Where(criterio).ToList();
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
