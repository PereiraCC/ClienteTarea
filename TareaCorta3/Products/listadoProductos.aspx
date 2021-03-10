<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listadoProductos.aspx.cs" Inherits="TareaCorta3.Products.listadoProductos" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/CSS/bootstrap.min.css" />
    <title>Registro</title>
</head>
<body>
    <div class="container p-4">
        <div style="top: 12px">
            <h3>Listado de Productos</h3>
        </div>
        <br />
        <br />
        <form id="Form1" method="post" runat="server">
            <div class="form-group" runat="server">
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtNombre" runat="server" Text="" ReadOnly="false" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            <asp:Button class="btn btn-success text-white" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            <asp:Button class="btn btn-secondary text-white" ID="btnTodos" runat="server" Text="Todos" OnClick="btnTodos_Click"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            <asp:Button class="btn btn-primary text-white" ID="btnAdd" runat="server" Text="Nuevo Producto" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            <asp:Button class="btn btn-success" ID="btnUpdate" runat="server" Text="Modificar Producto" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            <asp:Button class="btn btn-danger" ID="btnDelete" runat="server" Text="Eliminar Producto" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4">
                            <asp:Button class="btn btn-secondary" ID="idCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="idCerrarSesion_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-7">
                            <asp:Label ID="lblCodigoS" class="text-dark" runat="server" Text="Codigo seleccionado" Visible="true"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCodigoS" runat="server" Text="" ReadOnly="true" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-12">
                            <div class="alert-danger">
                                <asp:Label ID="lblError" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <br />

                <br />
                <br />
                <div class="row">
                    <div class="form-group">
                         <div class="col-md-12">
                           <asp:GridView ID="gvProducts" runat="server" Class="table table-bordered table-responsive" AutoGenerateColumns="False"  OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
                                 <Columns>
                                     <asp:CommandField HeaderText="Accion" SelectText="Seleccionar" ShowSelectButton="True" />
                                     <asp:BoundField DataField="Codigo" HeaderText="Codigo"/>
                                     <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                     <asp:BoundField DataField="Existencias" HeaderText="Existencias" />
                                     <asp:BoundField DataField="Almacen" HeaderText="Almacen" />
                                 </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            
        </form>
    </div>

</body>
</html>
