<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Working_Schedule_System.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>NSYSU Working Schedule</title>
    <link href="css/styles.css" rel="stylesheet" />
</head>
<body>
    <hr />
    <form runat="server">
        <div class="Frame">
            <div class="Top">
                <asp:Label ID="Head" runat="server" Text="Working Schedule System"></asp:Label>
            </div>
            <div class="Center">
                <asp:TextBox ID="Account" runat="server"></asp:TextBox> Account<br/> <br/>
                <asp:TextBox ID="Password" type="password" runat="server"></asp:TextBox> Password<br/> <br/>
                <asp:Button ID="Login_Button" runat="server" Text="Login" OnClick="Login_Button_Click" /><br/>
                <asp:Label ID="temp_msg" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
