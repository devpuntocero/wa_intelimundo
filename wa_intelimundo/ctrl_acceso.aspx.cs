using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class ctrl_acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cmd_login_Click(object sender, EventArgs e)
        {
            string str_codeuser = txt_code_user.Text;
            string str_password = mdl_encrypta.Encrypt(txt_password.Text);
            string str_password_V;
            int? str_id_type_user, str_idtypeuser;
            int? str_iduser_status;
            Guid str_idcenter;
            Guid str_id_user;

            if (ddl_center.Visible)
            {
                lbl_code_user.ForeColor = Color.White;


                using (db_imEntities data_user = new db_imEntities())
                {
                    var items_user = (from c in data_user.inf_usuarios
                                      where c.codigo_usuario == str_codeuser
                                      select c).FirstOrDefault();

                    str_id_user = items_user.id_usuario;
                    str_password_V = items_user.clave;
                    str_id_type_user = items_user.id_tipo_usuario;
                    str_iduser_status = items_user.id_estatus;


                    using (db_imEntities data_center = new db_imEntities())
                    {
                        var items_center = (from a in data_center.inf_centros
                                            join c in data_center.inf_centros_dep on a.id_centro equals c.id_centro
                                            where c.id_usuario == str_id_user
                                            select a).FirstOrDefault();


                        str_idcenter = items_center.id_centro;
                    }
                    if (str_password_V == str_password && str_iduser_status == 1)
                    {
                        Session["ss_id_user"] = str_id_user;
                        Session["ss_id_center"] = str_idcenter;

                        Response.Redirect("ctrl_menu.aspx");
                    }
                    else
                    {
                        lbl_mnsj.Visible = true;
                        lbl_mnsj.Text = "Contraseña Incorreca, Favor de contactar al Administrador.";
                    }
                }
            }
            else
            {
                try
                {
                    using (db_imEntities data_user = new db_imEntities())
                    {
                        var items_user = (from c in data_user.inf_usuarios
                                          where c.codigo_usuario == str_codeuser
                                          select c).FirstOrDefault();


                        str_id_user = items_user.id_usuario;
                        str_idtypeuser = items_user.id_tipo_usuario;
                    }


                    if (str_idtypeuser == 4)
                    {
                        int str_count_centers;
                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from a in data_user.inf_centros_dep
                                              where a.id_usuario == str_id_user
                                              select a).Count();

                            str_count_centers = Convert.ToInt32(items_user);
                        }
                        if (str_count_centers >= 1)
                        {
                            lbl_center.Visible = true;
                            ddl_center.Visible = true;

                            using (db_imEntities data_user = new db_imEntities())
                            {
                                var items_user = (from uc in data_user.inf_centros_dep
                                                  join c in data_user.inf_centros on uc.id_centro equals c.id_centro
                                                  where uc.id_usuario == str_id_user
                                                  select c).ToList();

                                ddl_center.DataSource = items_user;
                                ddl_center.DataTextField = "nombre";
                                ddl_center.DataValueField = "id_centro";
                                ddl_center.DataBind();
                                ddl_center.Items.Insert(0, new ListItem("--Seleccionar Centro--", "0"));

                            }

                            lbl_mnsj.Visible = true;
                            lbl_mnsj.Text = "Centro Intelimundo asigando, favor de seleccionarlo.";

                        }
                        else
                        {

                            lbl_mnsj.Visible = true;
                            lbl_mnsj.Text = "Franquiciado sin centro asignado, favor de contactar al Administrador";

                        }


                    }
                    else
                    {
                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from a in data_user.inf_centros
                                              join c in data_user.inf_centros_dep on a.id_centro equals c.id_centro
                                              where c.id_usuario == str_id_user
                                              select a).FirstOrDefault();


                            str_idcenter = items_user.id_centro;
                        }
                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var items_user = (from c in data_user.inf_usuarios
                                              where c.codigo_usuario == str_codeuser
                                              select c).FirstOrDefault();


                            str_id_user = items_user.id_usuario;
                            str_password_V = items_user.clave;
                            str_id_type_user = items_user.id_tipo_usuario;
                            str_iduser_status = items_user.id_estatus;

                            if (str_password_V == str_password && str_iduser_status == 1)
                            {
                                Session["ss_id_user"] = str_id_user;
                                Session["ss_id_center"] = str_idcenter;
                                Response.Redirect("ctrl_menu.aspx");
                            }
                            else
                            {
                                lbl_mnsj.Visible = true;
                                lbl_mnsj.Text = "Contraseña Incorreca, Favor de contactar al Administrador.";

                            }
                        }
                    }
                }
                catch
                {
                    lbl_mnsj.Visible = true;
                    lbl_mnsj.Text = "Usuario no registrado, favor de contactar al Administrador";
                }
            }
        }
    }
}