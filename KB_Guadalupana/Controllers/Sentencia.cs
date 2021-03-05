﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Guadalupana.Controllers
{
    public class Sentencia
    {
        string connectionString = @"Server=localhost;Database=bdkbguadalupana;Uid=root;Pwd=;";
        Conexion cn = new Conexion();
        MySqlCommand comm;

        public void ingreso(string query)
        {
            try { cn.conectar(query); }
            catch { }
            finally { cn.desconectar(); }

        }

        public MySqlDataReader consultar(string tabla)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string consultaGraAsis = " select * from " + tabla + ";";
                    comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                    MySqlDataReader mostrarResultados = comm.ExecuteReader();
                    return mostrarResultados;
                }


            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }

        }



        public MySqlDataReader consultarCodigo(string usuario)
        {
            try
            {
                string consultaGraAsis = "SELECT ep_control.codgenusuario FROM ep_control INNER JOIN gen_usuario ON ep_control.codgenusuario = gen_usuario.codgenusuario AND gen_usuario.gen_usuarionombre = '" + usuario + "' GROUP BY gen_usuario.codgenusuario; ";
                MySqlCommand comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }






        public MySqlDataReader consultaridcontrol(string usuario, string lote)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = " select codepcontrol from ep_control where codgenusuario ='" + usuario + "' AND codepadministracionlote ='" + lote + "' ;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }


        //CONSULTAR DATOS DE UN EP EXISTENTE
        public MySqlDataReader consultarepingresado(string sucursal, string estadocivil, string tipoidentificacion, string departamento, string municipio, string zona, string area, string cif)
        {
            try
            {
                cn.conectar();
                string consulta = "SELECT a.ep_informaciongeneralcif,a.ep_informaciongeneralpuesto,b.gen_sucursalnombre,h.gen_areanombre,ep_informaciongeneralprimerapellido,ep_informaciongeneralsegundoapellido,ep_informaciongeneralprimernombre,ep_informaciongeneralsegundonombre,ep_informaciongeneralnombreadicional,e.gen_departamentonombre,f.gen_municipionombre,g.gen_zonanombre,a.ep_informaciongeneraldireccion,d.gen_tipoidentificacionnombre,ep_informaciongeneralnumeroidentificacion,a.ep_informaciongeneralfechanacimiento,a.ep_informaciongeneralnit,a.ep_informaciongeneralnacionalidad,a.ep_informaciongeneralcelular,a.ep_informaciongeneraltelefonocasa,a.ep_informaciongeneralcorreo,a.ep_informaciongeneralestatura,a.ep_informaciongeneralpeso,a.ep_informaciongeneralreligion,c.ep_estadocivilnombre " +
                    "FROM ep_informaciongeneral a " +
                    "INNER JOIN gen_sucursal b " +
                    "INNER JOIN ep_estadocivil c " +
                    "INNER JOIN gen_tipoidentificacion d " +
                    "INNER JOIN gen_departamento e " +
                    "INNER JOIN gen_municipio f " +
                    "INNER JOIN gen_zona g " +
                    "INNER JOIN gen_area h " +
                    "ON b.codgensucursal='" + sucursal + "' " +
                    "AND c.codepestadocivil='" + estadocivil + "' " +
                    "AND d.codgentipoidentificacion='" + tipoidentificacion + "'" +
                    "AND e.codgendepartamento='" + departamento + "'" +
                    " AND f.codgenmunicipio='" + municipio + "'" +
                    "AND g.codgenzona='" + zona + "'" +
                    "AND h.codgenarea='" + area + "'" +
                    "WHERE codepinformaciongeneralcif='" + cif + "';";
                comm = new MySqlCommand(consulta, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                Console.WriteLine(consulta);

                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
            finally { cn.desconectar(); }
        }

     

        //MOSTRAR DATOS







        //Consultar Reporte

        public MySqlDataReader consultarconcampoIG(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT " +
                    "epig.ep_informaciongeneralcif, " +
                    "epig.ep_informaciongeneralpuesto," +
                    "gs.gen_sucursalnombre," +
                    "ga.gen_areanombre, " +
                    "epig.ep_informaciongeneralprimerapellido, " +
                    "epig.ep_informaciongeneralsegundoapellido," +
                    "epig.ep_informaciongeneralprimernombre, " +
                    "epig.ep_informaciongeneralsegundonombre, " +
                    "epig.ep_informaciongeneralnombreadicional," +
                    "gdep.gen_departamentonombre, " +
                    "gen_municipionombre, " +
                    "gz.gen_zonanombre," +
                    "epig.ep_informaciongeneraldireccion, " +
                    "gid.gen_tipoidentificacionnombre," +
                    "epig.ep_informaciongeneralnumeroidentificacion," +
                    "DATE_FORMAT(epig.ep_informaciongeneralfechanacimiento, '%Y-%m-%d')," +
                    "epig.ep_informaciongeneralnit," +
                    "epig.ep_informaciongeneralnacionalidad," +
                    "epig.ep_informaciongeneralreligion," +
                    "epig.ep_informaciongeneralestatura," +
                    "epig.ep_informaciongeneralpeso,epig.ep_informaciongeneralcorreo " +
                    "FROM ep_informaciongeneral epig " +
                    "INNER JOIN gen_sucursal gs ON epig.codgensucursal = gs.codgensucursal " +
                    "INNER JOIN ep_estadocivil epec ON epec.codepestadocivil= epig.codepestadocivil " +
                    "INNER JOIN gen_tipoidentificacion gid ON gid.codgentipoidentificacion= epig.codgentipoidentificacion " +
                    "INNER JOIN gen_departamento gdep ON gdep.codgendepartamento = epig.codgendepartamento " +
                    "INNER JOIN gen_municipio gmun ON gmun.codgenmunicipio=epig.codgenmunicipio " +
                    "INNER JOIN gen_zona gz ON gz.codgenzona = epig.codgenzona INNER JOIN gen_area ga ON ga.codgenarea= epig.codgenarea " +
                    "INNER JOIN ep_tipoestado epes on epes.codeptipoestado= epig.codeptipoestado  WHERE epig.codepinformaciongeneralcif = '1'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampoIE(string tabla, string campo, string cif)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT epec.ep_estadocivilnombre, " +
                    "epif.ep_infofamiliarnombreconyuge, " +
                    "epif.ep_infofamiliarocupacionconyuge, " +
                    "epif.ep_infofamiliarapellidocascada," +
                    "DATE_FORMAT(epig.ep_informaciongeneralfechaboda, '%Y-%m-%d'), " +
                    "DATE_FORMAT(epif.ep_infofamiliarfechanacimientoconyuge, '%Y-%m-%d'), " +
                    "epif.ep_infofamiliarnombreemergencia, " +
                    "epif.ep_infofamiliarnumeroemergencia, " +
                    "epif.ep_infofamiliarparentesco " +
                    "FROM ep_infofamiliar epif " +
                    "INNER JOIN ep_informaciongeneral epig ON epig.codepinformaciongeneralcif = epif.codepinformaciongeneralcif " +
                    "INNER JOIN ep_estadocivil epec ON epec.codepestadocivil = epig.codepestadocivil " +
                    "WHERE epig.ep_informaciongeneralcif ='"+cif+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampoIO(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT epes.ep_estudionombre," +
                    " epes.ep_estudioduracion," +
                    " epes.ep_estudioaño," +
                    " epes.ep_estudioidioma," +
                    " epes.ep_estudiolugar " +
                    " FROM ep_estudio epes " +
                    "INNER JOIN ep_informaciongeneral epig ON epes.codepinformaciongeneralcif = epig.codepinformaciongeneralcif  " +
                    "  WHERE  epig.ep_informaciongeneralcif = '"+ valor + "' AND epes.ep_estudiotipo = 0 ;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampoIOs(string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "select codepinformaciongeneralcif from ep_informaciongeneral where ep_informaciongeneralcif='"+valor+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampoCaja(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_bactivoscaja from ep_bactivos where codepinformaciongeneralcif='"+valor+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampoInv(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "select ep_inventarionombre,ep_inventariomonto from ep_inventario where codepinformaciongeneralcif='"+valor+"';";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomaq(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "select  ep_maquinarianombre,ep_maquinariadescripcion,ep_maquinariamonto from ep_maquinaria where codepinformaciongeneralcif='"+valor+"';";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaje(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=1;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaje1(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=2";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaje2(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=3";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenajeTV(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=4;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenajeES(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=5;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenajeL(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=6;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaSec(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=7;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaEST(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=8;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaRefri(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=9;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaTel(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=10;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaOtros(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='"+valor+"' AND a.codeptipobien=11;";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaOD(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_deudasvariasdescripcion,ep_deudasvariasvalor from ep_deudasvarias where codepinformaciongeneralcif='"+valor+"';";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaPC(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "Select ep_pasivocontigenombre,ep_pasivocontigentedeudor,ep_pasivocontigentecondeudor,ep_pasivocontigentesaldo," +
                    "DATE_FORMAT(ep_pasivocontigentefechadesembolso, '%Y-%m-%d')," +
                    "DATE_FORMAT(ep_pasivocontigentefechafinalizacion, '%Y-%m-%d') FROM ep_pasivocontigente where codepinformaciongeneralcif='"+valor+"';";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaIng(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_ingresosueldo,ep_ingresobonificacion,ep_ingresocomisiones FROM ep_ingreso a INNER JOIN ep_controlingreso b ON a.codepcontrolingreso=b.codepcontrolingreso WHERE b.codepinformaciongeneralcif='"+valor+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaNeg(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "" +
                    "SELECT ep_negociotipo,ep_negocionombre," +
                    "ep_negociopatente,ep_negocioempleados," +
                    "ep_negocioobjeto,ep_negocioingresos," +
                    "ep_negocioegresos,ep_negociodireccion " +
                    "FROM ep_negocio a INNER JOIN ep_controlingreso b ON a.codepcontrolingreso=b.codepcontrolingreso " +
                    "WHERE b.codepinformaciongeneralcif='"+valor+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaRem(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT ep_remesasnombre," +
                    "ep_remesasrelacion," +
                    "ep_remesasmonto," +
                    "DATE_FORMAT(ep_remesasperiodo, '%Y-%m-%d') " +
                    "FROM ep_remesas a " +
                    "INNER JOIN ep_controlingreso b ON a.codepcontrolingreso=b.codepcontrolingreso " +
                    "WHERE b.codepinformaciongeneralcif='"+valor+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public MySqlDataReader consultarconcampomenaEgres(string tabla, string campo, string valor)
        {
            try
            {
                cn.conectar();
                string consultaGraAsis = "SELECT * from ep_egresos where codinformaciongeneralcif='"+valor+"'";
                comm = new MySqlCommand(consultaGraAsis, cn.conectar());
                MySqlDataReader mostrarResultados = comm.ExecuteReader();
                return mostrarResultados;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //public string eliminarregistro(string tabla, string campo,string dato)
        //{
        //    String camporesultante = "";
        //    try
        //    {
        //        string sql = "DELETE FROM '"+tabla+"' WHERE '"+campo+"'='"+dato+"' ;"; //SELECT MAX(idFuncion) FROM `funciones`     
        //        MySqlCommand command = new MySqlCommand(sql, cn.conectar());
        //        MySqlDataReader reader = command.ExecuteReader();
        //        reader.Read();
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine(camporesultante);
        //    }
        //    finally { cn.desconectar(); }
        //    return camporesultante;
        //}

        public void eliminarregistro(string tabla, string campo, string dato)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "DELETE FROM " + tabla + " WHERE " + campo + " = " + dato + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                    comm = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader mostrarResultados = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        //-----------------------------------------------------------------------RESTRUCTURADOS--------------------------------------------------------------//
        public string[] validarcifantiguo(string usuario)
        {
            string[] Campos = new string[30];
            int i = 0;
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
               
                try
                {
                    string consulta = "SELECT a.codepinformaciongeneralcif,a.codepadministracionlote,c.ep_administracionlotefechainicio " +
                   "FROM ep_control  a " +
                   "INNER JOIN gen_usuario b " +
                   "INNER JOIN ep_administracionlote c " +
                   "ON a.codgenusuario=b.codgenusuario AND a.codepadministracionlote=c.codepadministracionlote WHERE  b.gen_usuarionombre='" + usuario + "' ORDER BY c.ep_administracionlotefechainicio DESC limit 1,1;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                           
            }
            return Campos;// devuelve un arrgeglo con los campos  
        }


        public string[] consultarconcampo(string tabla, string campo, string dato)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    //"SELECT * FROM " + tabla + " where" + campo + "='" + dato + "';"
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM "+tabla+" where "+campo+"='"+dato+"'", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -" + tabla); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultarcif(string nombre1, string nombre2, string apellido1)//metodo que obtiene la lista de los campos que requiere una tabla
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[300];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_informaciongeneralcif from ep_informaciongeneral" +
                        " where ep_informaciongeneralprimernombre='"+ nombre1 + "'" +
                        " and ep_informaciongeneralsegundonombre='"+ nombre2 + "' " +
                        "and ep_informaciongeneralprimerapellido='"+ apellido1 + "'";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }

        public string[] consultarinformaciong( string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[300];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select t1.gen_sucursalnombre,t2.ep_estadocivilnombre,t3.gen_tipoidentificacionnombre," +
                        "t4.gen_departamentonombre,t5.gen_municipionombre,t6.gen_zonanombre,t7.gen_areanombre,t0.codeptipoestado," +
                        "t0.ep_informaciongeneralprimernombre,t0.ep_informaciongeneralprimerapellido,t0.ep_informaciongeneralsegundoapellido," +
                        "t0.ep_informaciongeneralnombreadicional,DATE_FORMAT(t0.ep_informaciongeneralfechanacimiento, '%Y-%m-%d'),t0.ep_informaciongeneralnumeroidentificacion," +
                        "t0.ep_informaciongeneralnacionalidad,t0.ep_informaciongeneraldireccion,t0.ep_informaciongeneralestatura,t0.ep_informaciongeneralpeso," +
                        "t0.ep_informaciongeneralreligion,t0.ep_informaciongeneralcorreo,t0.ep_informaciongeneralfechaboda, t0.ep_informaciongeneralnit,t8.gen_puestosnombre,t0.ep_informaciongeneralsegundonombre " +
                        "from ep_informaciongeneral t0 " +
                        "inner join gen_sucursal t1 on t0.codgensucursal = t1.codgensucursal " +
                        "inner join ep_estadocivil t2 on t0.codepestadocivil = t2.codepestadocivil " +
                        "inner join gen_tipoidentificacion t3 on t0.codgentipoidentificacion = t3.codgentipoidentificacion " +
                        "inner join gen_departamento t4 on t0.codgendepartamento = t4.codgendepartamento " +
                        "inner join gen_municipio t5 on t0.codgenmunicipio = t5.codgenmunicipio " +
                        "inner join gen_zona t6 on t0.codgenzona = t6.codgenzona " +
                        "inner join gen_area t7 on t0.codgenarea = t7.codgenarea " +
                        "inner join gen_puestos t8 on t0.codgenpuesto = t8.codgenpuestos " +
                        "where t0.ep_informaciongeneralcif='"+cif+"'";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }

        public string[] fechaactual()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand("SELECT CURDATE();", sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos               
            }

        }
        public string[] validarfechadeingreso_ep()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[3000];
                int i = 0;
                List<string> miLista = new List<string>();
                try
                {
                    string consulta = "SELECT gen_usuarionombre,ep_administracionlotefechainicio,ep_administracionfechafin,a.codepadministracionlote,ep_administracionloteestado " +
                                        "FROM ep_control a " +
                                            "INNER JOIN gen_usuario b " +
                                                "INNER JOIN ep_administracionlote c " +
                                                       "ON a.codgenusuario = b.codgenusuario AND a.codepadministracionlote = c.codepadministracionlote WHERE ep_administracionloteestado = 1;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            miLista.Add(reader.GetString(p));
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                Campos = miLista.ToArray();
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] busquedacif(string usuario, string lote)
        {
            string[] Campos = new string[30];
            int i = 0;
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
               
                try
                {
                    sqlCon.Open();
                    string consulta = "SELECT codepinformaciongeneralcif,gen_usuarionombre " +
                 "FROM ep_control a " +
                    "INNER JOIN gen_usuario b " +
                  "ON a.codgenusuario = b.codgenusuario AND codepadministracionlote= '" + lote + "' where  b.gen_usuarionombre ='" + usuario + "';";         
                    MySqlCommand command = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                     
            }
            return Campos;// devuelve un arrgeglo con los campos      
        }
        public string[] estadodeprocesocif(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consulta = "SELECT codeptipoestado FROM ep_informaciongeneral WHERE codepinformaciongeneralcif = '" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }
        public string[] consultarRol(string usuario)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[300];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT gen_roles_codgenroles FROM gen_usuario WHERE gen_usuarionombre= '" + usuario + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos               
            }
        }

        public string[] consultarArea(string usuario)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[300];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT gen_area_codgenarea FROM bdkbguadalupana.gen_usuario WHERE gen_usuarionombre = '" + usuario + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarcamposgeneral(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT epig.ep_informaciongeneralcif,gs.codgensucursal,ga.codgenarea, epig.codgenpuesto, epig.ep_informaciongeneralprimerapellido, epig.ep_informaciongeneralsegundoapellido, epig.ep_informaciongeneralprimernombre, epig.ep_informaciongeneralsegundonombre, epig.ep_informaciongeneralnombreadicional,gdep.codgendepartamento, gmun.codgenmunicipio, gz.codgenzona,epig.ep_informaciongeneraldireccion, gid.codgentipoidentificacion,epig.ep_informaciongeneralnumeroidentificacion,epig.ep_informaciongeneralfechanacimiento, epig.ep_informaciongeneralnit, epig.ep_informaciongeneralnacionalidad, epig.ep_informaciongeneralcorreo, epig.ep_informaciongeneralestatura, epig.ep_informaciongeneralpeso, epig.ep_informaciongeneralreligion FROM ep_informaciongeneral epig INNER JOIN gen_sucursal gs ON epig.codgensucursal = gs.codgensucursal INNER JOIN ep_estadocivil epec ON epec.codepestadocivil= epig.codepestadocivil INNER JOIN gen_tipoidentificacion gid ON gid.codgentipoidentificacion= epig.codgentipoidentificacion INNER JOIN gen_departamento gdep ON gdep.codgendepartamento = epig.codgendepartamento INNER JOIN gen_municipio gmun ON gmun.codgenmunicipio=epig.codgenmunicipio INNER JOIN gen_zona gz ON gz.codgenzona = epig.codgenzona INNER JOIN gen_area ga ON ga.codgenarea= epig.codgenarea INNER JOIN ep_tipoestado epes on epes.codeptipoestado= epig.codeptipoestado  WHERE epig.codepinformaciongeneralcif = '" + cif + "'";

                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarcamposgeneralfam(string cif)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT epec.codepestadocivil, epif.ep_infofamiliarnombreconyuge, epif.ep_infofamiliarocupacionconyuge, epif.ep_infofamiliarapellidocascada,epig.ep_informaciongeneralfechaboda , epif.ep_infofamiliarfechanacimientoconyuge, epif.ep_infofamiliarnombreemergencia, epif.ep_infofamiliarnumeroemergencia, epif.ep_infofamiliarparentesco FROM ep_infofamiliar epif INNER JOIN ep_informaciongeneral epig ON epig.codepinformaciongeneralcif = epif.codepinformaciongeneralcif INNER JOIN ep_estadocivil epec ON epec.codepestadocivil = epig.codepestadocivil WHERE epig.codepinformaciongeneralcif ='" + cif + "' ;";

                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarestudios(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT epes.ep_estudionombre, epes.ep_estudioduracion, epes.ep_estudioaño, epes.ep_estudioidioma, epes.ep_estudiolugar  FROM ep_estudio epes INNER JOIN ep_informaciongeneral epig ON epes.codepinformaciongeneralcif = epig.codepinformaciongeneralcif    WHERE  epes.codepinformaciongeneralcif = '" + cif + "' AND epes.ep_estudiotipo = 0 ;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarcaja(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_bactivoscaja from ep_bactivos where codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarinventario(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select ep_inventarionombre,ep_inventariomonto from ep_inventario where codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmaquinaria(string cif)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "select  ep_maquinarianombre,ep_maquinariadescripcion,ep_maquinariamonto from ep_maquinaria where codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarcontratistaproveedor(string cif)
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_contratistaproveedor_si_no from ep_contratistaproveedor where codepcontratistaproveedor='"+cif+"';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarinversion(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_inversionesnombreinstitucion,ep_inversionesnombre,ep_inversionesplazo,codeptipomoneda,ep_inversionesmonto from ep_inversiones where codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje1(string cif)
        {
             using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=1;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje2(string cif)
        {          
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=2;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje3(string cif)
        {
           using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=3;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje4(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=4;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje5(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=5;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje6(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=6;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje7(string cif)
        {
           using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=7;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }

        }
        public string[] mostrarmenaje8(string cif)
        {
           using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=8;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje9(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=9;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje10(string cif)
        {         
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=10;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarmenaje11(string cif)
        {         
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_menajecasadetallecantidad,ep_menajecasadetallevalor from ep_menajecasadetalle a INNER JOIN ep_menajedecasaencabezado b ON a.codmenajedecasaencabezado=b.codepmenajedecasaencabezado WHERE b.codepinformaciongeneralcif='" + cif + "' AND a.codeptipobien=11;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrardeudas(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_deudasvariasdescripcion,ep_deudasvariasvalor from ep_deudasvarias where codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarpasivocontigente(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "Select ep_pasivocontigenombre,ep_pasivocontigentedeudor,ep_pasivocontigentecondeudor,ep_pasivocontigentesaldo,ep_pasivocontigentefechadesembolso,ep_pasivocontigentefechafinalizacion FROM ep_pasivocontigente where codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostraringresos(string cif)
        {
           using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_ingresosueldo,ep_ingresobonificacion,ep_ingresocomisiones  FROM ep_ingreso a INNER JOIN ep_controlingreso b ON a.codepcontrolingreso=b.codepcontrolingreso WHERE b.codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarnegocios(string cif)
        {
           using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_negociotipo,ep_negocionombre,ep_negociopatente,ep_negocioempleados,ep_negocioobjeto,ep_negocioingresos,ep_negocioegresos,ep_negociodireccion FROM ep_negocio a INNER JOIN ep_controlingreso b  ON a.codepcontrolingreso=b.codepcontrolingreso WHERE b.codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarremesas(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_remesasnombre,ep_remesasrelacion,ep_remesasmonto,ep_remesasperiodo FROM ep_remesas a INNER JOIN ep_controlingreso b  ON a.codepcontrolingreso=b.codepcontrolingreso WHERE b.codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostraregresos(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT * from ep_egresos where codinformaciongeneralcif='" + cif + "'";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarexpuestapep(string cif)
        {
             using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT ep_personapepnombreinstitucion,ep_personapeppuesto,ep_personapeppais FROM ep_personapep where codeptipopep=1 AND codepinformaciongeneralcif='" + cif + "';";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarparentescopep(string cif)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codeptiponacionalidad,codeptipoparentesco,ep_personapepnombre,ep_personapepnombreinstitucion,ep_personapeppuesto,ep_personapeppais FROM ep_personapep where codeptipopep=2 AND codepinformaciongeneralcif='" + cif + "' ;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string[] mostrarasociadocopep(string cif)
        {
           
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string[] Campos = new string[30];
                int i = 0;
                try
                {
                    string consultaGraAsis = "SELECT codeptiponacionalidad,codeptipoparentesco,ep_personapepmotivo,ep_personapepnombre,ep_personapepnombreinstitucion,ep_personapeppuesto,ep_personapeppais FROM ep_personapep where codeptipopep=3 AND codepinformaciongeneralcif='" + cif + "' ;";
                    sqlCon.Open();
                    MySqlCommand command = new MySqlCommand(consultaGraAsis, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int p = 0; p < reader.FieldCount; p++)
                        {
                            Campos[i] = reader.GetString(p);
                            i++;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nERROR EN CONSULTA\n -"); }
                return Campos;// devuelve un arrgeglo con los campos 
            }
        }
        public string obtenerfinal(string tabla, string campo)
        {
            String camporesultante = "";
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlCon.Open();
                    string sql = "SELECT MAX(" + campo + "+1) FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                    MySqlCommand command = new MySqlCommand(sql, sqlCon);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    camporesultante = reader.GetValue(0).ToString();
                    //Console.WriteLine("El resultado es: " + camporesultante);
                    if (String.IsNullOrEmpty(camporesultante))
                        camporesultante = "1";
                }
                catch (Exception)
                {
                    Console.WriteLine(camporesultante);
                }
                return camporesultante;
            }


        }
        public void insertartablas(string tabla, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string query = "";
                for (int i = 0; i < datos.Length; i++)
                {
                    query += "'";
                    query += datos[i];
                    if (i == datos.Length - 1)
                        query += "'";
                    else
                        query += "',";
                }
                try
                {
                    sqlCon.Open();
                    string consulta = "insert into " + tabla + " values(" + query + ");";
                    Console.WriteLine(consulta);
                    comm = new MySqlCommand(consulta,sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                }
            }
        }
        public void modificartablas(string tabla, string[] campos, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string query = "";
                int n = 1;
                query += " set ";
                for (int i = 1; i < datos.Length; i++)
                {
                    query += campos[n];
                    query += " = '";
                    query += datos[i];
                    if (i == datos.Length - 1)
                        query += "'";
                    else
                        query += "',";
                    n++;
                }

                try
                {
                    sqlCon.Open();
                    string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "';";
                    comm = new MySqlCommand(consulta, sqlCon);
                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
        public void modificartablasdoscampos(string tabla, string[] campos, string[] datos)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                string query = "";
                int n = 2;
                query += " set ";
                for (int i = 2; i < datos.Length; i++)
                {
                    query += campos[n];
                    query += " = '";
                    query += datos[i];
                    if (i == datos.Length - 1)
                        query += "'";
                    else
                        query += "',";
                    n++;
                }

                try
                {
                    sqlCon.Open();
                    string consulta = "UPDATE " + tabla + query + " where " + campos[0] + " = '" + datos[0] + "' AND " + campos[1] + " = '" + datos[1] + "';";
                    comm = new MySqlCommand(consulta, sqlCon);

                    MySqlDataReader mostrar = comm.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }


    }

}