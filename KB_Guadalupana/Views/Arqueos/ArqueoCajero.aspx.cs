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
    public partial class ArqueoCajero : System.Web.UI.Page
    {
        Conexion_arqueos cn = new Conexion_arqueos();
        Logica_arqueos logic = new Logica_arqueos();
        Logica_arqueos logic2 = new Logica_arqueos();
        Sentencia_arqueos sn = new Sentencia_arqueos();
        string fecha;
        string id;
        char delimitador2 = ' ';
        char delimitador = ':';
        string concat = "T";
        char delimitador3 = '-';
        string fechamin, horamin, fechahora, fechatotal1, año, mes, dia, usuario, puesto, idusuario, idusuario2;
        string op;
        int cont = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //CFecha.Value = Convert.ToString(fecha.Date);
            //VARIABLES SESSION
            //    Session["fechayhora"] = CFecha.Value.ToString();
            //    Session["agencia"] = CAgencia.Value.ToString();
            //    Session["codigoagencia"] = CCAgencia.Value.ToString();
            //    Session["nombre"] = CNombre.Value.ToString();
            //    Session["usuario"] = CUsuario.Value.ToString();
            //    Session["operador"] = COperador.Value.ToString();
            //    Session["jefe"] = CJefe.Value.ToString();
            //    Session["comentario"] = CComentario.Value.ToString();

            //    string fechayhora = Session["fechayhora"] as string;
            //    CFecha.Value = fechayhora.ToString();
            //string agencia = Session["agencia"] as string;
            //CAgencia.Value = agencia.ToString();

            //Session["agencia"] = "Hola";
            ////string agencia = Session["agencia"] as string;
            //CAgencia.Value = Session["agencia"] as string;
            if (!IsPostBack)
            {
                puesto = Session["puesto_usuario"] as string;
                usuario = Session["sesion_usuario"] as string;
                NombreUsuario.InnerHtml = Session["Nombre"] as string;
                CUsuario.Value = Session["sesion_usuario"] as string;
                //CFecha.Value = Session["fecha2"] as string;
                CAgencia.SelectedValue = Session["agencia"] as string;
                CCAgencia.Value = Session["codigo"] as string;
                CNombre.Value = Session["nombre"] as string;
                CUsuario.Value = Session["usuario"] as string;
                COperador.Value = Session["operador"] as string;
                CJefe.Value = Session["jefe"] as string;
                CPuestoencargado.Value = Session["puesto"] as string;

                llenarcomboagencia();
                llenarcombousuario();
                EBuscar.Visible = false;
                arqueo.Visible = false;
                now();
                visualizar.Visible = false;
                imprimir.Visible = false;
            }
            //siguiente.Enabled = false;
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
                CAgencia.DataSource = ds;
                CAgencia.DataTextField = "sa_nombreagencia";
                CAgencia.DataValueField = "idsa_agencia";
                CAgencia.DataBind();
                CAgencia.Items.Insert(0, new ListItem("[Agencia]", "0"));
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

        protected void CAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCAgencia.Value = CAgencia.SelectedValue;
        }
        protected void siguiente_Click(object sender, EventArgs e)
        {
            op = Session["op"] as string;
            if (op == "2")
            {
                String script = "alert('Debe guardar antes de cambiar de página');";
                ScriptManager.RegisterStartupScript(this, GetType().GetType(), "alertMessage", script, true);
            }
            else if(op == "1")
            {
                Response.Redirect("ArqueoCajero2.aspx");
            }
           
        }

        protected void operar_Click(object sender, EventArgs e)
        {
            Session["op"] = "1";
            try
                {
                
                  //SUMA DE BILLETES
                    decimal sumab1, sumab2, sumab3, sumab4, sumab5, sumab6, sumab7;
                    sumab1 = Convert.ToDecimal(200.00) * Convert.ToDecimal(CCantidad1.Value);
                    //CBTotal1.Value = Convert.ToString(sumab1);
                    sumab2 = Convert.ToDecimal(100.00) * Convert.ToDecimal(CCantidad2.Value);
                    //CBTotal2.Value = Convert.ToString(sumab2);
                    sumab3 = Convert.ToDecimal(50.00) * Convert.ToDecimal(CCantidad3.Value);
                    //CBTotal3.Value = Convert.ToString(sumab3);
                    sumab4 = Convert.ToDecimal(20.00) * Convert.ToDecimal(CCantidad4.Value);
                    //CBTotal4.Value = Convert.ToString(sumab4);
                    sumab5 = Convert.ToDecimal(10.00) * Convert.ToDecimal(CCantidad5.Value);
                    //CBTotal5.Value = Convert.ToString(sumab5);
                    sumab6 = Convert.ToDecimal(5.00) * Convert.ToDecimal(CCantidad6.Value);
                    //CBTotal6.Value = Convert.ToString(sumab6);
                    sumab7 = Convert.ToDecimal(1.00) * Convert.ToDecimal(CCantidad7.Value);
                    //CBTotal7.Value = Convert.ToString(sumab7);

                //SUMA DE MONEDAS
                decimal sumam1, sumam2, sumam3, sumam4, sumam5, sumam6;
                sumam1 = Convert.ToDecimal(1.00) * Convert.ToInt32(CMCantidad1.Value);
                //CMTotal1.Value = Convert.ToString(sumam1);
                sumam2 = Convert.ToDecimal(0.50) * Convert.ToDecimal(CMCantidad2.Value);
                //CMTotal2.Value = Convert.ToString(sumam2);
                sumam3 = Convert.ToDecimal(0.25) * Convert.ToDecimal(CMCantidad3.Value);
                //CMTotal3.Value = Convert.ToString(sumam3);
                sumam4 = Convert.ToDecimal(0.10) * Convert.ToDecimal(CMCantidad4.Value);
                //CMTotal4.Value = Convert.ToString(sumam4);
                sumam5 = Convert.ToDecimal(0.05) * Convert.ToDecimal(CMCantidad5.Value);
                //CMTotal5.Value = Convert.ToString(sumam5);
                sumam6 = Convert.ToDecimal(0.01) * Convert.ToDecimal(CMCantidad6.Value);
                //CMTotal6.Value = Convert.ToString(sumam6);

                //INSERTAR ENCABEZADO
                string usuario2;
                usuario2 = Session["sesion_usuario"] as string;
                idusuario = sn.obteneridusuario(usuario2);
                string sig = logic.siguiente("sa_encabezadocajero", "idsa_encabezadocajero");
                    Session["id"] = sig.ToString();
                string[] valores1 = { sig, idusuario, CFecha.Value, CCAgencia.Value, CNombre.Value, CUsuario.Value, COperador.Value, CJefe.Value, CPuestoencargado.Value, CComentario.Value };
                logic.insertartablas("sa_encabezadocajero", valores1);

                //VARIABLES SESSION DEL ENCABEZADO
                //string fecha = CFecha.Value;
                //Session["fecha2"] = fecha.ToString();
                string agencia = CAgencia.SelectedValue;
                Session["agencia"] = agencia.ToString();
                string codigo = CCAgencia.Value;
                Session["codigo"] = codigo.ToString();
                string nombre = CNombre.Value;
                Session["nombre"] = nombre.ToString();
                string usuario = CUsuario.Value;
                Session["usuario"] = usuario.ToString();
                string operador = COperador.Value;
                Session["operador"] = operador.ToString();
                string jefe = CJefe.Value;
                Session["jefe"] = jefe.ToString();
                string puesto = CPuestoencargado.Value;
                Session["puesto"] = puesto.ToString();


                //TOTAL DE CIERRE
                decimal sumatotal;
                    sumatotal = Convert.ToDecimal(sumab1) + Convert.ToDecimal(sumab2) + Convert.ToDecimal(sumab3) + Convert.ToDecimal(sumab4) + Convert.ToDecimal(sumab5) +
                    Convert.ToDecimal(sumab6) + Convert.ToDecimal(sumab7) + Convert.ToDecimal(sumam1) + Convert.ToDecimal(sumam2) + Convert.ToDecimal(sumam3) +
                    Convert.ToDecimal(sumam4) + Convert.ToDecimal(sumam5) + Convert.ToDecimal(sumam6);
                //CTotalefectivo.Value = Convert.ToString(sumatotal);

                //INSERTAR DETALLE
                string sig2 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores2 = { sig2, "1", CCantidad1.Value, Convert.ToString(sumab1), "1", CMCantidad1.Value, Convert.ToString(sumam1), Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores2);
                string sig3 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores3 = { sig3, "2", CCantidad2.Value, Convert.ToString(sumab2), "2", CMCantidad2.Value, Convert.ToString(sumam2), Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores3);
                string sig4 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores4 = { sig4, "3", CCantidad3.Value, Convert.ToString(sumab3), "3", CMCantidad3.Value, Convert.ToString(sumam3), Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores4);
                string sig5 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores5 = { sig5, "4", CCantidad4.Value, Convert.ToString(sumab4), "4", CMCantidad4.Value, Convert.ToString(sumam4), Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores5);
                string sig6 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores6 = { sig6, "5", CCantidad5.Value, Convert.ToString(sumab5), "5", CMCantidad5.Value, Convert.ToString(sumam5), Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores6);
                string sig7 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores7 = { sig7, "6", CCantidad6.Value, Convert.ToString(sumab6), "6", CMCantidad6.Value, Convert.ToString(sumam6), Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores7);
                string sig8 = logic.siguiente("sa_detallecajero", "idsa_detallecajero");
                string[] valores8 = { sig8, "7", CCantidad7.Value, Convert.ToString(sumab7), "8", "", "", Convert.ToString(sumatotal), CTotalrecibido.Value, CTotalentregado.Value, sig };
                logic.insertartablas("sa_detallecajero", valores8);

                siguiente.Enabled = true;
            }
            catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally { try { cn.desconectar(); } catch { } }
            
        }

        protected void buscar_Click(object sender, EventArgs e)
        {
            Session["siguiente"] = "1";
            Session["op"] = "1";
            mostrarcajero();
            if (cont == 1)
            {
                arqueo.Visible = false;
                EBuscar.Visible = false;
            }
            else
            {  mostrardetalle();
                arqueo.Visible = true;
                Creararqueo.Visible = false;
                Buscararqueo.Visible = false;
                visualizar.Visible = true;
                imprimir.Visible = true;
                operar.Visible = false;
                EBuscar.Visible = false;
            }
            
        }

        public void mostrarcajero()
        {
            fecha = CABuscarfecha.Value;
            string[] fechasep2 = fecha.Split(delimitador3);
            año = fechasep2[0];
            mes = fechasep2[1];
            dia = fechasep2[2];
            CFecha.Attributes.Add("value", fechatotal1);
            puesto = Session["puesto_usuario"] as string;
            usuario = Session["sesion_usuario"] as string;
            idusuario = sn.obteneridusuario(usuario);

            string[] var;
            if (puesto == "1")
            {
                var = sn.mostrarencabezadoC(año, mes, dia, idusuario);
            }
            else
            {
                var = sn.mostrarencabezadoC(año, mes, dia, CAUsuario.SelectedValue);
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
                    //CFecha.Value = Convert.ToString(var[1]);
                    CAgencia.SelectedValue = Convert.ToString(var[2]);
                    CCAgencia.Value = Convert.ToString(var[2]);
                    CNombre.Value = Convert.ToString(var[3]);
                    CUsuario.Value = Convert.ToString(var[4]);
                    COperador.Value = Convert.ToString(var[5]);
                    CJefe.Value = Convert.ToString(var[6]);
                    CPuestoencargado.Value = Convert.ToString(var[7]);
                    CComentario.Value = Convert.ToString(var[8]);
                    string idcajero1 = id.ToString();
                    Session["idcajero1"] = idcajero1.ToString();

                    string nombre = Convert.ToString(var[6]);
                    Session["jefe"] = nombre.ToString();

                    string puesto2 = Convert.ToString(var[7]);
                    Session["puesto"] = puesto2.ToString();

                    string[] fechasep = fechaenc.Split(delimitador2);
                    string[] horai = fechasep[3].Split(delimitador);
                    fechatotal1 = fechasep[0] + "-" + fechasep[1] + "-" + fechasep[2] + concat + horai[0] + ":" + horai[1];
                    CFecha.Attributes.Add("value", fechatotal1);
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
            string[] var = sn.mostrardetalleC1(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad1.Value = Convert.ToString(var[2]);
                CBTotal1.InnerHtml = Convert.ToString(var[3]);
                CMCantidad1.Value = Convert.ToString(var[5]);
                CMTotal1.InnerHtml = Convert.ToString(var[6]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle2()
        {
            string[] var = sn.mostrardetalleC2(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad2.Value = Convert.ToString(var[2]);
                CBTotal2.InnerHtml = Convert.ToString(var[3]);
                CMCantidad2.Value = Convert.ToString(var[5]);
                CMTotal2.InnerHtml = Convert.ToString(var[6]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle3()
        {
            string[] var = sn.mostrardetalleC3(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad3.Value = Convert.ToString(var[2]);
                CBTotal3.InnerHtml = Convert.ToString(var[3]);
                CMCantidad3.Value = Convert.ToString(var[5]);
                CMTotal3.InnerHtml = Convert.ToString(var[6]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle4()
        {
            string[] var = sn.mostrardetalleC4(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad4.Value = Convert.ToString(var[2]);
                CBTotal4.InnerHtml = Convert.ToString(var[3]);
                CMCantidad4.Value = Convert.ToString(var[5]);
                CMTotal4.InnerHtml = Convert.ToString(var[6]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle5()
        {
            string[] var = sn.mostrardetalleC5(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad5.Value = Convert.ToString(var[2]);
                CBTotal5.InnerHtml = Convert.ToString(var[3]);
                CMCantidad5.Value = Convert.ToString(var[5]);
                CMTotal5.InnerHtml = Convert.ToString(var[6]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle6()
        {
            string[] var = sn.mostrardetalleC6(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad6.Value = Convert.ToString(var[2]);
                CBTotal6.InnerHtml = Convert.ToString(var[3]);
                CMCantidad6.Value = Convert.ToString(var[5]);
                CMTotal6.InnerHtml = Convert.ToString(var[6]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        public void mostrardetalle7()
        {
            string[] var = sn.mostrardetalleC7(id);
            for (int i = 0; i < var.Length; i++)
            {
                CCantidad7.Value = Convert.ToString(var[2]);
                CBTotal7.InnerHtml = Convert.ToString(var[3]);
                CTotalefectivo.InnerHtml = Convert.ToString(var[7]);
                CTotalrecibido.Value = Convert.ToString(var[8]);
                CTotalentregado.Value = Convert.ToString(var[9]);
            }
        }

        protected void creararqueo_Click(object sender, EventArgs e)
        {
            string usuario3, consulta;
            usuario3 = Session["sesion_usuario"] as string;
            idusuario2 = sn.obteneridusuario(usuario3);
            consulta = sn.consultararqueoC(idusuario2);
            if (consulta == "")
            {
                Session["op"] = "2";
                arqueo.Visible = true;
                Creararqueo.Visible = false;
                Buscararqueo.Visible = false;
                visualizar.Visible = true;
                imprimir.Visible = true;
                CUsuario.Value = Session["sesion_usuario"] as string;
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
            Session["op"] = "1";
            puesto = Session["puesto_usuario"] as string;
            EBuscar.Visible = true;
            visualizar.Visible = false;
            imprimir.Visible = false;

            if (puesto == "1")
            {
                CAUsuario.Visible = false;
            }
            else if (puesto == "2")
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

                    CFecha.Attributes.Add("value", fechahora);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

            }


        }
    }
}