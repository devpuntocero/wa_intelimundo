using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    inf_user();
                    Load_ddl();
                }
                else
                {

                }
            }
            catch
            {
                Response.Redirect("ctrl_access.aspx");
            }


        }
        private void Load_ddl()
        {

            using (db_imEntities entities = new db_imEntities())
            {
                var data_gender = entities.fact_generos.ToList();

                ddl_gender.DataSource = data_gender;
                ddl_gender.DataTextField = "desc_genero";
                ddl_gender.DataValueField = "id_genero";
                ddl_gender.DataBind();
                ddl_gender.Items.Insert(0, new ListItem("--Seleccionar Género--", "0"));
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
        protected void cmd_save_Click(object sender, EventArgs e)
        {
            string str_password = mdl_encrypta.Encrypt(txt_password.Text.ToLower());
            Guid f_id_user = (Guid)(Session["ss_id_user"]);

            using (var data_user = new db_imEntities())
            {
                var items_user = (from c in data_user.inf_usuarios
                                  where c.id_usuario == f_id_user
                                  select c).FirstOrDefault();

                items_user.clave = str_password;

                data_user.SaveChanges();
            }
            lbl_mnsj.Visible = true;
            lbl_mnsj.Text = "Registro actualizado con Exito";
        }
        protected void rb_edit_CheckedChanged(object sender, EventArgs e)
        {
            Guid id_user = (Guid)(Session["ss_id_user"]);
            Guid id_center = (Guid)(Session["ss_id_center"]);

            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from u in data_user.inf_usuarios
                                join tu in data_user.fact_tipo_usuarios on u.id_tipo_usuario equals tu.id_tipo_usuario

                                join cd in data_user.inf_centros_dep on u.id_usuario equals cd.id_usuario
                                join c in data_user.inf_centros on cd.id_centro equals c.id_centro
                                where u.id_usuario == id_user
                                where c.id_centro == id_center
                                select new
                                {
                                    u.codigo_usuario,
                                    u.id_genero,
                                    u.fecha_nacimiento,
                                    u.nombres,
                                    u.a_paterno,
                                    u.a_materno,

                                }).FirstOrDefault();

                ddl_gender.SelectedValue = inf_user.id_genero.ToString();
                DateTime str_birthday = new DateTime();
                str_birthday = Convert.ToDateTime(inf_user.fecha_nacimiento);
                txt_birthday.Text = str_birthday.ToShortDateString();
                txt_name_user.Text = inf_user.nombres;
                txt_apater.Text = inf_user.a_paterno;
                txt_amater.Text = inf_user.a_materno;
                txt_code_user.Text = inf_user.codigo_usuario;
            }
        }
        protected void img_address_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_fid_user"] = (Guid)(Session["ss_id_user"]);
            Response.Redirect("ctrl_contacto.aspx");
        }

        protected void img_school_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_fid_user"] = (Guid)(Session["ss_id_user"]);
            Response.Redirect("ctrl_escolares.aspx");
        }

        protected void img_invoice_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_fid_user"] = (Guid)(Session["ss_id_user"]);
            Response.Redirect("ctrl_fiscales.aspx");
        }

        protected void img_banking_Click(object sender, ImageClickEventArgs e)
        {
            Session["ss_fid_user"] = (Guid)(Session["ss_id_user"]);
            Response.Redirect("ctrl_bancarios.aspx");
        }
    }
}