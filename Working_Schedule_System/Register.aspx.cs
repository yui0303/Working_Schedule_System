using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Security.Principal;
using System.Net.Mail;
using System.Xml.Linq;

namespace Working_Schedule_System
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Account = Request.QueryString["acc"];
            reg_Account.Text = Account;

        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            string Account = Request.QueryString["acc"];
            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            
            string strSQL;
            
            strSQL = "INSERT INTO [User] (Account, User_Level) ";
            strSQL += "VALUES (" + "'" + Account + "'" + ", '1')";
            
            OleDbConnection objCon = new OleDbConnection(strDbCon);
            objCon.Open();
            OleDbCommand objCmd = new OleDbCommand(strSQL, objCon);
            
            int count = objCmd.ExecuteNonQuery();
            
            Random random = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            string rand_pass = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

            strSQL = "INSERT INTO [User_Info] (Account, User_Password, User_Name, Phone, Mail, Office, Post) ";
            strSQL += "VALUES (" + 
                "'" + Account + "', " +
                "'" + rand_pass + "', " + "'" + Table_Username_Input.Text.ToString() + "', " +
                "'" + Table_Phone_Input.Text.ToString() + "', " +
                "'" + Table_Mail_Input.Text.ToString() + "', " +
                "'" + Table_Lab_Input.Text.ToString() + "', " +
                "'" + Table_Post_Input.Text.ToString() + "')";

            objCmd = new OleDbCommand(strSQL, objCon);
            count += objCmd.ExecuteNonQuery();
            if (count == 2) prompt_msg.Text = "Account Create Successfully! Back to login page for further operations.\nYour password is " + rand_pass;
            else prompt_msg.Text = "Failed to create account!";

            objCon.Close();

            /*
            MailMessage msg = new MailMessage();
            //收件者，以逗號分隔不同收件者 ex "test@gmail.com,test2@gmail.com"
            msg.To.Add(Table_Mail_Input.Text);
            msg.From = new MailAddress("test2@gmail.com", "測試郵件", System.Text.Encoding.UTF8);
            //郵件標題 
            msg.Subject = "NSYSU Working Schedule Password";
            //郵件標題編碼  
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //郵件內容
            msg.Body = "Account: " + Account + "\nPassword: " + rand_pass + "\n Use the password to login the system.";
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
            msg.Priority = MailPriority.Normal;//郵件優先級 
                                               //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port 
           
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            //設定你的帳號密碼
            
            MySmtp.Credentials = new System.Net.NetworkCredential("iampeter040004@gmail.com", "peter5225383");
            //Gmial 的 smtp 使用 SSL
            MySmtp.EnableSsl = true;
            MySmtp.Send(msg);
            */
        }
    }
}