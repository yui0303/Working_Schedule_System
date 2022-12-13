using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Working_Schedule_System
{
    public partial class Main_page : System.Web.UI.Page
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


            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            string strSQL;
            strSQL = "SELECT [User_Name], [Level_Name], [Phone], [Mail], [Office], [Post] FROM [User], [User_Info], [Levels] " +
                "WHERE User_Info.Account = User.Account AND User.User_Level = Levels.No AND User_Info.Account = '"+
                acc +"'";
            OleDbConnection objCon = new OleDbConnection(strDbCon);
            objCon.Open();
            OleDbCommand objCmd = new OleDbCommand(strSQL, objCon);

            OleDbDataReader objDataReader = objCmd.ExecuteReader();
            if(objDataReader.Read())
            {
                personal_acc.Text = acc;
                personal_name.Text = objDataReader["User_Name"].ToString();
                personal_type.Text = objDataReader["Level_Name"].ToString();
                personal_phone.Text = objDataReader["Phone"].ToString();
                personal_mail.Text = objDataReader["Mail"].ToString();
                personal_office.Text = objDataReader["Office"].ToString();
                personal_post.Text = objDataReader["Post"].ToString();
            }
            objDataReader.Close();
            objCon.Close();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        private void ExportGridToExcel()
        {
            string acc = Request.QueryString["acc"];
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "work_" + acc + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void Download_btn_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
    }
}