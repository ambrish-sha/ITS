using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data;

namespace ITS
{
    public partial class org_student_test_instruction : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        string name = "";
        string setid = "";
        string student_email = "";
        int attempt;
        int totques;
        int totmarks;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["curques"] = 1;
            string ename=Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            try
            {
                setid = Session["stid"].ToString();
                student_email = Session["id"].ToString();
                //setid = Request.QueryString["stid"];
                //student_email = Request.QueryString["id"];
                attempt = int.Parse(c1.Fillstring("Select count(*) from org_student_result Where student_id = '" + student_email + "' and set_id='" + setid + "' and examname='"+ename+"' and subjectname='"+esub+"' and org_name='"+org+"' "));
                int min = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "'  "));

                Session["remmin"] = min.ToString();
                if (IsPostBack != true)
                {



                    string l;
                    l = c1.Fillstring("Select examstatus From org_student_result Where set_id='" + setid + "'and student_id='" + student_email + "' and examname='" + ename + "' and subjectname='" + esub + "' and org_name='" + org + "' ");




                    if (l == "Finish")
                    {
                        Response.Redirect("org_student_exam_list.aspx");
                    }

                    else if (l == "Exam Runing")
                    {
                       int oc  = int.Parse(c1.Fillstring("Select opencount  From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and examname='" + ename + "' and subjectname='" + esub + "' and student_id='" + student_email + "'  "));

                        //DateTime dt = DateTime.Now;
                        oc = oc + 1;
                        c1.InsDelup("update org_student_result set opencount=" + oc+ " where student_id = '" + student_email + "' and examname='" + ename + "' and subjectname='" + esub + "' and org_name='" + org + "'");

                        Response.Redirect("org_student_test.aspx");
                    }
                    else
                    {

                        Session["attno"] = attempt.ToString();
                        attemptno.Text = "Attempt No:  " + attempt;
                        name = c1.Fillstring("Select st_name from org_student_info Where st_rollno = '" + student_email + "' and org_name='"+org+"' ");
                        string sql1 = "Select exam_name, subject,topic,exam_cat,total_marks,total_minut,correct_marks,wrong_marks from org_exam_set_info Where  set_id='" + setid + "' and org_name='" + org + "' ";
                        con.Open();
                        SqlCommand comm1 = new SqlCommand(sql1, con);
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        reader1.Read();
                        if (reader1.HasRows)
                        {

                            studentid.Text = "Candidate ID:  " + student_email;
                            studentname.Text = "Candidate Name:  " + name;
                            subjectname.Text = "Subject:  " + reader1["subject"].ToString();
                            correctmarks.Text = "Marks for Correct:  " + reader1["correct_marks"].ToString();
                            wrongmarks.Text = "Marks for wrong:  " + reader1["wrong_marks"].ToString();
                            remtime.Text = "Exam Duration:  " + reader1["total_minut"].ToString() + "Minutes";
                            examname.Text = "Exam Name:  " + reader1["exam_name"].ToString();
                            topic.Text = "Topic Name:  " + reader1["topic"].ToString();

                            Session["remtime"] = reader1["total_minut"].ToString() + ":" + "00";
                            Session["curques"] = "1";

                            Label12.Text = reader1["exam_cat"].ToString();
                            int ts = int.Parse(reader1["exam_cat"].ToString());
                            totalques.Text = "Total Question:  " + reader1["exam_cat"].ToString();
                            Label13.Text = reader1["total_marks"].ToString();
                            float tmk = float.Parse(reader1["total_marks"].ToString());
                            totalmarks.Text = "Total Marks:  " + reader1["total_marks"].ToString();
                            startexam.Enabled = false;

                            con.Close();
                            //SqlCommand com1 = new SqlCommand("select distinct(subject) from org_question_paper where set_id='"+setid+"' ", con);

                            SqlCommand com1 = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where set_id='" + setid + "' and org_name='" + org + "' group by subject order by qno asc", con);

                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter(com1);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            con.Close();


                            foreach (GridViewRow row in GridView1.Rows)
                            {


                                Label lbl = (Label)row.FindControl("Label2");
                                string sub = lbl.Text;
                                int qe = int.Parse(c1.Fillstring("Select min(q_no) From org_question_paper Where set_id='" + setid + "' and org_name='" + org + "' and subject='" + sub + "' "));
                                Label fq = (Label)row.FindControl("fromques");
                                fq.Text = qe.ToString();

                                int ql = int.Parse(c1.Fillstring("Select max(q_no) From org_question_paper Where set_id='" + setid + "' and org_name='" + org + "' and subject='" + sub + "' "));
                                Label fl = (Label)row.FindControl("toques");
                                fl.Text = ql.ToString();

                                Label tot = (Label)row.FindControl("totques");
                                int x = ql - qe + 1;
                                tot.Text = x.ToString();

                                float totmark = int.Parse(c1.Fillstring("Select sum(correct_marks) From org_question_paper Where set_id='" + setid + "' and org_name='" + org + "' and subject='" + sub + "' "));
                                Label ttm = (Label)row.FindControl("totmark");
                                ttm.Text = totmark.ToString();

                            }



                            GridView1.FooterRow.Cells[4].Text = ts.ToString();
                            GridView1.FooterRow.Cells[5].Text = tmk.ToString();




                            int i = 1;
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                Label lbl = (Label)row.FindControl("Label1");
                                lbl.Text = i.ToString();
                                i++;
                            }









                        }

                    }
                }

                else
                {
                    string l;
                    l = c1.Fillstring("Select examstatus  From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and examname='" + ename + "' and subjectname='" + esub + "' and student_id='" + student_email + "'  ");

                    if (l == "Finish")
                    {
                        Response.Redirect("org_student_exam_list.aspx");
                    }

                    else if (l == "Exam Runing")
                    {
                        //DateTime dt = DateTime.Now;

                        //c1.InsDelup("update org_student_result set date='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where student_id = '" + student_email + "' and examname='" + ename + "' and subjectname='" + esub + "' and org_name='" + org + "'");

                        Response.Redirect("org_student_test.aspx");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("studenthome.aspx"); 
                Response.Write(ex);
                //Response.Redirect(Session["RefUrl"].ToString());
            }
        }


        private int get_qid(int sno, string set_id)
        {
            string org = Session["orgname"].ToString();
            int id;
            id = int.Parse(c1.Fillstring("Select q_id From org_question_paper Where q_no = " + sno + " and org_name='" + org + "' and set_id = '" + set_id + "' "));

            return id;
        }

        protected void startexam_Click(object sender, EventArgs e)
        {
            Session["curques"] = 1;
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            int question_id;
            float cm;
            float wm;
            int qe, ql;
            setid = Session["stid"].ToString();
            student_email = Session["id"].ToString();

            totques = int.Parse(Label12.Text);
            totmarks = int.Parse(Label13.Text);

            string t;
            t = c1.Fillstring("Select examstatus From org_student_result Where set_id='" + setid + "'and student_id='" + student_email + "' and examname='" + ename + "' and subjectname='" + esub + "' and org_name='" + org + "' ");




            if (t == "Finish")
            {
                Response.Redirect("org_student_exam_list.aspx");
            }

            else if (t == "Exam runing")
            {
                //DateTime dt = DateTime.Now;

                //c1.InsDelup("update org_student_result set date='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where student_id = '" + student_email + "' and examname='" + ename + "' and subjectname='" + esub + "' and org_name='" + org + "'");

                Response.Redirect("org_student_test.aspx");
            }

            else
            {





                string status = "Started";




                foreach (GridViewRow row in GridView1.Rows)
                {

                    Label lbl = (Label)row.FindControl("Label2");
                    string sub = lbl.Text;

                    string sql1 = "Select min(q_no) as minqno,max(q_no) as maxqno From org_question_paper Where set_id = '" + setid + "' and org_name='" + org + "' and subject = '" + sub + "' ";
                    con.Open();
                    SqlCommand comm1 = new SqlCommand(sql1, con);
                    SqlDataReader reader1 = comm1.ExecuteReader();
                    reader1.Read();
                    //if (reader1.HasRows)
                    //{

                    qe = int.Parse(reader1["minqno"].ToString());
                    ql = int.Parse(reader1["maxqno"].ToString());
                    reader1.Close();
                    // }
                    con.Close();


                    //qe = int.Parse(c1.Fillstring("Select min(q_no) From org_question_paper Where set_id='" + setid + "' and subject='" + sub + "' "));

                    //ql = int.Parse(c1.Fillstring("Select max(q_no) From org_question_paper Where set_id='" + setid + "' and subject='" + sub + "' "));


                    Random r = new Random();
                    int qno = r.Next(qe, ql);
                    for (int l = qe; l <= ql; l++)
                    {



                        string sql2 = "Select q_id,correct_marks,wrong_marks From org_question_paper Where q_no = " + l + " and org_name='" + org + "' and set_id = '" + setid + "' ";
                        con.Open();
                        SqlCommand comm2 = new SqlCommand(sql2, con);
                        SqlDataReader reader3 = comm2.ExecuteReader();
                        reader3.Read();
                        //if (reader1.HasRows)
                        //{

                        question_id = int.Parse(reader3["q_id"].ToString());
                        cm = float.Parse(reader3["correct_marks"].ToString());
                        wm = float.Parse(reader3["wrong_marks"].ToString());
                        // }
                        reader3.Close();
                        con.Close();


                        //question_id = int.Parse(c1.Fillstring("Select q_id From org_question_paper Where q_no = " + l + " and set_id = '" + setid + "' "));
                        //cm = float.Parse(c1.Fillstring("Select correct_marks From org_question_paper Where q_no = " + l + " and set_id = '" + setid + "' "));
                        //wm = float.Parse(c1.Fillstring("Select wrong_marks From org_question_paper Where q_no = " + l + " and set_id = '" + setid + "' "));
                        c1.InsDelup("insert into org_student_exam(student_id,set_id,attemp_no,q_no,q_id,correct_marks,wrong_marks,sno,total_time_take,ques_mark,subj,org_name) Values( '" + student_email + "','" + setid + "',1," + qno + "," + question_id + "," + cm + "," + wm + "," + l + ",0,'N','" + sub + "','" + org + "') ");

                        qno = qno + 1;

                        if (qno > ql)
                        {
                            qno = qe;
                        }

                    }




                }




                DateTime dt = DateTime.Now;

                c1.InsDelup("update org_student_result set attempt_no=1,opencount=1,examstatus='" + status + "', atendance = 'Present' , date='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where student_id = '" + student_email + "' and examname='" + ename + "' and subjectname='" + esub + "' and org_name='" + org + "'");

                //setid = Request.QueryString["stid"];
                // student_email = Request.QueryString["id"];



                Session["curques"] = 1;
                startexam.Enabled = false;
                //Response.Write("<script>window.open('org_student_test.aspx','_blank')</script>");
                Response.Redirect("org_student_test.aspx");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                startexam.Enabled = true;
            }
            else
            {
                startexam.Enabled = false;
            }
        }
    }
}