<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Working_Schedule_System.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register.aspx</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header id="header">  
                <h1>Register</h1>  
            </header> 
            <div class="User_Info_Table">
                <table>
                    <tr><td><asp:Label ID="Table_Account_Label" runat="server" Text="Account (Student ID)"></asp:Label></td>
                        <td><asp:Label ID="reg_Account" runat="server"></asp:Label></td>
                    </tr>
                    <tr><td><asp:Label ID="Table_Mail_Label" runat="server" Text="Mail"></asp:Label></td>
                        <td><asp:TextBox ID="Table_Mail_Input" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr><td><asp:Label ID="Table_Username_Label" runat="server" Text="Username"></asp:Label></td>
                        <td><asp:TextBox ID="Table_Username_Input" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr><td><asp:Label ID="Table_Phone_Label" runat="server" Text="Phone (if any)"></asp:Label></td>
                        <td><asp:TextBox ID="Table_Phone_Input" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Table_Lab_Label" runat="server" Text="Lab No. (if any)"></asp:Label></td>
                        <td><asp:TextBox ID="Table_Lab_Input" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Table_Post_Label" runat="server" Text="Post Account (if any)"></asp:Label></td>
                        <td><asp:TextBox ID="Table_Post_Input" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="submit_btn" runat="server" Text="Submit" OnClick="submit_btn_Click" /></td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="prompt_msg" runat="server" style="display: block;text-align: center;"></asp:Label>
        </div>
    </form>
</body>
</html>
<style>
    .User_Info_Table{
        margin-left: auto;
        margin-right:auto;
        width: 400px;
        font-size: 20px;
    }
    .User_Info_Table td{
        height: 40px;
        text-indent: 5px;
    }
    #header{  
        margin: 20px 0 0 0;
        color: #424242;  
        text-align: center;
        font-size: 20px;  
    }  
</style>
