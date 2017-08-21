using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_fiscales : System.Web.UI.Page
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
                var data_typerfc = entities.fact_tipo_rfc.ToList();
                ddl_type_rfc.DataSource = data_typerfc;
                ddl_type_rfc.DataTextField = "desc_tipo_rfc";
                ddl_type_rfc.DataValueField = "id_tipo_rfc";
                ddl_type_rfc.DataBind();
                ddl_type_rfc.Items.Insert(0, new ListItem("--Seleccionar Tipo RFC--", "0"));
            }

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

        private void clean_text()
        {
            ddl_country.SelectedValue = "0";
            ddl_state.SelectedValue = "0";
            ddl_municipality.SelectedValue = "0";
            txt_colony.Text = "";
            txt_street.Text = "";
            txt_cp.Text = "";


            lbl_mnsj.Visible = false;

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
                    using (db_imEntities data_infF = new db_imEntities())
                    {
                        var items_addressF = (from i_fiscales in data_infF.inf_fiscales
                                              join i_municipios in data_infF.fact_municipios on i_fiscales.id_municipio equals i_municipios.id_municipio
                                              join i_estados in data_infF.fact_estados on i_municipios.id_estado equals i_estados.id_estado
                                              join i_paises in data_infF.fact_paises on i_estados.id_pais equals i_paises.id_pais
                                              where i_fiscales.id_usuario == id_fuser
                                              select new
                                              {
                                                  i_fiscales.id_tipo_rfc,
                                                  i_fiscales.razon_social,
                                                  i_fiscales.rfc,
                                                  i_paises.id_pais,
                                                  i_estados.id_estado,
                                                  i_fiscales.id_municipio,
                                                  i_fiscales.colonia,
                                                  i_fiscales.calle_num,
                                                  i_fiscales.cp,
                                                  i_fiscales.telefono,
                                                  i_fiscales.telefono_alt

                                              }).FirstOrDefault();



                        ddl_type_rfc.SelectedValue = items_addressF.id_tipo_rfc.ToString();
                        txt_business_name.Text = items_addressF.razon_social;
                        txt_rfc.Text = items_addressF.rfc;
                        ddl_country.SelectedValue = items_addressF.id_pais.ToString();
                        LoadCombostate(items_addressF.id_pais);
                        ddl_state.SelectedValue = items_addressF.id_estado.ToString();
                        LoadMunicipality(items_addressF.id_estado);
                        ddl_municipality.SelectedValue = items_addressF.id_municipio.ToString();
                        txt_colony.Text = items_addressF.colonia;
                        txt_street.Text = items_addressF.calle_num;
                        txt_cp.Text = items_addressF.cp;
                        txt_phone.Text = items_addressF.telefono;
                        txt_phone_alt.Text = items_addressF.telefono_alt;
                    }
                }
                catch
                {
                }
            }
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
        protected void rb_edit_CheckedChanged(object sender, EventArgs e)
        {
            flist_user();
        }
        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_country = Convert.ToInt32(ddl_country.SelectedValue);

            LoadCombostate(id_country);
        }

        protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_state = Convert.ToInt32(ddl_state.SelectedValue);

            LoadMunicipality(id_state);
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

                int str_typerfc = Convert.ToInt32(ddl_type_rfc.SelectedValue);
                string str_business_name = txt_business_name.Text;
                string str_rfc = txt_rfc.Text;
                int str_municipality = Convert.ToInt32(ddl_municipality.SelectedValue);
                string str_colony = txt_colony.Text.ToUpper();
                string str_street = txt_street.Text.ToUpper();
                string str_cp = txt_cp.Text;
                string str_phone = txt_phone.Text;
                string str_phonealt = txt_phone_alt.Text;
                int str_count_fiscal;

                using (db_imEntities data_count = new db_imEntities())
                {
                    var items_contact = (from c in data_count.inf_fiscales
                                         where c.id_usuario == id_fuser
                                         select c).Count();

                    str_count_fiscal = Convert.ToInt32(items_contact);
                }

                if (str_count_fiscal == 0)
                {
                    using (var insert_fiscal = new db_imEntities())
                    {
                        var items_fiscal = new inf_fiscales
                        {
                            id_tipo_rfc = str_typerfc,
                            razon_social = str_business_name,
                            rfc = str_rfc,
                            id_municipio = str_municipality,
                            colonia = str_colony,
                            calle_num = str_street,
                            cp = str_cp,
                            telefono = str_phone,
                            telefono_alt = str_phonealt,
                            id_usuario = id_fuser,

                        };
                        insert_fiscal.inf_fiscales.Add(items_fiscal);
                        insert_fiscal.SaveChanges();
                    }
                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Datos fiscales agregada con exito";
                }
                else
                {

                    using (var data_addressF = new db_imEntities())
                    {
                        var items_addressF = (from c in data_addressF.inf_fiscales
                                              where c.id_usuario == id_fuser
                                              select c).FirstOrDefault();

                        items_addressF.id_tipo_rfc = str_typerfc;
                        items_addressF.razon_social = str_business_name;
                        items_addressF.rfc = str_rfc;
                        items_addressF.id_municipio = str_municipality;
                        items_addressF.colonia = str_colony;
                        items_addressF.calle_num = str_street;
                        items_addressF.cp = str_cp;
                        items_addressF.telefono = str_phone;
                        items_addressF.telefono_alt = str_phonealt;

                        data_addressF.SaveChanges();
                    }
                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Datos fiscales actualizada con exito";
                }
            }
        }
    }
}