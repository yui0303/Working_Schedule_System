using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Working_Schedule_System
{
    public partial class Edit_Personal : System.Web.UI.Page
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

        protected void Modify_Click(object sender, EventArgs e)
        {
            

            int update(string text, string type)
            {
                string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
                
                string acc = Request.QueryString["acc"];
                string strSQL = "UPDATE [User_Info] SET " + type + " = '" + text + "'" + "WHERE Account = '" + acc + "'";

                OleDbConnection objCon = new OleDbConnection(strDbCon);
                objCon.Open();
                OleDbCommand objCmd = new OleDbCommand(strSQL, objCon);
                int count = objCmd.ExecuteNonQuery();
                objCon.Close();
                return count;
            }

            int sign = 5;
            if (User_Name.Text != "")
            {
                sign -= update(User_Name.Text, "User_Name");
            }
            else sign -= 1;

            if (Mail.Text != "")
            {
                sign -= update(Mail.Text, "Mail");
            }
            else sign -= 1;

            if (Phone.Text != "")
            {
                sign -= update(Phone.Text, "Phone");
            }
            else sign -= 1;

            if (Office.Text != "")
            {
                sign -= update(Office.Text, "Office");
            }
            else sign -= 1;

            if (Post.Text != "")
            {
                sign -= update(Post.Text, "Post");
            }
            else sign -= 1;

            if (sign == 0) temp_msg.Text = "Modify Successfully!";
            else temp_msg.Text = "Failed to modify!";
        }
    }
}