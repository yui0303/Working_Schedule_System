<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule_List.aspx.cs" Inherits="Working_Schedule_System.Schedule_List" %>

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
        <div class="btnlist">
            <asp:LinkButton ID="view_all" runat="server" OnClick="view_all_Click">All Schedule</asp:LinkButton>
            <asp:LinkButton ID="view_today" runat="server" OnClick="view_today_Click">Today Schedule</asp:LinkButton>
        </div>
        <div class="personal_work">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="worker_list" DataKeyNames="Working_Sheet.Account, Working_Sheet.Working_Date, Working_Sheet.Working_Time, Working_Sheet.Agent" SelectedIndex="0" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField>  
                        <ItemTemplate>  
                            <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                        </ItemTemplate>  
                        <EditItemTemplate>  
                            <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                        </EditItemTemplate>  
                    </asp:TemplateField>  
                    <asp:BoundField DataField="Working_Sheet.Account"  Readonly="true" HeaderText="Account" SortExpression="Working_Sheet.Account"  ItemStyle-Width="120px"></asp:BoundField>
                    <asp:BoundField DataField="Working_Sheet.Fname"  Readonly="true" HeaderText="Fname" SortExpression="Working_Sheet.Fname" ></asp:BoundField>
                    <asp:BoundField DataField="Working_Sheet.Agent"  HeaderText="Agent" SortExpression="Working_Sheet.Agent"  ItemStyle-Width="80px"></asp:BoundField>
                    <asp:BoundField DataField="Working_Sheet.Working_Date"  Readonly="true" HeaderText="Working_Date" SortExpression="Working_Sheet.Working_Date"  DataFormatString = "{0:MM/dd/yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="Working_Sheet.Working_Time"  Readonly="true" HeaderText="Working_Time" SortExpression="Working_Sheet.Working_Time" ></asp:BoundField>
                    <asp:BoundField DataField="User_Info.Phone" Readonly="true" HeaderText="Phone" SortExpression="User_Info.Phone"></asp:BoundField>
                    <asp:BoundField DataField="User_Info.Mail" Readonly="true" HeaderText="Mail" SortExpression="User_Info.Mail"></asp:BoundField>
                    <asp:BoundField DataField="User_Info.Office" Readonly="true" HeaderText="Office" SortExpression="User_Info.Office"></asp:BoundField>
                    <asp:BoundField DataField="User_Info.Post" Readonly="true" HeaderText="Post" SortExpression="User_Info.Post"></asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True"  ></asp:CommandField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="worker_list" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>"
                SelectCommand="SELECT [Working_Sheet.Account], [Working_Sheet.Fname], [Working_Sheet.Agent], [Working_Sheet.Working_Date], [Working_Sheet.Working_Time], [User_Info.Phone], [User_Info.Mail], [User_Info.Office], [User_Info.Post] FROM [Working_Sheet], [User_Info] WHERE (Working_Sheet.Account = User_Info.Account AND Working_Sheet.Agent = '' ) OR (Working_Sheet.Agent = User_Info.Account AND NOT Working_Sheet.Agent = '')" 
                DeleteCommand="DELETE FROM [Working_Sheet] WHERE Account=@Working_Sheet.Account AND Working_Date=@Working_Sheet.Working_Date AND Working_Time=@Working_Sheet.Working_Time" 
                UpdateCommand="UPDATE [Working_Sheet] SET Agent=@Working_Sheet.Agent WHERE Working_Date=@Working_Sheet.Working_Date AND Working_Time=@Working_Sheet.Working_Time">
                <UpdateParameters>
                    <asp:Parameter Name="Working_Sheet.Agent" Type="String" />
                    <asp:Parameter Name="Working_Sheet.Date" Type="String" />
                    <asp:Parameter Name="Working_Sheet.Time" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>

        </div>
        <asp:Label ID="temp_msg" runat="server"></asp:Label>
    </form>
</body>
</html>
<style>
    .linkbtn{
        position:absolute;
        right: 120px;
        top: 115px;
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