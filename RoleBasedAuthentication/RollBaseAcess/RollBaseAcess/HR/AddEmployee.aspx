<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="RollBaseAcess.HR.AddEmployee" %>
<%@ Register src="~/Controls/NavTab.ascx" tagname="NavTab" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <uc1:NavTab ID="NavTab1" runat="server" />
    <p>
        <br />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <table style="width: 100%;" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    
                                    <asp:CustomValidator ID="CustomValidator1" ValidationGroup="Employee" runat="server" ErrorMessage="This field cannot be empty" Font-Size="Small" ForeColor="Red" ControlToValidate="TextBox1"></asp:CustomValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
                                    <br />
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Employee" runat="server" ControlToValidate="TextBox2" ErrorMessage="This field cannot be empty" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                <td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>HR</asp:ListItem>
                                        <asp:ListItem>Employee</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Phno"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Employee" runat="server" ControlToValidate="TextBox4" ErrorMessage="This field cannot be empty" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Email" ValidateRequestMode="Enabled"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Employee" runat="server" ControlToValidate="TextBox5" ErrorMessage="This field cannot be empty" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="Employee" runat="server" ControlToValidate="TextBox5" ErrorMessage="Invalid Email Id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="Employee" BorderStyle="Double" Height="47px" Width="114px" OnClick="Button1_Click" />
                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                    <br />
                                </td>

                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel></p>
</asp:Content>
