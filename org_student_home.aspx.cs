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
    public partial class org_student_home : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string roll = Session["stuid"].ToString();
            string org = Session["orgname"].ToString();
            DateTime dt = DateTime.Now;
            try
            {

                if (org != "")
                {
                    card1.InnerText = c1.Fillstring("Select count(sno) From org_student_result Where org_name ='" + org + "' and student_id='"+roll+"' ");
                    card2.InnerText = c1.Fillstring("Select count(sno) From org_student_result Where org_name ='" + org + "' and student_id='" + roll + "' and atendance='Present' ");
                    card3.InnerText = c1.Fillstring("Select count(sno) From org_student_result Where org_name ='" + org + "' and student_id='" + roll + "'and atendance = 'Absent' and '" + dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' > linkclosetime ");
                    card4.InnerText = c1.Fillstring("Select count(sno) From org_student_result Where org_name ='" + org + "' and student_id='" + roll + "' and atendance = 'Absent' and '"+dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' between linkopentime and linkclosetime ");
                    card5.InnerText = c1.Fillstring("Select avg(obtain_marks) From org_student_result Where org_name ='" + org + "' and student_id='" + roll + "' and atendance='Present' ");
                    card6.InnerText = c1.Fillstring("Select avg(total_marks) From org_student_result Where org_name ='" + org + "' and student_id='" + roll + "' and atendance='Present' ");
                porg.InnerText ="Organization/Institute:  "+org;
                pid.InnerText = "User Id:  " + roll;
                pname.InnerText = "Name:  " + c1.Fillstring("Select st_name From org_student_info Where org_name ='" + org + "' and st_rollno='" + roll + "' ");
                pbatch.InnerText = "Batch:  " + c1.Fillstring("Select st_batch From org_student_info Where org_name ='" + org + "' and st_rollno='" + roll + "' ");

                pcourse.InnerText = "Course:  " + c1.Fillstring("Select st_course From org_student_info Where org_name ='" + org + "' and st_rollno='" + roll + "' ");
               
                pbranch.InnerText = "Branch/Stream:  " + c1.Fillstring("Select st_branch From org_student_info Where org_name ='" + org + "' and st_rollno='" + roll + "' ");
                pyearsem.InnerText = "Year/Sem:  " + c1.Fillstring("Select st_yearsem From org_student_info Where org_name ='" + org + "' and st_rollno='" + roll + "' ");



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
    }
}