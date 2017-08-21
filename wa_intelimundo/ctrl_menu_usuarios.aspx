<%@ Page Title="" Language="C#" MasterPageFile="~/mp_intelimundo.Master" AutoEventWireup="true" CodeBehind="ctrl_menu_usuarios.aspx.cs" Inherits="wa_intelimundo.ctrl_menu_usuarios" %>
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
                    <h1 class="text-center">Control de Usuarios</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 text-center" id="div_profile" runat="server">
                    <h4>Perfil</h4>
                    <asp:ImageButton ID="img_profile" runat="server" ImageUrl="~/img/png/verification.png" Width="64" Height="64" OnClick="img_profile_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_administrator" runat="server">
                    <h4>
                        <asp:Label ID="lbl_administrator" runat="server" Text="Administrador"></asp:Label></h4>

                    <asp:ImageButton ID="img_administrator" runat="server" ImageUrl="~/img/png/student-2.png" Width="64" Height="64" OnClick="img_administrator_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_franchisee" runat="server">
                    <h4>
                        <asp:Label ID="lbl_franchisee" runat="server" Text="Franquiciado"></asp:Label></h4>

                    <asp:ImageButton ID="img_franchisee" runat="server" ImageUrl="~/img/png/audiobook-1.png" Width="64" Height="64" OnClick="img_franchisee_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 text-center" id="div_manager" runat="server">
                    <h4>
                        <asp:Label ID="lbl_manager" runat="server" Text="Gerente"></asp:Label></h4>

                    <asp:ImageButton ID="img_manager" runat="server" ImageUrl="~/img/png/student-3.png" Width="64" Height="64" OnClick="img_manager_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_facilitator" runat="server">
                    <h4>
                        <asp:Label ID="lbl_facilitator" runat="server" Text="Facilitador"></asp:Label></h4>

                    <asp:ImageButton ID="img_facilitator" runat="server" ImageUrl="~/img/png/professor.png" Width="64" Height="64" OnClick="img_facilitator_Click" />

                </div>
                <div class="col-md-4 text-center" id="div_student" runat="server">
                    <h4>
                        <asp:Label ID="lbl_student" runat="server" Text="Alumno"></asp:Label></h4>

                    <asp:ImageButton ID="img_student" runat="server" ImageUrl="~/img/png/video-player.png" Width="64" Height="64" OnClick="img_student_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
