<%@ Page Title="" Language="C#" MasterPageFile="~/library/Interna.Master" AutoEventWireup="true" CodeBehind="FichaInscricao01.aspx.cs" Inherits="NetMag.Validation.Web.exemplos.FichaInscricao01" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
             
    <h1>Ficha de inscrição</h1>
    <h2>Dados do participante</h2>
    <br />
    <asp:Label ID="lblNome" runat="server" Text="Nome completo:"></asp:Label><br />
    <asp:TextBox ID="txtNome" runat="server" Width="400px"></asp:TextBox><br />
    <EntLibValidators:propertyproxyvalidator id="validadorNome" runat="server" 
    ControlToValidate="txtNome" PropertyName="Nome" 
    RulesetName="ValidacaoBasica" SpecificationSource="Both"
    SourceTypeName="NetMag.Validation.Entidades.Participante"></EntLibValidators:propertyproxyvalidator>
    
    <br />
    <br />
    
    <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label><br />
    <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox><br />
    <EntLibValidators:propertyproxyvalidator id="validadorEmail" runat="server" 
    ControlToValidate="txtEmail" PropertyName="Email" 
    RulesetName="ValidacaoBasica" SpecificationSource="Both"
    SourceTypeName="NetMag.Validation.Entidades.Participante"></EntLibValidators:propertyproxyvalidator>
    
    <br />
    <br />
    
    <asp:Label ID="lblDataNascimento" runat="server" Text="Data de nascimento:"></asp:Label><br />
    <asp:TextBox ID="txtDataNascimento" runat="server">22/10/1990</asp:TextBox><br />
    <EntLibValidators:propertyproxyvalidator id="validadorDataNascimento" runat="server" 
    ControlToValidate="txtDataNascimento" PropertyName="DataNascimento" 
    RulesetName="ValidacaoBasica" SpecificationSource="Both"
    SourceTypeName="NetMag.Validation.Entidades.Participante"></EntLibValidators:propertyproxyvalidator>
    
    <br />
    <br />
           
    <asp:Label ID="lblMeioComunicacao" runat="server" Text="Como ficou sabendo do treinamento?">
    </asp:Label><br />
    <asp:DropDownList ID="ddlMeioComunicacao" runat="server">
        <asp:ListItem>Revista .Net Magazine #</asp:ListItem>        
        <asp:ListItem>E-mail</asp:ListItem>
        <asp:ListItem>Indicação de um amigo</asp:ListItem>
        <asp:ListItem>Outros</asp:ListItem>
    </asp:DropDownList><br />
    <EntLibValidators:propertyproxyvalidator id="validadorMeioComunicacao" runat="server" 
    ControlToValidate="ddlMeioComunicacao" PropertyName="MeioComunicacao" 
    RulesetName="ValidacaoBasica" SpecificationSource="Both"
    SourceTypeName="NetMag.Validation.Entidades.Participante"></EntLibValidators:propertyproxyvalidator>         
    
    <br />
    <br />
    
    <asp:Label ID="lblVoucher" runat="server" 
    Text="Caso possua um Voucher Promocional, informe no campo abaixo:"></asp:Label><br />
    <asp:TextBox ID="txtVoucher" runat="server" Width="200px"></asp:TextBox><br />
    <EntLibValidators:propertyproxyvalidator id="validadorVoucher" runat="server" 
    ControlToValidate="txtVoucher" PropertyName="Voucher" 
    RulesetName="ValidacaoBasica" SpecificationSource="Both"
    SourceTypeName="NetMag.Validation.Entidades.Participante"></EntLibValidators:propertyproxyvalidator>         
    
    <br />
    <br />
    
    <asp:Label ID="lblComentarios" runat="server" Text="Comentários adicionais:"></asp:Label><br />
    <asp:TextBox ID="txtComentarios" runat="server" Height="100px" TextMode="MultiLine" 
    Width="400px"></asp:TextBox><br />
    <EntLibValidators:propertyproxyvalidator id="validadorComentarios" runat="server" 
    ControlToValidate="txtComentarios" PropertyName="Comentarios" 
    RulesetName="ValidacaoBasica" SpecificationSource="Both"
    SourceTypeName="NetMag.Validation.Entidades.Participante"></EntLibValidators:propertyproxyvalidator>
    
    <br />
    <br />
    
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar dados" Width="105px" onclick="btnEnviar_Click" />  

</asp:Content>