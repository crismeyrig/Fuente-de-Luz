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
    class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
                return Insertar(productos);

            else
                return Modificar(productos);
        }

        private static bool Existe(object productoId)
        {
            throw new NotImplementedException();
        }

        private static bool Insertar(Productos productos)
        {
            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Productos.Add(productos);
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

        public static bool Modificar(Productos productos)
        {

            Contexto context = new Contexto();
            bool paso = false;

            try
            {
                context.Entry(productos).State = EntityState.Modified;
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
                var productos = context.Productos.Find(id);

                if (productos != null)
                {
                    context.Productos.Remove(productos);
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
        public static Productos Buscar(int id)
        {
            Productos productos;
            Contexto context = new Contexto();

            try
            {
                productos = (Productos)context.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return productos;

        }
        public static bool Existe(int id)
        {

            Contexto context = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = context.Productos.Find(id) != null;
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
        
        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            Contexto context = new Contexto();

            try
            {
                lista = context.Productos.Where(criterio).ToList();
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
