﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex_VistaMensajeria.aspx.cs" Inherits="KB_Guadalupana.Views.ControlEX.Ex_VistaMensajeria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mensajería</title>
 <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.2/animate.css'><link rel="stylesheet" href="../../EXDiseños/EstilosMensajeria.css">
	    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css'/><link rel="stylesheet" href="../../EXDiseños/stylebarra.css"/>
   <link rel="stylesheet" type="text/css" href="../../EXDiseños/ExtiloExEnvio.css" />
     <link type="text/css" rel="stylesheet" href="../../EXDiseños/estilolector.css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
            <center>   <header class="encabezado">
	<div class="menu-bar">
		<div class="three col">
			<div class="hamburger" id="hamburger-pro">
				<span class="line"></span>
				<span class="line"></span>
				<span class="line"></span>
			</div>
		</div>

		<a href="javascript:void(0);" class="links" class="bt-menu">
			<span class="span fa fa-list"></span>
		</a>
	</div>  

	<nav class="nav">
		<ul class="ul">
			<li class="li">
				<a id="inicio" runat="server" href="javascript:void(0);" onclick="redirigir()" class="links">
					<span class="span fa fa-home"></span>Inicio
				</a>


			</li>

		<li class="li">
				<a href="javascript:void(0);" onclick="redirigir2()" class="links">
					<span class="span fa fa-user"></span>Cerrar Sesion
				</a>
			</li>
		</ul>
	</nav>
</header></center>
        <div class="center">
<div id="form-main">
  <div id="form-div">
    <form class="form" id="form1">
      
      <p class="name">
          <span id="span1" runat="server" style="font-size:15px; color:white; " >Número de Lote Entrada: </span>  <asp:TextBox ID="name" name="name"  onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox>

      
      </p>
     <p class="name">
          <span id="span2" runat="server" style="font-size:15px; color:white; " >Número de Lote Salida : </span>  <asp:TextBox ID="txtname" name="name"  onkeypress="return numeros(event);"  runat="server"  Width="20%" > </asp:TextBox>

      
      </p>
    <br />

     
    
      
      <div class="submit">
        
          <asp:LinkButton Text="Validar Lote" ID="buttoblue" runat="server" OnClick="envio_Click"   > </asp:LinkButton>

        <div class="ease"></div>
      </div>
    
    </form>
  </div>
</div>
            </div>

          <asp:LinkButton ID="btninicio" runat="server" OnClick="btninicio_click" ClientIDMode="Static"></asp:LinkButton>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btncerrar" ClientIDMode="Static"></asp:LinkButton>
    </form>
        <script type="text/javascript">

           function redirigir() {

               document.getElementById('btninicio').click();

           }
           function redirigir2() {

               document.getElementById('LinkButton1').click();

           }
           function redirigir3() {

               document.getElementById('LinkButton3').click();

           }
           function redirigir4() {

               document.getElementById('LinkButton4').click();

           }
           function redirigir5() {

               document.getElementById('LinkButton5').click();

           }
           function redirigir6() {

               document.getElementById('LinkButton6').click();

           }
           function redirigir7() {

               document.getElementById('LinkButton7').click();

           }

        </script>
    <script type="text/javascript" src="../../EXDiseños/scriptvalidar.js" >  </script>
</body>
</html>
