<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_fiscales.aspx.cs" Inherits="wa_intelimundo.ctrl_fiscales" %>
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
                            <h2 class="text-center">Registro de datos Fiscales</h2>
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
                    <div class="row" id="div_fiscal" runat="server" visible="true">

                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_type_rfc" runat="server" Text="Tipo de RFC" Visible="True"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_type_rfc" runat="server" Visible="True"></asp:DropDownList>
                              <asp:RequiredFieldValidator ID="rfv_type_rfc" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_type_rfc" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_business_name" runat="server" Text="Razón Social" Visible="True"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_business_name" runat="server" placeholder="Capturar Razón Social" Visible="True"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfv_business_name" runat="server"
                                ControlToValidate="txt_business_name"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_rfc" runat="server" Text="RFC" Visible="True"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_rfc" runat="server" placeholder="Capturar RFC" Visible="True"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfv_rfc" runat="server"
                                ControlToValidate="txt_rfc"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_country" runat="server" Text="País"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_country" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_country" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_country" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_state" runat="server" Text="Estado"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_state" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_state" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_state" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_municipality" runat="server" Text="Municipio"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_municipality" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_municipality" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_municipality" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_colony" runat="server" Text="Colonia"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_colony" runat="server" placeholder="Capturar Colonia"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_colony" runat="server"
                                ControlToValidate="txt_colony"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_street" runat="server" Text="Calle"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_street" runat="server" placeholder="Capturar Calle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_street" runat="server"
                                ControlToValidate="txt_street"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>

                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_cp" runat="server" Text="Código Postal"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_cp" runat="server" placeholder="Capturar Código Postal" MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="txt_cp_MaskedEditExtender" runat="server" TargetControlID="txt_cp" Mask="99999" />
                            <asp:RequiredFieldValidator ID="rfv_cp" runat="server"
                                ControlToValidate="txt_cp"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_phone" runat="server" Text="Teléfono"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_phone" runat="server" placeholder="Capturar Teléfono"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="txt_phone_MaskedEditExtender" runat="server" TargetControlID="txt_phone" Mask="(52) 99.99.99.99.99.99 ext 99999" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txt_phone"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_phone_alt" runat="server" Text="Teléfono Alterno"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_phone_alt" runat="server" placeholder="Capturar Teléfono Alterno"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="txt_phone_alt_MaskedEditExtender" runat="server" TargetControlID="txt_phone_alt" Mask="(52) 99.99.99.99.99.99 ext 99999" />
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
