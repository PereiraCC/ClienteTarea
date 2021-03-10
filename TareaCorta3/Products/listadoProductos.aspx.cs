using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TareaCorta3.Login;

namespace TareaCorta3.Products
{
    public partial class listadoProductos : System.Web.UI.Page
    {
        Producto producto = new Producto();
        ActionsUser user = new ActionsUser();
        DataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarTable();
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void cargarTable()
        {
            try
            {
                table = producto.allCustomer(LUser.Ticket, LUser.Identificacion);
                gvProducts.DataSource = table;
                gvProducts.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void idCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = user.cerrarSesion(LUser.Identificacion);
                if (resp.Equals("1"))
                {
                    Response.Redirect("../Users/index.aspx");
                }
                else
                {
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrarProducto.codigo = "";
                Response.Redirect("RegistrarProducto.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = gvProducts.SelectedIndex;
                DataRow row = table.Rows[fila];
                txtCodigoS.Text = row["codigo"].ToString();
            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = producto.validarCodigoP(txtCodigoS.Text);
                if (resp.Equals("1"))
                {
                    if (producto.eliminarProducto(LUser.Ticket, LUser.Identificacion, txtCodigoS.Text).Equals("1"))
                    {
                        cargarTable();
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error: La eliminacion de un producto fue cancelada";
                    }
                }
                else
                {
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = producto.validarCodigoP(txtCodigoS.Text);
                if (resp.Equals("1"))
                {
                    RegistrarProducto.codigo = txtCodigoS.Text;
                    Response.Redirect("RegistrarProducto.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Error: " + resp;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                table = producto.obtenerProductoFiltrado(LUser.Ticket, LUser.Identificacion, txtNombre.Text);
                gvProducts.DataSource = table;
                gvProducts.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                cargarTable();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}