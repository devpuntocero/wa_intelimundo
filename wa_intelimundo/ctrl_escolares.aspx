<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_escolares.aspx.cs" Inherits="wa_intelimundo.ctrl_escolares" %>
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
                            <a href="ctrl_menu_usuarios.aspx">
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
                            <h2 class="text-center">Registro de datos Escolares</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 text-right">
                            
                            <asp:RadioButton CssClass="radio-inline" ID="rb_edit" runat="server" Text="Editar" AutoPostBack="True" OnCheckedChanged="rb_edit_CheckedChanged" />
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
                    <div class="row" id="div_school" runat="server" visible="true">

                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_type_scholarship" runat="server" Text="Educación" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_type_scholarship" runat="server" AutoPostBack="True" Visible="True" OnSelectedIndexChanged="ddl_type_scholarship_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_type_scholarship" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_type_scholarship" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_scholarship" runat="server" Text="Escolaridad" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_scholarship" runat="server" AutoPostBack="True" Visible="True" OnSelectedIndexChanged="ddl_scholarship_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_scholarship" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_scholarship" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_scholarship_grade" runat="server" Text="Grado" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_scholarship_grade" runat="server" Visible="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_scholarship_grade" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_scholarship_grade" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_specialty" runat="server" Text="Especialidad" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_specialty" runat="server" Visible="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_specialty" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_specialty" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_language" runat="server" Text="Idioma" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_language" runat="server" Visible="True"></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="rfv_language" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_language" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_language_level" runat="server" Text="Nivel" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_language_level" runat="server" Visible="True"></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="rfv_language_level" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_language_level" InitialValue="0"
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
