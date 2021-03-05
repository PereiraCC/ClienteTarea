using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TareaCorta3.Login;

namespace TareaCorta3.Users
{
    public partial class Index : System.Web.UI.Page
    {
        ActionsUser user = new ActionsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                //Se valida los datos 
                string resp = user.ValidarNulosIndex(txtIdentificacion.Text, txtPassword.Text);
                if (resp.Equals("1"))
                {
                    resp = user.ValidarNumero(txtIdentificacion.Text);
                    if (resp.Equals("1"))
                    {
                        //Se valida las crendenciales del usuario
                        resp = user.ValidarUsuario(txtIdentificacion.Text, txtPassword.Text);
                        if (resp.Equals("El usuario no existe"))
                        {
                            lblError.Visible = true;
                            lblError.Text = "Error: " + resp;
                            txtIdentificacion.Text = "";
                            txtPassword.Text = "";
                        
                        }
                        else if (resp.Contains("Error"))
                        {
                            lblError.Visible = true;
                            lblError.Text = resp;
                            txtIdentificacion.Text = "";
                            txtPassword.Text = "";
                        }
                        else
                        {
                            //Se obtiene el ticket y se guarda en memoria.
                            LUser.Ticket = resp;
                            LUser.Identificacion = txtIdentificacion.Text;
                            Response.Redirect("../Products/listadoProductos.aspx");
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error: " + resp;
                        txtIdentificacion.Text = "";
                        txtPassword.Text = "";
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Error: " + resp;
                    txtIdentificacion.Text = "";
                    txtPassword.Text = "";
                }
            
            
        }
    }
}