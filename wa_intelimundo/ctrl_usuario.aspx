<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_usuario.aspx.cs" Inherits="wa_intelimundo.ctrl_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="section">
                <div class="container">
                    <div class="form-group form-group-sm">
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
                                <h2 class="text-center">
                                    <asp:Label ID="lbl_reg" runat="server" Text=""></asp:Label></h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 text-right">
                                <asp:RadioButton CssClass="radio-inline" ID="rb_add" runat="server" Text="Agregar" AutoPostBack="True" OnCheckedChanged="rb_add_CheckedChanged" />
                                <asp:RadioButton CssClass="radio-inline" ID="rb_edit" runat="server" Text="Editar" AutoPostBack="True" OnCheckedChanged="rb_edit_CheckedChanged" />
                                <asp:RadioButton CssClass="radio-inline" ID="rb_drop" runat="server" Text="Baja" AutoPostBack="True" OnCheckedChanged="rb_drop_CheckedChanged" />
                                <asp:RadioButton CssClass="radio-inline" ID="rb_del" runat="server" Text="Eliminar" AutoPostBack="True" OnCheckedChanged="rb_del_CheckedChanged" />
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
                                <br />
                                <asp:GridView CssClass="table" ID="gv_usuarios" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_usuarios_PageIndexChanging" >
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_select" runat="server" onclick="CheckOne(this)" OnCheckedChanged="chk_OnCheckedChanged" AutoPostBack="true"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="codigo_usuario" HeaderText="ID de Usuario" SortExpression="codigo_usuario" Visible="true" />
                                        <asp:BoundField DataField="desc_estatus" HeaderText="Estatus" SortExpression="desc_estatus" />
                                        <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" SortExpression="fecha_nacimiento" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                        <asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="nombres" />
                                        <asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="a_paterno" />
                                        <asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="a_materno" />
                                    </Columns>
                                </asp:GridView>
                              
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <h4 class="text-center">Datos de Usuario</h4>

                            <div class="col-md-4">
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_gender" runat="server" Text="*Género"></asp:Label></h6>
                                <asp:DropDownList CssClass="form-control" ID="ddl_gender" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_licence" runat="server"
                                    ErrorMessage="Campo Requerido"
                                    ControlToValidate="ddl_gender" InitialValue="0"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_birthday" runat="server" Text="*Fecha de Nacimiento"></asp:Label></h6>
                                <asp:TextBox CssClass="form-control" ID="txt_birthday" runat="server" ForeColor="Black" placeholder="Fecha de Nacimiento"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtce" runat="server" BehaviorID="txtce" TargetControlID="txt_birthday" Format="yyyy/MM/dd" />
                                <asp:RequiredFieldValidator ID="rfv_birthday" runat="server"
                                    ControlToValidate="txt_birthday"
                                    ErrorMessage="Campo Requerido"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_name_user" runat="server" Text="*Nombre(s)"></asp:Label></h6>
                                <asp:TextBox CssClass="form-control" ID="txt_name_user" runat="server" placeholder="Capturar Nombre(s)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_name_user" runat="server"
                                    ControlToValidate="txt_name_user"
                                    ErrorMessage="Campo Requerido"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_apater" runat="server" Text="*Apellido Paterno"></asp:Label></h6>
                                <asp:TextBox CssClass="form-control" ID="txt_apater" runat="server" placeholder="Capturar Apellido Paterno"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_apater" runat="server"
                                    ControlToValidate="txt_apater"
                                    ErrorMessage="Campo Requerido"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_amater" runat="server" Text="*Apellido Materno"></asp:Label></h6>
                                <asp:TextBox CssClass="form-control" ID="txt_amater" runat="server" placeholder="Capturar Apellido Materno"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_amater" runat="server"
                                    ControlToValidate="txt_amater"
                                    ErrorMessage="Campo Requerido"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_code_user" runat="server" Text="*Usuario Intelimundo"></asp:Label></h6>
                                <asp:TextBox CssClass="form-control" ID="txt_code_user" runat="server" placeholder="Capturar Usuario Intelimundo"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_email_im" runat="server"
                                    ControlToValidate="txt_code_user"
                                    ErrorMessage="Campo Requerido"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                                <h6>
                                    <asp:Label CssClass="control-label" ID="lbl_password" runat="server" Text="*Contraseña"></asp:Label></h6>
                                <asp:TextBox CssClass="form-control" ID="txt_password" runat="server" placeholder="Capturar Contraseña" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_password" runat="server"
                                    ControlToValidate="txt_password"
                                    ErrorMessage="Campo Requerido"
                                    ForeColor="orange">
                                </asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <div class="row" id="div_infusuarios" runat="server" visible="false">
                            <div class="col-md-3 text-center" id="div_address" runat="server">
                                <h4>Datos de contacto</h4>
                                <asp:ImageButton ID="img_address" runat="server" ImageUrl="~/img/png/earth-globe.png" Width="64" Height="64" OnClick="img_address_Click" />
                            </div>
                            <div class="col-md-3 text-center">
                                <h4>Datos escolares</h4>
                                <asp:ImageButton ID="img_school" runat="server" ImageUrl="~/img/png/student.png" Width="64" Height="64" OnClick="img_school_Click" />
                            </div>

                            <div class="col-md-3 text-center" id="div_invoice" runat="server">
                                <h4>Datos fiscales</h4>

                                <asp:ImageButton ID="img_invoice" runat="server" ImageUrl="~/img/png/browser-2.png" Width="64" Height="64" OnClick="img_invoice_Click" />
                            </div>
                            <div class="col-md-3 text-center" id="div_banking" runat="server">
                                <h4>Datos Bancarios</h4>

                                <asp:ImageButton ID="img_banking" runat="server" ImageUrl="~/img/png/folder-1.png" Width="64" Height="64" OnClick="img_banking_Click" />
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
                                <h3 class="text-center text-warning">
                                    <asp:Label ID="lbl_mnsj" runat="server" Visible="True"></asp:Label>
                                </h3>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
