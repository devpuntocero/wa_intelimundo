<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_menu_contabilidad.aspx.cs" Inherits="wa_intelimundo.ctrl_menu_contabilidad" %>
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
                    <h1 class="text-center">Menu Contabilidad</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 text-center">
                    <h4>Gastos</h4>
                    <asp:ImageButton ID="img_expenses" runat="server" ImageUrl="~/img/png/browser-2.png" Width="64" Height="64" OnClick="img_expenses_Click" />
                </div>
                <div class="col-md-4 text-center">
                    <h4>Remisión</h4>
                    <asp:ImageButton ID="img_remission" runat="server" ImageUrl="~/img/png/browser.png" Width="64" Height="64" OnClick="img_remission_Click" />
                </div>
                <div class="col-md-4 text-center">
                    <h4>Factura</h4>
                    <asp:ImageButton ID="img_invoice" runat="server" ImageUrl="~/img/png/code.png" Width="64" Height="64" OnClick="img_invoice_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 text-center">
                    <h4>Reporte de Gastos</h4>
                    <asp:ImageButton ID="img_rptexpenses" runat="server" ImageUrl="~/img/png/ebook.png" Width="64" Height="64" OnClick="img_rptexpenses_Click" />
                </div>
                <div class="col-md-4 text-center">
                    <h4>Reporte de Remisiones</h4>
                    <asp:ImageButton ID="img_rptremission" runat="server" ImageUrl="~/img/png/tutorial.png" Width="64" Height="64" OnClick="img_rptremission_Click" />
                </div>
                <div class="col-md-4 text-center">
                    <h4>Reporte de Facturas</h4>
                    <asp:ImageButton ID="img_rptinvoice" runat="server" ImageUrl="~/img/png/book.png" Width="64" Height="64" OnClick="img_rptinvoice_Click"  />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
