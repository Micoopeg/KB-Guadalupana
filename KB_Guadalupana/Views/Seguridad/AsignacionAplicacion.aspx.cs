﻿using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class AsignacionAplicacion : System.Web.UI.Page
    {
        Conexion_seguridad cn = new Conexion_seguridad();
        Sentencia_seguridad sn = new Sentencia_seguridad();
        Logica lg = new Logica();
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        string app, idusuario, user;
        protected void Page_Load(object sender, EventArgs e)
        {
            AAUsuario.Value = Session["usuario_seguridad"] as string;
            user = Convert.ToString( Session["usuario_seguridad"]);
            if (user != "")
            {
                if (!IsPostBack)
                {
                    llenarcomboaplicacion();

                    llenargridviewaplicacion();
                }
            }
            else
            {
                String script = "alert('no hay un usuario seleccionado');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                Response.Redirect("Seguridad1");

            }
           
        }

        protected void AAsignar_Click(object sender, EventArgs e)
        {
            idusuario = sn.obteneridusuario(AAUsuario.Value);
            app = sn.obtenerapp(idusuario, AAplicacion.SelectedValue);

            if(app == "")
            {
                string sig = lg.siguiente("gen_mdimenu", "codgenmdi");
                sn.asignarAplicacion(sig, AAplicacion.SelectedValue, idusuario);
                String script = "alert('Se ha asignado exitosamente');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
              
            }
            else
            {
                String script = "alert('El usuario ya se encuentra asignado a la aplicación');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
           
            }
            //Response.Redirect("Seguridad2.aspx");
            llenargridviewaplicacion();
        }

        public void llenarcomboaplicacion()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string QueryString = "select * from gen_aplicacion";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Aplicacion");
                    AAplicacion.DataSource = ds;
                    AAplicacion.DataTextField = "gen_nombreapp";
                    AAplicacion.DataValueField = "codgenapp";
                    AAplicacion.DataBind();
                    AAplicacion.Items.Insert(0, new ListItem("[Aplicacion]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        public void llenargridviewaplicacion()
        {
            idusuario = sn.obteneridusuario(AAUsuario.Value);
            DataTable dt1 = new DataTable();
            dt1 = sn.llenarGridViewAplicaciones(idusuario);
            GridViewAplicaciones.DataSource = dt1;
            GridViewAplicaciones.DataBind();
        }

        protected void btninicio_Click(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad1.aspx");
        }
        protected void btnmoduloscrear_Click(object sender, EventArgs e)
        {

            Response.Redirect("SeguridadMod.aspx");
        }
        protected void btnappuser_Click(object sender, EventArgs e)
        {

            Response.Redirect("AsignacionAplicacion.aspx");
        }
        protected void btnmodulospermisos_Clicl(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad2.aspx");
        }
    }
}