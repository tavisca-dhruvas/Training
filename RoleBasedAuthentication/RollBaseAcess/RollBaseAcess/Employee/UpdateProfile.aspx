﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="RollBaseAcess.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 41px;
        }

    </style>
   >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Remark" />
            </td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>&nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
              <asp:Label ID="Label1" runat="server" Text="User Id:"></asp:Label>
            </td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                <asp:TextBox ID="TextBox1" runat="server" Width="230px" ReadOnly="True"></asp:TextBox>
            </td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                <asp:Label ID="Label2" runat="server" Text="  Old Password:"></asp:Label>
            </td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                <asp:TextBox ID="TextBox2" runat="server" Width="230px" TextMode="  Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Employee" ControlToValidate="TextBox2" ErrorMessage="TextBox cannopt be left empty"></asp:RequiredFieldValidator>
            </td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                &nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                <asp:Label ID="Label3" runat="server" Text="  New Password:"></asp:Label>
            </td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                <asp:TextBox ID="TextBox3" runat="server" Width="229px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Employee" ControlToValidate="TextBox3" ErrorMessage="TextBox cannopt be left empty"></asp:RequiredFieldValidator>
            </td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                <asp:Label ID="Label4" runat="server" Text="  Re-enter Password:"></asp:Label>
            </td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                <asp:TextBox ID="TextBox4" runat="server" Width="228px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Employee" runat="server" ControlToValidate="TextBox4" ErrorMessage="TextBox cannopt be left empty"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="Employee" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ErrorMessage="Password Mismatch..!!"></asp:CompareValidator>
            </td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">
                <asp:Button ID="Button1" ValidationGroup="Employee" runat="server" Text="Submit" OnClick="Button1_Click" />
            </td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%">&nbsp;</td>
            <td width="20%>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%>&nbsp;</td>
            <td 20% class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
</asp:Content>
