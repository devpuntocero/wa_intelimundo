using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_menu_contabilidad : System.Web.UI.Page
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


            }
        }
        protected void img_back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_menu.aspx");
        }
        protected void img_exit_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_access.aspx");
        }
        protected void img_expenses_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_expenses.aspx");
        }

        protected void img_remission_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_remission.aspx");
        }

        protected void img_invoice_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_invoice.aspx");
        }

        protected void img_rptremission_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_rpt_remission.aspx");
        }

        protected void img_rptinvoice_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_rpt_invoice.aspx");
        }

        protected void img_rptexpenses_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ctrl_rpt_expenses.aspx");
        }
    }
}