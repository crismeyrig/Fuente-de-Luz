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
    class PropiedadBLL
    {
        public static bool Guardar(Propiedad propiedad)
        {
            if (!Existe(propiedad.PropiedadId))
                return Insertar(propiedad);

            else
                return Modificar(propiedad);
        }

        private static bool Existe(object propiedadId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Propiedad propiedad)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Propiedad.Add(propiedad);
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

        public static bool Modificar(Propiedad propiedad)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(propiedad).State = EntityState.Modified;
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
                var propiedad = context.Propiedad.Find(id);

                if (propiedad != null)
                {
                    context.Propiedad.Remove(propiedad);
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
        public static Propiedad Buscar(int id)
        {
            Propiedad propiedad;
            Contexto context = new Contexto();

            try
            {
                propiedad = (Propiedad)context.Propiedad.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return propiedad;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Propiedad.Find(id) != null;
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
        
        public static List<Propiedad> GetList(Expression<Func<Propiedad, bool>> criterio)
        {
            List<Propiedad> lista = new List<Propiedad>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Propiedad.Where(criterio).ToList();
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
