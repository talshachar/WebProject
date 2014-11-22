<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="manage-users.aspx.cs" Inherits="manage_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
.gvshadow
{
    box-shadow: 1px 1px 7px #bbb;
}
</style>   
    <h1>
        ניהול משתמשים</h1>
        <asp:GridView ID="GridViewUsers" runat="server" Style="margin: 0 auto; direction: rtl;
        text-align: right; width: 70%;" AutoGenerateColumns="False" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit"
        OnRowEditing="GridViewUsers_RowEditing" OnRowUpdating="GridViewUsers_RowUpdating"
        OnRowDeleting="GridViewUsers_RowDeleting" CellPadding="4" ForeColor="#333333"
        GridLines="Horizontal" BorderColor="#5D7B9D" 
        onrowdatabound="GridViewUsers_RowDataBound" CssClass="gvshadow">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="מס' תעודת זהות" ReadOnly="True">
                <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="שם פרטי">
                <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="שם משפחה">
                <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="עיר">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownListCity" runat="server" >
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabelCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Address" HeaderText="כתובת">
                <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="דוא'ל" >
                </asp:BoundField>
                <asp:BoundField DataField="Password" HeaderText="סיסמה">
                <ControlStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Permission" HeaderText="רמת הרשאות">
                <ControlStyle Width="20px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="פעיל">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBoxStatus" runat="server" Checked="True" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxStatusDisplay" runat="server" Checked='<%# Bind("Status") %>'
                        Enabled="False" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" 
                    ShowEditButton="True" CancelText="בטל" DeleteText="מחיקה" EditText="עריכה" 
                    UpdateText="עדכן">
                <ControlStyle CssClass="blackbutton" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="40px" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
</asp:Content>
