<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRemark.ascx.cs" Inherits="EmsWidget.EmployeePage.ViewRemark" %>

 <asp:GridView ID="GridViewRemark" runat="server" OnPageIndexChanging="GridViewRemark_SelectedIndexChanging" OnSelectedIndexChanged="GridViewRemark_SelectedIndexChanged" AllowPaging="True" PageSize="3" AllowCustomPaging="True">
        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PageButtonCount="4" PreviousPageText="Prev" />
    </asp:GridView>
    <asp:Label ID="LabelFetchRemark" runat="server" Visible="False"></asp:Label>