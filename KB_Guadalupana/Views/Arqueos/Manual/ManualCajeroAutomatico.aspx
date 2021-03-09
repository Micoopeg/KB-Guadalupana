﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManualCajeroAutomatico.aspx.cs" Inherits="KB_Guadalupana.Views.Arqueos.Manual.ManualCajeroAutomatico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Manual Usuario</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="../../DiseñoCss/StyleCss.css" type="text/css" />
</head>
    <style>
.tarjeta 
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 3fr;
  grid-template-rows: 1fr;
}
.tarjeta1 
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-template-rows: 1fr;
}
.tarjeta2 
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 3fr;
  grid-template-rows: 1fr;
}
.tarjeta3
{
  width: 80%;
  min-height: 300px;
  background-color: white;
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-template-rows: 1fr;
}

.foto 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 275px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto1 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 275px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto2 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 490px;
    height: 240px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto3
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 210px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.foto4 
{
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
    padding: 13px;
    width: 505px;
    height: 200px;
    background-size: 100% 100%;
    background-repeat: no-repeat;
}
.frase {
  font-family: sans-serif;
  font-size: 2em;
  color: #77ce97;
}

.frase p {
  margin-bottom: 20px;
}

.boton {
  grid-column: 1 / 2;
  grid-row: 1 / 2;
  text-decoration: none;
  font-family: sans-serif;
  font-size: .6em;
  padding: 10px;
  color: #fff;
  background-color: #77ce97;
  border-radius: 5%;
}

.texto {
    justify-content: center;
    align-items: center;
    padding: 4em;
    color: #333;
    text-align: center;
    font-size: 15px;
}
}

@media (max-width: 700px) {
  .tarjeta {
    grid-template-columns: 1fr;
    grid-template-rows: 2fr 3fr;
  }
  .foto {
    grid-column: 1 / 2;
    grid-row: 1 / 2;
    padding: 2em;
  }
  .texto {
    grid-column: 1 / 2;
    grid-row: 2 / 3;
    padding: 2em;
  }
  
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

header {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin: 50px auto;
  width: 100%;
}

#contenedor-logo {
  border-right: 3px solid black;
  margin-right: 10px;
  padding-right: 20px;
  text-align: right;
}

#logo-ntln{  
  border-radius: 50%;
  max-width: 100px;
  height: auto;  
}

#contenedor-texto {
  display:flex;
  flex-direction: column;
  height:100px;
  justify-content: space-around;
  padding-left: 10px;
}

#contenedor-texto h1 {
  font-family: 'BenchNine', sans-serif;
  font-size: 3em;
  text-transform: capitalize;
}

#contenedor-texto p {
  font-family: 'BenchNine', sans-serif;
  font-size: 1.5em;
}

#contenedor-texto i{
  padding: 5px;
}

main {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}

.descripcion {
  align-self: flex-end;
  color: #6d5f5e;
  font-family: 'Indie Flower';
  font-size: 1.5em;
  margin-left: 50px;
  padding-bottom: 20px;
}

.descripcion li {
  list-style: none;
}

.descripcion li::before {
  content: "- ";
}

.sombra{
  box-shadow: 0 1px 4px 0 rgba(0,0,0,.14);
}

body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
}

.topnav {
  overflow: hidden;
  background-color: #333;
}

.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #ddd;
  color: black;
}

.topnav a.active {
  background-color: #4CAF50;
  color: white;
}
        
.topnav {
  overflow: hidden;
  background-color: #003563;
}

.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 15px 35px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #B80416;;
  color: White;
}

.topnav a.active {
  background-color: #69a43c;
  color: white;
}
        
</style>

<body>
     <form id="form1" runat="server">
       
    <div class="topnav">
            <a class="active" href="../ArqueoCajeroAutomatico.aspx">Regresar</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b >Manual De Usuario Arqueo Cajero Automático</b></span>
            <a href="../CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
    <br>
    <br>
    <main>
        
<section class="tarjeta">
    <div>
        <img class="foto" src="../../../Imagenes/Imagenes_arqueos/Opciones_arqueos.PNG">
      <div class="frase">
      </div>
    </div>
    <p class="texto" >Al ingresar a la opción de <b style="color:#003563">Arqueos</b> <i class="fa fa-sign-in" ></i> Arqueo Cajero Automatico, se podra visualizar 2 opciones de:
        <br>
        <br>
        <b>1. Crear Nuevo Arqueo</b>
        <br>
        <b>2. Buscar Arqueo</b></p>
</section>
        
        
<section class="tarjeta1">
        <p class="texto" style="text-align: justify">Al ingresar a la opción de Crear Nuevo Arqueo, se podrá visualizar el formato de arqueo de cajero automático. Se debe llenar el encabezado</p>
       
    <div class="frase">
      <div >
            <img class="foto1" src="../../../Imagenes/Imagenes_arqueos/Encabezado_CajeroAut.PNG">
      </div>
    </div>
</section>
        
        
<section class="tarjeta2">
    <div>
         <img class="foto2" src="../../../Imagenes/Imagenes_arqueos/Detalle_CajeroAut.PNG">
      <div class="frase">
      </div>
    </div>
    <p class="texto" style="text-align: justify">Se prosigue con el llenado de las cantidades de billetes y monedas, el efectivo según reportes y observaciones.</p>
  </section>


        <section class="tarjeta1">
        <p class="texto" style="text-align: justify">Guardar el arqueo</p>
       
    <div class="frase">
      <div >
            <img class="foto1" src="../../../Imagenes/Imagenes_arqueos/guardar.PNG">
      </div>
    </div>
</section>

  <section class="tarjeta2">
    <div>
         <img class="foto2" src="../../../Imagenes/Imagenes_arqueos/Buscar_arqueo.PNG">
      <div class="frase">
      </div>
    </div>
    <p class="texto" style="text-align: justify">Al ingresar a la opción de Buscar Arqueo, debe ingresar la fecha y el número de arqueo que desea consultar. Si es el caso, también debe seleccionar el usuario de quien hizo el arqueo.</p>
  </section>

                <section class="tarjeta1">
        <p class="texto" style="text-align: justify">Para imprimir el documento, como primer paso se debe seleccionar la opción de "Visualizar" y luego seleccionar la opción de "Guardar/Imprimir"</p>
       
    <div class="frase">
      <div >
            <img class="foto4" src="../../../Imagenes/Imagenes_arqueos/imprimir.PNG">
      </div>
    </div>
</section>
        
</main>
    
</form>
</body>
</html>
