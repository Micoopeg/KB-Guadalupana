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

namespace KB_Guadalupana.Views.Sesion
{
    public partial class Reporte : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        Logica logic = new Logica();
        Conexion conn = new Conexion();
        Sentencia sn = new Sentencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenargridviewreporte();
            }
        }

        public void llenargridviewreporte()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                    sqlCon.Open();
                    string QueryString = "SELECT ep_control.codepinformaciongeneralcif, gen_usuario.gen_usuarionombre, ep_informaciongeneral.ep_informaciongeneralcif  FROM ep_control INNER JOIN gen_usuario ON gen_usuario.codgenusuario = ep_control.codgenusuario INNER JOIN ep_informaciongeneral ON ep_control.codepinformaciongeneralcif = ep_informaciongeneral.codepinformaciongeneralcif ORDER BY ep_control.codepcontrol";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds3 = new DataTable();
                    command.Fill(ds3);
                    GridViewReporte.DataSource = ds3;
                    GridViewReporte.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        protected void iniciarsesion_Click(object sender, EventArgs e)
        {
            Session["IDReporte"] = RCif.Value;
            string nombre;
            string id;
            nombre = Session["IDReporte"].ToString();

            //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('"+nombre+"');", true);
            MySqlDataReader mostrar = logic.consultarCif(nombre);
            try
            {
                if (mostrar.Read())
                {
                    id = Convert.ToString(mostrar.GetString(0));
                    Session["IDReporte1"] = id;

                    Response.Redirect("ReportesAdmin/ReporteAdmin1.aspx");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            //
        }

        protected void OnSelectedIndexChangedReporte(object sender, EventArgs e)
        {
            GridViewRow row = GridViewReporte.SelectedRow;
            Text6.Value = (GridViewReporte.SelectedRow.FindControl("lblnombre") as Label).Text;
            RCif.Value = Convert.ToString((GridViewReporte.SelectedRow.FindControl("lblcif") as Label).Text);

        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = logic.buscarCIF(RBuscarcif.Value);
            GridViewReporte.DataSource = dt1;
            GridViewReporte.DataBind();
            //try
            //{
            //    string QueryString = "SELECT gen_usuarionombre, codepinformaciongeneralcif FROM gen_usuario INNER JOIN ep_control ON gen_usuario.codgenusuario = ep_control.codgenusuario WHERE codepinformaciongeneralcif='" + RBuscarcif.Value + "'";
            //    MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
            //    DataTable ds3 = new DataTable();
            //    myCommand.Fill(ds3);
            //    GridViewReporte.DataSource = ds3;
            //    GridViewReporte.DataBind();
            //}
            //catch { }
        }

        protected void VerTodos_Click(object sender, EventArgs e)
        {
            llenargridviewreporte();
        }
    }
}