<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_acceso.aspx.cs" Inherits="wa_intelimundo.ctrl_acceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="section animated bounceInLeft">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="text-center">Control de Acceso</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Image CssClass="center-block img-responsive img-rounded animated bounceInLeft" ID="Image1" runat="server" ImageUrl="~/img/im.png" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 center-block">
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <h6>
                            <asp:Label CssClass="control-label" ID="lbl_code_user" runat="server" Text="*Usuario Intelimundo"></asp:Label></h6>
                        <asp:TextBox CssClass="form-control" ID="txt_code_user" runat="server" TabIndex="1" placeholder="Capturar Usuario Intelimundo"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_email_im" runat="server"
                            ControlToValidate="txt_code_user"
                            ErrorMessage="Campo Requerido"
                            ForeColor="orange">
                        </asp:RequiredFieldValidator>
                         <h6>
                            <asp:Label CssClass="control-label" ID="lbl_center" runat="server" Text="Centro" Visible="false" ></asp:Label></h6>
                        <asp:DropDownList CssClass="form-control" ID="ddl_center" runat="server"  TabIndex="2" Visible="false" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_center" runat="server"
                            ErrorMessage="Campo Requerido"
                            ControlToValidate="ddl_center" InitialValue="0"
                            ForeColor="orange">
                        </asp:RequiredFieldValidator>
                        <h6>
                            <asp:Label CssClass="control-label" ID="lbl_password" runat="server" Text="*Contraseña"></asp:Label></h6>
                        <asp:TextBox CssClass="form-control" ID="txt_password" runat="server" TabIndex="3" placeholder="Capturar Contraseña" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_password" runat="server"
                            ControlToValidate="txt_password"
                            ErrorMessage="Campo Requerido"
                            ForeColor="orange">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="row">
                        <div class="col-md-6 text-center">
                            <asp:Button CssClass="btn btn-success" ID="cmd_registry" runat="server" Text="Registrar" TabIndex="5" />
                        </div>
                        <div class="col-md-6 text-center">
                            <asp:Button CssClass="btn btn-success" ID="cmd_login" runat="server" Text="Entrar" TabIndex="4" OnClick="cmd_login_Click" />
                        </div>
                    </div>
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
</asp:Content>
