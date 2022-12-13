<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Working_Schedule_System.Schedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Schedule.aspx</title>
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
        <div class="linkbtn1">
            <asp:LinkButton ID="List_link" runat="server">
                <image src="assets/img/build_FILL0_wght400_GRAD0_opsz48.svg" /></asp:LinkButton> 
        </div>
        <div class="calendar">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>Date</asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date1" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date2" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date3" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date4" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date5" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date6" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Date7" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Week</asp:TableCell>
                    <asp:TableCell>Sun</asp:TableCell>
                    <asp:TableCell>Mon</asp:TableCell>
                    <asp:TableCell>Tue</asp:TableCell>
                    <asp:TableCell>Wed</asp:TableCell>
                    <asp:TableCell>Thu</asp:TableCell>
                    <asp:TableCell>Fri</asp:TableCell>
                    <asp:TableCell>Sat</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Morning</asp:TableCell>
                    <asp:TableCell><asp:Label ID="M1" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="M2" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="M3" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="M4" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="M5" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="M6" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="M7" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Agent</asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA1" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA2" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA3" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA4" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA5" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA6" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="MA7" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Afternoon</asp:TableCell>
                    <asp:TableCell><asp:Label ID="A1" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="A2" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="A3" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="A4" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="A5" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="A6" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="A7" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Agent</asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA1" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA2" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA3" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA4" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA5" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA6" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="AA7" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div class="linkbtn">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                <image src="assets/img/arrow_back_ios_FILL0_wght400_GRAD0_opsz48.svg" />Previous
            </asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
                Forward<image src="assets/img/arrow_forward_ios_FILL0_wght400_GRAD0_opsz48.svg" />
            </asp:LinkButton>
        </div>
        
        
        <div class="insert_schedule">
            <table>
                <tr>
                    <td>Year: </td>
                    <td><asp:DropDownList ID="Years" runat="server">
                        </asp:DropDownList></td>
                    <td>Month: </td>
                    <td><asp:DropDownList ID="Month" runat="server">                            
                        </asp:DropDownList></td>
                    <td>Day: </td>
                    <td><asp:DropDownList ID="Day" runat="server">                            
                        </asp:DropDownList></td>
                    <td><asp:DropDownList ID="Time" runat="server">
                        <asp:ListItem Value="Morning"></asp:ListItem>
                        <asp:ListItem Value="Afternoon"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>Agent</td>
                    <td><asp:TextBox ID="agent_text" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="schedule_btn" runat="server" Text="Schedule" OnClick="schedule_btn_Click"/></td>
                </tr>                
            </table>
            <asp:Label ID="temp_msg" runat="server"></asp:Label>
        </div>
    </form>

</body>
</html>

<style>
    .linkbtn1{
        position:absolute;
        right: 120px;
        top: 115px;
    }
    .linkbtn{
        font-size: 20px;
        align-items:center;
        text-align:center;
    }
    .material-symbols-outlined{
        vertical-align: middle;
    }
    .calendar table{
      table-layout: fixed;
      width: 100%;
      font-size: 20px;
      border: solid;
    }
    .calendar td{
      height: 70px;
      overflow: hidden;
      white-space: nowrap;
      text-overflow: ellipsis;
      text-align: center;
      border:solid;
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