using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections.Specialized;

namespace ITS
{
    public partial class org_student_test_history : System.Web.UI.Page
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

                    SqlCommand com1 = new SqlCommand("select examname as ExamName,subjectname as Subjectname,total_marks as TotalMarks,obtain_marks as ObtainMarks,correct_answer as TotalCorrectAnswer,wrong_answer as TotalWrongAnswer,un_answer as TotalNotAttempt,atendance as Attendance,submitexam_time as TestSubmitTime,linkclosetime as LinkCloseTime from org_student_result where org_name='" + org + "' and student_id = '" + rollno + "' and atendance='Present' and studentstatus = 'Active' and  '" + curdt + "' > linkclosetime order by linkclosetime", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();


                    SqlCommand com2 = new SqlCommand("select examname as ExamName,subjectname as Subjectname,total_marks as TotalMarks,obtain_marks as ObtainMarks,correct_answer as TotalCorrectAnswer,wrong_answer as TotalWrongAnswer,un_answer as TotalNotAttempt,atendance as Attendance,submitexam_time as TestSubmitTime,linkclosetime as LinkCloseTime from org_student_result where org_name='" + org + "' and student_id = '" + rollno + "' and atendance='Absent'  and studentstatus = 'Active' and  '" + curdt + "' > linkclosetime order by linkclosetime", con);
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
            
            string sid = c1.Fillstring("Select set_id  From org_student_result Where student_id='" + rollno + "'and subjectname='" + subject + "' and examname='" + exname + "' and org_name='" + org + "' ");

            Session["stid"] = sid;
            Session["id"] = rollno;
            Session["examname"] = exname;
            Session["testsubject"] = subject;


            
           
           
            c1.InsDelup("insert into org_student_exam_temp (student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name) select student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name from org_student_exam where student_id='" + rollno + "' and org_name='" + org + "' ");

            c1.InsDelup("delete from org_student_exam where student_id='" + rollno + "' and org_name='" + org + "'");









            string ests = c1.Fillstring("Select answerkey  From org_student_result Where student_id='" + rollno + "'and subjectname='" + subject + "' and examname='" + exname + "' and org_name='" + org + "' ");

            if (ests == "Yes" )
            {
                Response.Redirect("org_student_result.aspx");
            }

            else
            {
                string message = "Answer key not released by institute/organization";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }
    }
}