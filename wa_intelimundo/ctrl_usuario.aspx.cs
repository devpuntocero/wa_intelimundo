using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                inf_user();
                if (!IsPostBack)
                {
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
            int save_user = (int)(Session["ss_save_user"]);

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
            switch (save_user)
            {

                case 2:
                    lbl_reg.Text = "Registro Director";

                    break;
                case 3:
                    lbl_reg.Text = "Registro Administradores";

                    break;
                case 4:
                    lbl_reg.Text = "Contacto Franquiciados";

                    break;
                case 5:
                    lbl_reg.Text = "Registro Gerente";

                    break;
                case 6:
                    lbl_reg.Text = "Registro Facilitador";

                    break;
                case 7:
                    lbl_reg.Text = "Registro Alumno";

                    break;
            }
        }
        protected void cmd_save_Click(object sender, EventArgs e)
        {
            if (rb_add.Checked == false & rb_edit.Checked == false & rb_drop.Checked == false & rb_del.Checked == false)
            {
                lbl_mnsj.Visible = true;
                lbl_mnsj.Text = "Favor de seleccionar una acción";
            }
            else
            {

                Guid id_center = (Guid)(Session["ss_id_center"]);
                Guid str_iduser = Guid.NewGuid();
                int str_gender = Convert.ToInt32(ddl_gender.SelectedValue);
                DateTime str_birthday = Convert.ToDateTime(txt_birthday.Text);
                string str_nameuser = txt_name_user.Text.ToUpper();
                string str_apater = txt_apater.Text.ToUpper();
                string str_amater = txt_amater.Text.ToUpper();
                string str_codeuser = txt_code_user.Text.ToLower();
                string str_password = mdl_encrypta.Encrypt(txt_password.Text.ToLower());
                Guid f_id_user = (Guid)(Session["ss_id_user"]);


                if (rb_add.Checked)
                {

                    try
                    {
                        string str_filter_code;
                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == str_codeuser
                                              select c).FirstOrDefault();

                            str_filter_code = items_user.codigo_usuario.ToString();
                        }

                        if (str_codeuser == str_filter_code)
                        {
                            lbl_mnsj.Visible = true;
                            lbl_mnsj.Text = "Usuario ya existe en la base";
                        }
                    }
                    catch
                    {
                        int save_user = (int)(Session["ss_save_user"]);

                        using (var insert_user = new db_imEntities())
                        {
                            var items_user = new inf_usuarios
                            {
                                id_usuario = str_iduser,
                                nombres = str_nameuser,
                                a_paterno = str_apater,
                                a_materno = str_amater,
                                id_tipo_usuario = save_user,
                                fecha_nacimiento = str_birthday,
                                id_genero = str_gender,
                                codigo_usuario = str_codeuser,
                                clave = str_password,
                                id_estatus = 1,
                                fecha_registro = DateTime.Now,
                            };
                            insert_user.inf_usuarios.Add(items_user);
                            insert_user.SaveChanges();
                        }


                        using (var insert_user_center = new db_imEntities())
                        {

                            var items_user = new inf_centros_dep
                            {
                                id_centro = id_center,
                                id_usuario = str_iduser,
                            };
                            insert_user_center.inf_centros_dep.Add(items_user);
                            insert_user_center.SaveChanges();
                        }

                        lbl_mnsj.Visible = true;
                        lbl_mnsj.Text = "Registro de usuario con Exito.";
                    }

                }
                else if (rb_edit.Checked)
                {
                    lbl_mnsj.Visible = false;

                    foreach (GridViewRow row in gv_usuarios.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                            if (chkRow.Checked)
                            {
                                string codeuser = row.Cells[1].Text;

                                using (db_imEntities data_user = new db_imEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.codigo_usuario == codeuser
                                                      select c).FirstOrDefault();

                                    f_id_user = items_user.id_usuario;
                                }

                                using (var data_user = new db_imEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.id_usuario == f_id_user
                                                      select c).FirstOrDefault();

                                    items_user.nombres = str_nameuser;
                                    items_user.a_paterno = str_apater;
                                    items_user.a_materno = str_amater;
                                    items_user.fecha_nacimiento = str_birthday;
                                    items_user.id_genero = str_gender;
                                    items_user.clave = str_password;

                                    data_user.SaveChanges();
                                }

                                lbl_mnsj.Visible = true;

                                lbl_mnsj.Text = "Registro actualizado con Exito.";
                            }
                        }
                    }
                }
                else if (rb_drop.Checked)
                {
                    lbl_mnsj.Visible = false;

                    foreach (GridViewRow row in gv_usuarios.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                            if (chkRow.Checked)
                            {
                                string codeuser = row.Cells[1].Text;

                                using (db_imEntities data_user = new db_imEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.codigo_usuario == codeuser
                                                      select c).FirstOrDefault();

                                    f_id_user = items_user.id_usuario;
                                }

                                using (var data_user = new db_imEntities())
                                {
                                    var items_user = (from c in data_user.inf_usuarios
                                                      where c.id_usuario == f_id_user
                                                      select c).FirstOrDefault();

                                    items_user.id_estatus = 2;

                                    data_user.SaveChanges();
                                }

                                lbl_mnsj.Visible = true;

                                lbl_mnsj.Text = "Registro desactivado con Exito.";
                            }

                        }
                    }
                }
                else if (rb_del.Checked)
                {
                }
            }

        }
        protected void rb_add_CheckedChanged(object sender, EventArgs e)
        {
            clean_text();
            rb_edit.Checked = false;
            rb_drop.Checked = false;
            rb_del.Checked = false;


            gv_usuarios.Visible = false;
            txt_search.Visible = false;
            cmd_search.Visible = false;
            div_infusuarios.Visible = false;
        }
        protected void rb_edit_CheckedChanged(object sender, EventArgs e)
        {
            rb_add.Checked = false;
            rb_drop.Checked = false;
            rb_del.Checked = false;
            txt_search.Visible = true;
            cmd_search.Visible = true;
            div_infusuarios.Visible = true;

            int? save_user = (int)(Session["ss_save_user"]);
            var two_user = new int?[] { save_user };
            flist_user(two_user);
        }
        protected void rb_drop_CheckedChanged(object sender, EventArgs e)
        {
            rb_edit.Checked = false;
            rb_add.Checked = false;
            rb_del.Checked = false;
        }
        protected void rb_del_CheckedChanged(object sender, EventArgs e)
        {
            rb_edit.Checked = false;
            rb_drop.Checked = false;
            rb_add.Checked = false;
        }
        private void clean_text()
        {

            ddl_gender.SelectedIndex = 0;
            txt_birthday.Text = "";
            txt_name_user.Text = "";
            txt_apater.Text = "";
            txt_amater.Text = "";
            txt_code_user.Text = "";
            txt_password.Text = "";
            lbl_mnsj.Visible = false;

        }
        protected void img_address_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in gv_usuarios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string codeuser = row.Cells[1].Text;
                        Guid f_id_user;

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == codeuser
                                              select c).FirstOrDefault();

                            f_id_user = items_user.id_usuario;
                        }

                        Session["ss_fid_user"] = f_id_user;
                        Response.Redirect("ctrl_contacto.aspx");
                    }
                }
            }

        }

        private void flist_user(int?[] id_flist_user)
        {
            Guid id_center = (Guid)(Session["ss_id_center"]);

            if (lbl_id_profile_user.Text == "2")
            {
                using (db_imEntities data_user = new db_imEntities())
                {
                    var inf_user = (from u in data_user.inf_usuarios
                                    join e in data_user.fact_estatus on u.id_estatus equals e.id_estatus
                                    join cd in data_user.inf_centros_dep on u.id_usuario equals cd.id_usuario
                                    where id_flist_user.Contains(u.id_tipo_usuario)
                                    where u.id_estatus == 1

                                    select new
                                    {
                                        u.codigo_usuario,
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
            }
            else
            {
                using (db_imEntities data_user = new db_imEntities())
                {
                    var inf_user = (from u in data_user.inf_usuarios
                                    join e in data_user.fact_estatus on u.id_estatus equals e.id_estatus
                                    join cd in data_user.inf_centros_dep on u.id_usuario equals cd.id_usuario
                                    where id_flist_user.Contains(u.id_tipo_usuario)
                                    where u.id_estatus == 1
                                    where cd.id_centro == id_center
                                    select new
                                    {
                                        u.codigo_usuario,
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
            }

            if (rb_edit.Checked)
            {
                lbl_mnsj.Visible = false;
            }
        }

        protected void chk_OnCheckedChanged(object sender, EventArgs e)
        {
            Guid id_fuser;
            Guid id_center = (Guid)(Session["ss_id_center"]);

            foreach (GridViewRow row in gv_usuarios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string codeuser = row.Cells[1].Text;

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == codeuser
                                              select c).FirstOrDefault();

                            id_fuser = items_user.id_usuario;
                        }
                        int? save_user = (int)(Session["ss_save_user"]);

                        if (save_user == 4)
                        {
                            using (db_imEntities data_user = new db_imEntities())
                            {
                                var inf_user = (from u in data_user.inf_usuarios
                                                where u.id_usuario == id_fuser
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
                        else
                        {
                            using (db_imEntities data_user = new db_imEntities())
                            {
                                var inf_user = (from u in data_user.inf_usuarios
                                                join tu in data_user.fact_tipo_usuarios on u.id_tipo_usuario equals tu.id_tipo_usuario

                                                join cd in data_user.inf_centros_dep on u.id_usuario equals cd.id_usuario
                                                join c in data_user.inf_centros on cd.id_centro equals c.id_centro
                                                where u.id_usuario == id_fuser
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


                    }

                }
            }

        }

        protected void gv_usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_usuarios.PageIndex = e.NewPageIndex;
        }

        protected void img_school_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in gv_usuarios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string codeuser = row.Cells[1].Text;
                        Guid f_id_user;

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == codeuser
                                              select c).FirstOrDefault();

                            f_id_user = items_user.id_usuario;
                        }

                        Session["ss_fid_user"] = f_id_user;
                        Response.Redirect("ctrl_escolares.aspx");
                    }
                }
            }
        }

        protected void img_invoice_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in gv_usuarios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string codeuser = row.Cells[1].Text;
                        Guid f_id_user;

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == codeuser
                                              select c).FirstOrDefault();

                            f_id_user = items_user.id_usuario;
                        }

                        Session["ss_fid_user"] = f_id_user;
                        Response.Redirect("ctrl_fiscales.aspx");
                    }
                }
            }
        }

        protected void img_banking_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in gv_usuarios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk_select") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string codeuser = row.Cells[1].Text;
                        Guid f_id_user;

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == codeuser
                                              select c).FirstOrDefault();

                            f_id_user = items_user.id_usuario;
                        }

                        Session["ss_fid_user"] = f_id_user;
                        Response.Redirect("ctrl_bancarios.aspx");
                    }
                }
            }
        }
    }
}