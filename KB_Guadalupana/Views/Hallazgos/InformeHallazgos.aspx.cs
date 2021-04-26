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

namespace KB_Guadalupana.Views.Hallazgos
{
    public partial class InformeHallazgos : System.Web.UI.Page
    {
        Conexion_Hallazgo con = new Conexion_Hallazgo();
        Sentencia_Hallazgo sen = new Sentencia_Hallazgo();
        string trimestre, año, gerencia, area, estado;
        string mes1 = "1";
        string mes2 = "2";
        string mes3 = "3";
        string mes4 = "4";
        string idguardar;

        string val1, val2, val3;

        protected void Page_Load(object sender, EventArgs e)
        {
            llenargridviewreporte();
        }

        public void llenargridviewreporte()
        {
            trimestre = Session["Mes1"].ToString();
            año = Session["Año1"].ToString();
            gerencia = Session["Gerencia1"].ToString();
            area = Session["Area1"].ToString();
            estado = Session["Estado1"].ToString();
            mostrar();

            mess.InnerText = trimestre;
            B1.InnerText = año;
        }

        public void mostrar()
        {
            if((estado == "2") || (estado == "3") || (estado == "1"))
            {
                GridView1.Visible = false;
                using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
                {
                    try
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                        sqlCon.Open();
                        string QueryString = "select t0.id_shhallazgo,t0.sh_rubro,t0.sh_hallazgo,t0.sh_mes,t4.sh_nombre,t2.sh_gerencianombre," +
                            "t3.sh_areanombre, t0.sh_recomendacion,t4.sh_nombre,t5.sh_comentario as Comen,t5.sh_fecha as Fecha " +
                            "from sh_hallazgo t0 inner join sh_asignacion t1 on t0.id_shhallazgo = t1.sh_hallazgo_id_shhallazgo " +
                            "inner join sh_gerencias t2 on t1.sh_gerencias_id_shgerencia= t2.id_shgerencia " +
                            "inner join sh_area t3 on t1.sh_idarea= t3.id_sharea inner join sh_estado t4 on t0.sh_estado_id_shestado= t4.id_shestado " +
                            "inner join sh_respuesta t5 on t0.id_shhallazgo=t5.sh_hallazgo_id_shhallazgo " +
                            "where t0.sh_mes='"+trimestre+"' " +
                            "and t0.sh_año='"+año+"' and t1.sh_gerencias_id_shgerencia='"+gerencia+"' and t1.sh_idarea='"+area+"'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds3 = new DataTable();
                        command.Fill(ds3);
                        GridViewReporteH.DataSource = ds3;
                        GridViewReporteH.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                    }
                }
            }
            else
            {
                GridViewReporteH.Visible = false;
                using (MySqlConnection sqlCon = new MySqlConnection(con.cadenadeconexion()))
                {
                    try
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('" + sesion + "');", true);
                        sqlCon.Open();
                        string QueryString = "select t0.id_shhallazgo,t0.sh_rubro,t0.sh_hallazgo,t0.sh_mes,t4.sh_nombre,t2.sh_gerencianombre,t3.sh_areanombre, t0.sh_recomendacion,t4.sh_nombre " +
                            "from sh_hallazgo t0 inner join sh_asignacion t1 on t0.id_shhallazgo = t1.sh_hallazgo_id_shhallazgo " +
                            "inner join sh_gerencias t2 on t1.sh_gerencias_id_shgerencia= t2.id_shgerencia " +
                            "inner join sh_area t3 on t1.sh_idarea= t3.id_sharea " +
                            "inner join sh_estado t4 on t0.sh_estado_id_shestado= t4.id_shestado " +
                            "where t0.sh_mes='" + trimestre + "' and t0.sh_año='" + año + "' and t1.sh_gerencias_id_shgerencia='" + gerencia + "' and t1.sh_idarea='" + area + "' and t0.sh_estado_id_shestado ='" + estado + "'";
                        MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                        DataTable ds3 = new DataTable();
                        command.Fill(ds3);
                        GridView1.DataSource = ds3;
                        GridView1.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                    }
                }
            }
        }

        protected void OnSelectedIndexChangedReporte(object sender, EventArgs e)
        {
            string val1, val2;

            GridViewRow row = GridViewReporteH.SelectedRow;
            idguardar = Convert.ToString((GridViewReporteH.SelectedRow.FindControl("idhallazgo") as Label).Text);

            Session["Idguardar"] = idguardar;
            Response.Redirect("EditarHallazgo.aspx");
        }
    }
}