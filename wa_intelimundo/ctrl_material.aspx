<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_material.aspx.cs" Inherits="wa_intelimundo.ctrl_material" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <h1 class="text-center">Menu</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 text-center" id="div_recursos" runat="server">
                    <h4>Recursos</h4>
                    <asp:ImageButton ID="img_recursos" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />

                </div>
                <div class="col-md-3 text-center" id="div_preescolar" runat="server">
                    <h4>Preescolar</h4>
                    <asp:ImageButton ID="img_preescolar" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />

                </div>
                <div class="col-md-3 text-center" id="div_primaria" runat="server">
                    <h4>Primaria</h4>
                    <asp:ImageButton ID="img_primaria" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />

                </div>
                <div class="col-md-3 text-center" id="div_secundaria" runat="server">
                    <h4>Secundaria</h4>
                    <asp:ImageButton ID="img_secundaria" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />

                </div>

            </div>
            <div class="row">
                <div class="col-md-4 text-center" id="div_mediasuperior" runat="server">
                    <h4>Media Superior</h4>
                    <asp:ImageButton ID="img_mediasuperior" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />

                </div>
                <div class="col-md-4 text-center" id="div_idiomas" runat="server">
                    <h4>Idiomas</h4>
                    <asp:ImageButton ID="img_idiomas" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />

                </div>
                <div class="col-md-4 text-center" id="div_eingresos" runat="server">
                    <h4>Examens de Ingreso</h4>
                    <asp:ImageButton ID="img_eingresos" runat="server" ImageUrl="~/img/png/cloud-computing.png" Width="64" Height="64" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
