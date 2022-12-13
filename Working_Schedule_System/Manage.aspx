<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Working_Schedule_System.Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table">
            <table border="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" id="AutoNumber1" cellpadding="2">
                <tr height="30px">
                  <td>Account</td>
                  <td><asp:TextBox ID="Account_Input" runat="server"></asp:TextBox></td>
                </tr>
                <tr height="30px">
                  <td>Password</td>
                  <td><asp:TextBox ID="Password_Input" runat="server"></asp:TextBox></td>
                </tr>
                <tr height="30px">
                  <td>User Type</td>
                  <td>
                      <asp:DropDownList ID="User_Type" runat="server" DataSourceID="SqlDataSource2" DataTextField="Level_Name" DataValueField="Level_Name"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT [Level_Name] FROM [Levels]"></asp:SqlDataSource></td>
                </tr>
                <tr height="30px"> 
                    <td><asp:Button ID="create_account" runat="server" Text="Create" OnClick="create_account_Click" /></td> 
                </tr>   
            </table>
        </div>
        <div style="text-align:center"><asp:Label ID="temp_msg" runat="server"></asp:Label></div>
        <div class="grid">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="User_Info.Account" SelectedIndex="0" OnRowdeleted="GridView1_OnRowDeleted">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button"></asp:CommandField>
                    <asp:BoundField DataField="User_Info.Account" HeaderText="Account" SortExpression="User_Info.Account"></asp:BoundField>
                    <asp:BoundField DataField="User_Password" HeaderText="User_Password" SortExpression="User_Password"></asp:BoundField>
                    <asp:BoundField DataField="Level_Name" HeaderText="Level_Name" SortExpression="Level_Name"></asp:BoundField>
                    <asp:BoundField DataField="User_Name" HeaderText="User_Name" SortExpression="User_Name"></asp:BoundField>
                    <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail"></asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True"  ></asp:CommandField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                SelectCommand="SELECT [User_Info.Account], [User_Password], [Level_Name], [User_Name], [Mail] FROM [User_Info], [User], [Levels] WHERE User_Info.Account = User.Account AND User.User_Level = Levels.No ORDER BY User.Account ASC"
                DeleteCommand="DELETE [user_info] FROM [user_info] WHERE user_info.account=@User_Info.Account"></asp:SqlDataSource>
        </div>
    </form>
</body>
    </html>

<style>
    .grid, .table {
        display: flex;
        align-items: center;
        justify-content: center;
        /*this will be the color of the odd row*/
        background-color: #fff;
        margin: 50px 0 0 0;
        /*border: solid 1px #525252;*/
        border-collapse: collapse;
     }
    /*data elements*/
    .grid td {
        padding: 2px;
        border: solid 1px #c1c1c1;
        color: #717171;
    }
    /*header elements*/
    .grid th {
        padding: 4px 2px;
        color: #fff;
        background: #424242;
        border-left: solid 1px #525252;
        font-size: 0.9em;
    }
</style>
