using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_contacto : System.Web.UI.Page
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


        }
        private void inf_user()
        {
            Guid id_user = (Guid)(Session["ss_id_user"]);
            Guid id_center = (Guid)(Session["ss_id_center"]);
            Guid id_fuser = (Guid)(Session["ss_fid_user"]);

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
        protected void rb_edit_CheckedChanged(object sender, EventArgs e)
        {

            flist_user();
        }
        private void clean_text()
        {
            ddl_country.SelectedValue = "0";
            ddl_state.SelectedValue = "0";
            ddl_municipality.SelectedValue = "0";
            txt_colony.Text = "";
            txt_street.Text = "";
            txt_cp.Text = "";
            txt_phone.Text = "";
            txt_phone_alt.Text = "";
            txt_email.Text = "";
            txt_email_alt.Text = "";

            lbl_mnsj.Visible = false;

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
            if (rb_edit.Checked == false)
            {
                lbl_mnsj.Visible = true;
                lbl_mnsj.Text = "Favor de seleccionar una acción";
            }
            else
            {

                Guid id_fuser = (Guid)(Session["ss_fid_user"]);

                int str_municipality = Convert.ToInt32(ddl_municipality.SelectedValue);
                string str_colony = txt_colony.Text.ToUpper();
                string str_street = txt_street.Text.ToUpper();
                string str_cp = txt_cp.Text;
                string str_phone = txt_phone.Text;
                string str_phonealt = txt_phone_alt.Text;
                string str_email = txt_email.Text.ToLower();
                string str_emailalt = txt_email_alt.Text.ToUpper();
                int str_count_contact;

                using (db_imEntities data_count = new db_imEntities())
                {
                    var items_contact = (from c in data_count.inf_contacto
                                         where c.id_usuario == id_fuser
                                         select c).Count();

                    str_count_contact = Convert.ToInt32(items_contact);
                }

                if (str_count_contact == 0)
                {
                    using (var insert_user_center = new db_imEntities())
                    {

                        var items_user = new inf_contacto
                        {

                            id_usuario = id_fuser,
                            id_municipio = str_municipality,
                            colonia = str_colony,
                            calle_num = str_street,
                            cp = str_cp,
                            telefono = str_phone,
                            telefono_alt = str_phonealt,
                            email = str_email,
                            email_alt = str_emailalt,

                        };
                        insert_user_center.inf_contacto.Add(items_user);
                        insert_user_center.SaveChanges();
                    }

                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Datos de contacto registrados con exito.";
                }
                else
                {
                    using (var data_address = new db_imEntities())
                    {
                        var items_address = (from c in data_address.inf_contacto
                                             where c.id_usuario == id_fuser
                                             select c).FirstOrDefault();

                        items_address.id_municipio = str_municipality;
                        items_address.colonia = str_colony;
                        items_address.calle_num = str_street;
                        items_address.cp = str_cp;
                        items_address.telefono = str_phone;
                        items_address.telefono_alt = str_phonealt;
                        items_address.email = str_email;
                        items_address.email_alt = str_emailalt;

                        data_address.SaveChanges();
                    }

                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Datos de contacto actualizados con exito";
                }
            }
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
                    using (db_imEntities data_user = new db_imEntities())
                    {
                        var items_user = (from i_user in data_user.inf_usuarios
                                          join i_address in data_user.inf_contacto on i_user.id_usuario equals i_address.id_usuario
                                          join i_municipaly in data_user.fact_municipios on i_address.id_municipio equals i_municipaly.id_municipio
                                          join i_state in data_user.fact_estados on i_municipaly.id_estado equals i_state.id_estado
                                          join i_country in data_user.fact_paises on i_state.id_pais equals i_country.id_pais
                                          where i_user.id_usuario == id_fuser
                                          select new
                                          {
                                              i_country.id_pais,
                                              i_state.id_estado,
                                              i_address.id_municipio,
                                              i_address.colonia,
                                              i_address.calle_num,
                                              i_address.cp,
                                              i_address.telefono,
                                              i_address.telefono_alt,
                                              i_address.email,
                                              i_address.email_alt

                                          }).FirstOrDefault();

                        int str_id_address_country = items_user.id_pais;
                        int str_id_address_state = items_user.id_estado;
                        int? str_id_address_municipality = items_user.id_municipio;
                        string str_address_colony = items_user.colonia;
                        string str_address_street = items_user.calle_num;
                        string str_address_postal_code = items_user.cp;
                        string str_address_phone = items_user.telefono;
                        string str_address_phone_alt = items_user.telefono_alt;
                        string str_address_email = items_user.email;
                        string str_address_email_alt = items_user.email_alt;

                        ddl_country.SelectedValue = str_id_address_country.ToString();
                        LoadCombostate(str_id_address_country);
                        ddl_state.SelectedValue = str_id_address_state.ToString();
                        LoadMunicipality(str_id_address_state);
                        ddl_municipality.SelectedValue = str_id_address_municipality.ToString();
                        txt_colony.Text = str_address_colony;
                        txt_street.Text = str_address_street;
                        txt_cp.Text = str_address_postal_code;
                        txt_phone.Text = str_address_phone;
                        txt_phone_alt.Text = str_address_phone_alt;
                        txt_email.Text = str_address_email;
                        txt_email_alt.Text = str_address_email_alt;
                    }
                }
                catch
                {
                }
            }
        }
    }
}