<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        הרשמה</h1>
    <div style="border: thin solid #cccccc; width: 400px; padding: 30px; background: #efefef;
        margin-left: auto; margin-right: auto; box-shadow: 1px 1px 7px #bbb">
        <div style="display: inline-block;">
            מס&#39; תעודת זהות*
            <br />
            <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatoriID" runat="server" ControlToValidate="TextBoxID"
                ErrorMessage="הכנס מס&amp;#39; תעודת זהות" ForeColor="Red" Display="Dynamic"
                ValidationGroup="signup"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidatorID" runat="server" ControlToValidate="TextBoxID"
                ErrorMessage="תעודת זהות לא חוקית" ForeColor="Red" Display="Dynamic" ValidationGroup="signup"
                OnServerValidate="CustomValidatorID_ServerValidate"></asp:CustomValidator>
        </div>
        <br />
        <br />
        <br />
        <div style="display: inline-block;">
            כתובת דוא&#39;ל*<br />
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail"
                ErrorMessage="הכנס כתובת אי-מייל" ForeColor="Red" Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <br />
        <div style="display: inline-block;">
            שם פרטי*<br />
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ControlToValidate="TextBoxFirstName"
                ErrorMessage="הכנס שם פרטי" ForeColor="Red" Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
        </div>
        <div style="display: block; float: left;">
            שם משפחה*
            <br />
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ControlToValidate="TextBoxLastName"
                ErrorMessage="הכנס שם משפחה" ForeColor="Red" Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <br />
        <div style="display: inline-block;">
            עיר*<br />
            <asp:DropDownList ID="DropDownListCity" runat="server" Font-Names="Open Sans Hebrew">
                <asp:ListItem Value="0">בחר עיר</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div style="display: block; float: left;">
            כתובת*<br />
            <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress"
                ErrorMessage="הכנס כתובת" ForeColor="Red" Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="DropDownListCity" ErrorMessage="בחר עיר" Operator="NotEqual" 
            ForeColor="Red" Display="Dynamic" ValidationGroup="signup" ValueToCompare="0"></asp:CompareValidator>
        <br />
        <br />
        <div style="display: inline-block;">
            סיסמה*<br />
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword"
                ErrorMessage="הכנס סיסמה" ForeColor="Red" Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
        </div>
        <div style="display: block; float: left;">
            אימות סיסמה*<br />
            <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server"
                ControlToValidate="TextBoxConfirmPassword" ErrorMessage="אמת סיסמה" ForeColor="Red"
                Display="Dynamic" ValidationGroup="signup"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorConfirmPassword" runat="server" ControlToCompare="TextBoxPassword"
                ControlToValidate="TextBoxConfirmPassword" ErrorMessage="הסיסמה אינה תואמת" ForeColor="Red"
                Display="Dynamic" ValueToCompare="signup"></asp:CompareValidator>
        </div>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonSignUp" class="blackbutton" runat="server" Text="הירשם לאתר"
            OnClick="ButtonSignUp_Click" ValidationGroup="signup" />
    </div>
</asp:Content>
