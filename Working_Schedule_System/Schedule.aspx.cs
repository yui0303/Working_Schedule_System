using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Working_Schedule_System
{
    public partial class Schedule : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string acc = Request.QueryString["acc"];

            string pattern = @"^[B|M][\d]{9}$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(acc);
            if (m.Success)
            {
                List_link.Attributes.Add("href", "#");

            }
            else List_link.Attributes.Add("href", "Schedule_List.aspx?acc=" + acc);

            int offset = 0;
            try
            {
                offset = Int16.Parse(Request.QueryString["offset"]);
            }
            catch{}
            
            Main_link.NavigateUrl = "Main_page.aspx?acc=" + acc;
            Pass_link.NavigateUrl = "Change_Password.aspx?acc=" + acc;
            Edit_link.NavigateUrl = "Edit_Personal.aspx?acc=" + acc;
            Schedule_link.NavigateUrl = "Schedule.aspx?acc=" + acc + "&offset=0";
            Contact_link.NavigateUrl = "Contact.aspx?acc=" + acc;

            string[] weekday = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            DateTime dateTime = new DateTime(2002, 5, 20, 22, 35, 25);
            DateTime dtToday = DateTime.Now;
            Label[] labels = {Date1, Date2, Date3, Date4, Date5, Date6, Date7 };
            DateTime FirstDay = dtToday.AddDays(-(int)dtToday.DayOfWeek);
            FirstDay = FirstDay.AddDays(offset * 7);

            if (!IsPostBack)
            {
                for (int i = 0; i < weekday.Length; i++)
                {
                    string date = FirstDay.AddDays(i).Year.ToString() + "/";
                    date += FirstDay.AddDays(i).Month.ToString() + "/";
                    date += FirstDay.AddDays(i).Day.ToString();
                    labels[i].Text = date;
                }
                for (int i = 0; i < 3; i++)
                {
                    ListItem newItem = new ListItem((dtToday.Year + i).ToString());
                    Years.Items.Add(newItem);
                }

                for (int i = 1; i <= 12; i++)
                {
                    ListItem newItem = new ListItem(i.ToString());
                    Month.Items.Add(newItem);
                }

                for (int i = 1; i <= 31; i++)
                {
                    ListItem newItem = new ListItem(i.ToString());
                    Day.Items.Add(newItem);
                }
            }

            Label[] M = { M1, M2, M3, M4, M5, M6, M7 };
            Label[] MA = { MA1, MA2, MA3, MA4, MA5, MA6, MA7 };
            Label[] A = { A1, A2, A3, A4, A5, A6, A7 };
            Label[] AA = { AA1, AA2, AA3, AA4, AA5, AA6, AA7 };

            string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";
            string selectSQL;
            selectSQL = "SELECT [Account], [Agent], [Working_Date], [Working_Time] FROM [Working_Sheet] ";
            selectSQL += "WHERE [Working_Date] BETWEEN " + "#" + FirstDay.Month + "/" + FirstDay.Day + "/" + FirstDay.Year + "#" + " AND " + "#" + FirstDay.AddDays(7).Month + "/" + FirstDay.AddDays(7).Day + "/" + FirstDay.AddDays(7).Year + "#";

            OleDbConnection selectCon = new OleDbConnection(strDbCon);
            selectCon.Open();
            OleDbCommand selectCmd = new OleDbCommand(selectSQL, selectCon);
            OleDbDataReader objDataReader = selectCmd.ExecuteReader();
            while (objDataReader.Read())
            {
                string Account = objDataReader["Account"].ToString();
                string Agent = objDataReader["Agent"].ToString();
                string Working_Date = objDataReader["Working_Date"].ToString();
                string Working_Time = objDataReader["Working_Time"].ToString();
                DateTime.TryParse(Working_Date, out DateTime temp);
                int index = (int)temp.DayOfWeek;
                if(Working_Time == "Morning")
                {
                    M[index].Text = Account;
                    MA[index].Text = Agent;
                }
                else
                {
                    A[index].Text = Account;
                    AA[index].Text = Agent;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string acc = Request.QueryString["acc"];
            int offset = 0;
            try
            {
                offset = Int16.Parse(Request.QueryString["offset"]) -1;
            }
            catch
            {

            }
            string url = "Schedule.aspx?acc=" + acc + "&offset=" + offset.ToString();
            Response.Redirect(url);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string acc = Request.QueryString["acc"];
            int offset = 0;
            try
            {
                offset = Int16.Parse(Request.QueryString["offset"]) + 1;
            }
            catch
            {

            }
            string url = "Schedule.aspx?acc=" + acc + "&offset=" + offset.ToString();
            Response.Redirect(url);
        }

        protected void schedule_btn_Click(object sender, EventArgs e)
        {
            string acc = Request.QueryString["acc"];
            DateTime dateTime = new DateTime(2002, 5, 20, 22, 35, 25);
            string schedule_date = Month.Text + "/" + Day.Text + "/" + Years.Text;
            if (DateTime.TryParse(schedule_date, out DateTime temp))
            {
                //temp_msg.Text = temp.ToString();
                string strDbCon = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=C:\\Users\\asus\\source\\repos\\Working_Schedule_System\\Working_Schedule_System\\database.accdb";

                string selectSQL;
                selectSQL = "SELECT [Account], [Agent], [Working_Date], [Working_Time] FROM [Working_Sheet] ";
                selectSQL += "WHERE [Working_Date] = " + "#" + schedule_date + "# AND [Working_Time] = " + "'" + Time.Text + "' ";

                OleDbConnection selectCon = new OleDbConnection(strDbCon);
                selectCon.Open();
                OleDbCommand selectCmd = new OleDbCommand(selectSQL, selectCon);
                OleDbDataReader objDataReader = selectCmd.ExecuteReader();
                if (objDataReader.Read()) // same working date and time
                {
                    string Account = objDataReader["Account"].ToString();
                    if (Account == acc)
                    {
                        string agent = objDataReader["Agent"].ToString();
                        if (agent == "")
                        {
                            if(agent_text.Text == "")
                            {
                                temp_msg.Text = "You have already fill the time. Nothing Change";
                            }
                            else // fill the agent
                            {
                                string insertSQL = "UPDATE [Working_Sheet] SET [Agent] = '" + agent_text.Text + "'" +
                                    " WHERE [Working_Date] = " + "#" + schedule_date + "# AND [Working_Time] = " + "'" + Time.Text + "' ";
                                OleDbConnection insertCon = new OleDbConnection(strDbCon);
                                insertCon.Open();
                                OleDbCommand insertCmd = new OleDbCommand(insertSQL, insertCon);
                                int count = insertCmd.ExecuteNonQuery();
                                temp_msg.Text = count==1 ? "Set Agent Successfully!" : "Failed to set agent!";
                                insertCon.Close();
                            }
                        }
                        else
                        {
                            if (agent_text.Text == "")
                            {
                                temp_msg.Text = "You have already fill the time. Nothing Change";
                            }
                            else temp_msg.Text = "You caanot fill the agent twice! Please contact the worker for the modification.";
                        }
                    }
                    else
                    {
                        if (agent_text.Text == "")
                        {
                            temp_msg.Text = "The time you pick has already pick by other";
                        }
                        else temp_msg.Text = "It is not your working time, you cannot fill the agent!";
                    }
                    

                }
                else // still empty
                {
                    if(agent_text.Text != "") //fill the agent, contradiction
                    {
                        temp_msg.Text = "The time you pick is empty! No need to fill the agent.";
                    }
                    else
                    {
                        string insertSQL;
                        insertSQL = "INSERT INTO[Working_Sheet] (Account, Fname, Agent, Working_Date, Working_Time) ";
                        insertSQL += "SELECT[Account], [User_Name], " + "'" + agent_text.Text + "', " +
                            "'" + schedule_date + "', " + "'" + Time.Text + "' " + "FROM[User_Info] WHERE [Account] = " + "'" + acc + "'";

                        OleDbConnection insertCon = new OleDbConnection(strDbCon);
                        insertCon.Open();
                        OleDbCommand insertCmd = new OleDbCommand(insertSQL, insertCon);
                        int count = insertCmd.ExecuteNonQuery();
                        if (count == 1)
                        {
                            temp_msg.Text = "Successful!";
                        }
                        else
                        {
                            temp_msg.Text = "Failed to Schedule!";
                        }
                        insertCon.Close();
                    }

                }
                objDataReader.Close();
                selectCon.Close();
            }
            else
            {
                temp_msg.Text = "Invalid Time";
            }

            Page_Load(sender, e);
        }
    }
}