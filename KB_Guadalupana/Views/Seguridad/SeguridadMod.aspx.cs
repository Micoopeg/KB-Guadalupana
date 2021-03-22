﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBGuada.Controllers;
using KBGuada.Models;
using KB_Guadalupana.Controllers;
using MySql.Data.MySqlClient;
using System.Data;

namespace KB_Guadalupana.Views.Seguridad
{
    public partial class SeguridadMod : System.Web.UI.Page
    {
        ControladorAV cav = new ControladorAV();

        string NOMAPP, URL, ABRAPP, OP, op2;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarcomboarea();
            }
        }

        public void ingresar()
        {
            NOMAPP = nommodul.Value;
            URL = url1.Value;
            ABRAPP = abrmodulo.Value;
            OP = seleccion.Value;
            switch (OP)
            {

                case "Activo":
                
                    op2 = "Activo";
                    string sig = cav.siguiente("gen_aplicacion", "codgenapp");

                    string sql = "INSERT INTO gen_aplicacion  VALUES('" + sig + "', '" + ABRAPP + "', '" + NOMAPP + "', '" + URL + "', '" + op2 + "');";
                    cav.Insertar(sql);

                    string sig1 = cav.siguiente("gen_areaapp", "");
                    string sql1 = "INSERT INTO gen_areaapp VALUES ('" + sig1 + "', '" + SArea.SelectedValue + "', '" + sig + "')";
                    cav.Insertar(sql1);

                    break;
                case "Inactivo":

                 
                    op2 = "Inactivo";
                    string sig2 = cav.siguiente("gen_aplicacion", "codgenapp");

                    string sql2 = "INSERT INTO gen_aplicacion  VALUES('" + sig2 + "', '" + ABRAPP + "', '" + NOMAPP + "', '" + URL + "', '" + op2 + "');";
                    cav.Insertar(sql2);
                    break;

            }

        }

        public void llenarcomboarea()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {

                    sqlCon.Open();
                    string QueryString = "select * from gen_area";
                    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, sqlCon);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Área");
                    SArea.DataSource = ds;
                    SArea.DataTextField = "gen_areanombre";
                    SArea.DataValueField = "codgenarea";
                    SArea.DataBind();
                    SArea.Items.Insert(0, new ListItem("[Área]", "0"));
                }
                catch { Console.WriteLine("Verifique los campos"); }
            }

        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

            NOMAPP = nommodul.Value;
            URL = url1.Value;
            ABRAPP = abrmodulo.Value;
            OP = seleccion.Value;
            if (NOMAPP != null || URL != null || ABRAPP != null || seleccion.Value != "Estado")
            {
                ingresar();
                Response.Redirect("AsignacionAplicacion.aspx");
            }

            else
            {

                String script = "alert('Llene todos los campos');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
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