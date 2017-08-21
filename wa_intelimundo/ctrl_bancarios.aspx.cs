using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_bancarios : System.Web.UI.Page
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
                var data_typerfc = entities.fact_bancos.ToList();
                ddl_bankdata.DataSource = data_typerfc;
                ddl_bankdata.DataTextField = "desc_banco";
                ddl_bankdata.DataValueField = "id_banco";
                ddl_bankdata.DataBind();
                ddl_bankdata.Items.Insert(0, new ListItem("--Seleccionar Banco--", "0"));
            }
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
            ddl_bankdata.SelectedValue = "0";
            txt_card.Text = "";
            txt_clabe.Text = "";

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
                    using (db_imEntities data_inff = new db_imEntities())
                    {
                        var items_addressf = (from i_fiscales in data_inff.inf_bancarios

                                              where i_fiscales.id_usuario == id_fuser
                                              select new
                                              {
                                                  i_fiscales.id_banco,
                                                  i_fiscales.tarjeta,
                                                  i_fiscales.clabe

                                              }).FirstOrDefault();



                        ddl_bankdata.SelectedValue = items_addressf.id_banco.ToString();
                        txt_card.Text = items_addressf.tarjeta;
                        txt_clabe.Text = items_addressf.clabe;

                    }
                }
                catch
                {
                }
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
                int str_bankdata = Convert.ToInt32(ddl_bankdata.SelectedValue);
                string str_card = txt_card.Text;
                string str_clabe = txt_clabe.Text;
                int str_count_contact;

                using (db_imEntities data_count = new db_imEntities())
                {
                    var items_contact = (from c in data_count.inf_bancarios
                                         where c.id_usuario == id_fuser
                                         select c).Count();

                    str_count_contact = Convert.ToInt32(items_contact);
                }

                if (str_count_contact == 0)
                {

                    using (var insert_address = new db_imEntities())
                    {
                        var items_address = new inf_bancarios
                        {
                            id_banco = str_bankdata,
                            tarjeta = str_card,
                            clabe = str_clabe,
                            id_usuario = id_fuser
                        };
                        insert_address.inf_bancarios.Add(items_address);
                        insert_address.SaveChanges();
                    }
                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Datos de bancarios agregados con exito";
                }
                else
                {
                    using (var data_address = new db_imEntities())
                    {
                        var items_address = (from c in data_address.inf_bancarios
                                             where c.id_usuario == id_fuser
                                             select c).FirstOrDefault();

                        items_address.id_banco = str_bankdata;
                        items_address.tarjeta = str_card;
                        items_address.clabe = str_clabe;


                        data_address.SaveChanges();
                    }

                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Datos de bancarios actualizados con exito";
                }
            }
        }
    }
}