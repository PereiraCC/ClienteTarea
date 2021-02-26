﻿using Negocios;
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
            if(LUser.Estado == false)
            {
                string resp = user.ValidarNulosIndex(txtIdentificacion.Text, txtPassword.Text);
                if (resp.Equals("1"))
                {
                    resp = user.ValidarNumero(txtIdentificacion.Text);
                    if (resp.Equals("1"))
                    {
                        resp = user.ValidarUsuario(txtIdentificacion.Text, txtPassword.Text);
                        if (resp.Equals("1"))
                        {
                            LUser.Estado = true;
                            Response.Redirect("../Products/listadoProductos.aspx");
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Error: " + resp;
                            txtIdentificacion.Text = "";
                            txtPassword.Text = "";
                        }//vusuario
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error: " + resp;
                        txtIdentificacion.Text = "";
                        txtPassword.Text = "";
                    }//vnumeros
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
                Response.Redirect("index.aspx");
            }
            
        }
    }
}