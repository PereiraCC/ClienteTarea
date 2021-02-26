using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaCorta3.Users
{
    public partial class Registro : System.Web.UI.Page
    {
        ActionsUser user = new ActionsUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = user.ValidarNulos(txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, txtPassword.Text);
                if (resp.Equals("1"))
                {
                    resp = user.validarTexto(txtNombre.Text, txtApellidos.Text);
                    if (resp.Equals("1"))
                    {
                        resp = user.ValidarNumero(txtIdentificacion.Text);
                        if (resp.Equals("1"))
                        {
                            resp = user.crearUsuario(txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, txtPassword.Text);
                            if (resp.Equals("1"))
                            {
                                Response.Redirect("index.aspx");
                            }
                            else
                            {
                                lblError.Visible = true;
                                lblError.Text = "Error: La insercion del nuevo usuario es invalida.";
                                txtIdentificacion.Text = "";
                                txtNombre.Text = "";
                                txtApellidos.Text = "";
                                txtPassword.Text = "";
                            }
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Error: " + resp;
                            txtIdentificacion.Text = "";
                            txtNombre.Text = "";
                            txtApellidos.Text = "";
                            txtPassword.Text = "";
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error: " + resp;
                        txtIdentificacion.Text = "";
                        txtNombre.Text = "";
                        txtApellidos.Text = "";
                        txtPassword.Text = "";
                    }
                }
                else
                {
                    txtIdentificacion.Text = "";
                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtPassword.Text = "";
                    lblError.Visible = true;
                    lblError.Text = "Error:  " + resp;
                }

            }
            catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error:  " + ex.Message;
            }  
        }
    }
}