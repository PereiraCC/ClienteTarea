<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TareaCorta3.Users.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/CSS/bootstrap.min.css" />
    <title>Inicio Sesion</title>
</head>
<body>
    <div class="container p-4">
    <div class="row">
        <div class="col-md-4 mx-auto">
            <div class="card text-center">
                <div class="card-header">
                    <h3>Iniciar Sesion</h3>
                </div>
                <img src="/Assets/user.png" class="mx-auto w-25"/>
                <div class="card-body">
                   <form id="Form1" method="post" runat="server" autocomplete="off">
                        <div class="form-group">
                            <asp:TextBox ID="txtIdentificacion"  placeholder="Identificacion" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPassword" Type="password"  placeholder="Contraseña" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnIniciarSesion" Text="Iniciar Sesion" OnClick="Button1_Click" runat="server" CssClass="btn btn-primary btn-block"/>
                        <br />
                        <div class="form-group">
                            <a href="Registro.aspx">Nuevo Usuario</a>
                        </div>
                       <div class="alert-danger">
                           <asp:Label ID="lblError" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                       </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div> 
</body>
</html>
