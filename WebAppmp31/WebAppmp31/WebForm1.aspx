<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppmp31.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script>


        //document.getElementById( "audiotagII").play();
    </script>
    <form id="form1" runat="server">
    <div> 
    <%--<embed id="audiotagII" src='r112.mp3'   width='2' height='0'  />--%>
    <audio src="r112.mp3" runat="server" autoplay="autoplay" id="aud1" preload="auto" controls="controls">hello1</audio>
       <br /><br /> <asp:Button runat="server" ID="btn1" OnClick="btn1_Click" />
<br /><br />
        <asp:DropDownList runat="server" ID="ddl1" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">

            <asp:ListItem Value="r112.mp3" Text="r1"></asp:ListItem>
            <asp:ListItem Value="r113.mp3" Text="r2"></asp:ListItem>
            <asp:ListItem Value="r114.mp3" Text="r3"></asp:ListItem>
            
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
