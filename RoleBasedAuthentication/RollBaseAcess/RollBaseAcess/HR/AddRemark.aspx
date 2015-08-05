<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRemark.aspx.cs" Inherits="RollBaseAcess.HR.AddRemark" %>
<%@ Register src="~/Controls/NavTab.ascx" tagname="NavTab" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <uc1:NavTab ID="NavTab1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table style="width:100%;">
            <tr>
                <td width="33%">
                    <asp:Label ID="Label1" runat="server" Text="Select Employee :"></asp:Label>
                </td>
                <td width="33%">&nbsp;</td>
                <td width="33%">&nbsp;</td>
            </tr>
            <tr>
                <td width="33%" class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td width="33%" class="auto-style1"></td>
                <td width="33%" class="auto-style1"></td>
            </tr>
            <tr>
                <td width="33%" class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Enter Remark:"></asp:Label>
                </td>
                <td width="33%" class="auto-style1">&nbsp;</td>
                <td width="33%" class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td width="33%">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Field cannot be left empty!!" ForeColor="Red" ValidationGroup="Employee"></asp:RequiredFieldValidator>
                </td>
                <td width="33%">&nbsp;</td>
            </tr>
            <tr>
                <td width="33%">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" ValidationGroup="Employee" Text="Add" />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td width="33%">&nbsp;</td>
                <td width="33%">&nbsp;</td>
            </tr>
        </table>
        <br />
    </p>
</asp:Content>
