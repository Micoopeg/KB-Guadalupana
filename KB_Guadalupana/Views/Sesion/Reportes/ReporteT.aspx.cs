﻿using KB_Guadalupana.Controllers;
using KB_Guadalupana.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KB_Guadalupana.Views.Sesion.Reportes
{
    public partial class ReporteT : System.Web.UI.Page
    {
        Conexion cn = new Conexion();
        Logica logic = new Logica();
        Sentencia sn = new Sentencia();

        string sesion;

        int caja1, cuentasQ1, CooperativasQ1, CP1, IN1, Inmuebles1, vehiculo1, maquinaria1, computo1, TotalQ1,salas1, comedor1,tele, Es1,L1,S1, Est1,Ref1,Mov1,otr1;
        int cuentasD1, CooperativasD1, TotalD1;
        int pp1,TotalQ2,patrimonio1,pres1,tc1,OD1,pas1;


        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarCaja();
            mostrarCuentasQ();
            mostrarCuentasD();
            mostrarCooperativasD();
            mostrarCooperativasQ();
            mostrarCP();
            mostrarIN();
            mostrarInmueble();
            mostrarVehiculo();
            mostrarMaquinaria();
            mostrarSala();
            mostrarComedor();
            mostrarComputo();
            mostrarTV();
            mostrarES(); 
            mostrarL();
            mostrarSec();
            mostrarEst();
            mostrarRefri();
            mostrarTel();
            mostrarOtros();
            mostrarPP();
            mostrarPrestamos();
            mostrarTarjeta();
            mostrarOD();
            mostrarpasivcon();
            dolaresa();
            quetzalessa();
            quetzalessp();
            patrimonio();
        }

        public void dolaresa()
        {
            TotalD1 = cuentasD1 + CooperativasD1;
            Text23.Value = TotalD1.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void quetzalessa()
        {
            TotalQ1 = caja1 + cuentasQ1 + CooperativasQ1 + CP1 + IN1 + Inmuebles1 + vehiculo1 + maquinaria1 + computo1 + salas1 + comedor1 + tele + Es1 + L1 + S1 + Est1 + Ref1 + Mov1 + otr1;
            Text14.Value = TotalQ1.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void quetzalessp()
        {
            TotalQ2 = pp1 + pres1 + tc1 + OD1 + pas1;
            TotalPasivo.Value = TotalQ2.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void patrimonio()
        {
            patrimonio1 = TotalQ1 - TotalQ2;
            pat.Value = patrimonio1.ToString("N1", CultureInfo.CurrentCulture);
        }

        public void mostrarCaja()
        {
            sesion = Session["sesion_usuario"].ToString();

            FRmE1.Value = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCajas(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                caja1 = Convert.ToInt32(var1[0]);
                EfectivoCaja.Value = caja1.ToString("N1",CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCuentasQ()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoQ(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                cuentasQ1 = Convert.ToInt32(var1[0]);
                CuentasBancos.Value = cuentasQ1.ToString("N1", CultureInfo.CurrentCulture); 
            }
        }

        public void mostrarCuentasD()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoD(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                cuentasD1 = Convert.ToInt32(var1[0]);
                CuentasBancos1.Value = cuentasD1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCooperativasD()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCD(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                CooperativasD1 = Convert.ToInt32(var1[0]);
                CuentasCope1.Value = CooperativasD1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCooperativasQ()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCQ(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                CooperativasQ1 = Convert.ToInt32(var1[0]);
                CuentasCope.Value = CooperativasQ1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarCP()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCP(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                CP1 = Convert.ToInt32(var1[0]);
                CuentasPC.Value = CP1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarIN()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoIN(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                IN1 = Convert.ToInt32(var1[0]);
                Inventario.Value = IN1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarInmueble()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoInmueble(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                Inmuebles1 = Convert.ToInt32(var1[0]);
                Inmueble.Value = Inmuebles1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarVehiculo()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoVehiculo(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                vehiculo1 = Convert.ToInt32(var1[0]);
                Vehiculo.Value = vehiculo1.ToString("N1", CultureInfo.CurrentCulture); ;
            }
        }

        public void mostrarMaquinaria()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoMaquinaria(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                maquinaria1 = Convert.ToInt32(var1[0]);
                Maquinaria.Value = maquinaria1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarComputo()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoComputo(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                computo1 = Convert.ToInt32(var1[0]);
                Computo.Value = computo1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarSala()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoSala(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                salas1 = Convert.ToInt32(var1[0]);
                sala.Value = salas1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarComedor()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoComedor(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                comedor1 = Convert.ToInt32(var1[0]);
                comedor.Value = comedor1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarTV()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoTV(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                tele = Convert.ToInt32(var1[0]);
                TV.Value = tele.ToString("N1", CultureInfo.CurrentCulture);
            }
        }
        
        public void mostrarES()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoES(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                Es1 = Convert.ToInt32(var1[0]);
                EquipoS.Value = Es1.ToString("N1", CultureInfo.CurrentCulture);
            }
        } 
        
        public void mostrarL()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoL(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                L1 = Convert.ToInt32(var1[0]);
                lava.Value = L1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }
        
        public void mostrarSec()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoSec(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                S1 = Convert.ToInt32(var1[0]);
                SECA.Value = S1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarEst()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoEst(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                Est1 = Convert.ToInt32(var1[0]);
                Estufa.Value = Est1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarRefri()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoRefri(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                Ref1 = Convert.ToInt32(var1[0]);
                Refri.Value = Ref1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarTel()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoTel(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                Mov1 = Convert.ToInt32(var1[0]);
                Movil.Value = Mov1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarOtros()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoOtros(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                otr1 = Convert.ToInt32(var1[0]);
                otross.Value = otr1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        //Pasivos
        public void mostrarPP()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCP1(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                pp1 = Convert.ToInt32(var1[0]);
                CuentaPP.Value = pp1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarPrestamos()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCuentaspp(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                pres1 = Convert.ToInt32(var1[0]);
                Pres.Value = pres1.ToString("N1", CultureInfo.CurrentCulture);
            }
        } 
        
        public void mostrarTarjeta()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCuentaTarjeta(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                tc1 = Convert.ToInt32(var1[0]);
                TC.Value = tc1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }
        
        public void mostrarOD()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCuentaOD(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                OD1 = Convert.ToInt32(var1[0]);
                ode.Value = OD1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

        public void mostrarpasivcon()
        {
            sesion = Session["sesion_usuario"].ToString();
            string[] var10 = sn.consultarcif(sesion);
            string cifnumero = var10[0];

            string[] var1 = sn.consultarconcampoCuentapasc(cifnumero);
            for (int i = 0; i < var1.Length; i++)
            {
                pas1 = Convert.ToInt32(var1[0]);
                pasc.Value = pas1.ToString("N1", CultureInfo.CurrentCulture);
            }
        }

    }
}