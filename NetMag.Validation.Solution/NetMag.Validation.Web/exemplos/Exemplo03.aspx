<%@ Page Title="" Language="C#" MasterPageFile="~/library/Interna.Master" AutoEventWireup="true" CodeBehind="Exemplo03.aspx.cs" Inherits="NetMag.Validation.Web.exemplos.Exemplo03" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Validação de acesso a inscrição (via WCF)</h1>
    <h2>Dados do funcionário</h2>
    <br />
    <div class="alertValidation" id="divAlerta" runat="server" visible="false">
        <asp:Label ID="lblMensagemValidacao" runat="server"></asp:Label>
    </div>
    <br />
    <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label><br />
    <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="lblLogin" runat="server" Text="Nome"></asp:Label><br />
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnValidarAcesso" runat="server" Text="Validar acesso" 
        onclick="btnValidarAcesso_Click" Width="144px" />
</asp:Content>
