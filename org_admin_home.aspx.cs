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
    public partial class org_admin_home : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
            string org = Session["orgname"].ToString();

           

                if (org != "")
                {
                    card1.InnerText = c1.Fillstring("Select count(sno) From org_student_info Where org_name ='" + org + "' ");
                    card2.InnerText = c1.Fillstring("Select count(sno) From org_question_bank Where org_name ='" + org + "' ");
                    card3.InnerText = c1.Fillstring("select count(p.set_id) from (Select distinct(set_id) From org_question_paper Where org_name ='" + org + "') as p ");
                    card4.InnerText = c1.Fillstring("Select count(sno) From org_exam_schedule Where org_name ='" + org + "' ");
                    card5.InnerText = c1.Fillstring("Select count(sno) From org_student_result Where org_name ='" + org + "' and atendance='Present' ");
                    card6.InnerText = c1.Fillstring("Select count(sno) From org_student_result Where org_name ='" + org + "' and atendance='Absent' ");
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