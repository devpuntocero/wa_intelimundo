using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_centros : System.Web.UI.Page
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

        private void Load_ddl()
        {
            using (db_imEntities entities = new db_imEntities())
            {
                var data_country = entities.fact_paises.ToList();
                ddl_country.DataSource = data_country;
                ddl_country.DataTextField = "desc_pais";
                ddl_country.DataValueField = "id_pais";
                ddl_country.DataBind();
                ddl_country.Items.Insert(0, new ListItem("--Seleccionar País--", "0"));
            }
            ddl_state.Items.Insert(0, new ListItem("--Seleccionar Estado--", "0"));
            ddl_municipality.Items.Insert(0, new ListItem("--Seleccionar Municipio--", "0"));


            using (db_imEntities entities = new db_imEntities())
            {
                var data_licence = entities.fact_licencias.ToList();

                ddl_license.DataSource = data_licence;
                ddl_license.DataTextField = "desc_licencia";
                ddl_license.DataValueField = "id_licencia";
                ddl_license.DataBind();
                ddl_license.Items.Insert(0, new ListItem("Seleccionar Licencia", "0"));
            }
        }

        protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_state = Convert.ToInt32(ddl_state.SelectedValue);

            LoadMunicipality(id_state);
        }

        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_country = Convert.ToInt32(ddl_country.SelectedValue);

            LoadCombostate(id_country);
        }
        private void LoadCombostate(int id_country)
        {
            using (db_imEntities data_user = new db_imEntities())
            {
                var items_user = (from c in data_user.fact_estados
                                  where c.id_pais == id_country
                                  select c).ToList();

                ddl_state.DataSource = items_user;
                ddl_state.DataTextField = "desc_estado";
                ddl_state.DataValueField = "id_estado";
                ddl_state.DataBind();
                ddl_state.Items.Insert(0, new ListItem("--Seleccionar Estado--", "0"));
            }

            if (ddl_state.Items.Count != 0)
            {
                int id_state = Convert.ToInt32(ddl_state.SelectedValue);

                LoadMunicipality(id_state);
            }
            else
            {
                ddl_municipality.Items.Clear();
            }
        }
        private void LoadMunicipality(int id_state)
        {
            using (db_imEntities data_user = new db_imEntities())
            {
                var items_user = (from c in data_user.fact_municipios
                                  where c.id_estado == id_state
                                  select c).ToList();
                ddl_municipality.DataSource = items_user;
                ddl_municipality.DataTextField = "desc_municipio";
                ddl_municipality.DataValueField = "id_municipio";
                ddl_municipality.DataBind();
                ddl_municipality.Items.Insert(0, new ListItem("--Seleccionar Municipio--", "0"));
            }
        }

        protected void cmd_save_Click(object sender, EventArgs e)
        {
            int str_licence = Convert.ToInt32(ddl_license.SelectedValue);
            string str_namecenter = txt_namecenter.Text.ToUpper();

            int str_country = Convert.ToInt32(ddl_country.SelectedValue);
            int str_state = Convert.ToInt32(ddl_state.SelectedValue);
            int str_municipality = Convert.ToInt32(ddl_municipality.SelectedValue);
            string str_colony = txt_colony.Text.ToUpper();
            string str_street = txt_street.Text.ToUpper();
            string str_cp = txt_cp.Text;
            string str_phone = txt_phone.Text;
            string str_phonealt = txt_phone_alt.Text;
            string str_email = txt_email.Text;
            string str_emailalt = txt_email_alt.Text;

            Guid str_idcentro = Guid.NewGuid();

            if (rb_add.Checked)
            {
                foreach (GridViewRow row in GridView2.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk_select_users") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string str_codeuser = row.Cells[1].Text;
                            Guid fid_user;

                            using (db_imEntities data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_usuarios
                                                  where c.codigo_usuario == str_codeuser
                                                  select c).FirstOrDefault();

                                fid_user = items_user.id_usuario;
                            }
                            int str_count_centers;
                            using (db_imEntities data_count = new db_imEntities())
                            {
                                var items_center = (from c in data_count.inf_centros
                                                    select c).Count();

                                str_count_centers = Convert.ToInt32(items_center) + 1;
                            }
                            using (var insert_center = new db_imEntities())
                            {
                                var items_center = new inf_centros
                                {

                                    id_centro = str_idcentro,
                                    id_licencia = str_licence,
                                    codigo_centro = "imc_" + str_count_centers,
                                    nombre = str_namecenter,
                                    id_estatus = 1,
                                    fecha_registro = DateTime.Now,
                                    id_municipio = str_municipality,
                                    colonia = str_colony,
                                    calle_num = str_street,
                                    cp = str_cp,
                                    telefono = str_phone,
                                    telefono_alt = str_phonealt,
                                    email = str_email,
                                    email_alt = str_emailalt,
                                };
                                insert_center.inf_centros.Add(items_center);
                                insert_center.SaveChanges();
                            }

                            using (var data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_centros_dep
                                                  where c.id_usuario == fid_user
                                                  select c).FirstOrDefault();

                                items_user.id_centro = str_idcentro;

                                data_user.SaveChanges();
                            }


                            GridView2.DataSource = "";

                            lbl_mnsj.Visible = true;
                            lbl_mnsj.Text = "Registro de Centro con Exito.";
                        }
                        else
                        {
                            chkRow.Checked = false;
                        }
                    }
                }
            }
            else if (rb_edit.Checked)
            {
                Guid id_fcenter;
                foreach (GridViewRow row_c in gv_centros.Rows)
                {
                    if (row_c.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow_c = (row_c.Cells[0].FindControl("chk_select_centers") as CheckBox);
                        if (chkRow_c.Checked)
                        {
                            string str_code = row_c.Cells[1].Text;

                            using (db_imEntities data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_centros
                                                  where c.codigo_centro == str_code
                                                  select c).FirstOrDefault();

                                id_fcenter = items_user.id_centro;
                            }
                            foreach (GridViewRow row in GridView2.Rows)
                            {
                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select_users") as CheckBox);
                                    if (chkRow.Checked)
                                    {
                                        string str_codeuser = row.Cells[1].Text;
                                        Guid fid_user;

                                        using (db_imEntities data_user = new db_imEntities())
                                        {
                                            var items_user = (from c in data_user.inf_usuarios
                                                              where c.codigo_usuario == str_codeuser
                                                              select c).FirstOrDefault();

                                            fid_user = items_user.id_usuario;
                                        }

                                        using (var data_user = new db_imEntities())
                                        {
                                            var items_user = (from c in data_user.inf_centros
                                                              where c.id_centro == id_fcenter
                                                              select c).FirstOrDefault();

                                            items_user.id_licencia = str_licence;
                                            items_user.nombre = str_namecenter;
                                            items_user.id_municipio = str_municipality;
                                            items_user.colonia = str_colony;
                                            items_user.calle_num = str_street;
                                            items_user.cp = str_cp;
                                            items_user.telefono = str_phone;
                                            items_user.telefono_alt = str_phonealt;
                                            items_user.email = str_email;
                                            items_user.email_alt = str_emailalt;

                                            data_user.SaveChanges();
                                        }

                                        using (var data_user = new db_imEntities())
                                        {
                                            var items_user = (from c in data_user.inf_centros_dep
                                                              where c.id_usuario == fid_user
                                                              select c).FirstOrDefault();

                                            items_user.id_centro = id_fcenter;

                                            data_user.SaveChanges();
                                        }

                                        GridView2.DataSource = "";

                                        lbl_mnsj.Visible = true;
                                        lbl_mnsj.Text = "Centro actualizado con Exito.";
                                    }
                                    else
                                    {
                                        chkRow.Checked = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void rb_add_CheckedChanged(object sender, EventArgs e)
        {
            clean_text();
            rb_edit.Checked = false;
            rb_drop.Checked = false;
            rb_edit.Checked = false;
            rb_drop.Checked = false;
            cmd_centers.Visible = false;
            gv_centros.Visible = false;
            txt_search.Visible = false;
            cmd_search.Visible = false;

            var two_user = new int?[] { 2, 4 };

            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from a in data_user.inf_usuarios
                                join b in data_user.fact_tipo_usuarios on a.id_tipo_usuario equals b.id_tipo_usuario
                                where two_user.Contains(a.id_tipo_usuario)
                                select new
                                {
                                    a.codigo_usuario,
                                    a.nombres,
                                    a.a_paterno,
                                    a.a_materno,
                                    b.desc_tipo_usuario

                                }).ToList();

                GridView2.DataSource = inf_user;
                GridView2.DataBind();
                GridView2.Visible = true;
            }

        }

        protected void rb_edit_CheckedChanged(object sender, EventArgs e)
        {
            rb_add.Checked = false;
            rb_drop.Checked = false;
            txt_search.Visible = true;
            cmd_search.Visible = true;
            GridView2.Visible = false;

            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from a in data_user.inf_centros
                                join b in data_user.fact_licencias on a.id_licencia equals b.id_licencia
                                join c in data_user.inf_centros_dep on a.id_centro equals c.id_centro
                                join d in data_user.inf_usuarios on c.id_usuario equals d.id_usuario
                                where d.id_tipo_usuario == 4
                                select new
                                {
                                    a.codigo_centro,
                                    a.nombre,
                                    b.desc_licencia,
                                    d.nombres,
                                    d.a_paterno,
                                    d.a_materno

                                }).ToList();

                gv_centros.DataSource = inf_user;
                gv_centros.DataBind();
                gv_centros.Visible = true;
            }

        }

        protected void rb_drop_CheckedChanged(object sender, EventArgs e)
        {
            rb_edit.Checked = false;
            rb_add.Checked = false;
            txt_search.Visible = true;
            cmd_search.Visible = true;
            GridView2.Visible = false;
        }
        private void clean_text()
        {

            ddl_license.SelectedIndex = 0;
            ddl_country.SelectedIndex = 0;
            ddl_state.SelectedIndex = 0;
            ddl_municipality.SelectedIndex = 0;

            txt_namecenter.Text = "";
            txt_colony.Text = "";
            txt_street.Text = "";
            txt_cp.Text = "";
            txt_phone.Text = "";
            txt_phone_alt.Text = "";
            txt_email.Text = "";
            txt_email_alt.Text = "";
            lbl_mnsj.Visible = false;

        }

        protected void gv_centros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_centros.PageIndex = e.NewPageIndex;

        }

        protected void chk_OnCheckedChanged(object sender, EventArgs e)
        {
            Guid id_fcenter;
            Guid id_center = (Guid)(Session["ss_id_center"]);

            foreach (GridViewRow row in gv_centros.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select_centers") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string str_code = row.Cells[1].Text;

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_centros
                                              where c.codigo_centro == str_code
                                              select c).FirstOrDefault();

                            id_fcenter = items_user.id_centro;
                        }

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var inf_user = (from u in data_user.inf_centros
                                            join i_municipaly in data_user.fact_municipios on u.id_municipio equals i_municipaly.id_municipio
                                            join i_state in data_user.fact_estados on i_municipaly.id_estado equals i_state.id_estado
                                            join i_country in data_user.fact_paises on i_state.id_pais equals i_country.id_pais
                                            where u.id_centro == id_fcenter
                                            select new
                                            {
                                                u.id_licencia,
                                                u.nombre,
                                                i_country.id_pais,
                                                i_state.id_estado,
                                                u.id_municipio,
                                                u.colonia,
                                                u.calle_num,
                                                u.cp,
                                                u.telefono,
                                                u.telefono_alt,
                                                u.email,
                                                u.email_alt

                                            }).FirstOrDefault();

                            ddl_license.SelectedValue = inf_user.id_licencia.ToString();
                            txt_namecenter.Text = inf_user.nombre;
                            ddl_country.SelectedValue = inf_user.id_pais.ToString();
                            LoadCombostate(inf_user.id_pais);
                            ddl_state.SelectedValue = inf_user.id_estado.ToString();
                            LoadMunicipality(inf_user.id_estado);
                            ddl_municipality.SelectedValue = inf_user.id_municipio.ToString();
                            txt_colony.Text = inf_user.colonia;
                            txt_street.Text = inf_user.calle_num;
                            txt_cp.Text = inf_user.cp;
                            txt_phone.Text = inf_user.telefono;
                            txt_phone_alt.Text = inf_user.telefono_alt;
                            txt_email.Text = inf_user.email;
                            txt_email_alt.Text = inf_user.email_alt;
                        }
                        var two_user = new int?[] { 2, 4 };

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var inf_user = (from a in data_user.inf_usuarios
                                            join b in data_user.fact_tipo_usuarios on a.id_tipo_usuario equals b.id_tipo_usuario
                                            where two_user.Contains(a.id_tipo_usuario)
                                            select new
                                            {
                                                a.codigo_usuario,
                                                a.nombres,
                                                a.a_paterno,
                                                a.a_materno,
                                                b.desc_tipo_usuario

                                            }).ToList();

                            GridView2.DataSource = inf_user;
                            GridView2.DataBind();
                            GridView2.Visible = true;
                        }
                    }
                }
            }
        }
    }
}