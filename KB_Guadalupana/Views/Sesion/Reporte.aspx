﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consultar Reporte</title>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
     <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
<style>
     .tabla{
            width:100%;
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
     }
     .mGrid{
        width:100%;
     }
    table th{
           background-color:#0076DE;
           color: white;
           padding: 2px;
           font-size:15px;
           justify-content: center;
    }
    table td{
       border: 0.3px solid black;
    }
    table {
        margin: 0px 15px;
        border-collapse: collapse;
    }
      .etiquetas{
            font-size: 15px;
            justify-content: flex-start;
            display: flex;
            justify-content:center;
            margin: 3px;
            padding: 5px;
            width: 50%;
      }
      .general{
          display:flex;
          justify-content:center;
          flex-direction: column;
          padding: 20px;
      }
      .opcion{
          color:black;

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

.button {
  border: none;
  color: white;
  padding: 4px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  transition-duration: 0.4s;
  cursor: pointer;
}

.button1 {
  background-color: white; 
  color: black; 
  border: 2px solid #69a43c;
}

.button1:hover {
  background-color: #69a43c;
  color: white;
}

 .fa-check-circle::before 
 {
  font-family: "FontAwesome", sans-serif;
  content: "\f0a5";
  font-size: 17px;
  color: #003563;
  text-decoration: none;
}


</style>
</head>

<body>
    <center><img class="sobre" src="../../../Imagenes/barra.png"/></center>
    <form id="form1" runat="server">
          <div class="topnav">
            <a class="active" href="Inicio.aspx">Inicio</a>
            <span class="nav-text" style="position: absolute;font-size: 25px;MARGIN: 0.6%;left: 37%;color: white; height: 20px;"><b>Reporte Estado Patrimonial Usuarios</b></span>
            <a href="CerrarSesion.aspx" style="right: 0%;position: absolute;">Cerrar Sesion</a>
    </div>
        <br />
        <br />
        <div class="general">
            <div style="display:flex; align-content:center;align-items:center; justify-content:center; flex-direction:row">
                <input type="number" runat="server"  id="RCif" style="font-size: 20px;width: 10%;border:0;" placeholder="CIF" runat="server" class="etiquetas" readonly="readonly"/>
                <asp:Button ID="Button1" runat="server" CssClass="button button1" OnClick="iniciarsesion_Click" Text="Buscar" />
                <input id="Text6" visible="false" runat="server" style="width: 20.0%;" type="text" class="tampe"  readonly="readonly" />
            </div><br />

            
              <div class="tabla">
     <asp:GridView ID="GridViewReporte" CssClass="mGrid" style="width: 950px;text-align:center;text-decoration: none;Color: black;" runat="server"  HeaderStyle-ForeColor="White"
    AutoGenerateColumns="False"  OnSelectedIndexChanged = "OnSelectedIndexChangedReporte" BorderStyle="Solid">
                     <Columns>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="Nombre">
                           <ItemTemplate>
                           <asp:Label ID="lblnombre" Text='<%# Eval("gen_usuarionombre") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField ControlStyle-CssClass="diseño"  HeaderText="ID Usuario">
                           <ItemTemplate>
                           <asp:Label ID="lblcif" Text='<%# Eval("codepinformaciongeneralcif") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:ButtonField ItemStyle-Font-Underline="false" ItemStyle-CssClass="fa-check-circle"  Text="Seleccionar" CommandName="Select" ItemStyle-Width="150" >
                            <ItemStyle Width="120px"></ItemStyle>
                         </asp:ButtonField>
                     </Columns>
     <HeaderStyle CssClass="prueba"  ForeColor="White"></HeaderStyle>
        </asp:GridView>
            </div>
        </div>
    </form>
</body>

</html>
