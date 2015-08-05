<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RollBaseAcess.Account.Login" %>

<%@ Register Src="~/Controls/Login.ascx" TagPrefix="uc1" TagName="Login" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent" >
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <section id="loginForm">
        <h2>Use a local account to log in.</h2>
        <uc1:Login ID="Login1" runat="server" />
        <p></p>
    </section>
</asp:Content>
