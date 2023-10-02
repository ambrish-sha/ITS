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
    public partial class org_student_test_result : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        string name = "";

        string setid = "";
        string student_id = "";
        int at_no = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            try
            {
                if (IsPostBack != true)
                {
                    Session["curques"] = 1;
                    sectionwiseresult.Visible = false;
                    setid = Session["stid"].ToString();
                    student_id = Session["id"].ToString();

                    if (at_no == 0)
                    {
                        Response.Redirect("Default.aspx");
                    }


                   


                    string sql3 = "Select exam_name,subject,total_marks From org_exam_set_info Where set_id = '" + setid + "' and org_name='"+org+"' ";
                    con.Open();
                    SqlCommand comm3 = new SqlCommand(sql3, con);
                    SqlDataReader reader3 = comm3.ExecuteReader();
                    reader3.Read();

                    if (reader3.HasRows)
                    {

                        examname.Text = ename;
                        subjectname.Text = esub;
                        setidno.Text = "Set Id: " + setid;
                        Label1.Text = reader3["total_marks"].ToString();

                    }
                    con.Close();







                    //examname.Text = "Exam Name: " + c1.Fillstring("Select exam_name From exam_set_info Where set_id='" + setid + "' ");
                    //subjectname.Text = "Subject Name: " + c1.Fillstring("Select subject From exam_set_info Where set_id='" + setid + "' ");

                    //Label1.Text = c1.Fillstring("Select total_marks From exam_set_info Where set_id='" + setid + "' ");


                    // int min = int.Parse(c1.Fillstring("Select total_minut From exam_set_info Where set_id='" + setid + "' "));
                    // int rmt = int.Parse(c1.Fillstring("Select remaning_min From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + ""));
                    // timetake.Text = (min - rmt).ToString();
                    //// Label2.Text = c1.Fillstring("Select obtain_marks From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");
                    //Label3.Text = c1.Fillstring("Select correct_answer From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");
                    //Label4.Text = c1.Fillstring("Select wrong_answer From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");
                    //Label5.Text = c1.Fillstring("Select un_answer From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");




                    string sql1 = "Select total_marks,obtain_marks,correct_answer,wrong_answer,un_answer,remaning_min From org_student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'  and examname='" + ename + "' and subjectname='" + esub + "'";
                    con.Open();
                    SqlCommand comm1 = new SqlCommand(sql1, con);
                    SqlDataReader reader1 = comm1.ExecuteReader();
                    reader1.Read();
                    if (reader1.HasRows)
                    {

                       
                        Label2ym.Text = reader1["obtain_marks"].ToString();
                        corans.Text = reader1["correct_answer"].ToString();
                        wroans.Text = reader1["wrong_answer"].ToString();
                        naans.Text = reader1["un_answer"].ToString();
                        //tmtk.Text = reader1["remaning_min"].ToString() + " Minutes";

                    }
                    con.Close();




















                    //string sql1 = "Select exam_name, subject,topic,exam_cat,total_marks,total_minut,correct_marks,wrong_marks from exam_set_info Where  set_id='" + setid + "' ";
                    //con.Open();
                    //SqlCommand comm1 = new SqlCommand(sql1, con);
                    //SqlDataReader reader1 = comm1.ExecuteReader();
                    //reader1.Read();
                    //if (reader1.HasRows)
                    //{






                    //    int ts = int.Parse(reader1["exam_cat"].ToString());

                    //    float tmk = float.Parse(reader1["total_marks"].ToString());


                    //    con.Close();
                    //    //SqlCommand com1 = new SqlCommand("select distinct(subject) from question_paper where set_id='"+setid+"' ", con);

                    //    SqlCommand com1 = new SqlCommand("select subject,MIN(q_no) as qno from question_paper where set_id='" + setid + "' group by subject order by qno asc", con);


                    //    con.Open();
                    //    SqlDataAdapter sda = new SqlDataAdapter(com1);
                    //    DataTable dt = new DataTable();
                    //    sda.Fill(dt);
                    //    GridView1.DataSource = dt;
                    //    GridView1.DataBind();
                    //    con.Close();


                    //    foreach (GridViewRow row in GridView1.Rows)
                    //    {


                    //        Label lbl = (Label)row.FindControl("Label2");
                    //        string sub = lbl.Text;
                    //        int qe = int.Parse(c1.Fillstring("Select min(q_no) From question_paper Where set_id='" + setid + "' and subject='" + sub + "' "));
                    //        Label fq = (Label)row.FindControl("fromques");
                    //        fq.Text = qe.ToString();

                    //        int ql = int.Parse(c1.Fillstring("Select max(q_no) From question_paper Where set_id='" + setid + "' and subject='" + sub + "' "));
                    //        Label fl = (Label)row.FindControl("toques");
                    //        fl.Text = ql.ToString();

                    //        Label tot = (Label)row.FindControl("totques");
                    //        int x = ql - qe + 1;
                    //        tot.Text = x.ToString();

                    //        float totmark = int.Parse(c1.Fillstring("Select sum(correct_marks) From question_paper Where set_id='" + setid + "' and subject='" + sub + "' "));
                    //        Label ttm = (Label)row.FindControl("totmark");
                    //        ttm.Text = totmark.ToString();


                    //        at_no = int.Parse(Session["attno"].ToString());

                    //        int noanscount = int.Parse(c1.Fillstring("select count(answer) from question_paper as qp join student_exam_temp as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "'and answer='' ")) + int.Parse(c1.Fillstring("select count(isnull(answer,0)) from question_paper as qp join student_exam_temp as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "'and answer is null "));
                    //        Label noans = (Label)row.FindControl("totnoans");
                    //        noans.Text = noanscount.ToString();


                    //        int anscount = x - noanscount;
                    //        Label ttans = (Label)row.FindControl("totans");
                    //        ttans.Text = anscount.ToString();


                    //        int cno = 0;
                    //        int wno = 0;
                    //        int uno = 0;
                    //        float marks = 0;
                    //        int k;
                    //        for (k = qe; k <= ql; k++)
                    //        {
                    //            //string crr = c1.Fillstring("select qp.correct_option from question_paper as qp join student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "' and qp.q_no="+k+" ");
                    //            //string ans = c1.Fillstring("select se.answer from question_paper as qp join student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "'and qp.q_no=" + k + " ");
                    //            //float c_marks = float.Parse(c1.Fillstring("select qp.correct_marks from question_paper as qp join student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "' and qp.q_no=" + k + " "));
                    //            //float w_marks = float.Parse(c1.Fillstring("select qp.wrong_marks from question_paper as qp join student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "' and qp.q_no=" + k + " "));

                    //            string crr = c1.Fillstring("select correct_option from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                    //            string ans = c1.Fillstring("select answer from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                    //            float c_marks = float.Parse(c1.Fillstring("select correct_marks from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));
                    //            float w_marks = float.Parse(c1.Fillstring("select wrong_marks from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));


                    //            if (ans != "")
                    //            {
                    //                if (ans == crr)
                    //                {
                    //                    cno += 1;
                    //                    marks += c_marks;
                    //                }
                    //                else
                    //                {
                    //                    wno += 1;
                    //                    marks -= w_marks;
                    //                }


                    //            }
                    //            else
                    //            {
                    //                uno += 1;
                    //            }

                    //        }


                    //        Label crno = (Label)row.FindControl("corans");
                    //        crno.Text = cno.ToString();

                    //        Label wrno = (Label)row.FindControl("wrans");
                    //        wrno.Text = wno.ToString();

                    //        Label yrmk = (Label)row.FindControl("yourmark");
                    //        float mrk1 = (float)Math.Round(marks * 100f) / 100f;
                    //        yrmk.Text = mrk1.ToString();
                    //        //change marks







                    //    }










                    //    int totnoans = int.Parse(c1.Fillstring("select count(answer) from question_paper as qp join student_exam_temp as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and  answer='' ")) + int.Parse(c1.Fillstring("select count(isnull(answer,0)) from question_paper as qp join student_exam_temp as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and answer is null "));

                    //    int totans = ts - totnoans;


                    //    GridView1.FooterRow.Cells[4].Text = ts.ToString();
                    //    GridView1.FooterRow.Cells[9].Text = tmk.ToString();
                    //    GridView1.FooterRow.Cells[5].Text = totans.ToString();
                    //    GridView1.FooterRow.Cells[6].Text = totnoans.ToString();

                    //    int cno1 = 0;
                    //    int wno1 = 0;
                    //    float marks1 = 0;
                    //    int k1;
                    //    for (k1 = 1; k1 <= ts; k1++)
                    //    {
                    //        string crr = c1.Fillstring("select correct_option from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                    //        string ans = c1.Fillstring("select answer from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                    //        float c_marks = float.Parse(c1.Fillstring("select correct_marks from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));
                    //        float w_marks = float.Parse(c1.Fillstring("select wrong_marks from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

                    //        if (ans != "")
                    //        {
                    //            if (ans == crr)
                    //            {

                    //                marks1 += c_marks;
                    //                cno1 += 1;
                    //            }
                    //            else
                    //            {

                    //                marks1 -= w_marks;
                    //                wno1 += 1;
                    //            }


                    //        }
                    //        else
                    //        {

                    //        }

                    //    }

                    //    GridView1.FooterRow.Cells[7].Text = cno1.ToString();
                    //    GridView1.FooterRow.Cells[8].Text = wno1.ToString();
                    //    //change marks

                    //    float mrk = (float)Math.Round(marks1 * 100f) / 100f;
                    //    GridView1.FooterRow.Cells[10].Text = mrk.ToString();
                    //    Label2ym.Text = mrk.ToString();
                    //    int i = 1;
                    //    foreach (GridViewRow row in GridView1.Rows)
                    //    {
                    //        Label lbl = (Label)row.FindControl("Label1");
                    //        lbl.Text = i.ToString();
                    //        i++;
                    //    }








                    //}



















                }
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }
        }



        




        protected void Button1_Click(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            student_id = Session["id"].ToString();
            c1.InsDelup("insert into org_student_exam_temp (student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name,exam) select student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj,org_name,exam from org_student_exam where student_id='" + student_id + "' and org_name='"+org+"' ");

            c1.InsDelup("delete from org_student_exam where student_id='" + student_id + "' and org_name='"+org+"'");
            


            Response.Redirect("org_student_home.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            string crr = "";
            string ans = "";
            float c_marks = 0;
            float w_marks = 0;
            sectionwiseresult.Visible = true;
            //Session["attno"] = attemptnumber.SelectedValue;
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            
            //examname.Text = "Exam Name: " + c1.Fillstring("Select exam_name From exam_set_info Where set_id='" + setid + "' ");
            //subjectname.Text = "Subject Name: " + c1.Fillstring("Select subject From exam_set_info Where set_id='" + setid + "' ");
            //setidno.Text = "Set Id: " + setid;
            //Label1.Text = c1.Fillstring("Select total_marks From exam_set_info Where set_id='" + setid + "' ");
            //int  min = int.Parse(c1.Fillstring("Select total_minut From exam_set_info Where set_id='" + setid + "' "));
            //int rmt = int.Parse(c1.Fillstring("Select remaning_min From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + ""));
            //timetake.Text = (min - rmt).ToString();
            // //Label2.Text = c1.Fillstring("Select obtain_marks From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");
            //Label3.Text = c1.Fillstring("Select correct_answer From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");
            //Label4.Text = c1.Fillstring("Select wrong_answer From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");
            //Label5.Text = c1.Fillstring("Select un_answer From student_result Where student_id = '" + student_id + "' and set_id='" + setid + "' and attempt_no=" + at_no + "");

            string sql1 = "Select exam_name, subject,topic,exam_cat,total_marks,total_minut,correct_marks,wrong_marks from org_exam_set_info Where  set_id='" + setid + "' and org_name='"+org+"' ";
            con.Open();
            SqlCommand comm1 = new SqlCommand(sql1, con);
            SqlDataReader reader1 = comm1.ExecuteReader();
            reader1.Read();
            if (reader1.HasRows)
            {






                int ts = int.Parse(reader1["exam_cat"].ToString());







                float tmk = float.Parse(reader1["total_marks"].ToString());


                con.Close();
                //SqlCommand com1 = new SqlCommand("select distinct(subject) from question_paper where set_id='"+setid+"' ", con);

                SqlCommand com1 = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where org_name='"+org+"' and set_id='" + setid + "' group by subject order by qno asc", con);

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
                    int qe = int.Parse(c1.Fillstring("Select min(q_no) From org_question_paper Where org_name='"+org+"' and set_id='" + setid + "' and subject='" + sub + "' "));
                    Label fq = (Label)row.FindControl("fromques");
                    fq.Text = qe.ToString();

                    int ql = int.Parse(c1.Fillstring("Select max(q_no) From org_question_paper Where org_name='" + org + "' and set_id='" + setid + "' and subject='" + sub + "' "));
                    Label fl = (Label)row.FindControl("toques");
                    fl.Text = ql.ToString();

                    Label tot = (Label)row.FindControl("totques");
                    int x = ql - qe + 1;
                    tot.Text = x.ToString();

                    float totmark = int.Parse(c1.Fillstring("Select sum(correct_marks) From org_question_paper Where org_name='" + org + "' and set_id='" + setid + "' and subject='" + sub + "' "));
                    Label ttm = (Label)row.FindControl("totmark");
                    ttm.Text = totmark.ToString();


                    at_no = int.Parse(Session["attno"].ToString());

                    int noanscount = int.Parse(c1.Fillstring("select count(answer) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and se.org_name='" + org + "' and qp.org_name='" + org + "' and qp.set_id='" + setid + "' and  qp.subject='" + sub + "'and answer='' ")) + int.Parse(c1.Fillstring("select count(isnull(answer,0)) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.org_name='"+org+"' and qp.org_name='"+org+"' and se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and  qp.subject='" + sub + "'and answer is null "));
                    Label noans = (Label)row.FindControl("totnoans");
                    noans.Text = noanscount.ToString();


                    int anscount = x - noanscount;
                    Label ttans = (Label)row.FindControl("totans");
                    ttans.Text = anscount.ToString();


                    int cno = 0;
                    int wno = 0;
                    int uno = 0;
                    float marks = 0;
                    int k;
                    for (k = qe; k <= ql; k++)
                    {

                        string sql3 = "select correct_option,answer,correct_marks,wrong_marks from org_student_exam Where q_no = " + k + " and student_id = '" + student_id + "' and org_name='"+org+"' and set_id = '" + setid + "' ";
                        con.Open();
                        SqlCommand comm3 = new SqlCommand(sql3, con);
                        SqlDataReader reader3 = comm3.ExecuteReader();
                        reader3.Read();

                        if (reader3.HasRows)
                        {

                            crr = reader3["correct_option"].ToString();
                            ans = reader3["answer"].ToString();
                            c_marks = float.Parse(reader3["correct_marks"].ToString());
                            w_marks = float.Parse(reader3["wrong_marks"].ToString());


                        }
                        con.Close();



                        //crr = c1.Fillstring("select correct_option from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                        //ans = c1.Fillstring("select answer from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                        //c_marks = float.Parse(c1.Fillstring("select correct_marks from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));
                        //w_marks = float.Parse(c1.Fillstring("select wrong_marks from student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

                        if (ans != "")
                        {
                            if (ans == crr)
                            {
                                cno += 1;
                                marks += c_marks;
                            }
                            else
                            {
                                wno += 1;
                                marks -= w_marks;
                            }


                        }
                        else
                        {
                            uno += 1;
                        }

                    }


                    Label crno = (Label)row.FindControl("corans");
                    crno.Text = cno.ToString();

                    Label wrno = (Label)row.FindControl("wrans");
                    wrno.Text = wno.ToString();

                    Label yrmk = (Label)row.FindControl("yourmark");
                    float mrk1 = (float)Math.Round(marks * 100f) / 100f;
                    yrmk.Text = mrk1.ToString();






                }
                int totnoans = int.Parse(c1.Fillstring("select count(answer) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and  se.org_name='" + org + "' and qp.org_name='" + org + "' and qp.set_id='" + setid + "' and   answer='' ")) + int.Parse(c1.Fillstring("select count(isnull(answer,0)) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.org_name='" + org + "' and qp.org_name='" + org + "' and se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and  answer is null "));

                int totans = ts - totnoans;


                GridView1.FooterRow.Cells[4].Text = ts.ToString();
                GridView1.FooterRow.Cells[9].Text = tmk.ToString();
                GridView1.FooterRow.Cells[5].Text = totans.ToString();
                GridView1.FooterRow.Cells[6].Text = totnoans.ToString();
                GridView1.FooterRow.Cells[7].Text = c1.Fillstring("Select correct_answer From org_student_result Where org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "' ");
                GridView1.FooterRow.Cells[8].Text = c1.Fillstring("Select wrong_answer From org_student_result Where  org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'");


                int cno1 = 0;
                int wno1 = 0;
                float marks1 = 0;
                int k1;
                for (k1 = 1; k1 <= ts; k1++)
                {



                    string sql3 = "select correct_option,answer,correct_marks,wrong_marks from org_student_exam Where  org_name='" + org + "' and q_no = " + k1 + " and student_id = '" + student_id + "' and set_id = '" + setid + "' ";
                    con.Open();
                    SqlCommand comm3 = new SqlCommand(sql3, con);
                    SqlDataReader reader3 = comm3.ExecuteReader();
                    reader3.Read();

                    if (reader3.HasRows)
                    {

                        crr = reader3["correct_option"].ToString();
                        ans = reader3["answer"].ToString();
                        c_marks = float.Parse(reader3["correct_marks"].ToString());
                        w_marks = float.Parse(reader3["wrong_marks"].ToString());


                    }
                    con.Close();











                    //string crr = c1.Fillstring("select correct_option from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                    //string ans = c1.Fillstring("select answer from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                    //float c_marks = float.Parse(c1.Fillstring("select correct_marks from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));
                    //float w_marks = float.Parse(c1.Fillstring("select wrong_marks from student_exam_temp Where q_no = " + k1 + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

                    if (ans != "")
                    {
                        if (ans == crr)
                        {

                            marks1 += c_marks;
                            cno1 += 1;
                        }
                        else
                        {

                            marks1 -= w_marks;
                            wno1 += 1;
                        }


                    }
                    else
                    {

                    }

                }

                GridView1.FooterRow.Cells[7].Text = cno1.ToString();
                GridView1.FooterRow.Cells[8].Text = wno1.ToString();




                float mrk = (float)Math.Round(marks1 * 100f) / 100f;
                GridView1.FooterRow.Cells[10].Text = mrk.ToString();
                //Label2ym.Text = mrk.ToString();


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
}