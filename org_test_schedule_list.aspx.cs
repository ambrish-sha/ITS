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
    public partial class org_test_schedule_list : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
           
            DateTime dt = DateTime.Now;
            string curdt = dt.ToString("yyyy-MM-dd HH:mm:ss.fff");

            try
            {


                

                    SqlCommand com1 = new SqlCommand("select batch_name,course_name,branch_name,yearsem,exam_name,subject_name,set_id from org_exam_schedule where org_name='" + org + "' and endtime<'"+curdt+"' order by endtime", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();


                   





            }
            catch
            {
                Response.Redirect("Default.aspx");
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string btch = GridView1.SelectedRow.Cells[1].Text;
            string course = GridView1.SelectedRow.Cells[2].Text;
            string branch = GridView1.SelectedRow.Cells[3].Text;
            string yearsem = GridView1.SelectedRow.Cells[4].Text;
            string exname = GridView1.SelectedRow.Cells[5].Text;
            string subject = GridView1.SelectedRow.Cells[6].Text;
            string sid = GridView1.SelectedRow.Cells[7].Text;
            Session["batchname"] = btch;
            Session["coursename"] = course;
            Session["branchname"] = branch;
            Session["yearsem"] = yearsem;
           

            Session["stid"] = sid;
            Session["examname"] = exname;
            Session["testsubject"] = subject;
          




            c1.InsDelup("insert into org_student_exam_temp (student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name,exam) select student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name,exam from org_student_exam where set_id='" + sid + "' and org_name='" + org + "' ");
            c1.InsDelup("delete from org_student_exam where set_id='" + sid+ "' and org_name='" + org + "'");




            Response.Redirect("../org_test_question_analysis.aspx");
            
        }
    }
}