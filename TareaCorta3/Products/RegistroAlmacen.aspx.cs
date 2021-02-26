using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaCorta3.Products
{
    public partial class RegistroAlmacen : System.Web.UI.Page
    {
        Producto produtos = new Producto();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("RegistrarProducto.aspx");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRegistrarAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = produtos.crearAlmacen(txtNombre.Text);
                if (resp.Equals("0") || resp.Equals("1"))
                {
                    if (resp.Equals("1"))
                    {
                        Response.Redirect("RegistrarProducto.aspx");
                    }
                    else
                    {
                        txtNombre.Text = "";
                        lblError.Visible = true;
                        lblError.Text = "Error: Insercion cancelada";
                    }
                    
                }
                else
                {
                    txtNombre.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "Error: Datos incorrectos";
                }
                
            }
            catch (Exception ex)
            {
                txtNombre.Text = "";
                lblError.Visible = true;
                lblError.Text = "Error: " + ex.Message;
            }
        }
    }
}