<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="update.aspx.cs" Inherits="update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        עריכת פרטים</h1>
    <div style="width: 60%; margin-left: auto; margin-right: auto">
        <div style="text-align: center">
            <div style="display: inline-block;">
                <h2>
                    עדכון פרטים</h2>
            </div>
            <div style="display: inline-block; padding-right: 50%;">
                <h2>
                    עדכון סיסמה</h2>
            </div>
        </div>
        <br />
        <div style="border: thin solid #cccccc; padding: 30px; background: #efefef; display: inline-block;">
            <div style="display: inline-block;">
                מס' תעודת זהות:<br />
                <asp:TextBox ID="TextBoxID" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />
            <div style="display: inline-block;">
                דוא'ל:<br />
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="320px"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />
            <div style="display: inline-block;">
                שם פרטי:<br />
                <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            </div>
            <div style="float: left; padding-right: 50px;">
                שם משפחה:<br />
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />
            <div style="display: inline-block;">
                עיר:<br />
                <asp:DropDownList ID="DropDownListCity" runat="server" Font-Names="Open Sans Hebrew">
                </asp:DropDownList>
            </div>
            <div style="float: left; padding-right: 50px;">
                כתובת:<br />
                <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />
            <br />
            סיסמה נוכחית*:<br />
            <asp:TextBox ID="TextBoxPasswordDetails" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
            <asp:Button ID="ButtonUpdateDetails" class="blackbutton" runat="server" Text="עדכן פרטים"
                OnClick="ButtonUpdateDetails_Click" />
            <br />
            <asp:Label ID="LabelErrorDetails" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div style="border: thin solid #cccccc; padding: 30px; background: #efefef; float: left;">
            <div style="display: inline-block;">
                סיסמה חדשה:<br />
                <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div style="float: left; padding-right: 50px;">
                אימות סיסמה חדשה:
                <br />
                <asp:TextBox ID="TextBoxConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxNewPassword"
                    ControlToValidate="TextBoxConfirmNewPassword" ErrorMessage="הסיסמה אינה תואמת"
                    ForeColor="Red"></asp:CompareValidator>
            </div>
            <br />
            <br />
            <br />
            <br />
            סיסמה נוכחית*:<br />
            <asp:TextBox ID="TextBoxPasswordPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;
            <asp:Button ID="ButtonUpdatePassword" class="blackbutton" runat="server" Text="עדכן סיסמה"
                OnClick="ButtonUpdatePassword_Click" />
            <br />
            <asp:Label ID="LabelErrorPassword" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
