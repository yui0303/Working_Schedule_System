using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Working_Schedule_System
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string acc = Request.QueryString["acc"];
            Main_link.NavigateUrl = "Main_page.aspx?acc=" + acc;
            Pass_link.NavigateUrl = "Change_Password.aspx?acc=" + acc;
            Edit_link.NavigateUrl = "Edit_Personal.aspx?acc=" + acc;
            Schedule_link.NavigateUrl = "Schedule.aspx?acc=" + acc + "&offset=0";
            Contact_link.NavigateUrl = "Schedule.aspx?acc=" + acc;

            string pattern = @"^[B|M][\d]{9}$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(acc);
            if (m.Success)
            {
                List_link.Attributes.Add("href", "#");

            }
            else List_link.Attributes.Add("href", "Schedule_List.aspx?acc=" + acc);
        }

        protected void Change_Click(object sender, EventArgs e)
        {
            if(new_pass.Text != confirm.Text)
            {
                temp_msg.Text = "Password didn't match!";
            }
            else
            {
                string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";

                string acc = Request.QueryString["acc"];
                string strSQL = "UPDATE [User_Info] SET " + "User_Password" + " = '" + new_pass.Text + "'" + "WHERE Account = '" + acc + "'";

                OleDbConnection objCon = new OleDbConnection(strDbCon);
                objCon.Open();
                OleDbCommand objCmd = new OleDbCommand(strSQL, objCon);
                int count = objCmd.ExecuteNonQuery();
                objCon.Close();
                if (count == 1) temp_msg.Text = "Password Changed!";
                else temp_msg.Text = "Failed to change the password!";
            }
        }
    }
}