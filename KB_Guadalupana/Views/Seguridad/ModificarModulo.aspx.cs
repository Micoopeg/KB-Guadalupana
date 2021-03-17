﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using KB_Guadalupana.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class ModificarModulo : System.Web.UI.Page
    {
        Sentencia_seguridad sn = new Sentencia_seguridad();
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcomboaplicacion();
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if (abrmodulo.Value == "" && nommodul.Value == "" && url1.Value == "" && seleccion.Value == "")
            {
                String script = "alert('Debe llenar todos los campos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else
            {
                sn.actualizarmodulo(MModulo.SelectedValue, abrmodulo.Value, nommodul.Value, url1.Value, seleccion.Value);
                MModulo.SelectedIndex = 0;
                abrmodulo.Value = "";
                nommodul.Value = "";
                url1.Value = "";
                seleccion.Value = "Estado";
                String script = "alert('Cambios realizados');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
               

            }
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
                    MModulo.DataSource = ds;
                    MModulo.DataTextField = "gen_nombreapp";
                    MModulo.DataValueField = "codgenapp";
                    MModulo.DataBind();
                    MModulo.Items.Insert(0, new ListItem("[Aplicacion]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }
        }

        protected void MBuscarModulo_Click(object sender, EventArgs e)
        {
            string[] var = sn.mostraraplicacion(MModulo.SelectedValue);

            for (int i = 0; i < var.Length; i++)
            {
                string estado;
                abrmodulo.Value = Convert.ToString(var[1]);
                nommodul.Value = Convert.ToString(var[2]);
                url1.Value = Convert.ToString(var[3]);
                estado = Convert.ToString(var[4]);
                if (estado == "True")
                {
                    seleccion.Value = "1";
                }
                else
                {
                    seleccion.Value = "0";
                }
            }
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
        protected void btnModapp_Click(object sender, EventArgs e)
        {

            Response.Redirect("ModificarModulo.aspx");
        }
        protected void btnmodulospermisos_Clicl(object sender, EventArgs e)
        {

            Response.Redirect("Seguridad2.aspx");
        }
        protected void btnestadouser_Click(object sender, EventArgs e)
        {

            Response.Redirect("ModificarEstado.aspx");
        }
    }
}