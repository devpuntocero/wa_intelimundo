<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_centros.aspx.cs" Inherits="wa_intelimundo.ctrl_centros" %>
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
                            <h2 class="text-center">Registro de Centros Intelimundo</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 text-right">
                            <asp:RadioButton CssClass="radio-inline" ID="rb_add" runat="server" Text="Agregar" AutoPostBack="True" OnCheckedChanged="rb_add_CheckedChanged" />
                            <asp:RadioButton CssClass="radio-inline" ID="rb_edit" runat="server" Text="Editar" AutoPostBack="True" OnCheckedChanged="rb_edit_CheckedChanged" />
                            <asp:RadioButton CssClass="radio-inline" ID="rb_drop" runat="server" Text="Baja" AutoPostBack="True" OnCheckedChanged="rb_drop_CheckedChanged" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-offset-3 col-md-6">

                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txt_search" runat="server" placeholder="Buscar" Visible="false"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button CssClass="btn btn-success" ID="cmd_search" runat="server" Text="Ir" Visible="false" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <br />
                            <script>
                                function CheckOne(obj) {
                                    var grid = obj.parentNode.parentNode.parentNode;
                                    var inputs = grid.getElementsByTagName("input");
                                    for (var i = 0; i < inputs.length; i++) {
                                        if (inputs[i].type == "checkbox") {
                                            if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                                                inputs[i].checked = false;
                                            }
                                        }
                                    }
                                }
                            </script>
                            <asp:GridView CssClass="table" ID="gv_centros" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_centros_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_select_centers" runat="server" onclick="CheckOne(this)" OnCheckedChanged="chk_OnCheckedChanged" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="codigo_centro" HeaderText="Codigo Centro" SortExpression="codigo_centro" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre de Centro" SortExpression="nombre" />
                                    <asp:BoundField DataField="desc_licencia" HeaderText="Licencia" SortExpression="desc_licencia" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="nombres" />
                                    <asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="a_paterno" />
                                    <asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="a_materno" />
                                </Columns>
                            </asp:GridView>
                            <div class="text-right">
                                <asp:Button CssClass="btn btn-success" ID="cmd_centers" runat="server" Text="Ver" Visible="False" />
                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="row">
                        <h4 class="text-center">Datos Generales</h4>

                        <div class="col-md-4 text-center">
                            <asp:ImageButton ID="img_profile" runat="server" ImageUrl="~/img/png/university-1.png" Width="128" Height="128" />
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_license" runat="server" Text="Licencia"></asp:Label></h6>
                            <asp:DropDownList CssClass="form-control" ID="ddl_license" runat="server" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_licence" runat="server"
                                ErrorMessage="Campo Requerido"
                                ControlToValidate="ddl_license" InitialValue="0"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_namecenter" runat="server" Text="Nombre del Centro"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_namecenter" runat="server" placeholder="Capturar Nombre del Centro"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_namecenter" runat="server"
                                ControlToValidate="txt_namecenter"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="div_contact" runat="server">
                        <br />
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
                        <div class="col-md-4">
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_email" runat="server" Text="Correo Electrónico"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_email" runat="server" placeholder="Capturar Correo Electrónico"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_email" runat="server"
                                ControlToValidate="txt_email"
                                ErrorMessage="Campo Requerido"
                                ForeColor="orange">
                            </asp:RequiredFieldValidator>
                            <h6>
                                <asp:Label CssClass="control-label" ID="lbl_email_alt" runat="server" Text="Correo Electrónico Alterno"></asp:Label></h6>
                            <asp:TextBox CssClass="form-control" ID="txt_email_alt" runat="server" placeholder="Capturar Correo Electrónico Alterno"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <h4 class="text-center">Asignar Franquiciado a Centro</h4>
                        <div class="col-md-12">
                            <br />
                            <asp:GridView CssClass="table" ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="true" Visible="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_select_users" runat="server" AutoPostBack="True" onclick="CheckOne(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="codigo_usuario" HeaderText="ID Usuario" SortExpression="email_im" Visible="true" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="name" />
                                    <asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="apater" />
                                    <asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="amater" />
                                    <asp:BoundField DataField="desc_tipo_usuario" HeaderText="Tipo de Usuario" SortExpression="users_type" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
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
