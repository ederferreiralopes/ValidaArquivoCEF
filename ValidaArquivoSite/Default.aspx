<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ValidaArquivoSite.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/javascript.js"></script>  
</head>
<body>
    <input id="mostrar" type="submit" value="Mostrar Oculto" onclick="mostrarOculto()"/>
    <input id="oculto" type="hidden" value="Eu Estava Oculto" />	
    <form id="form1" runat="server">
            <a href="UrlAmigavel.aspx"> 
                 <img alt="logo" src="images/logo.jpg" />
            </a>
            <div class="Controles"><h4>&nbsp;VALIDADOR ARQUIVO CEF SIACC 240</h4> 
                &nbsp;<asp:Label ID="Statuslbl" runat="server" Text="" />
                <br />
                <asp:RadioButton ID="rb_Remessa" GroupName="tipoArquivo" runat="server" Text="Remessa" OnCheckedChanged="rb_Remessa_CheckedChanged"  AutoPostBack="true" />
                <asp:RadioButton ID="rb_Retorno" GroupName="tipoArquivo" runat="server" Text="Retorno" OnCheckedChanged="rb_Retorno_CheckedChanged" AutoPostBack="true" />
                &nbsp;
                <asp:FileUpload ID="fileUp" runat="server" />
                &nbsp;
                <asp:Button ID="bt_Validar" runat="server" OnClick="button1_Click" text="Validar" Height="23px" OnClientClick="localStorage.removeItem('textoOriginal'), mostrarOculto();"/>
                &nbsp;&nbsp;
                <asp:Button ID="bt_Limpar" runat="server" Height="23px" OnClick="bt_Limpar_Click" Text="Limpar" />
                &nbsp;&nbsp;
                <asp:Button ID="bt_exportaPdf" runat="server" Height="23px" OnClick="bt_exportaPdf_Click" Text="Gerar PDF" />
                &nbsp;&nbsp;
                <input class="Visibilidade" id="busca" type="text" value="Digite aqui" size="12" />
                <input class="Visibilidade" id="bt_busca" type="button" onclick="doDestacaTexto(document.getElementById('busca').value, log_TextoValidacao.innerHTML)" value="Destacar" />
                <br />
            </div>
            <div class="Coluna">
            </div>
       <div class="TextoValidacao">
            <p id="log_TextoValidacao"><asp:Literal ID="lt_LogValidacao" runat="server"></asp:Literal></p>
       </div>
    </form>
</body>
</html>
