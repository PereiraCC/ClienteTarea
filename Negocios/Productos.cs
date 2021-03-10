using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Producto
    {
        private Product productos = new Product();

        public string crearProducto(string descripcion, string codigo, string cantidad, string nombreAlmacen, string ticket, string identificacion)
        {
            try
            {
                string res = productos.crearProducto(new ModelProducto()
                {
                    descripcion = descripcion,
                    codigo = codigo,
                    cantidad = cantidad,
                    nombreAlmacen = nombreAlmacen
                }, ticket, identificacion);

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string crearAlmacen(string descripcion, string ticket, string id)
        {
            try
            {
                if (vacioTexto(descripcion) == false  && validarKeyWords(descripcion) == false)
                {
                    string res = productos.crearAlmacen(new ModelAlmacen()
                    {
                        Descripcion = descripcion,
                    }, ticket, id);

                    return res;
                }
                else
                {
                    return "Datos invalidos";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            
        }

        public List<string> obtenerAlmacenes(string identificacion, string ticket)
        {
            try
            {
                List<string> almacenes = new List<string>();
                List<ModelAlmacen> data = productos.ObtenerAlmacenes(identificacion, ticket);
                foreach(ModelAlmacen alm in data)
                {
                    almacenes.Add(alm.Descripcion);
                }

                return almacenes;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable allCustomer(string ticket, string identificacion)
        {
            try
            {
                DataTable dtProducto = createTable();
                List<VLIS_Articulos> allProd = productos.ObtenerTodosProductos(ticket, identificacion);
                foreach(VLIS_Articulos prod in allProd)
                {
                    DataRow drRow = dtProducto.NewRow();
                    drRow["Codigo"] = prod.codigo;
                    drRow["Nombre"] = prod.Descripcion;
                    drRow["Existencias"] = prod.Stock.ToString();
                    drRow["Almacen"] = prod.Almacen;

                    dtProducto.Rows.Add(drRow);
                }

                return dtProducto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable obtenerProductoFiltrado(string ticket, string identificacion, string nombre)
        {
            try
            {
                DataTable dtProducto = createTable();
                if (validarNombreP(nombre))
                {
                    List<ModelProducto> allProd = productos.ObtenerUnProductoNombre(ticket, identificacion, nombre);
                    foreach (ModelProducto prod in allProd)
                    {
                        DataRow drRow = dtProducto.NewRow();
                        drRow["Codigo"] = prod.codigo;
                        drRow["Nombre"] = prod.descripcion;
                        drRow["Existencias"] = prod.cantidad.ToString();
                        drRow["Almacen"] = prod.nombreAlmacen;

                        dtProducto.Rows.Add(drRow);
                    }

                    return dtProducto;
                }
                else
                {
                    return dtProducto;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarProducto(string ticket, string identificacion, string codigo)
        {
            try
            {
                string resp = productos.BorrarProducto(ticket, identificacion, codigo);

                return resp;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> obtenerUnProducto(string ticket, string identificacion, string codigo)
        {
            try
            {
                ModelProducto product = productos.ObtenerUnProducto(ticket, identificacion, codigo);
                List<string> data = new List<string>();
                data.Add(product.codigo);
                data.Add(product.descripcion);
                data.Add(product.cantidad.ToString());
                data.Add(product.nombreAlmacen);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarDatosProducto(string descripcion, string codigo, string cantidad, string nombreAlmacen)
        {
            try
            {
                if (vacioTexto(descripcion) == false && validarTexto(descripcion) == true && validarKeyWords(descripcion) == false)
                {
                    if (vacioTexto(codigo) == false && validarNumero(codigo) == true && validarKeyWords(codigo) == false)
                    {
                        if (vacioTexto(cantidad) == false && validarNumero(cantidad) == true && cantidad.Equals("0") == false)
                        {
                            if (vacioTexto(nombreAlmacen) == false && validarTexto(nombreAlmacen) == true && validarKeyWords(nombreAlmacen) == false && nombreAlmacen.Equals("Seleccione un almacen") == false)
                            {
                                return "1";
                            }
                            else
                            {
                                return "El nombre del almacen es invalido";
                            }
                        }
                        else
                        {
                            return "La cantidad es invalida.";
                        }

                    }
                    else
                    {
                        return "El codigo del producto es invalido.";
                    }
                }
                else
                {
                    return "El nombre del producto es invalido.";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string actualizarProducto(string codigo, string descripcion, string cantidad, string nombreAlmacen, string ticket, string identificacion)
        {
            try
            {
                string res = productos.ActualizarProducto(new ModelProducto()
                {
                    descripcion = descripcion,
                    codigo = codigo,
                    cantidad = cantidad,
                    nombreAlmacen = nombreAlmacen
                }, ticket, identificacion);

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private DataTable createTable()
        {
            try
            {
                DataTable dtProducto = new DataTable("tablaProductos");
                string[] columns = { "Codigo", "Nombre", "Existencias", "Almacen" };
                foreach (string column in columns)
                {
                    DataColumn dcColumna = new DataColumn()
                    {
                        Caption = column,
                        ColumnName = column,
                        DataType = System.Type.GetType("System.String")
                    };

                    dtProducto.Columns.Add(dcColumna);
                }

                return dtProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarCodigoP(string data)
        {
            try
            {
                if(vacioTexto(data) == false && validarNumero(data))
                {
                    return "1";
                }
                else
                {
                    return "Se debe seleccionar un producto";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool validarNombreP(string data)
        {
            try
            {
                if (vacioTexto(data) == false && validarTexto(data))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarTexto(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                return data.All(char.IsLetter);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool validarNumero(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                return data.All(char.IsDigit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarKeyWords(string data)
        {
            try
            {
                data = data.Replace(" ", String.Empty);
                data = data.ToUpper();
                if((data.Contains("SELECT") || data.Equals("SELECT")) ||  (data.Contains("UPDATE") || data.Equals("UPDATE")) || (data.Contains("INSERT") || data.Equals("INSERT")) || (data.Contains("DELETE")) || data.Equals("DELETE"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool vacioTexto(string data)
        {
            try
            {
                if(data.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
