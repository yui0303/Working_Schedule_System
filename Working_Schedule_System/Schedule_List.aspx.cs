using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace Working_Schedule_System
{
    public partial class Schedule_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string acc = Request.QueryString["acc"];
            Main_link.NavigateUrl = "Main_page.aspx?acc=" + acc;
            Pass_link.NavigateUrl = "Change_Password.aspx?acc=" + acc;
            Edit_link.NavigateUrl = "Edit_Personal.aspx?acc=" + acc;
            Schedule_link.NavigateUrl = "Schedule.aspx?acc=" + acc + "&offset=0";
            Contact_link.NavigateUrl = "Contact.aspx?acc=" + acc;

            string pattern = @"^[B|M][\d]{9}$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(acc);
            if (m.Success)
            {
                List_link.Attributes.Add("href", "#");

            }
            else List_link.Attributes.Add("href", "Schedule_List.aspx?acc=" + acc);

        }

        protected void view_today_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Now;
            string date = dtToday.Month.ToString() + "/" + dtToday.Day.ToString() + "/" + dtToday.Year.ToString();
            worker_list.SelectCommand = "SELECT [Working_Sheet.Account], [Working_Sheet.Fname], [Working_Sheet.Agent], [Working_Sheet.Working_Date], [Working_Sheet.Working_Time], [User_Info.Phone], [User_Info.Mail], [User_Info.Office], [User_Info.Post] FROM [Working_Sheet], [User_Info] WHERE ((Working_Sheet.Account = User_Info.Account AND Working_Sheet.Agent = '') OR (Working_Sheet.Agent = User_Info.Account AND NOT Working_Sheet.Agent = ''))" +" AND Working_Sheet.Working_Date = #" + date + "#";
            GridView1.DataBind();
        }

        protected void view_all_Click(object sender, EventArgs e)
        {
            worker_list.SelectCommand = "SELECT [Working_Sheet.Account], [Working_Sheet.Fname], [Working_Sheet.Agent], [Working_Sheet.Working_Date], [Working_Sheet.Working_Time], [User_Info.Phone], [User_Info.Mail], [User_Info.Office], [User_Info.Post] FROM [Working_Sheet], [User_Info] WHERE (Working_Sheet.Account = User_Info.Account AND Working_Sheet.Agent = '') OR (Working_Sheet.Agent = User_Info.Account AND NOT Working_Sheet.Agent = '')";
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
            
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            
            //Finding the controls from Gridview for the row which is going to update  
            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            //TextBox agent = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Working_Sheet.Agent");
            string agent = (row.Cells[2].Controls[0] as TextBox).Text;
            temp_msg.Text = agent;
            /*
            GridViewRow row = GridView1.Rows[e.RowIndex];
            //string agent = GridView1.DataKeys[e.RowIndex].Values["Working_Sheet.Agent"].ToString();
            string d = GridView1.DataKeys[e.RowIndex].Values["Working_Sheet.Working_Date"].ToString();
            DateTime.TryParse(d, out DateTime temp);
            string date = temp.Month + "/" + temp.Day + "/" + temp.Year;
            string time = GridView1.DataKeys[e.RowIndex].Values["Working_Sheet.Working_Time"].ToString();
            string strSQL = "UPDATE [Working_Sheet] SET [Agent] = '" + agent.Text + "' WHERE Working_Sheet.Working_Date = #" + date  + "# AND Working_Sheet.Working_Time = '" + time + "'";

            OleDbConnection objCon = new OleDbConnection(strDbCon);
            objCon.Open();
            OleDbCommand objCmd = new OleDbCommand(strSQL, objCon);
            int count = objCmd.ExecuteNonQuery();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data              
            GridView1.DataBind();
            */
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            GridView1.DataBind();
            
        }
    }
}