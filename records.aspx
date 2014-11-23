<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="records.aspx.cs" Inherits="records" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .pageindex
        {
            font-family: Century Gothic, Open Sans Hebrew;
            color: #fff;
            background: #555555;
            border-color: #000;
            border-width: thin;
            border-radius: 2px;
            padding: 5px 10px 5px 10px;
            box-shadow: 1px 1px 3px 0px #999;
        }
    </style>
    <h1>
        תקליטים</h1>
    <asp:DataList ID="DataListRecords" runat="server" CellPadding="0" Font-Bold="False"
        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
        HorizontalAlign="Center" RepeatColumns="4" RepeatDirection="Horizontal" Font-Names="Segoe UI"
        CellSpacing="20" OnItemCommand="DataListRecords_ItemCommand">
        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
            Font-Underline="False" HorizontalAlign="Center" Font-Names="Open Sans Hebrew" />
        <ItemTemplate>
            <table style="width: 100%; text-align: center; background: #fafafa;">
                <tr>
                    <td style="border: 1px solid #cccccc; padding-bottom: 10px;">
                        <asp:Image ID="ImageRecord" runat="server" ImageUrl='<%# Eval("ImageURL") %>' />
                        <asp:Label ID="LabelRecordCode" runat="server" Text='<%# Eval("RecordCode") %>' Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelRecordName" runat="server" Text='<%# Eval("RecordName") %>' Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="LabelArtistName" runat="server" Text='<%# Eval("ArtistName") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LabelRecordReleaseYear" runat="server" Text='<%# Eval("ReleaseYear") %>'
                            Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border: 1px solid #cccccc; padding-bottom: 10px; padding-top: 10px; font-size: 14px;">
                        כמות במלאי<br />
                        <asp:Label ID="LabelRecordsInStock" runat="server" Text='<%# Eval("RecordsInStock") %>'
                            Font-Bold="True"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="LabelRecordPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecordPrice", "{0:c}") %>'
                            Font-Bold="True" Font-Size="16px" ForeColor="#00AE00"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="ButtonAdd" runat="server" CssClass="bluebutton" Text="הוסף לסל הקניות"
                            CommandName="AddToCart" />
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <div style="text-align: center;">
        <asp:Button ID="ButtonNextPage" runat="server" OnClick="ButtonNextPage_Click" CssClass="blackbutton"
            Text="&lt;&lt; הבא"></asp:Button>
        <asp:Label ID="LabelPageIndex" runat="server" CssClass="pageindex"></asp:Label>
        <asp:Button ID="ButtonPrevPage" runat="server" OnClick="ButtonPrevPage_Click" CssClass="blackbutton"
            Text="הקודם &gt;&gt;"></asp:Button>
    </div>
</asp:Content>
