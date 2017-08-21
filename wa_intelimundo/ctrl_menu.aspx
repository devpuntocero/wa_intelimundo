<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_menu.aspx.cs" Inherits="wa_intelimundo.ctrl_menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="section">
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    <a href="ctrl_acceso.aspx">
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
                    <h1 class="text-center">Menu</h1>
                </div>
            </div>
            <div class="row animated bounceInUp">
                <div class="col-md-4 text-center" id="div_control_users" runat="server">
                    <h4>Control de Usuarios</h4>
                    <asp:ImageButton ID="img_control_users" runat="server" ImageUrl="~/img/png/lecture.png" Width="64" Height="64" OnClick="img_control_users_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_accountant" runat="server">
                    <h4>Control Contabilidad</h4>
                    <asp:ImageButton ID="img_accountant" runat="server" ImageUrl="~/img/png/desk.png" Width="64" Height="64" OnClick="img_accountant_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_material" runat="server">
                    <h4>Material</h4>
                    <asp:ImageButton ID="img_material" runat="server" ImageUrl="~/img/png/desktop.png" Width="64" Height="64" OnClick="img_material_Click" />

                </div>

            </div>
            <div class="row animated bounceInUp">
                <div class="col-md-4 text-center" id="div_control_centers" runat="server">
                    <h4>Control de Centros</h4>
                    <asp:ImageButton ID="img_control_centers" runat="server" ImageUrl="~/img/png/university.png" Width="64" Height="64" OnClick="img_control_centers_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_products" runat="server">
                    <h4>Control de Productos</h4>
                    <asp:ImageButton ID="img_products" runat="server" ImageUrl="~/img/png/cloud.png" Width="64" Height="64" OnClick="img_products_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_resumen" runat="server">
                    <h4>Resumen</h4>
                    <asp:ImageButton ID="img_summary" runat="server" ImageUrl="~/img/png/test-3.png" Width="64" Height="64" OnClick="img_summary_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
