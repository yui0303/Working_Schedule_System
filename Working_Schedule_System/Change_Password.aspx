<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="Working_Schedule_System.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header id="header">  
            <h1>NSYSU Working Schedule</h1>  
            </header> 
            <nav id="nav">  
                <ul>  
                    <li><asp:HyperLink ID="Main_link" runat="server">Home</asp:HyperLink></li> 
                    <li><asp:HyperLink ID="Pass_link" runat="server">Change Password</asp:HyperLink></li>
                    <li><asp:HyperLink ID="Edit_link" runat="server">Edit Personal Info</asp:HyperLink></li>
                    <li><asp:HyperLink ID="Schedule_link" runat="server">Working Schedule</asp:HyperLink></li>
                    <li><asp:HyperLink ID="Contact_link" runat="server">Contact</asp:HyperLink></li>
                </ul>  
            </nav> 
        </div>
        <div class="linkbtn">
            <asp:LinkButton ID="List_link" runat="server">
                <image src="assets/img/build_FILL0_wght400_GRAD0_opsz48.svg" /></asp:LinkButton> 
        </div>
        <div class="Update_Table">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>New Password</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="new_pass" Type="password" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Confirm Password</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="confirm" Type="password" runat="server"></asp:TextBox></asp:TableCell>
               </asp:TableRow>         
            </asp:Table>
            <asp:Button runat="server" Text="Change" OnClick="Change_Click" />
            <asp:Label ID="temp_msg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

<style>
    .Update_Table{
        margin: 50px 0 0 100px;
    }
    .linkbtn{
        position:absolute;
        right: 120px;
        top: 115px;
    }
    #header{  
        margin: 20px 0 0 0;
        color: #424242;  
        text-align: center;  
        font-size: 20px;  
    }  
    #nav{  
        background-color:#aeb6b6; 
        padding: 5px;  
    }  
    ul{  
        list-style-type: none;  
    } 
    li a{  
        color: #424242;  
        font-size: 30px;
        column-width:20px;
    } 
    li{  
        display: inline;  
        padding-left: 10px;  
        column-width: 20px;  
    }  
   a{  
        text-decoration: none;  
        margin-left:20px  
   }  
   li a:hover{  
        background-color: #000000;  
        color: #ffffff;  
        padding:1%;  
   }  
</style>