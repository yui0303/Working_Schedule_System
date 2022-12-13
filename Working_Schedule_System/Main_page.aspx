<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_page.aspx.cs" Inherits="Working_Schedule_System.Main_page" %>

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
        <div>
            <table class="show_personal">
                <tr><td>Student ID (Account)</td><td>
                    <asp:Label ID="personal_acc" runat="server"></asp:Label></td></tr>
                <tr><td>Username</td><td>
                    <asp:Label ID="personal_name" runat="server"></asp:Label></td></tr>
                <tr><td>User_Type</td><td>
                    <asp:Label ID="personal_type" runat="server"></asp:Label></td></tr>
                <tr><td>Phone Number</td><td>
                    <asp:Label ID="personal_phone" runat="server"></asp:Label></td></tr>
                <tr><td>Mail</td><td>
                    <asp:Label ID="personal_mail" runat="server"></asp:Label></td></tr>
                <tr><td>Lab/Office</td><td>
                    <asp:Label ID="personal_office" runat="server"></asp:Label></td></tr>
                <tr><td>Post</td><td>
                    <asp:Label ID="personal_post" runat="server"></asp:Label></td></tr>
            </table>
        </div>
        <div class="personal_work">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="working_db">
                <Columns>
                    <asp:BoundField DataField="Account" HeaderText="Account" SortExpression="Account" ItemStyle-Width="120px"></asp:BoundField>
                    <asp:BoundField DataField="Working_Date" HeaderText="Working_Date" SortExpression="Working_Date" DataFormatString = "{0:MM/dd/yyyy}" ItemStyle-Width="120px"></asp:BoundField>
                    <asp:BoundField DataField="Working_Time" HeaderText="Working_Time" SortExpression="Working_Time" ItemStyle-Width="120px"></asp:BoundField>
                    <asp:BoundField DataField="Agent" HeaderText="Agent" SortExpression="Agent" ItemStyle-Width="80px"></asp:BoundField>
                    <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" ItemStyle-Width="80px"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="working_db" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT [Account], [Fname], [Agent], [Working_Date], [Working_Time] FROM [Working_Sheet] WHERE (([Account] = ?) OR ([Agent] = ?))">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="acc" Name="Account" Type="String"></asp:QueryStringParameter>
                <asp:QueryStringParameter QueryStringField="acc" Name="Agent" Type="String"></asp:QueryStringParameter></SelectParameters>
            </asp:SqlDataSource>            
        </div>
        <div class="download">
            <asp:Button ID="Download_btn" runat="server" Text="Download" OnClick="Download_btn_Click" />
        </div>
    </form>
</body>
</html>

<style>
    .download{
        margin: 10px 0 0 100px;
    }
    .linkbtn{
        position:absolute;
        right: 120px;
        top: 115px;
    }
    .show_personal{
        margin: 50px 0 0 100px;
        width: 350px;
        border-collapse: collapse;
    }
    .show_personal td{
        height: 40px;
        border: 1px solid;
        text-indent: 5px;
    }

    .personal_work{
        align-items: center;
        justify-content: center;
        /*this will be the color of the odd row*/
        background-color: #fff;        
        margin: 50px 0 0 100px;
        /*border: solid 1px #525252;*/
        border-collapse: collapse;
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
