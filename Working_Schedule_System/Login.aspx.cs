using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Working_Schedule_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Button_Click(object sender, EventArgs e)
        {
            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            
            
            string strSQL;
            strSQL = "SELECT * FROM [User] WHERE Account = '" + Account.Text.ToString() + "'";
            OleDbConnection objCon = new OleDbConnection(strDbCon);
            objCon.Open();
            OleDbCommand objCmd = new OleDbCommand(strSQL, objCon);

            OleDbDataReader objDataReader = objCmd.ExecuteReader();

            if (objDataReader.Read())
            {
                string user_level = objDataReader["User_Level"].ToString();
                string pass = "SELECT * From [User_Info] WHERE Account = '" + Account.Text.ToString() + "' AND User_Password = '"
                    + Password.Text.ToString() + "'";
                objCmd = new OleDbCommand(pass, objCon);
                objDataReader = objCmd.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    if (user_level == "1")//user
                    {
                        //temp_msg.Text = "user!";
                        string strURL = "Main_page.aspx?" + "acc=" + Account.Text.ToString();
                        Response.Redirect(strURL);
                    }
                    else if(user_level == "2")
                    {
                        string strURL = "Main_page.aspx?" + "acc=" + Account.Text.ToString();
                        Response.Redirect(strURL);
                        //temp_msg.Text = "worker!";
                    }
                    else//admin
                    {
                        //temp_msg.Text = "admin!";
                        string strURL = "Manage.aspx?" + "acc=" + Account.Text.ToString();
                        Response.Redirect(strURL);
                    }
                    
                }
                else
                {
                    temp_msg.Text = "Account or Password!";
                }
                
            }
            else
            {
                string pattern = @"^[B|M][\d]{9}$";
                Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                Match m = r.Match(Account.Text.ToString());
                if (m.Success)
                {
                    string strURL = "Register.aspx?" + "acc=" + Account.Text.ToString();

                    Response.Redirect(strURL);
                }
                else temp_msg.Text = "Account or Password!";
            }
            objCon.Close();
        }
    }
}