using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Product
    {
        private TAREA3Entities entities;

        public Product()
        {
            try
            {
                entities = new TAREA3Entities();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int crearProducto(Productos u)
        {
            try
            {
                entities.Productos.Add(u);
                int res = entities.SaveChanges();

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public int CrearStock(Stock p)
        {
            try
            {
                entities.Stock.Add(p);
                int res = entities.SaveChanges();

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<VLIS_Articulos> ObtenerTodos()
        {
            try
            {
                return entities.VLIS_Articulos.ToList<VLIS_Articulos>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Usuarios> BuscarUsuario(string identificacion)
        {
            try
            {
                var query = from c in entities.Usuarios
                            where c.Identificacion == identificacion
                            select c;
                return query.ToList<Usuarios>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int BorrarProducto(string id)
        {
            try
            {
                Productos P = entities.Productos.First<Productos>(x => x.codigo == id);
                Stock S = entities.Stock.First<Stock>(x => x.idProducto == P.idArticulo);
                entities.Stock.Remove(S);
                entities.Productos.Remove(P);
                return entities.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public int ActualizarProducto(string idProducto, string nombre, string stock, string almacen)
        {
            try
            {
                Productos P = entities.Productos.First<Productos>(x => x.codigo == idProducto);
                Stock C = entities.Stock.First<Stock>(x => x.idProducto == P.idArticulo);
                P.Descripcion = nombre;
                C.Stock1 = Int32.Parse(stock);
                C.idAlmacen = ObtenerUnAlmacen(almacen);
                return entities.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int crearAlmacen(Almacenes a)
        {
            try
            {
                entities.Almacenes.Add(a);
                int res = entities.SaveChanges();

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Almacenes> ObtenerAlmacenes()
        {
            try
            {
                return entities.Almacenes.ToList<Almacenes>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ObtenerUnAlmacen(string nombre)
        {
            try
            {
                List<Almacenes> almacenes = ObtenerAlmacenes();

                foreach (Almacenes alm in almacenes)
                {
                    if (alm.Descripcion == nombre)
                    {
                        return alm.idAlmacen;
                    }
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public VLIS_Articulos ObtenerUnProducto(string codigo)
        {
            try
            {
                VLIS_Articulos produ = new VLIS_Articulos();
                List<VLIS_Articulos> productos = entities.VLIS_Articulos.ToList<VLIS_Articulos>();

                foreach (VLIS_Articulos prod in productos)
                {
                    if (prod.codigo == codigo)
                    {
                        produ = prod;
                    }
                }
                return produ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ObtenerUnProducto2(string nombre)
        {
            try
            {
                List<Productos> productos = entities.Productos.ToList<Productos>();

                foreach (Productos prod in productos)
                {
                    if (prod.Descripcion == nombre)
                    {
                        return prod.idArticulo;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ObtenerStock(int idAlmacen, int idArticulo)
        {
            try
            {
                var query = from c in entities.Stock
                            where c.idAlmacen == idAlmacen && c.idProducto == idArticulo
                            select c;
                List<Stock> stocks = query.ToList<Stock>();

                foreach (Stock stock in stocks)
                {
                    return stock.Stock1;
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
