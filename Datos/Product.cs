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
        private const string SERVICE_BASE_URL = "http://localhost/ApiTarea/api/";

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

        public string crearProducto(ModelProducto producto, string ticket, string identificacion)
        {
            try
            {
                string json = producto.ToJsonString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            SERVICE_BASE_URL + "Productos/?ticket=" + ticket + "&id=" + identificacion,
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
                        return "El producto ya se encuentra registrado";
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

        public List<VLIS_Articulos> ObtenerTodosProductos(string ticket, string identificacion)
        {
            try
            {
                List<VLIS_Articulos> productos;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(SERVICE_BASE_URL + "Productos/?ticket=" + ticket + "&id=" + identificacion);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        productos = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            productos = JsonConvert.DeserializeObject<List<VLIS_Articulos>>(mens);
                        }
                        else
                        {
                            productos = null;
                        }

                    }
                    return productos;
                }
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

        public string BorrarProducto(string ticket, string identificacion, string codigo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.DeleteAsync(
                             SERVICE_BASE_URL + "Productos/?ticket=" + ticket + "&id=" + identificacion + "&codigo=" + codigo);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El producto no se encuentra registrado";
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

        public string ActualizarProducto(ModelProducto producto, string ticket, string identificacion)
        {
            try
            {
                string json = producto.ToJsonString();
                string url = SERVICE_BASE_URL + "Productos/?ticket=" + ticket + "&id=" + identificacion;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PutAsync(
                            url,
                            new StringContent(json, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El producto no se encuentra registrado";
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

        public string crearAlmacen(ModelAlmacen almacen, string ticket, string identificacion)
        {
            try
            {
                string json = almacen.ToJsonString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            SERVICE_BASE_URL + "Almacenes/?ticket=" + ticket + "&id=" + identificacion,
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

        public List<ModelAlmacen> ObtenerAlmacenes(string identificacion, string ticket)
        {
            try
            {
                List<ModelAlmacen> almacenes;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(SERVICE_BASE_URL + "Almacenes/?ticket=" + ticket + "&id=" + identificacion);  
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if(message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        almacenes = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        almacenes = JsonConvert.DeserializeObject<List<ModelAlmacen>>(mens);
                        
                    }
                    return almacenes;

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ModelProducto ObtenerUnProducto(string ticket, string identificacion, string codigo)
        {
            try
            {
                ModelProducto product;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(SERVICE_BASE_URL + "Productos/?ticket=" + ticket + 
                            "&id=" + identificacion + "&codigo=" + codigo);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        product = JsonConvert.DeserializeObject<ModelProducto>(mens);
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        product = null;
                    }
                    else
                    {
                        product = null;
                    }
                    return product;

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelProducto> ObtenerUnProductoNombre(string ticket, string identificacion, string nombre)
        {
            try
            {
                List<ModelProducto> product = new List<ModelProducto>();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(SERVICE_BASE_URL + "Productos/BuscarProducto/?ticket=" + ticket +
                            "&id=" + identificacion + "&nombre=" + nombre);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        product = JsonConvert.DeserializeObject<List<ModelProducto>>(mens);
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        product = null;
                    }
                    else
                    {
                        product = null;
                    }
                    return product;

                }
            }
            catch (Exception ex)
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
