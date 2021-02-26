using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaCorta3.Products
{
    public partial class RegistrarProducto : System.Web.UI.Page
    {
        Producto producto = new Producto();
        public static string codigo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCboAlmacenes();
                if (!codigo.Equals(""))
                {
                    cargarDatosProducto();
                    lblTitulo.Text = "Modificacion de producto";
                }
                else
                {
                    lblTitulo.Text = "Registro de producto";
                }
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void cargarCboAlmacenes()
        {
            try
            {
                List<string> data = producto.obtenerAlmacenes();
                drpBodega.Items.Add("Seleccione un almacen");
                foreach (string alm in data)
                {
                    drpBodega.Items.Add(alm);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void cargarDatosProducto()
        {
            try
            {
                List<string> data = producto.obtenerUnProducto(codigo);
                txtCodigo.ReadOnly = true;
                txtCodigo.Text = data[0];
                lblNombre.Visible = true;
                lblNombre.Text = "Dato actual: " + data[1];
                lblExistencias.Visible = true;
                lblExistencias.Text = "Dato actual: " + data[2];
                lblAlmacen.Visible = true;
                lblAlmacen.Text = "Dato actual: " + data[3];
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
            
        }

        protected void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = producto.validarDatosProducto(txtNombre.Text, txtCodigo.Text, txtExistencias.Text, drpBodega.Text);
                if (resp.Equals("1"))
                {
                    if (codigo.Equals(""))
                    {
                        resp = producto.crearProducto(txtNombre.Text, txtCodigo.Text);
                        if (resp.Equals("1"))
                        {
                            resp = producto.crearStock(txtExistencias.Text, drpBodega.Text, txtNombre.Text);
                            if (resp.Equals("1"))
                            {
                                Response.Redirect("listadoProductos.aspx");
                            }
                            else
                            {
                                txtCodigo.Text = "";
                                txtNombre.Text = "";
                                txtExistencias.Text = "";
                                drpBodega.Items.Clear();
                                cargarCboAlmacenes();
                                drpBodega.SelectedValue = "Seleccione un almacen";
                                lblError.Visible = true;
                                lblError.Text = "Error: La insercion de un producto fue cancelada";
                            }
                        }
                        else
                        {
                            txtCodigo.Text = "";
                            txtNombre.Text = "";
                            txtExistencias.Text = "";
                            drpBodega.Items.Clear();
                            cargarCboAlmacenes();
                            drpBodega.SelectedValue = "Seleccione un almacen";
                            lblError.Visible = true;
                            lblError.Text = "Error: La insercion de un producto fue cancelada";
                        }
                    }
                    else
                    {
                        resp = producto.actualizarProducto(txtCodigo.Text, txtNombre.Text, txtExistencias.Text, drpBodega.Text);
                        if (resp.Equals("1"))
                        {
                            Response.Redirect("listadoProductos.aspx");
                        }
                        else
                        {
                            cargarCboAlmacenes();
                            cargarDatosProducto();
                            lblError.Visible = true;
                            lblError.Text = "Error: La modificacion de un producto fue cancelada";
                        }
                    }
                    
                }
                else
                {
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtExistencias.Text = "";
                    drpBodega.Items.Clear();
                    cargarCboAlmacenes();
                    drpBodega.SelectedValue = "Seleccione un almacen";
                    lblError.Visible = true;
                    lblError.Text = "Error: " + resp;
                }

            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void btnBodega_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("RegistroAlmacen.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("listadoProductos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }
    }
}