﻿using System;
using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion
{
    public partial class MantenimientoRoles : System.Web.UI.Page
    {
        Logica logic = new Logica();
        Conexion conn = new Conexion();
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
            RVCodigo.Value = logic.siguiente("gen_roles", "codgenroles");
            RVCodigo.Disabled = false;
        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO gen_roles (codgenroles,gen_rolesnombre) VALUES (@FirstName,@Contact)";
                        MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        //sqlCmd.Parameters.AddWithValue("@FirstName", (logic.siguiente("ep_tipovehiculo", "codeptipovehiculo")));

                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "Registro añadido exitosamente";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }

        }

        void PopulateGridview()
        {
            try
            {


                string QueryString = "SELECT * FROM gen_roles;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
                //(gvPhoneBook.SelectedRow.FindControl("txtFirstNameFooter") as TextBox).Text = Convert.ToString(logic.siguiente("ep_tipovehiculo", "codeptipovehiculo"));
                //(gvPhoneBook.FindControl("txtFirstNameFooter") as TextBox).Text = RVCodigo.Value;

            }
            catch
            {
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE gen_roles SET codgenroles=@FirstName,gen_rolesnombre=@Contact WHERE codgenroles = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Registro modificado exitosamente";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM gen_roles WHERE codgenroles = @id";
                    MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Registro eliminado exitosamente";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        public DataSet GetCategoryNames()
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM gen_roles;", conn.conectar());
            DataSet ds = new DataSet();
            ad.Fill(ds, "Nombre");
            return ds;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT * FROM gen_roles WHERE gen_rolesnombre='" + TextBox1.Text + "';";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
            }
            catch { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string QueryString = "SELECT * FROM gen_roles;";
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conn.conectar());
                DataTable ds3 = new DataTable();
                myCommand.Fill(ds3);
                gvPhoneBook.DataSource = ds3;
                gvPhoneBook.DataBind();
            }
            catch { }
        }

    }
}