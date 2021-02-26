<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TareaCorta3.Users.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/CSS/bootstrap.min.css" />
    <title>Registro Usuario</title>
</head>
<body>
   <div class="container p-4">
        <form id="Form1" method="post" runat="server" autocomplete="off">
            <div class="col-xs-6 col-md-5">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Registro de usuario</h3><br />
                    </div>
                    <div class="panel-body">
                        <div class="accordion" id="accordionExample">
                            <div class="card">
                                <div class="card-header" id="headingOne">
                                    <div id="header" class="bg-info">
                                        <h2 class="mb-0 t">
                                            <button class="btn btn-link text-light" type="button" data-toggle="collapse"
                                                    data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                Ingresar Informacion
                                            </button>
                                        </h2>
                                    </div>
                                </div>
                                <div id="collapseOne" class="collapse show" aria-labelledby="headingOne"
                                     data-parent="#accordionExample">
                                    <div class="card-body">
                                       
                                        <div class="form-group">
                                            <asp:TextBox ID="txtIdentificacion"  placeholder="Identificacion" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtNombre"  placeholder="Nombre" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtApellidos"  placeholder="Apellidos" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" type="password"  placeholder="Contraseña" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group text-center">
                                            <asp:Button ID="btnRegistrar" Text="Registrar"  runat="server" CssClass="btn btn-primary btn-block" OnClick="btnRegistrar_Click"/>
                                        </div>

                                        <div class="form-group text-center">
                                            <div class="alert-danger">
                                                <asp:Label ID="lblError" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
