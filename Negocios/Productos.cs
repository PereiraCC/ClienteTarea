using Datos;
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

        public string crearProducto(string descripcion, string codigo)
        {
            try
            {
                int res = productos.crearProducto(new Productos()
                {
                    Descripcion = descripcion,
                    codigo = codigo,
                });

                if (res == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string crearAlmacen(string descripcion)
        {
            try
            {
                if (vacioTexto(descripcion) == false && validarTexto(descripcion) == true && validarKeyWords(descripcion) == false)
                {
                    int res = productos.crearAlmacen(new Almacenes()
                    {
                        Descripcion = descripcion,
                    });

                    if (res == 1)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
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

        public string crearStock(string cantidad, string nombreAlmacen, string producto)
        {
            try
            {
                int idAlmacen = productos.ObtenerUnAlmacen(nombreAlmacen);
                int idProducto = productos.ObtenerUnProducto2(producto);
                int res = productos.CrearStock(new Stock()
                {
                    Stock1 = Int32.Parse(cantidad),
                    idAlmacen = idAlmacen,
                    idProducto = idProducto
                });

                if (res == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> obtenerAlmacenes()
        {
            try
            {
                List<string> almacenes = new List<string>();
                List<Almacenes> data = productos.ObtenerAlmacenes();
                foreach(Almacenes alm in data)
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

        public DataTable allCustomer()
        {
            try
            {
                DataTable dtProducto = createTable();
                List<VLIS_Articulos> allProd = productos.ObtenerTodos();
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

        public string eliminarProducto(string codigo)
        {
            try
            {
                int resp = productos.BorrarProducto(codigo);
                if(resp == 2)
                {
                    return "1";
                }
                else if(resp == 1)
                {
                    return "0";
                }
                else
                {
                    return "0";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> obtenerUnProducto(string codigo)
        {
            try
            {
                VLIS_Articulos product = productos.ObtenerUnProducto(codigo);
                List<string> data = new List<string>();
                data.Add(product.codigo);
                data.Add(product.Descripcion);
                data.Add(product.Stock.ToString());
                data.Add(product.Almacen);

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

        public string actualizarProducto(string codigo, string descripcion, string cantidad, string nombreAlmacen)
        {
            try
            {
                int resp = productos.ActualizarProducto(codigo, descripcion, cantidad, nombreAlmacen);
                if(resp == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
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
