﻿using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.ReportesAdmin
{
    public partial class ReporteAdmin2 : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string cifactual;
        string sesion;
        int TVC = 0, TVM = 0, TVT = 0;
        int ESC = 0, ESM = 0, EST = 0;
        int LC = 0, LM = 0, LT = 0;
        int SC = 0, SM = 0, ST = 0;
        int EC = 0, EM = 0, ET = 0;
        int RC = 0, RM = 0, RT = 0;
        int CC = 0, CM = 0, CT = 0;
        int OC = 0, OM = 0, OT = 0;
        string firma;
        string Nombre, usuario;
        string cifnom;

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarCaja();
            llenargridviewcuentasvarias();
            llenargridviewcuentasporcobrar();
            mostrarInventario();
            llenargridviewbienesinmuebles();
            llenargridviewvehiculos();
            mostrarmaquinaria();
            mostrarmenaje();
            mostrarmenaje1();
            mostrarmenaje2();
            mostrarTV();
            mostrarES();
            mostrarL();
            llenargridviewcuentasporpagar();
            llenargridviewpasivos();
            llenargridviewtarjetas();
            mostrarSec();
            mostrarEstufa();
            mostrarRefri();
            mostrarTel();
            mostrarOtros();
            mostrarOtrasDeudas();
            mostrarPasivoC();
            mostrarIngresos();
            mostrarNegocio();
            mostrarRemesas();
            mostrarEgresos();

            //Nombre = Session["nombre"].ToString();
            //usuario = Session["sesion_usuario"].ToString();
        }

        public void mostrarCaja()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampoCaja(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                CajaA.Value = Convert.ToString(var1[0]);
            }
        }

        public void llenargridviewcuentasvarias()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codepcuentas,a.codeptipocuenta,a.codepinstitucion," +
                           "a.codeptipoestatuscuenta,a.codeptipomoneda,b.ep_tipocuentanombre," +
                           "c.ep_institucionnombre,d.ep_tipoestatuscuentanombre," +
                           "e.ep_tipomonedanombre,ep_cuentasmonto,ep_cuentasorigen " +
                           "FROM ep_cuentas a INNER JOIN ep_tipocuenta b " +
                           "INNER JOIN ep_institucion c INNER JOIN ep_tipoestatuscuenta d " +
                           "INNER JOIN ep_tipomoneda e " +
                           "inner join ep_informaciongeneral f ON a.codeptipocuenta=b.codeptipocuenta " +
                           "AND a.codepinstitucion=c.codepinstitucion " +
                           "AND a.codeptipoestatuscuenta=d.codeptipoestatuscuenta " +
                           "AND a.codeptipomoneda=e.codeptipomoneda and a.codepinformaciongeneralcif=f.codepinformaciongeneralcif " +
                           "WHERE f.ep_informaciongeneralcif='" + sesion + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewcuentasvarias.DataSource = ds4;
                    GridViewcuentasvarias.DataBind();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewcuentasporcobrar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codepcuentas,ep_cuentasnombre,ep_cuentasmonto,ep_cuentasorigen FROM ep_cuentas t0 " +
                    "inner JOIN ep_informaciongeneral t1 on t0.codepinformaciongeneralcif=t1.codepinformaciongeneralcif" +
                    " where t1.ep_informaciongeneralcif='" + sesion + "' AND t0.codeptipocuenta=4";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewcuentasporcobrar.DataSource = ds4;
                    GridViewcuentasporcobrar.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrarInventario()
        {
            sesion = Session["IDReporte1"].ToString();

            string[] var1 = sn.consultarconcampoInv(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                NombreM.Value = Convert.ToString(var1[0]);
                MontoM.Value = Convert.ToString(var1[1]);
            }
        }

        public void llenargridviewbienesinmuebles()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codepinmueble,b.ep_tipoinmueblenombre,a.codeptipoinmueble," +
                    "ep_inmueblefolio,ep_inmueblelibro,ep_inmuebledireccion,ep_inmueblevalor," +
                    "ep_inmuebledescripcion FROM ep_inmueble a INNER JOIN ep_tipoinmueble b " +
                    "INNER join ep_informaciongeneral c ON a.codeptipoinmueble=b.codeptipoinmueble" +
                    " and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif" +
                    " WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewbienesinmuebles.DataSource = ds4;
                    GridViewbienesinmuebles.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewvehiculos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codepvehiculo,a.codeptipovehiculo,b.ep_tipovehiculonombre," +
                     "ep_vehiculomarca,ep_vehiculolinea," +
                     "ep_vehiculomodelo,ep_vehiculoplaca " +
                     "FROM ep_vehiculo a INNER JOIN ep_tipovehiculo b " +
                     "inner join ep_informaciongeneral c ON a.codeptipovehiculo = b.codeptipovehiculo " +
                     "and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewvehiculos.DataSource = ds4;
                    GridViewvehiculos.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrarmaquinaria()
        {

            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomaq(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                TMaquinaria.Value = Convert.ToString(var1[0]);
                TMaquinariaEs.Value = Convert.ToString(var1[1]);
                TMaquinariaMonto.Value = Convert.ToString(var1[2]);
            }
        }

        public void mostrarmenaje()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaje(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                EComputo.Value = Convert.ToString(var1[0]);
            }
        }

        public void mostrarmenaje1()
        {

            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaje1(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                AmuebladoS.Value = Convert.ToString(var1[0]);
            }
        }

        public void mostrarmenaje2()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaje2(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                AmuebladoCom.Value = Convert.ToString(var1[0]);
            }
        }

        public void mostrarTV()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenajeTV(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                TVC = Convert.ToInt32(var1[0].Trim());
                TVM = Convert.ToInt32(var1[1].Trim());

                TVT = TVC * TVM;
                TelevisorC.Value = TVC.ToString();
                TelevisorM.Value = TVM.ToString();
                TelevisorT.Value = TVT.ToString();
            }
        }

        public void mostrarES()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenajeES(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                ESC = Convert.ToInt32(var1[0].Trim());
                ESM = Convert.ToInt32(var1[1].Trim());

                EST = ESC * ESM;
                EquipoSC.Value = ESC.ToString();
                EquipoSM.Value = ESM.ToString();
                EquipoST.Value = EST.ToString();
            }
        }

        public void mostrarL()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenajeL(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                LC = Convert.ToInt32(var1[0].Trim());
                LM = Convert.ToInt32(var1[1].Trim());

                LT = LC * LM;
                LavadoraC.Value = LC.ToString();
                LavadoraM.Value = LM.ToString();
                LavadoraT.Value = LT.ToString();
            }
        }

        public void llenargridviewcuentasporpagar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codepcuentasporpagar,a.codeptipocuentasporpagar,b.ep_tipocuentaspopagarnombre," +
                   "ep_cuentasporpagardescripcion,ep_cuentasporpagarmonto FROM ep_cuentasporpagar a " +
                   "INNER JOIN ep_tipocuentaspopagar b INNER JOIN ep_informaciongeneral c " +
                   "ON a.codeptipocuentasporpagar=b.codeptipocuentaspopagar " +
                   "and a.codepinformaciongeneralcif=c.codepinformaciongeneralcif " +
                   "WHERE c.ep_informaciongeneralcif='" + sesion + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewcuentasporpagar.DataSource = ds4;
                    GridViewcuentasporpagar.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewpasivos()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codepprestamo,a.codeptipoprestamo,a.codepinstitucion,a.codeptipoinstitucion," +
                     "b.ep_tipoprestamonombre,d.ep_tipoinstitucionnombre," +
                     "c.ep_institucionnombre,ep_prestamomomentoinicial," +
                     "ep_prestamosaldoactual,ep_prestamodestino,ep_prestamofechadesembolso," +
                     "ep_prestamofechadefinalizacion FROM ep_prestamo a " +
                     "INNER JOIN ep_tipoprestamo b INNER JOIN ep_institucion c " +
                     "INNER JOIN ep_tipoinstitucion d " +
                     "INNER JOIN ep_informaciongeneral e " +
                     "ON a.codeptipoprestamo=b.codeptipoprestamo " +
                     "AND a.codepinstitucion=c.codepinstitucion " +
                     "AND a.codeptipoinstitucion=d.codeptipoinstitucion " +
                     "AND a.codepinformaciongeneralcif=e.codepinformaciongeneralcif " +
                     "WHERE e.ep_informaciongeneralcif='" + sesion + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewpasivos.DataSource = ds4;
                    GridViewpasivos.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void llenargridviewtarjetas()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sesion = Session["IDReporte1"].ToString();
                    sqlCon.Open();
                    string QueryString = "SELECT codeptrajetadecredito,b.codeptipoinstitucion,c.codepinstitucion, " +
                   "b.ep_tipoinstitucionnombre, c.ep_institucionnombre,ep_tarjetadecreditomonedaqtz," +
                   "ep_tarjetadecreditomonedausd,ep_tarjetadecreditosaldoactual FROM ep_tarjetadecredito a " +
                   "INNER JOIN ep_tipoinstitucion b INNER JOIN ep_institucion c " +
                   "INNER JOIN ep_informaciongeneral d ON a.codeptipoinstitucion=b.codeptipoinstitucion " +
                   "AND a.codepinstitucion=c.codepinstitucion " +
                   "AND a.codepinformaciongeneralcif=d.codepinformaciongeneralcif " +
                   "WHERE d.ep_informaciongeneralcif='" + sesion + "'";
                    MySqlDataAdapter command = new MySqlDataAdapter(QueryString, sqlCon);
                    DataTable ds4 = new DataTable();
                    command.Fill(ds4);
                    GridViewtarjetas.DataSource = ds4;
                    GridViewtarjetas.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -");
                }
            }
        }

        public void mostrarSec()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaSec(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                SC = Convert.ToInt32(var1[0].Trim());
                SM = Convert.ToInt32(var1[1].Trim());

                ST = SC * SM;
                SecadoraC.Value = SC.ToString();
                SecadoraM.Value = SM.ToString();
                SecadoraT.Value = ST.ToString();
            }
        }

        public void mostrarEstufa()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaEST(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                EC = Convert.ToInt32(var1[0].Trim());
                EM = Convert.ToInt32(var1[1].Trim());

                ET = EC * EM;
                EstufaC.Value = EC.ToString();
                EstufaM.Value = EM.ToString();
                EstufaT.Value = ET.ToString();
            }
        }

        public void mostrarRefri()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaRefri(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                RC = Convert.ToInt32(var1[0].Trim());
                RM = Convert.ToInt32(var1[1].Trim());

                RT = RC * RM;
                RefriC.Value = RC.ToString();
                RefriM.Value = RM.ToString();
                RefriT.Value = RT.ToString();
            }
        }

        public void mostrarTel()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaTel(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                CC = Convert.ToInt32(var1[0].Trim());
                CM = Convert.ToInt32(var1[1].Trim());

                CT = CC * CM;
                TMC.Value = CC.ToString();
                TMM.Value = CM.ToString();
                TMT.Value = CT.ToString();
            }
        }

        public void mostrarOtros()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaOtros(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                OC = Convert.ToInt32(var1[0].Trim());
                OM = Convert.ToInt32(var1[1].Trim());

                OT = OC * OM;
                OtrosC.Value = OC.ToString();
                OtrosM.Value = OM.ToString();
                OtrosT.Value = OT.ToString();
            }
        }

        public void mostrarOtrasDeudas()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaOD(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                EspD.Value = Convert.ToString(var1[0]);
                EspM.Value = Convert.ToString(var1[1]);
            }
        }

        public void mostrarPasivoC()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaPC(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                NombreEN.Value = Convert.ToString(var1[0]);
                NombreD.Value = Convert.ToString(var1[1]);
                RelacionD.Value = Convert.ToString(var1[2]);
                SaldoD.Value = Convert.ToString(var1[3]);
                FechaDD.Value = Convert.ToString(var1[4]);
                FechaFina.Value = Convert.ToString(var1[5]);
            }
        }

        public void mostrarIngresos()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaIng(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                SuelB.Value = Convert.ToString(var1[0]);
                SBoni.Value = Convert.ToString(var1[1]);
                CMensua.Value = Convert.ToString(var1[2]);
            }
        }

        public void mostrarNegocio()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaNeg(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                TipoNeg.Value = Convert.ToString(var1[0]);
                NombreNeg.Value = Convert.ToString(var1[1]);
                NoNeg.Value = Convert.ToString(var1[2]);
                EmpleNeg.Value = Convert.ToString(var1[3]);
                ObjNeg.Value = Convert.ToString(var1[4]);
                IngeNeg.Value = Convert.ToString(var1[5]);
                EgrNeg.Value = Convert.ToString(var1[6]);
                DireNeg.Value = Convert.ToString(var1[7]);
            }
        }

        public void mostrarRemesas()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaRem(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                NomRem.Value = Convert.ToString(var1[0]);
                RelaRem.Value = Convert.ToString(var1[1]);
                MontoRem.Value = Convert.ToString(var1[2]);
                PeriRem.Value = Convert.ToString(var1[3]);
            }
        }

        public void mostrarEgresos()
        {
            sesion = Session["IDReporte1"].ToString();
            string[] var1 = sn.consultarconcampomenaEgres(sesion);
            for (int i = 0; i < var1.Length; i++)
            {
                Alimen.Value = Convert.ToString(var1[2]);
                Gas.Value = Convert.ToString(var1[3]);
                PagoEstud.Value = Convert.ToString(var1[5]);
                Presta.Value = Convert.ToString(var1[5]);
                TarCre.Value = Convert.ToString(var1[6]);
                Vestuar.Value = Convert.ToString(var1[4]);
                Recrea.Value = Convert.ToString(var1[8]);
                Otros.Value = Convert.ToString(var1[9]);
            }
        }
    }
}