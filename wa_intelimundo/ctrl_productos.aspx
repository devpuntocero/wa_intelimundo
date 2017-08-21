<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_productos.aspx.cs" Inherits="wa_intelimundo.ctrl_productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="section">
                <div class="container">
                    <div class="row">
                        <div class="col-md-1">
                            <a href="ctrl_menu.aspx">
                                <img alt="" src="img/ico_back.png" /></a>
                        </div>
                        <div class="col-md-1">
                            <a href="ctrl_acceso.aspx">
                                <img alt="" src="img/ico_exit.png" /></a>
                        </div>
                        <br />
                        <div class="col-md-10">
                            <p class="text-right text-success">
                                <asp:Label ID="lbl_welcome" runat="server" Text="Bienvenid@: "></asp:Label>
                                <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>

                                <br />
                                <asp:Label ID="lbl_profilelbl" runat="server" Text="Perfil: "></asp:Label>
                                <asp:Label ID="lbl_profile_user" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_id_profile_user" runat="server" Text="" Visible="false"></asp:Label>
                                <br />
                                <asp:Label ID="lbl_user_centerP" runat="server" Text="Centro: "></asp:Label>
                                <asp:Label ID="lbl_user_centerCP" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_id_centerCP" runat="server" Text="" Visible="false"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h2 class="text-center">Registro de Productos</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 text-right">
                            <asp:RadioButton CssClass="radio-inline" ID="rb_edit" runat="server" Text="Editar" AutoPostBack="True"  />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">

                            <asp:GridView CssClass="table" ID="gv_usuarios" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="codigo_usuario" HeaderText="ID de Usuario" SortExpression="codigo_usuario" Visible="true" />
                                    <asp:BoundField DataField="desc_genero" HeaderText="Género" SortExpression="desc_genero" />
                                    <asp:BoundField DataField="desc_estatus" HeaderText="Estatus" SortExpression="desc_estatus" />
                                    <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" SortExpression="fecha_nacimiento" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="nombres" />
                                    <asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="a_paterno" />
                                    <asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="a_materno" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row" id="div_infbank" runat="server" visible="true">
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_bankdata" runat="server" Text="Banco"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_bankdata" runat="server" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_bankdata" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_bankdata" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_card" runat="server" Text="Tarjeta"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_card" runat="server" placeholder="Capturar Tarjeta" MaxLength="16"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="mee_card" runat="server" TargetControlID="txt_card" Mask="9999999999999999" />
                            <asp:RequiredFieldValidator ID="rfv_card" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="txt_card"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_clabe" runat="server" Text="CLABE Interbancaria"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_clabe" runat="server" placeholder="Capturar CLABE" MaxLength="18"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="mee_clabe" runat="server" TargetControlID="txt_clabe" Mask="999999999999999999" />
                            <asp:RequiredFieldValidator ID="rfv_clabe" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="txt_clabe"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-right">
                            <asp:Button CssClass="btn btn-success" ID="cmd_save" runat="server" Text="Guardar" OnClick="cmd_save_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="text-center">
                                <asp:Label ID="lbl_mnsj" runat="server" Visible="False"></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
