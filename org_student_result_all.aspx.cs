using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI.DataVisualization.Charting;

namespace ITS
{
    public partial class org_student_result_all : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {
                getcourse();
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
               

                DateTime dt = DateTime.Now;
                string curdt = dt.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string st = c1.Fillstring("select count(*) from org_exam_schedule where org_name = '" + org + "' and endtime > '" + curdt + "' ");


                if (st == "0")
                {
                    transfer.Visible = true;
                }
                else
                {
                    transfer.Visible = false;
                }


            }
        }
        protected void getcourse()
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            SqlCommand com = new SqlCommand("select batch_name from org_batchname where org_name='" + org + "' and user_type='" + utype + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            batchlist2.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist2.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist2.DataBind();
            batchlist2.Items.Insert(0, "Select");



        }

        protected void batchlist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlist2.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            courselist2.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            courselist2.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            courselist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            courselist2.DataBind();
            courselist2.Items.Insert(0, "Select");
        }

        protected void cmplist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = courselist2.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            branchlist2.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            branchlist2.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            branchlist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            branchlist2.DataBind();
            branchlist2.Items.Insert(0, "Select");
        }

        protected void branchlist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = courselist2.Text;
            string branch = branchlist2.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and branch_name='" + branch + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist2.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist2.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            yearsemlist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            yearsemlist2.DataBind();
            yearsemlist2.Items.Insert(0, "Select");
        }

        protected void semid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = courselist2.Text;
            string branch = branchlist2.Text;
            string ys = yearsemlist2.Text;
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + comp + "' and branch_name='" + branch + "' and yearsem='" + ys + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            examnamelist2.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            examnamelist2.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            examnamelist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            examnamelist2.DataBind();
            examnamelist2.Items.Insert(0, "Select");
        }

        protected void examnamelist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsm = yearsemlist2.Text;
            string en = examnamelist2.Text;
            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsm + "'  and org_name='" + org + "' and exam_name='" + en + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            subjectlist2.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
            subjectlist2.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
            // to retrive specific  textfield name   
            subjectlist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            subjectlist2.DataBind();
            subjectlist2.Items.Insert(0, "Select");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsm = yearsemlist2.Text;
            string en = examnamelist2.Text;
            string sub = subjectlist2.Text;

            if (org != "" && btch != "" && course != "" && branch != "" && yearsm != "" && en != "" && sub != "")
            {
                SqlCommand com1 = new SqlCommand("select sr.batch_name as Batch,sr.course as Course,sr.branch as Branch,sr.yearsem as YearOrSem,sr.student_id as RollNo,si.st_name as Name, sr.examname as ExamName,sr.subjectname as SubjectName,sr.set_id as SetID, sr.total_marks as TotalMarks,sr.obtain_marks as ObtainMarks,sr.correct_answer as CorrectAnswer, sr.wrong_answer as WrongAnswer, sr.un_answer as NotAttempt, sr.atendance as Attendance,sr.submitexam_time as SubmitExamTime,opencount as OpenExamCount  from org_student_result as sr,org_student_info as si Where  sr.student_id=si.st_rollno and sr.course ='" + course + "' and sr.branch ='" + branch + "' and sr.yearsem ='" + yearsm + "'  and sr.org_name='" + org + "' and sr.org_name=si.org_name and sr.batch_name='" + btch + "' and sr.examname='" + en + "' and sr.subjectname='" + sub + "' ", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();


               
            }
            else
            {
                string message = "Select all Entry";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }

        protected void exceldownload_Click(object sender, EventArgs e)
        {
            
                ExportGridToExcel();
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        private void ExportGridToExcel()
        {
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GridView2.AllowPaging = false;

            //GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells
            //for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
            //{
            //    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            //}
            //GridView2.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();


            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "employeetestresult" + DateTime.Now + ".xls";
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

        protected void transfer_Click(object sender, EventArgs e)
        {

            string org = Session["orgname"].ToString();
            c1.InsDelup("insert into org_student_exam_temp (student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name,exam) select student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name,exam from org_student_exam where org_name='" + org + "' ");

            c1.InsDelup("delete from org_student_exam where org_name='" + org + "'");
            string message = "All Answer Key transfered Successfully";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stuid = GridView1.SelectedRow.Cells[5].Text;
            string org = Session["orgname"].ToString();
            string setid = GridView1.SelectedRow.Cells[9].Text;

            string af = ansfrom.Value;

            if (af == "cur")
            {

                SqlCommand com1 = new SqlCommand("select sno as Sno, student_id as StudentID, set_id as SetID,answer as StudentResponse, correct_option as CorrectOption,start_time as StartTime,submit_time as SubmitTime from org_student_exam where org_name='" + org + "' and student_id='" + stuid + "' and set_id='" + setid + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataBind();
                con.Close();
            }
            else if(af=="old")
            {
                SqlCommand com1 = new SqlCommand("select sno as Sno, student_id as StudentID, set_id as SetID,answer as StudentResponse, correct_option as CorrectOption,start_time as StartTime,submit_time as SubmitTime from org_student_exam_temp where org_name='" + org + "' and student_id='" + stuid + "' and set_id='" + setid + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView3.DataSource = rd;
                GridView3.DataBind();
                con.Close();
            }
        }

        protected void downanswerkey_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "StudentsTestAnswersheet" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView3.GridLines = GridLines.Both;
            GridView3.HeaderStyle.Font.Bold = true;
            GridView3.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}