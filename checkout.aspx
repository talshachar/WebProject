<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    סוג כרטיס*
    <br />
    <asp:RadioButton ID="RadioButtonCC" runat="server" Checked="True" GroupName="CardType" />
    <img src="icons/american-express-straight-32px.png" style="height: 32px; height: 20.5px" />
    <img src="icons/mastercard-straight-32px.png" style="height: 32px; height: 20.5px" />
    <img src="icons/visa-straight-32px.png" style="height: 32px; height: 20.5px" />
    <asp:RadioButton ID="RadioButtonPP" runat="server" GroupName="CardType" />
    <img src="icons/paypal-straight-32px.png" style="height: 32px; height: 20.5px" />
    <br />
    <br />
    מספר כרטיס אשראי*
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Width="225px"></asp:TextBox>
    <br />
    <br />
    תאריך תפוגה*
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>2014</asp:ListItem>
        <asp:ListItem>2015</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>01</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    קוד אבטחה*<br />
    <asp:TextBox ID="TextBox2" runat="server" Width="50px"></asp:TextBox>
    <br />
    <span style="color:Gray; font-size:13px;">(3 ספרות אחרונות בגב הכרטיס)</span>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="bluebutton" 
        onclick="Button1_Click" Text="בצע רכישה" />
    </form>
</body>
</html>
