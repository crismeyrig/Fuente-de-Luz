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
    class TipoPropiedadBLL
    {
        public static bool Guardar(TipoPropiedad tipoPropiedad)
        {
            if (!Existe(tipoPropiedad.TipoPropiedadId))
                return Insertar(tipoPropiedad);

            else
                return Modificar(tipoPropiedad);
        }

        private static bool Existe(object tipoPropiedadId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(TipoPropiedad tipoPropiedad)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.TipoPropiedad.Add(tipoPropiedad);
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

        public static bool Modificar(TipoPropiedad tipoPropiedad)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(tipoPropiedad).State = EntityState.Modified;
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
                var tipoPropiedad = context.Cuotas.Find(id);

                if (tipoPropiedad != null)
                {
                    context.Cuotas.Remove(tipoPropiedad);
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
        public static TipoPropiedad Buscar(int id)
        {
            TipoPropiedad tipoPropiedad;
            Contexto context = new Contexto();

            try
            {
                tipoPropiedad = (TipoPropiedad)context.TipoPropiedad.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return tipoPropiedad;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.TipoPropiedad.Find(id) != null;
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
        
        public static List<TipoPropiedad> GetList(Expression<Func<TipoPropiedad, bool>> criterio)
        {
            List<TipoPropiedad> lista = new List<TipoPropiedad>();
            Contexto context = new Contexto();

            try
            {
                lista = context.TipoPropiedad.Where(criterio).ToList();
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
