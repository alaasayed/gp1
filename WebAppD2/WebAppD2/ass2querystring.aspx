<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ass2querystring.aspx.cs" Inherits="WebAppD2.ass2cooki" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <label>username</label>
        <asp:TextBox runat="server" ID="t1">name</asp:TextBox><br /><br />
        <label>skill</label>
        <asp:TextBox runat="server" ID="t2">skill</asp:TextBox><br /><br />
        <asp:Button runat="server" Text="submit" ID="b1" OnClick="b1_Click"/>
    </div>
    </form>
</body>
</html>
