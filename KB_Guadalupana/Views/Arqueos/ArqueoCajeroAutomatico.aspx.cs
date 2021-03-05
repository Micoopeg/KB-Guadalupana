﻿using System;
using SA_Arqueos.Controllers;
using SA_Arqueos.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modulo_de_arqueos.Views
{
    public partial class ArqueoCajeroAutomatico : System.Web.UI.Page
    {
        Conexion_arqueos cn = new Conexion_arqueos();
        Logica_arqueos logic = new Logica_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        string fecha;
        string id;
        int cont = 0;
        char delimitador2 = ' ';
        char delimitador = ':';
        char delimitador3 = '-';
        string concat = "T";
        string fechamin, horamin, fechahora, fechatotal1, año, mes, dia, usuario, puesto, idusuario, idusuario2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                puesto = Session["puesto_usuario"] as string;
                usuario = Session["sesion_usuario"] as string;
                NombreUsuario.InnerHtml = Session["Nombre"] as string;
                llenarcomboagencia();
                llenarcombousuario();
                EBuscar.Visible = false;
                arqueo.Visible = false;
                now();
                visualizar.Visible = false;
                imprimir.Visible = false;
            }
        }

        public void llenarcomboagencia()
        {
            try
            {
                string QueryString = "select * from sa_agencia";
                MySqlConnection conect = cn.conectar();
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conect);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "Agencia");
                CAAgencia.DataSource = ds;
                CAAgencia.DataTextField = "sa_nombreagencia";
                CAAgencia.DataValueField = "idsa_agencia";
                CAAgencia.DataBind();
                CAAgencia.Items.Insert(0, new ListItem("[Agencia]", "0"));
            }
            catch { }
            finally { try { cn.desconectar(); } catch { } }
        }

        public void llenarcombousuario()
        {
            try
            {
                string QueryString = "select * from gen_usuario";
                MySqlConnection conect = cn.conectar();
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, conect);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "Usuario");
                CAUsuario.DataSource = ds;
                CAUsuario.DataTextField = "gen_usuarionombre";
                CAUsuario.DataValueField = "codgenusuario";
                CAUsuario.DataBind();
                CAUsuario.Items.Insert(0, new ListItem("[Usuario]", "0"));
            }
            catch { }
            finally { try { cn.desconectar(); } catch { } }
        }

        protected void CAAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CACodigoagencia.Value = CAAgencia.SelectedValue;
        }
        protected void operar_Click(object sender, EventArgs e)
        {
            try
            {
                //SUBTOTAL BILLETES
                decimal subtotalb1, subtotalb2, subtotalb3, subtotalb4, subtotalb5, subtotalb6, subtotalb7;
                subtotalb1 = 200 * Convert.ToDecimal(CACantidad1.Value);
                //CASubtotalb1.Value = Convert.ToString(subtotalb1);
                subtotalb2 = 100 * Convert.ToDecimal(CACantidad2.Value);
                //CASubtotalb2.Value = Convert.ToString(subtotalb2);
                subtotalb3 = 50 * Convert.ToDecimal(CACantidad3.Value);
                //CASubtotalb3.Value = Convert.ToString(subtotalb3);
                subtotalb4 = 20 * Convert.ToDecimal(CACantidad4.Value);
                //CASubtotalb4.Value = Convert.ToString(subtotalb4);
                subtotalb5 = 10 * Convert.ToDecimal(CACantidad5.Value);
                //CASubtotalb5.Value = Convert.ToString(subtotalb5);
                subtotalb6 = 5 * Convert.ToDecimal(CACantidad6.Value);
                //CASubtotalb6.Value = Convert.ToString(subtotalb6);
                subtotalb7 = 1 * Convert.ToDecimal(CACantidad7.Value);
                //CASubtotalb7.Value = Convert.ToString(subtotalb7);

                //TOTAL BILLETES
                decimal totalb;
                totalb = Convert.ToDecimal(subtotalb1) + Convert.ToDecimal(subtotalb2) + Convert.ToDecimal(subtotalb3) + Convert.ToDecimal(subtotalb4) +
                         Convert.ToDecimal(subtotalb5) + Convert.ToDecimal(subtotalb6) + Convert.ToDecimal(subtotalb7);
                //CATotalb.Value = Convert.ToString(totalb);

                //SUBTOTAL MONEDAS
                decimal subtotalm1, subtotalm2, subtotalm3, subtotalm4, subtotalm5, subtotalm6;
                subtotalm1 = 1 * Convert.ToDecimal(CACantidadm1.Value);
                //CASubtotalm1.Value = Convert.ToString(subtotalm1);
                subtotalm2 = Convert.ToDecimal(0.50) * Convert.ToDecimal(CACantidadm2.Value);
                //CASubtotalm2.Value = Convert.ToString(subtotalm2);
                subtotalm3 = Convert.ToDecimal(0.25) * Convert.ToDecimal(CACantidadm3.Value);
                //CASubtotalm3.Value = Convert.ToString(subtotalm3);
                subtotalm4 = Convert.ToDecimal(0.10) * Convert.ToDecimal(CACantidadm4.Value);
                //CASubtotalm4.Value = Convert.ToString(subtotalm4);
                subtotalm5 = Convert.ToDecimal(0.05) * Convert.ToDecimal(CACantidadm5.Value);
                //CASubtotalm5.Value = Convert.ToString(subtotalm5);
                subtotalm6 = Convert.ToDecimal(0.01) * Convert.ToDecimal(CACantidadm6.Value);
                //CASubtotalm6.Value = Convert.ToString(subtotalm6);

                //TOTAL MONEDAS
                decimal totalm;
                //totalm = subtotalm1 + subtotalm2 + subtotalm3 + subtotalm4 + subtotalm5 + subtotalm6;
                totalm = Convert.ToDecimal(subtotalm1) + Convert.ToDecimal(subtotalm2) + Convert.ToDecimal(subtotalm3) +
                         Convert.ToDecimal(subtotalm4) + Convert.ToDecimal(subtotalm5) + Convert.ToDecimal(subtotalm6);
                //CATotalm.Value = Convert.ToString(totalm);

                //TOTAL EFECTIVO
                decimal totalefectivo;
                totalefectivo = Convert.ToDecimal(totalb) + Convert.ToDecimal(totalm);
                //CATotalefectivo.Value = totalefectivo.ToString();

                //DIFERENCIA
                decimal diferencia;
                diferencia = Convert.ToDecimal(totalefectivo) - Convert.ToDecimal(CAEfectivoreporte.Value);
                //CADiferencia.Value = diferencia.ToString();

                //INSERTAR ENCABEZADO
                usuario = Session["sesion_usuario"] as string;
                idusuario = sn.obteneridusuario(usuario);
                string sig = logic.siguiente("sa_encabezadocajeroaut", "idsa_encabezadocajeroaut");
                string[] valores1 = { sig, idusuario, CAFecha.Value, CACodigoagencia.Value, CAOperador.Value, CANumperador.Value, CANombreencargado.Value, CAPuestoencargado.Value, CAAtm.Value };
                logic.insertartablas("sa_encabezadocajeroaut", valores1);

                //INSERTAR DETALLE
                string sig2 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores2 = { sig2, "1", CACantidad1.Value, Convert.ToString(subtotalb1), Convert.ToString(totalb), "1", CACantidadm1.Value, Convert.ToString(subtotalm1), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores2);
                string sig3 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores3 = { sig3, "2", CACantidad2.Value, Convert.ToString(subtotalb2), Convert.ToString(totalb), "2", CACantidadm2.Value, Convert.ToString(subtotalm2), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores3);
                string sig4 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores4 = { sig4, "3", CACantidad3.Value, Convert.ToString(subtotalb3), Convert.ToString(totalb), "3", CACantidadm3.Value, Convert.ToString(subtotalm3), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores4);
                string sig5 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores5 = { sig5, "4", CACantidad4.Value, Convert.ToString(subtotalb4), Convert.ToString(totalb), "4", CACantidadm4.Value, Convert.ToString(subtotalm4), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores5);
                string sig6 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores6 = { sig6, "5", CACantidad5.Value, Convert.ToString(subtotalb5), Convert.ToString(totalb), "5", CACantidadm5.Value, Convert.ToString(subtotalm5), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores6);
                string sig7 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores7 = { sig7, "6", CACantidad6.Value, Convert.ToString(subtotalb6), Convert.ToString(totalb), "6", CACantidadm6.Value, Convert.ToString(subtotalm5), Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores7);
                string sig8 = logic.siguiente("sa_detallecajeroaut", "idsa_detallecajeroaut");
                string[] valores8 = { sig8, "7", CACantidad7.Value, Convert.ToString(subtotalb7), Convert.ToString(totalb), "8", "", "", Convert.ToString(totalm), Convert.ToString(totalefectivo), CAEfectivoreporte.Value, Convert.ToString(diferencia), CAComentario.Value, sig };
                logic.insertartablas("sa_detallecajeroaut", valores8);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            finally { try { cn.desconectar(); } catch { } }
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            mostrarcajeroauto();
            if(cont == 1)
            {
                arqueo.Visible = false;
                EBuscar.Visible = false;
            }
            else
            {
                mostrardetalle();
                arqueo.Visible = true;
                Creararqueo.Visible = false;
                Buscararqueo.Visible = false;
                visualizar.Visible = true;
                imprimir.Visible = true;
                operar.Visible = false;
                EBuscar.Visible = false;
            }
            
        }

        public void mostrarcajeroauto()
        {
            fecha = CABuscarfecha.Value;

            string[] fechasep2 = fecha.Split(delimitador3);
            año = fechasep2[0];
            mes = fechasep2[1];
            dia = fechasep2[2];
            CAFecha.Attributes.Add("value", fechatotal1);
            puesto = Session["puesto_usuario"] as string;
            usuario = Session["sesion_usuario"] as string;
            idusuario = sn.obteneridusuario(usuario);

            string[] var;
            if (puesto == "1")
            {
                var = sn.mostrarencabezadoCA(año, mes, dia, idusuario);
            }
            else
            {
                var = sn.mostrarencabezadoCA(año, mes, dia, CAUsuario.SelectedValue);
            }
            
            if (var[1] == null)
            {
                String script = "alert('No existe arqueo con esa fecha');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                cont = 1;
            }
            else
            {
                for (int i = 0; i < var.Length; i++)
                {
                    id = Convert.ToString(var[0]);
                    string fechaenc = Convert.ToString(var[1]);
                    //CAFecha.Value = Convert.ToString(var[1]);
                    CAAgencia.SelectedValue = Convert.ToString(var[2]);
                    CACodigoagencia.Value = Convert.ToString(var[2]);
                    CAOperador.Value = Convert.ToString(var[3]);
                    CANumperador.Value = Convert.ToString(var[4]);
                    CANombreencargado.Value = Convert.ToString(var[5]);
                    CAPuestoencargado.Value = Convert.ToString(var[6]);
                    CAAtm.Value = Convert.ToString(var[7]);
                    NombreFirma.InnerText = Convert.ToString(var[3]);
                    NombreFirma2.InnerHtml = Convert.ToString(var[5]);
                    puesto2.InnerHtml = Convert.ToString(var[6]);

                    string[] fechasep = fechaenc.Split(delimitador2);
                    string[] horai = fechasep[3].Split(delimitador);
                    fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horai[0] + ":" + horai[1];
                    CAFecha.Attributes.Add("value", fechatotal1);
                }
            }
        }

        public void mostrardetalle()
        {
            mostrardetalle1();
            mostrardetalle2();
            mostrardetalle3();
            mostrardetalle4();
            mostrardetalle5();
            mostrardetalle6();
            mostrardetalle7();
        }

        public void mostrardetalle1()
        {
            string[] var = sn.mostrardetalleCA1(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad1.Value = Convert.ToString(var[2]);
                CASubtotalb1.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm1.Value = Convert.ToString(var[6]);
                CASubtotalm1.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrardetalleCA2(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad2.Value = Convert.ToString(var[2]);
                CASubtotalb2.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm2.Value = Convert.ToString(var[6]);
                CASubtotalm2.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrardetalleCA3(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad3.Value = Convert.ToString(var[2]);
                CASubtotalb3.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm3.Value = Convert.ToString(var[6]);
                CASubtotalm3.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrardetalleCA4(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad4.Value = Convert.ToString(var[2]);
                CASubtotalb4.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm4.Value = Convert.ToString(var[6]);
                CASubtotalm4.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle5()
        {
            string[] var = sn.mostrardetalleCA5(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad5.Value = Convert.ToString(var[2]);
                CASubtotalb5.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm5.Value = Convert.ToString(var[6]);
                CASubtotalm5.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle6()
        {
            string[] var = sn.mostrardetalleCA6(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad6.Value = Convert.ToString(var[2]);
                CASubtotalb6.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CACantidadm6.Value = Convert.ToString(var[6]);
                CASubtotalm6.InnerHtml = Convert.ToString(var[7]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        public void mostrardetalle7()
        {
            string[] var = sn.mostrardetalleCA7(id);
            for (int i = 0; i < var.Length; i++)
            {
                CACantidad7.Value = Convert.ToString(var[2]);
                CASubtotalb7.InnerHtml = Convert.ToString(var[3]);
                CATotalb.InnerHtml = Convert.ToString(var[4]);
                CATotalm.InnerHtml = Convert.ToString(var[8]);
                CATotalefectivo.InnerHtml = Convert.ToString(var[9]);
                CAEfectivoreporte.Value = Convert.ToString(var[10]);
                CADiferencia.InnerHtml = Convert.ToString(var[11]);
                CAComentario.Value = Convert.ToString(var[12]);
            }
        }

        protected void creararqueo_Click(object sender, EventArgs e)
        {
            string usuario3, consulta;
            usuario3 = Session["sesion_usuario"] as string;
            idusuario2 = sn.obteneridusuario(usuario3);
            consulta = sn.consultararqueoCA(idusuario2);

            if (consulta == "")
            {
                arqueo.Visible = true;
                Creararqueo.Visible = false;
                Buscararqueo.Visible = false;
                visualizar.Visible = true;
                imprimir.Visible = true;
                CAOperador.Value = Session["Nombre"] as string;
                NombreFirma.InnerHtml = Session["Nombre"] as string;
            }
            else
            {
                String script = "alert('Ya tiene un arqueo creado por el dia de hoy');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
                arqueo.Visible = false;
                EBuscar.Visible = false;
                visualizar.Visible = false;
                imprimir.Visible = false;
            }
                
        }

        protected void buscararqueo_Click(object sender, EventArgs e)
        {
            puesto = Session["puesto_usuario"] as string;
            EBuscar.Visible = true;
            visualizar.Visible = false;
            imprimir.Visible = false;

            if(puesto == "1")
            {
                CAUsuario.Visible = false;
            }else if(puesto == "2")
            {
                CAUsuario.Visible = true;
            }
          
        }

        public void now()
        {

            string[] fecha = sn.datetime();
            try
            {
                for (int i = 0; i < fecha.Length; i++)
                {
                    fechamin = Convert.ToString(fecha.GetValue(0));

                    string[] valores2 = fechamin.Split(delimitador2);
                    horamin = Convert.ToString(fecha.GetValue(1));
                    string[] horas = horamin.Split(delimitador);
                    fechahora = valores2[0] + "-" + valores2[1] + "-" + valores2[2] + concat + horas[0] + ":" + horas[1];

                    CAFecha.Attributes.Add("value", fechahora);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
    }
}