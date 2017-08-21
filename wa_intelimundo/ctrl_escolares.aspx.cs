using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_escolares : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    inf_user();
                    load_ddl();
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

        private void load_ddl()
        {
            using (db_imEntities entities = new db_imEntities())
            {
                var data_country = entities.fact_nivel_escolar.ToList();
                ddl_type_scholarship.DataSource = data_country;
                ddl_type_scholarship.DataTextField = "desc_nivel_escolar";
                ddl_type_scholarship.DataValueField = "id_nivel_escolar";
                ddl_type_scholarship.DataBind();
                ddl_type_scholarship.Items.Insert(0, new ListItem("--Seleccionar Educación--", "0"));
            }

            ddl_scholarship_grade.Items.Insert(0, new ListItem("--Seleccionar Grado--", "0"));
            ddl_specialty.Items.Insert(0, new ListItem("--Seleccionar Especialidad--", "0"));
            ddl_scholarship.Items.Insert(0, new ListItem("--Seleccionar Escolaridad--", "0"));


            using (db_imEntities entities = new db_imEntities())
            {
                var data_language = entities.fact_lenguajes.ToList();

                ddl_language.DataSource = data_language;
                ddl_language.DataTextField = "desc_lenguaje";
                ddl_language.DataValueField = "id_lenguaje";
                ddl_language.DataBind();
                ddl_language.Items.Insert(0, new ListItem("--Seleccionar Lenguaje--", "0"));
            }

            using (db_imEntities entities = new db_imEntities())
            {
                var data_language_level = entities.fact_nivel_lenguaje.ToList();

                ddl_language_level.DataSource = data_language_level;
                ddl_language_level.DataTextField = "desc_nivel_lenguaje";
                ddl_language_level.DataValueField = "id_nivel_lenguaje";
                ddl_language_level.DataBind();
                ddl_language_level.Items.Insert(0, new ListItem("--Seleccionar Nivel--", "0"));
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
            flist_user();
        }
        private void flist_user()
        {
            Guid id_fuser = (Guid)(Session["ss_fid_user"]);
            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from u in data_user.inf_usuarios
                                join e in data_user.fact_estatus on u.id_estatus equals e.id_estatus
                                join g in data_user.fact_generos on u.id_genero equals g.id_genero
                                join cd in data_user.inf_centros_dep on u.id_usuario equals cd.id_usuario
                                where u.id_usuario == id_fuser
                                select new
                                {
                                    u.codigo_usuario,
                                    g.desc_genero,
                                    e.desc_estatus,
                                    u.fecha_nacimiento,
                                    u.nombres,
                                    u.a_paterno,
                                    u.a_materno

                                }).ToList();

                gv_usuarios.DataSource = inf_user;
                gv_usuarios.DataBind();
                gv_usuarios.Visible = true;
            }
            if (rb_edit.Checked)
            {
                lbl_mnsj.Visible = false;

                try
                {
                    using (db_imEntities data_escolares = new db_imEntities())
                    {
                        var items_escolares = (from i_escolares in data_escolares.inf_escolares
                                               join i_especialidad in data_escolares.fact_especialidad_escolar on i_escolares.id_especialidad_escolar equals i_especialidad.id_especialidad_escolar
                                               join i_tipo in data_escolares.fact_tipo_escolar on i_especialidad.id_tipo_escolar equals i_tipo.id_tipo_escolar
                                               join i_nivel in data_escolares.fact_nivel_escolar on i_tipo.id_nivel_escolar equals i_nivel.id_nivel_escolar
                                               where i_escolares.id_usuario == id_fuser
                                               select new
                                               {
                                                   i_nivel.id_nivel_escolar,
                                                   i_tipo.id_tipo_escolar,
                                                   i_escolares.id_especialidad_escolar,
                                                   i_escolares.id_grado_escolar,
                                                   i_escolares.id_lenguaje,
                                                   i_escolares.id_nivel_lenguaje


                                               }).FirstOrDefault();

                        ddl_type_scholarship.SelectedValue = items_escolares.id_nivel_escolar.ToString();
                        loadscholarship(items_escolares.id_nivel_escolar);
                        ddl_scholarship.SelectedValue = items_escolares.id_tipo_escolar.ToString();
                        loadschool_grade(items_escolares.id_tipo_escolar);
                        ddl_scholarship_grade.SelectedValue = items_escolares.id_grado_escolar.ToString();
                        loadspecialty(items_escolares.id_tipo_escolar);
                        ddl_specialty.SelectedValue = items_escolares.id_especialidad_escolar.ToString();
                        ddl_language.SelectedValue = items_escolares.id_lenguaje.ToString();
                        ddl_language_level.SelectedValue = items_escolares.id_nivel_lenguaje.ToString();
                    }
                }
                catch
                {
                }
            }
        }

        protected void rb_edit_CheckedChanged(object sender, EventArgs e)
        {

            flist_user();
        }

        protected void ddl_type_scholarship_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_level_scholarship = Convert.ToInt32(ddl_type_scholarship.SelectedValue);

            loadscholarship(id_level_scholarship);
        }
        private void loadscholarship(int id_level_scholarship)
        {

            using (db_imEntities data_user = new db_imEntities())
            {
                var data_scholarship = (from c in data_user.fact_tipo_escolar
                                        where c.id_nivel_escolar == id_level_scholarship
                                        select c).ToList();

                ddl_scholarship.DataSource = data_scholarship;
                ddl_scholarship.DataTextField = "desc_tipo_escolar";
                ddl_scholarship.DataValueField = "id_tipo_escolar";
                ddl_scholarship.DataBind();
                ddl_scholarship.Items.Insert(0, new ListItem("--Seleccionar Escolaridad--", "0"));
            }

        }

        protected void ddl_scholarship_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_scholarship = Convert.ToInt32(ddl_scholarship.SelectedValue);

            loadschool_grade(id_scholarship);
            loadspecialty(id_scholarship);
        }
        private void loadschool_grade(int id_scholarship)
        {
            using (db_imEntities entities = new db_imEntities())
            {
                var data_scholarship = (from c in entities.fact_grado_escolar
                                        where c.id_tipo_escolar == id_scholarship
                                        select c).ToList();


                ddl_scholarship_grade.DataSource = data_scholarship;
                ddl_scholarship_grade.DataTextField = "desc_grado_escolar";
                ddl_scholarship_grade.DataValueField = "id_grado_escolar";
                ddl_scholarship_grade.DataBind();
                ddl_scholarship_grade.Items.Insert(0, new ListItem("--Seleccionar Grado--", "0"));
            }

        }
        private void loadspecialty(int id_scholarship)
        {
            using (db_imEntities entities = new db_imEntities())
            {
                var items_user = (from c in entities.fact_especialidad_escolar
                                  where c.id_tipo_escolar == id_scholarship
                                  select c).ToList();

                ddl_specialty.DataSource = items_user;
                ddl_specialty.DataTextField = "desc_especialidad_escolar";
                ddl_specialty.DataValueField = "id_especialidad_escolar";
                ddl_specialty.DataBind();
                ddl_specialty.Items.Insert(0, new ListItem("--Seleccionar Especialidad--", "0"));
            }

        }
        private void clean_text()
        {

            ddl_type_scholarship.SelectedValue = "0";
            ddl_scholarship.SelectedValue = "0";
            ddl_scholarship_grade.SelectedValue = "0";
            ddl_specialty.SelectedValue = "0";
            ddl_language.SelectedValue = "0";
            ddl_language_level.SelectedValue = "0";

            lbl_mnsj.Visible = false;

        }

        protected void cmd_save_Click(object sender, EventArgs e)
        {

            if (rb_edit.Checked == false)
            {
                lbl_mnsj.Visible = true;
                lbl_mnsj.Text = "Favor de seleccionar una acción";
            }
            else
            {
            }

            Guid id_fuser = (Guid)(Session["ss_fid_user"]);
            int str_type_scholarship = Convert.ToInt32(ddl_type_scholarship.SelectedValue);
            int str_scholarship = Convert.ToInt32(ddl_scholarship.SelectedValue);
            int str_school_grade = Convert.ToInt32(ddl_scholarship_grade.SelectedValue);
            int str_speciality = Convert.ToInt32(ddl_specialty.SelectedValue);
            int str_language = Convert.ToInt32(ddl_language.SelectedValue);
            int str_language_level = Convert.ToInt32(ddl_language_level.SelectedValue);
            int str_count_contact;


            using (db_imEntities data_count = new db_imEntities())
            {
                var items_contact = (from c in data_count.inf_escolares
                                     where c.id_usuario == id_fuser
                                     select c).Count();

                str_count_contact = Convert.ToInt32(items_contact);
            }

            if (str_count_contact == 0)
            {
                using (var insert_scholarship = new db_imEntities())
                {
                    var items_scholarship = new inf_escolares
                    {

                        id_especialidad_escolar = str_speciality,
                        id_grado_escolar = str_school_grade,
                        id_lenguaje = str_language,
                        id_nivel_lenguaje = str_language_level,
                        id_usuario = id_fuser
                    };
                    insert_scholarship.inf_escolares.Add(items_scholarship);
                    insert_scholarship.SaveChanges();
                }
                lbl_mnsj.Visible = true;
                lbl_mnsj.Text = "Datos escolares agregados con exito";
            }
            else
            {
                using (var data_scholarship = new db_imEntities())
                {
                    var items_scholarship = (from c in data_scholarship.inf_escolares
                                             where c.id_usuario == id_fuser
                                             select c).FirstOrDefault();

                    items_scholarship.id_grado_escolar = str_school_grade;
                    items_scholarship.id_especialidad_escolar = str_speciality;
                    items_scholarship.id_lenguaje = str_language;
                    items_scholarship.id_nivel_lenguaje = str_language_level;

                    data_scholarship.SaveChanges();
                }
                lbl_mnsj.Visible = true;
                lbl_mnsj.Text = "Datos de contacto actualizados con exito";
            }
        }
    }
}