using Datos.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Product
    {
        private TAREA3Entities entities;
        private const string SERVICE_BASE_URL = "http://localhost:80/WebApiTarea/api/Almacenes";

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

        public string crearAlmacen(ModelAlmacen almacen)
        {
            try
            {
                string json = almacen.ToJsonString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            SERVICE_BASE_URL,
                            new StringContent(json, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "El almacen ya se encuentra registrado";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }
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
