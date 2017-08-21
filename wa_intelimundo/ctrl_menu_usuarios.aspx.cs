using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_menu_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    inf_user();
                }
                else
                {

                }
            }
            catch
            {
                Response.Redirect("ctrl_acceso.aspx");
            }
        }
        private void inf_user()
        {
            Guid id_user = (Guid)(Session["ss_id_user"]);
            Guid id_center = (Guid)(Session["ss_id_center"]);


            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from a in data_user.inf_usuarios
                                join b in data_user.fact_tipo_usuarios on a.id_tipo_usuario equals b.id_tipo_usuario
                                join c in data_user.inf_centros_dep on a.id_usuario equals c.id_usuario
                                join d in data_user.inf_centros on c.id_centro equals d.id_centro

                                where a.id_usuario == id_user
                                where d.id_centro == id_center
                                select new
                                {
                                    a.nombres,
                                    a.a_paterno,
                                    a.a_materno,
                                    b.desc_tipo_usuario,
                                    b.id_tipo_usuario,
                                    d.id_centro,
                                    d.nombre

                                }).FirstOrDefault();

                lbl_name.Text = inf_user.nombres + " " + inf_user.a_paterno + " " + inf_user.a_materno;
                lbl_profile_user.Text = inf_user.desc_tipo_usuario;
                lbl_id_profile_user.Text = inf_user.id_tipo_usuario.ToString();
                lbl_user_centerCP.Text = inf_user.nombre;
                lbl_id_centerCP.Text = inf_user.id_centro.ToString();

                int str_id_type_user = inf_user.id_tipo_usuario;
                switch (str_id_type_user)
                {
                    case 1:

                        break;
                    case 2:


                        break;
                    case 3:

                        div_administrator.Visible = false;
                        break;
                    case 4:

                        div_administrator.Visible = false;
                        div_franchisee.Visible = false;
                        break;
                    case 5:

                        div_administrator.Visible = false;
                        div_franchisee.Visible = false;
                        div_manager.Visible = false;
                        break;
                    case 6:

                        div_administrator.Visible = false;
                        div_franchisee.Visible = false;
                        div_manager.Visible = false;
                        div_facilitator.Visible = false;
                        break;
                }
            }
        }
        protected void img_profile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_perfil.aspx");
        }

        protected void img_administrator_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_save_user"] = 3;
            Response.Redirect("ctrl_usuario.aspx");
        }

        protected void img_franchisee_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_save_user"] = 4;
            Response.Redirect("ctrl_usuario.aspx");
        }

        protected void img_manager_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_save_user"] = 5;
            Response.Redirect("ctrl_usuario.aspx");
        }

        protected void img_facilitator_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_save_user"] = 6;
            Response.Redirect("ctrl_usuario.aspx");
        }

        protected void img_student_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_save_user"] = 7;
            Response.Redirect("ctrl_usuario.aspx");
        }
    }
}