﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Conexion_seguridad
    {
        protected MySqlDataAdapter AdaptadorDatos;
        protected MySqlDataReader reader;
        protected DataSet data;
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";

        public void conectar(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //string insertData = "insert into pruebadatos values ('" + TextBox1.Text + "', '" + TextBox2.Text + "')";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.Write("realizado");
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.Write("no realizado" + ex);
                }
                finally { desconectar(); }

            }
        }

        public MySqlConnection conectar()
        {


            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("se realizo");
                //  conn.Close();



            }
            catch (MySqlException ex)
            {
                Console.WriteLine("No se pudo realizar la conexion", ex);
            }
            finally
            {
                desconectar();
                KillSleepingConnections(5);
            }
            return conn;
        }

        public MySqlConnection desconectar()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return conn;
        }

        public int KillSleepingConnections(int iMinSecondsToExpire)
        {
            string strSQL = "show processlist";
            System.Collections.ArrayList m_ProcessesToKill = new ArrayList();

            MySqlConnection myConn = new MySqlConnection(connectionString);
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);
            MySqlDataReader MyReader = null;

            try
            {
                myConn.Open();

                // Get a list of processes to kill.
                MyReader = myCmd.ExecuteReader();
                while (MyReader.Read())
                {
                    // Find all processes sleeping with a timeout value higher than our threshold.
                    int iPID = Convert.ToInt32(MyReader["Id"].ToString());
                    string strState = MyReader["Command"].ToString();
                    int iTime = Convert.ToInt32(MyReader["Time"].ToString());

                    if (strState == "Sleep" && iTime >= iMinSecondsToExpire && iPID > 0)
                    {
                        // This connection is sitting around doing nothing. Kill it.
                        m_ProcessesToKill.Add(iPID);
                    }
                }

                MyReader.Close();

                foreach (int aPID in m_ProcessesToKill)
                {
                    strSQL = "kill " + aPID;
                    myCmd.CommandText = strSQL;
                    myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception excep)
            {
            }
            finally
            {
                if (MyReader != null && !MyReader.IsClosed)
                {
                    MyReader.Close();
                }

                if (myConn != null && myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            return m_ProcessesToKill.Count;
        }
    }
}