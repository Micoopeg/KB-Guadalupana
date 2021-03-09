﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoRoles.aspx.cs" Inherits="KB_Guadalupana.Views.Sesion.MantenimientoRoles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <title>Roles</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link rel="stylesheet" href="../../DiseñoForms/style.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
       <style>  
        .responsive 
        {
            max-width: 100%;
            height: auto;
        }

        body {
           display: flex;
            justify-content: center;
            justify-items: center;
            align-items: center;
            align-content:center;
            width: 100%;
            height: 100%;
            flex-direction: column;
          font-family: Arial, Helvetica, sans-serif;
          padding-top:25px;

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

        .tampe {
            margin: 4px;
            padding: 6px;
            border: 1px lightgray solid;
            width: 100px;
        }

        .tamp {
            margin: 0px;
            padding: 6px;
            border: 1px lightgray solid;
            width: 200px;
            margin: 5px;
        }

        .tam {
            margin-right: 10px;
            padding: 6px;
            border: 1px lightgray solid;
            width: 100px;
           margin: 5px;
           color: white;
           background-color: #003A6E;
        }
        
      
        .mantenimientos {
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-content: center;
            align-items:center;
            margin-top: 50px;
            /*padding: 15px;*/
            /*position: absolute;*/
            left: 24%;
            /*margin-left: 400px;*/
            height: 100px;
            width: 700px;
            /*position: absolute;*/
        }

        .mantenimientos a {
          display: flex;
          flex-direction: row;
          justify-content: center;
          align-content: center;
          align-items:center;
          background-color: #0066BF; /* Green background */
          border: 0px; /* Green border */
          color: white; /* White text */
          padding: 5px; /* Some padding */
          cursor: pointer; /* Pointer/hand icon */
          float: left; /* Float the buttons side by side */
          padding: 5px;
          margin: 1px;
          width: 110px;
          height: 30px;
          font-family: 'Montserrat';
          font-size: 10px;
        }


        h2.fs-title {
            justify-content: center;
            align-items: center;
            display: flex;
        }

       .tabla {
           border-collapse:collapse;
           align-items: center;
           align-content: center;
           justify-content:center;
       }

       .tabla th {
           align-items: center;
           justify-content:center;
           border: 0.5px solid black;
           align-content:center;
           padding: 5px;
       }

       .tabla tr {
           align-items: center;
           justify-content:center;
           border: 0.5px solid black;
           align-content:center;
           padding: 5px;
       }

       .tabla td {
           align-items: center;
           justify-content:center;
           border: 0.5px solid black;
           align-content:center;
           padding: 5px;
       }

        /*.formulario {
            -webkit-box-shadow: 1px 0px 15px 5px rgba(0,0,0,0.81); 
            box-shadow: 1px 0px 15px 5px rgba(0,0,0,0.81);
            width:auto;
            height:auto;
            padding:20px;
            display: flex;
            flex-direction: column;
            overflow:auto;
            margin-bottom:20px;
        }*/

           .encabezado {
               flex-direction: row;
               display: flex;
               justify-content: space-between;
               padding-top: 10px;
           }

           .buscar {
               flex-direction: row;
               display: flex;
               justify-content: center;
               margin: 5px;
           }
        .btnprueba{

        }
  
</style>
</head>
<body>
     <div class="menu"></div>
        <div class="mantenimientos">
          <a href="MantenimientoAreas.aspx" class="active">Áreas</a>
          <a href="MantenimientoRoles.aspx"  id="MantenimientoMoneda">Roles</a>
          <a href="AsignacionRolArea.aspx">Asignación</a>
        </div>

 <form id="form1" runat="server">
 <div >
     <div class="encabezado">
         <h2 class="fs-title">
            <b>Registro Tipo Roles</b>
        </h2>
        <img src="../../Imagenes/Logotipo-Guadalupana1.png" style="width: 180px; height: 120px; top: 0; margin-left: 0px;" />
     </div>

  <input id="RVCodigo" disabled="disabled" readonly="readonly" runat="server" type="text" class="tam" style="width:10%;" required/>
  <div class="buscar">
    <asp:TextBox ID="TextBox1" placeholder="Ingrese nombre de rol" runat="server" CssClass="tamp"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" CssClass="tam" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ver todos" CssClass="tam" />
  </div>
        <br />
            <asp:GridView ID="gvPhoneBook" CssClass="tabla" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="codgenroles"
                ShowHeaderWhenEmpty="true"
                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="496px">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066"/>
                <HeaderStyle BackColor="#0071D4" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:Label  Text='<%# Eval("codgenroles") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("codgenroles") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter" placeholder="Ingrese código" runat="server" />
                           <%-- <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server"/>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rol">
                  <ItemTemplate>
                            <asp:Label Text='<%# Eval("gen_rolesnombre") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("gen_rolesnombre") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" placeholder="Ingrese rol" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="../../Imagenes/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="../../Imagenes/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="../../Imagenes/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
     <br />
     <br />
     
  </div>
      </form>

</body>
   <script>
       $(document).ready(function () {
           $('.menu').load('MenuBarra.aspx');
       });

       function MantenimientoMoneda() {
           document.getElementById('MantenimientoMoneda').click();
       }

       function agregarRegistro() {
           document.getElementById('agregarRegistro').click();
       }


   </script>
</html>

