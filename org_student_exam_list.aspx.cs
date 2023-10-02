using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ITS
{
    public partial class org_student_exam_list : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string rollno = Session["stuid"].ToString();

            DateTime dt = DateTime.Now;
            string curdt = dt.ToString("yyyy-MM-dd HH:mm:ss.fff");

            try
            {


                if (rollno != "")
                {

                    SqlCommand com1 = new SqlCommand("select examname as ExamName,subjectname as SubjectName,total_marks as TotalMarks,remaning_min as ExamDuration,studentstatus as StudentStatus,examstatus as ExamStatus,linkopentime as LinkOpenTime,linkclosetime as LinkCloseTime from org_student_result where org_name='" + org + "' and student_id = '" + rollno + "' and examstatus != 'Finish' and studentstatus = 'Active' and  '"+curdt+"' <= linkclosetime", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();


                SqlCommand com2 = new SqlCommand("select examname as ExamName,subjectname as SubjectName,total_marks as TotalMarks,remaning_min as ExamDuration,studentstatus as StudentStatus,examstatus as ExamStatus,linkopentime as LinkOpenTime,linkclosetime as LinkCloseTime from org_student_result where org_name='" + org + "' and student_id = '" + rollno + "' and examstatus = 'Finish' and studentstatus = 'Active' and  '" + curdt + "' between linkopentime and linkclosetime", con);
                con.Open();
                SqlDataReader rd2 = com2.ExecuteReader();
                GridView2.DataSource = rd2;
                GridView2.DataBind();
                con.Close();



            }
                else
                {
                    Response.Redirect("Default.aspx");
                }


            }
            catch
            {
                Response.Redirect("Default.aspx");
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string rollno = Session["stuid"].ToString();
            string exname = GridView1.SelectedRow.Cells[1].Text;
            string subject = GridView1.SelectedRow.Cells[2].Text;
            DateTime optime =DateTime.Parse( GridView1.SelectedRow.Cells[7].Text);

            DateTime td = DateTime.Now;

            if (td < optime)
            {
                string message = "Your exam will be start at "+optime.ToString();
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string sid = c1.Fillstring("Select set_id  From org_student_result Where student_id='" + rollno + "'and subjectname='" + subject + "' and examname='" + exname + "' and org_name='" + org + "' ");

                Session["stid"] = sid;
                Session["id"] = rollno;
                Session["examname"] = exname;
                Session["testsubject"] = subject;

                string ests = c1.Fillstring("Select examstatus  From org_student_result Where student_id='" + rollno + "'and subjectname='" + subject + "' and examname='" + exname + "' and org_name='" + org + "' ");

                if (ests == "Not started" || ests == "Exam Runing")
                {
                    Response.Redirect("org_student_test_instruction.aspx");
                }

                else if (ests == "Finish")
                {
                    Response.Redirect("org_student_exam_list.aspx");
                }
            }


        }

        protected void starttest_Click(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                string rollno = Session["stuid"].ToString();
                //string exname = GridView1.SelectedRow.Cells[1].Text;
                //string subject = GridView1.SelectedRow.Cells[2].Text;
                //DateTime optime = DateTime.Parse(GridView1.SelectedRow.Cells[7].Text);
                Button btnStartTest = (sender as Button);


                string exname1 = btnStartTest.CommandArgument;
                string[] b = new string[] {"~"};
                string[] c = exname1.Split(b, StringSplitOptions.None);
                string exname = c[0];
                string subject = c[1];
                DateTime optime = DateTime.Parse(c[2]);
                
                //string subject = GridView1.SelectedRow.Cells[2].Text;
                //DateTime optime = DateTime.Parse(GridView1.SelectedRow.Cells[7].Text);

                DateTime td = DateTime.Now;

                if (td < optime)
                {
                    string message = "Your exam will be start at " + optime.ToString();
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                else
                {
                    string sid = c1.Fillstring("Select set_id  From org_student_result Where student_id='" + rollno + "'and subjectname='" + subject + "' and examname='" + exname + "' and org_name='" + org + "' ");

                    Session["stid"] = sid;
                    Session["id"] = rollno;
                    Session["examname"] = exname;
                    Session["testsubject"] = subject;

                    string ests = c1.Fillstring("Select examstatus  From org_student_result Where student_id='" + rollno + "'and subjectname='" + subject + "' and examname='" + exname + "' and org_name='" + org + "' ");

                    if (ests == "Not started" || ests == "Exam Runing")
                    {
                        Response.Redirect("org_student_test_instruction.aspx");
                    }

                    else if (ests == "Finish")
                    {
                        Response.Redirect("org_student_exam_list.aspx");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    
}