<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ass1.aspx.cs" Inherits="WebAppD2.ass1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList runat="server" id="ddly"  AutoPostBack ="true" OnSelectedIndexChanged="ddly_SelectedIndexChanged"    ></asp:DropDownList ><br /> <br /> <br />  
         <asp:DropDownList runat="server" id="ddlm" AutoPostBack="true" ></asp:DropDownList><br /> <br /> <br /> 
    <asp:DropDownList runat="server" id="ddld" AutoPostBack="true" ></asp:DropDownList><br /> <br /> <br /> 



         <asp:Button ID="B1" runat="server" PostBackUrl="~/ass1rec.aspx" Text="Button" />

    </div>
    </form>
</body>
</html>
