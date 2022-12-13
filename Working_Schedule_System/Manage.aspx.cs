using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Working_Schedule_System
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void create_account_Click(object sender, EventArgs e)
        {
            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            string strSQL1, strSQL2;
            strSQL1 = "INSERT INTO [User] (Account, User_Level) ";
            string level;
            if (User_Type.Text == "系辦小姐") level = "2";
            else if (User_Type.Text == "一般使用者") level = "1";
            else level = "3";
            strSQL1 += "VALUES (" + "'" + Account_Input.Text.ToString() + "'," +
                "'" + level + "')";
            //temp_msg.Text = strSQL1;
            strSQL2 = "INSERT INTO [User_Info] (Account, User_Password) ";
            strSQL2 += "VALUES (" + "'" + Account_Input.Text.ToString() + "'," +
                "'" + Password_Input.Text.ToString() + "')";

            OleDbConnection objCon = new OleDbConnection(strDbCon);
            objCon.Open();
            OleDbCommand objCmd1 = new OleDbCommand(strSQL1, objCon);
            OleDbCommand objCmd2 = new OleDbCommand(strSQL2, objCon);

            int count = objCmd1.ExecuteNonQuery();
            count += objCmd2.ExecuteNonQuery();
            if (count == 2) temp_msg.Text = "Account Create Successfully!";
            else temp_msg.Text = "Failed to create account";
            objCon.Close();

            GridView1.DataBind();
            
        }

        protected void GridView1_OnRowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            //string strSQL1 = "DELETE [user_info] FROM [user_info] WHERE user_info.account=" + "'" + str + "'";
            string strSQL2 = "DELETE FROM [User] WHERE Account NOT IN (SELECT [Account] FROM [User_Info])";
            OleDbConnection objCon = new OleDbConnection(strDbCon);
            objCon.Open();
            //OleDbCommand objCmd1 = new OleDbCommand(strSQL1, objCon);
            OleDbCommand objCmd2 = new OleDbCommand(strSQL2, objCon);
            //int count = objCmd1.ExecuteNonQuery();
            int count = objCmd2.ExecuteNonQuery();
            objCon.Close();
        }
    }
}