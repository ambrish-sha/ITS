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
using System.Net.Mail;
using System.Text;
using System.Globalization;

namespace ITS
{
    public partial class org_student_test : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        string name = "";
        int qstart;
        int qend;
        string setid = "";
        string student_id = "";
      
        float cm;
        float wm;

        string answer = "";


        int min;
        static int sec = 00;

        private void getquestion(int n, int s)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            Session["curques"] = s;
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
          
            string ai = "", bi = "", ci = "", di = "", emp = "", empurl = "";
            string a = "", b = "", c = "", d = "", t = "", desc = "", url = "", qimage = "";
            int x = 1;

            if (Panel2.FindControl("btn" + s.ToString()) != null)
            {
                Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                button.Focus();


            }


            string im = c1.Fillstring("Select image from emptyimage Where id = " + x + " ");
            if (im != "")
            {

                string sql = "Select image from emptyimage Where id = " + x + "  ";
                con.Open();
                SqlCommand comm = new SqlCommand(sql, con);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    emp = Convert.ToBase64String(img, 0, img.Length);
                    empurl = string.Format("data:image/png;base64," + emp);

                }
                con.Close();
            }


            //ai = bi = ci = di = url = empurl;


            Label1.Text = s.ToString();
            string qtyp = c1.Fillstring("Select ques_type image from org_question_paper Where q_no = " + n + " and org_name='"+org+"' and set_id='" + setid + "' ");
            if (qtyp == "MCQ")
            {
                mcqtypeques.Visible = true;
                inputtypeques.Visible = false;
                string sql1 = "Select subject,correct_marks,wrong_marks, question,option_a,option_b,option_c,option_d,question_image,option_a_image,option_b_image,option_c_image,option_d_image  from org_question_paper Where q_no = " + n + " and  org_name='" + org + "' and set_id='" + setid + "' ";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows)
                {
                    subjectname.Text = reader1["subject"].ToString();
                    correctmarks.Text = "Marks for Correct: " + reader1["correct_marks"].ToString();
                    wrongmarks.Text = "Marks for Wrong: " + reader1["wrong_marks"].ToString();

                    questno.Text = "Question No: " + s;
                    t = reader1["question"].ToString();
                    a = " " + reader1["option_a"].ToString();
                    b = " " + reader1["option_b"].ToString();
                    c = " " + reader1["option_c"].ToString();
                    d = " " + reader1["option_d"].ToString();

                    im = reader1["question_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["question_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        url = string.Format("data:image/png;base64," + qimage);
                    }

                    im = reader1["option_a_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["option_a_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        ai = string.Format("data:image/png;base64," + qimage);
                    }

                    im = reader1["option_b_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["option_b_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        bi = string.Format("data:image/png;base64," + qimage);
                    }

                    im = reader1["option_c_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["option_c_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        ci = string.Format("data:image/png;base64," + qimage);
                    }

                    im = reader1["option_d_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["option_d_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        di = string.Format("data:image/png;base64," + qimage);
                    }

                }
                con.Close();

                // Response.Redirect(string.Format( "~/question.aspx?setid={0}&qno={1}",setid,n));

                //HtmlControl quesspace = (HtmlControl)this.FindControl("quesspace");
                // quesspace.Attributes["src"] = string.Format("~/question.aspx?setid={0}&qno={1}", setid, n);

                questxt.InnerText = t;
                Image1.ImageUrl = url;
                RadioButton1.Text = a;
                Image2.ImageUrl = ai;
                RadioButton2.Text = b;
                Image3.ImageUrl = bi;
                RadioButton3.Text = c;
                Image4.ImageUrl = ci;
                RadioButton4.Text = d;
                Image5.ImageUrl = di;
            }

            if (qtyp == "INPUT")
            {
                mcqtypeques.Visible = false;
                inputtypeques.Visible = true;
                string ihint = c1.Fillstring("Select input_hint image from org_question_paper Where q_no = " + n + " and org_name='" + org + "' and set_id='" + setid + "' ");
                hintinput.InnerText = "Hint:- " + ihint;



                string sql1 = "Select subject,correct_marks,wrong_marks, question,option_a,option_b,option_c,option_d,question_image,option_a_image,option_b_image,option_c_image,option_d_image  from org_question_paper Where q_no = " + n + " and org_name='" + org + "' and set_id='" + setid + "' ";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows)
                {
                    subjectname.Text = reader1["subject"].ToString();
                    correctmarks.Text = "Marks for Correct: " + reader1["correct_marks"].ToString();
                    wrongmarks.Text = "Marks for Wrong: " + reader1["wrong_marks"].ToString();

                    questno.Text = "Question No: " + s;
                    t = reader1["question"].ToString();


                    im = reader1["question_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["question_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        url = string.Format("data:image/png;base64," + qimage);
                    }


                }
                con.Close();

                // Response.Redirect(string.Format( "~/question.aspx?setid={0}&qno={1}",setid,n));

                //HtmlControl quesspace = (HtmlControl)this.FindControl("quesspace");
                // quesspace.Attributes["src"] = string.Format("~/question.aspx?setid={0}&qno={1}", setid, n);

                questxt.InnerText = t;
                Image1.ImageUrl = url;

            }

            // string text = "</head><body><p style='font-size:medium;'>" + t + "</p><img src='" + url + "'  width='100%' height='40%' alt='' onerror='this.onerror=null;'><p style='font-size:medium;'>  (A)." + a + " </p> <img src='" + ai + "'  width='50%' height='50%' alt='' onerror='this.onerror=null;'> <p style='font-size: medium;'>  (B)." + b + "</p><img src='" + bi + "'  width='50%' height='50%' alt='' onerror='this.onerror=null;'> <p style='font-size: medium;'>  (C)." + c + "</p><img src= '" + ci + "'  width='50%' height='50%' alt='' onerror='this.onerror=null;'><p style='font-size: medium;'>  (D)." + d + "</p><img src='" + di + "' alt='' onerror='this.onerror=null;'></body></html>  ";
            // quesspace.Attributes["srcdoc"] = text;
            DateTime dt = DateTime.Now;

            c1.InsDelup("update org_student_exam set start_time= '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where q_no = " + n + " and student_id = '" + student_id + "'  and org_name='" + org + "' and set_id='" + setid + "' ");


        }


        private void save_answer(int no, int s)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
          
            string qtp = c1.Fillstring("Select ques_type From org_question_paper Where q_no = " + no + " and org_name='" + org + "' and set_id='" + setid + "'");
            if (qtp == "MCQ")
            {
                if (RadioButton1.Checked == true)
                {

                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-success rounded-circle";

                    }
                    answer = "A";
                }
                else if (RadioButton2.Checked == true)
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-success rounded-circle";

                    }
                    answer = "B";
                }
                else if (RadioButton3.Checked == true)
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-success rounded-circle";

                    }
                    answer = "C";
                }
                else if (RadioButton4.Checked == true)
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-success rounded-circle";

                    }
                    answer = "D";
                }
                else
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-danger";

                    }
                    answer = "";
                }
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and org_name='" + org + "' and set_id='" + setid + "'");

                string anstype;
                if (answer == "")
                {
                    anstype = "NA";
                }
                else
                {
                    anstype = "SA";
                }
                DateTime dt = DateTime.Now;

                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam Where q_no=" + no + " and org_name='" + org + "' and set_id='" + setid + "'and student_id='" + student_id + "'  "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam Where q_no = " + no + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'  "));
                int tottime = prevtime + sec;

                c1.InsDelup("update org_student_exam set correct_option= '" + crr + "',answer='" + answer + "', total_time_take = " + tottime + " , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'  ");




                DateTime dt1 = DateTime.Now;
                DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' "));
                TimeSpan tt = dt1 - dc;
                int minut = int.Parse(tt.Minutes.ToString());

                int totrem =int.Parse(Session["remmin"].ToString());
                int rm = totrem - minut;
                c1.InsDelup("update org_student_result set  remaning_min=" + rm + " where student_id='" + student_id + "'and org_name='" + org + "' and  set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' ");


            }

            if (qtp == "INPUT")
            {
                answer = inputanswer.Text;
                if (answer == "")
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-danger";

                    }
                }
                else
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-success rounded-circle";

                    }
                }
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and org_name='" + org + "' and set_id='" + setid + "'");

                string anstype;
                if (answer == "")
                {
                    anstype = "NA";
                }
                else
                {
                    anstype = "SA";
                }
                DateTime dt = DateTime.Now;

                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam Where q_no=" + no + " and org_name='" + org + "' and set_id='" + setid + "'and student_id='" + student_id + "'  "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam Where q_no = " + no + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'  "));
                int tottime = prevtime + sec;
                c1.InsDelup("update org_student_exam set correct_option= '" + crr + "', total_time_take = " + tottime + ",answer='" + answer + "' , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='" + org + "' ");

                DateTime dt1 = DateTime.Now;
                DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' "));
                TimeSpan tt = dt1 - dc;
                int minut = int.Parse(tt.Minutes.ToString());

                int totrem = int.Parse(Session["remmin"].ToString());
                int rm = totrem - minut;
                c1.InsDelup("update org_student_result set  remaning_min=" + rm + " where student_id='" + student_id + "'and org_name='" + org + "' and  set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' ");



            }

        }


        private void save_answer1(int no, int s)

        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
           
            string qtp = c1.Fillstring("Select ques_type From org_question_paper Where q_no = " + no + " and org_name='" + org + "' and set_id='" + setid + "'");
            if (qtp == "MCQ")
            {

                if (RadioButton1.Checked == true)
                {

                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning rounded-circle";

                    }
                    answer = "A";
                }
                else if (RadioButton2.Checked == true)
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning rounded-circle";

                    }
                    answer = "B";
                }
                else if (RadioButton3.Checked == true)
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning rounded-circle";

                    }
                    answer = "C";
                }
                else if (RadioButton4.Checked == true)
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning rounded-circle";

                    }
                    answer = "D";
                }
                else
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning";

                    }
                    answer = "";
                }
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and org_name='" + org + "' and set_id='" + setid + "' ");


                string anstype;
                if (answer == "")
                {
                    anstype = "MNA";
                }
                else
                {
                    anstype = "MSA";
                }
                DateTime dt = DateTime.Now;
                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam Where q_no=" + no + " and org_name='" + org + "' and set_id='" + setid + "'and student_id='" + student_id + "'  "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam Where q_no = " + no + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'  "));
                int tottime = prevtime + sec;

                c1.InsDelup("update org_student_exam set correct_option= '" + crr + "', total_time_take = " + tottime + " ,answer='" + answer + "' , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id ='" + student_id + "' and org_name='" + org + "' and set_id='" + setid + "'  ");

                DateTime dt1 = DateTime.Now;
                DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' "));
                TimeSpan tt = dt1 - dc;
                int minut = int.Parse(tt.Minutes.ToString());

                int totrem = int.Parse(Session["remmin"].ToString());
                int rm = totrem - minut;
                c1.InsDelup("update org_student_result set  remaning_min=" + rm + " where student_id='" + student_id + "'and org_name='" + org + "' and  set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' ");

            }

            if (qtp == "INPUT")
            {
                answer = inputanswer.Text;
                if (answer == "")
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning";

                    }
                }
                else
                {
                    if (Panel2.FindControl("btn" + s.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + s.ToString());
                        button.CssClass = "btn btn-warning rounded-circle";

                    }
                }
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and org_name='" + org + "' and set_id='" + setid + "'");



                string anstype;
                if (answer == "")
                {
                    anstype = "MNA";
                }
                else
                {
                    anstype = "MSA";
                }
                DateTime dt = DateTime.Now;
                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam Where q_no=" + no + " and org_name='" + org + "' and set_id='" + setid + "'and student_id='" + student_id + "'  "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam Where q_no = " + no + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'  "));
                int tottime = prevtime + sec;


                DateTime dt1 = DateTime.Now;
                c1.InsDelup("update org_student_exam set correct_option= '" + crr + "' , total_time_take = " + tottime + " ,answer='" + answer + "' , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='" + org + "' ");
                DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' "));
                TimeSpan tt = dt1 - dc;
                int minut = int.Parse(tt.Minutes.ToString());

                int totrem = int.Parse(Session["remmin"].ToString());
                int rm = totrem - minut;
                c1.InsDelup("update org_student_result set  remaning_min=" + rm + " where student_id='" + student_id + "'and org_name='" + org + "' and  set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' ");


            }


        }


        private void save_exam()
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            string crr = "";
            string ans = "";
            float c_marks = 0;
            float w_marks = 0;
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            
            float marks = 0;
            int cno = 0;
            int wno = 0;
            int uno = 0;
            int k = 1;
            for (k = 1; k <= qend; k++)
            {

                string sql1 = "select correct_option,answer,correct_marks,wrong_marks from org_student_exam Where q_no = " + k + " and student_id = '" + student_id + "' and org_name='" + org + "' and set_id = '" + setid + "'";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows)
                {
                    crr = reader1["correct_option"].ToString();
                    ans = reader1["answer"].ToString();
                    c_marks = float.Parse(reader1["correct_marks"].ToString());
                    w_marks = float.Parse(reader1["wrong_marks"].ToString());

                }
                con.Close();







                //    string crr = c1.Fillstring("select correct_option from org_student_exam Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                //string ans = c1.Fillstring("select answer from org_student_exam Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                //float c_marks = float.Parse(c1.Fillstring("select correct_marks from org_student_exam Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));
                //float w_marks = float.Parse(c1.Fillstring("select wrong_marks from org_student_exam Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

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



       
            DateTime dt = DateTime.Now;


            DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' "));
            TimeSpan ttt = dt - dc;
            string minut = ttt.Minutes.ToString();

            int tmk = 0;
            string exam = "";
            string subjj = "";

            string sql2 = "Select total_minut,total_marks,exam_name,subject From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "'";
            con.Open();
            SqlCommand comm2 = new SqlCommand(sql2, con);
            SqlDataReader reader2 = comm2.ExecuteReader();
            reader2.Read();
            if (reader2.HasRows)
            {
                min = int.Parse(Session["remmin"].ToString());
                tmk = int.Parse(reader2["total_marks"].ToString());
                exam = reader2["exam_name"].ToString();
                subjj = reader2["subject"].ToString();

            }
            con.Close();


            
            int rm = min - int.Parse(minut);
            if (rm <= 0)
            {
                rm = 0;
            }

            c1.InsDelup("update org_student_result set  examstatus='Finish', obtain_marks= " + marks + ", submitexam_time= '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "',correct_answer=" + cno + ",wrong_answer=" + wno + ",un_answer=" + uno + ", remaning_min=" + rm + " where student_id='" + student_id + "'and org_name='" + org + "' and  set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' ");














        }



        private int get_qid(int sno, string set_id)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();

            int id;
            id = int.Parse(c1.Fillstring("Select q_id From org_question_paper Where q_no = " + sno + " and org_name='" + org + "' and set_id = '" + set_id + "' "));

            return id;
        }

        private string retrieve_answer(int n)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
           
            string ans = "";
            ans = c1.Fillstring("select answer from org_student_exam Where q_no = " + n + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "' ");
            return ans;
        }


        protected void voidPopulateControls()
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
           
            string an;
            //qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' "));
            for (int i = 1; i <= qend; i++)
            {
                Button btn = new Button();
                btn.ID = "btn" + i;
                btn.Style.Add("margin", "5px");
                btn.Style.Add("width", "40px");
                btn.Style.Add("font-size", "12px");
                btn.Style.Add("text-align", "center");
                btn.CssClass = "btn btn-info";
                btn.Text = i.ToString();
                btn.Click += buttonHandler;
                //btn.Click += btn_Click;
                Panel2.Controls.Add(btn);

                an = c1.Fillstring("select ques_mark from org_student_exam Where sno = " + i + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "' ");
                if (an == "SA")
                {
                    if (Panel2.FindControl("btn" + i.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + i.ToString());
                        button.CssClass = "btn btn-success rounded-circle";
                    }
                }
                else if (an == "NA")
                {
                    if (Panel2.FindControl("btn" + i.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + i.ToString());
                        button.CssClass = "btn btn-danger";
                    }
                }
                else if (an == "MSA")
                {
                    if (Panel2.FindControl("btn" + i.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + i.ToString());
                        button.CssClass = "btn btn-warning rounded-circle";
                    }
                }

                else if (an == "MNA")
                {
                    if (Panel2.FindControl("btn" + i.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + i.ToString());
                        button.CssClass = "btn btn-warning";
                    }
                }

                else
                {
                    if (Panel2.FindControl("btn" + i.ToString()) != null)
                    {
                        Button button = (Button)Panel2.FindControl("btn" + i.ToString());
                        button.CssClass = "btn btn-btn btn-info";
                    }
                }


            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:openFullscreen(); ", true);
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            qstart = int.Parse(Session["curques"].ToString());
            //try

            //{
            //qstart = 1;
            string l;

                setid = Session["stid"].ToString();
                student_id = Session["id"].ToString();
            qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' "));

            if (IsPostBack != true)
                {

                    l = c1.Fillstring("Select examstatus From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' ");




                    if (l == "Started")
                    {
                        

                        min = int.Parse(c1.Fillstring("Select remaning_min From org_student_result Where org_name='" + org + "' and set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' and student_id='" + student_id+"'  "));
                        remtime.Text = min.ToString() + ":" + sec.ToString();
                        //Label4.Text = min.ToString() + ":" + sec.ToString();
                       

                      

                        studentname.Text = "Candidate Name: " + c1.Fillstring("Select st_name From org_student_info Where org_name='" + org + "' and st_rollno='" + student_id + "' ");
                        examname.Text = "Exam Name: " + ename;
                        totalmarks.Text = "Total Marks: " + c1.Fillstring("Select total_marks From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' ");
                        totalques.Text = c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' ");

                        SqlCommand com = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where set_id='" + setid + "' group by subject order by qno asc", con);

                        // table name   
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataSet ds = new DataSet();
                        da.Fill(ds);  // fill dataset  
                        subjectname.DataTextField = ds.Tables[0].Columns["subject"].ToString(); // text field name of table dispalyed in dropdown       
                        subjectname.DataValueField = ds.Tables[0].Columns["subject"].ToString();
                        // to retrive specific  textfield name   
                        subjectname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                        subjectname.DataBind();

                        DateTime dt = DateTime.Now;

                        c1.InsDelup("update org_student_exam set start_time= '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where sno = " + qstart + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "' ");



                        int qno = int.Parse(c1.Fillstring("select q_no from org_student_exam Where sno = " + qstart + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'"));

                       

                    string ans = "";


                     ans = retrieve_answer(qno);

                    string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qno + " and org_name='" + org + "' and set_id='" + setid + "'");


                    if (qtype == "INPUT")
                    {
                        inputanswer.Text = ans;
                    }
                    else
                    {
                        if (ans == "A")
                        {

                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                            RadioButton1.Checked = true;
                        }
                        else if (ans == "B")
                        {
                            RadioButton1.Checked = false;

                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                            RadioButton2.Checked = true;
                        }
                        else if (ans == "C")
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;

                            RadioButton4.Checked = false;
                            RadioButton3.Checked = true;
                        }
                        else if (ans == "D")
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;

                            RadioButton4.Checked = true;
                        }
                        else
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                        }
                    }

                        getquestion(qno, qstart);
                        string stat = "Exam Runing";
                        c1.InsDelup("update org_student_result set examstatus='" + stat + "' where org_name='" + org + "' and set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' and student_id='" + student_id + "' ");

                    }

                    else if (l == "Exam Runing")
                    {

                        //DateTime dn = DateTime.Now;
                        //DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date From org_student_result Where org_name='" + org + "' and set_id='" + setid + "'and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "'  "));
                        //TimeSpan ttt = dn - dc;
                        //string sec = ttt.Seconds.ToString();
                        //string minut = ttt.Minutes.ToString();


                        //qstart = int.Parse(Session["curques"].ToString());
                        //min = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' ")) - 1;
                        //int rtimem = min - int.Parse(minut);
                        //int rtimes = 59 - int.Parse(sec);
                        min = int.Parse(c1.Fillstring("Select remaning_min From org_student_result Where org_name='" + org + "' and set_id='" + setid + "' and examname='" + ename + "' and subjectname='" + esub + "' and student_id='" + student_id + "'  "));
                        remtime.Text = min.ToString() + ":" + sec.ToString();
                        //Label4.Text = min.ToString() + ":" + sec.ToString();
                        
                        if (min <= 0)
                        {
                            save_exam();
                            Response.Redirect("org_student_exam_list.aspx");

                        }



                       
                        //Label4.Text = min.ToString() + ":" + sec.ToString();

                        
                       

                        studentname.Text = "Candidate Name: " + c1.Fillstring("Select st_name From org_student_info Where org_name='" + org + "' and st_rollno='" + student_id + "' ");
                        examname.Text = "Exam Name: " + ename;
                        totalmarks.Text = "Total Marks: " + c1.Fillstring("Select total_marks From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' ");
                        totalques.Text = c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' ");

                        SqlCommand com = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where org_name='" + org + "' and set_id='" + setid + "' group by subject order by qno asc", con);

                        // table name   
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataSet ds = new DataSet();
                        da.Fill(ds);  // fill dataset  
                        subjectname.DataTextField = ds.Tables[0].Columns["subject"].ToString(); // text field name of table dispalyed in dropdown       
                        subjectname.DataValueField = ds.Tables[0].Columns["subject"].ToString();
                        // to retrive specific  textfield name   
                        subjectname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                        subjectname.DataBind();





                        int qno = int.Parse(c1.Fillstring("select q_no from org_student_exam Where sno = " + qstart + " and org_name='" + org + "' and student_id = '" + student_id + "' and set_id='" + setid + "'"));

                        string ans = "";


                        ans = retrieve_answer(qno);

                    string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qno + " and org_name='" + org + "' and set_id='" + setid + "'");


                    if (qtype == "INPUT")
                    {
                        inputanswer.Text = ans;
                    }
                    else
                    {

                        if (ans == "A")
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                            RadioButton1.Checked = true;
                        }
                        else if (ans == "B")
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                            RadioButton2.Checked = true;
                        }
                        else if (ans == "C")
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                            RadioButton3.Checked = true;
                        }
                        else if (ans == "D")
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                            RadioButton4.Checked = true;
                        }
                        else
                        {
                            RadioButton1.Checked = false;
                            RadioButton2.Checked = false;
                            RadioButton3.Checked = false;
                            RadioButton4.Checked = false;
                        }

                    }


                        getquestion(qno, qstart);
                        string stat = "Exam Runing";
                        c1.InsDelup("update org_student_result set examstatus='" + stat + "' where org_name='" + org + "' and set_id='" + setid + "'and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' ");


                        //string message = "Do not refresh page ";
                        //string script = "window.onload = function(){ alert('";
                        //script += message;
                        //script += "')};";
                        //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                        //Response.Redirect("studenthome.aspx");
                    }





                    else
                    {
                        //string message = "You have already given this attempt or refresh page start next attempt";
                        //string script = "window.onload = function(){ alert('";
                        //script += message;
                        //script += "')};";
                        //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                        Response.Redirect("org_student_exam_list.aspx");
                    }

                }

                voidPopulateControls();

            //}

            //catch (Exception)
            //{
            //    Response.Redirect("index.aspx");
            //}













        }


        public void buttonHandler(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();

            //Session["remtime"] = remtime.Text;
            Button btn = sender as Button;
            string ans = "";
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
          
            int sn = int.Parse(btn.Text);
            int q = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + sn + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));



            ans = retrieve_answer(q);


            string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + q + " and org_name='" + org + "' and set_id='" + setid + "'");


            if (qtype == "INPUT")
            {
                inputanswer.Text = ans;
            }
            else
            {
                if (ans == "A")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton1.Checked = true;
                }
                else if (ans == "B")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton2.Checked = true;
                }
                else if (ans == "C")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton3.Checked = true;
                }
                else if (ans == "D")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton4.Checked = true;
                }
                else
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                }
            }
            getquestion(q, sn);
            Session["curques"] = sn.ToString();


        }

        /*void btn_Click(object sender, EventArgs e)
        {
            // which button click
            Button who = (Button)sender;
            who.Style.Add("BackColor", "red");

        }*/

        protected void clearresponce_Click(object sender, EventArgs e)
        {
            //Session["remtime"] = remtime.Text;
            inputanswer.Text = "";
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
        }

        protected void saveandprev_Click(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            //Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            //qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' "));
            qstart = 1;
            int q = int.Parse(Label1.Text);
            string ans = "";
            student_id = Session["id"].ToString();
         
            int qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

            save_answer(qn, q);

            if (q != qstart)
            {





                q = q - 1;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

                ans = retrieve_answer(qn);


                string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qn + " and org_name='" + org + "' and set_id='" + setid + "'");


                if (qtype == "INPUT")
                {
                    inputanswer.Text = ans;
                }
                else
                {

                    if (ans == "A")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton1.Checked = true;
                    }
                    else if (ans == "B")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton2.Checked = true;
                    }
                    else if (ans == "C")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton3.Checked = true;
                    }
                    else if (ans == "D")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                    }
                }
                getquestion(qn, q);

            }
            else
            {


                q = qend;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

                ans = retrieve_answer(qn);


                string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qn + " and org_name='" + org + "' and set_id='" + setid + "'");


                if (qtype == "INPUT")
                {
                    inputanswer.Text = ans;
                }
                else
                {

                    if (ans == "A")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton1.Checked = true;
                    }
                    else if (ans == "B")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton2.Checked = true;
                    }
                    else if (ans == "C")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton3.Checked = true;
                    }
                    else if (ans == "D")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                    }
                }
                getquestion(qn, q);

            }
            //Session["curques"] = q.ToString();

        }

        protected void saveandnext_Click(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            // Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            //qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "' and set_id='" + setid + "' "));
            qstart = 1;
            int q = int.Parse(Label1.Text);
            string ans = "";
            student_id = Session["id"].ToString();
         

            int qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "'"));

            save_answer(qn, q);
            if (q != qend)
            {

                q = q + 1;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

                ans = retrieve_answer(qn);

                string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qn + " and org_name='" + org + "' and set_id='" + setid + "'");


                if (qtype == "INPUT")
                {
                    inputanswer.Text = ans;
                }
                else
                {
                    if (ans == "A")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton1.Checked = true;
                    }
                    else if (ans == "B")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton2.Checked = true;
                    }
                    else if (ans == "C")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton3.Checked = true;
                    }
                    else if (ans == "D")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                    }
                }
                getquestion(qn, q);

            }
            else
            {

                q = qstart;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "' and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "'"));


                ans = retrieve_answer(qn);
                string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qn + " and org_name='" + org + "' and set_id='" + setid + "'");


                if (qtype == "INPUT")
                {
                    inputanswer.Text = ans;
                }
                else
                {
                    if (ans == "A")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton1.Checked = true;
                    }
                    else if (ans == "B")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton2.Checked = true;
                    }
                    else if (ans == "C")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton3.Checked = true;
                    }
                    else if (ans == "D")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                    }
                }
                getquestion(qn, q);
            }
            //Session["curques"] = q.ToString();

        }

        protected void finalsubmit_Click(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            //Session["remtime"] = remtime.Text;


            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            //setid = Request.QueryString["stid"];
            //student_email = Request.QueryString["id"];

            string sql1 = "Select exam_name, subject,topic,exam_cat,total_marks,total_minut,correct_marks,wrong_marks from org_exam_set_info Where org_name='" + org + "' and  set_id='" + setid + "' ";
            con.Open();
            SqlCommand comm1 = new SqlCommand(sql1, con);
            SqlDataReader reader1 = comm1.ExecuteReader();
            reader1.Read();
            if (reader1.HasRows)
            {


                int ts = int.Parse(reader1["exam_cat"].ToString());

                float tmk = float.Parse(reader1["total_marks"].ToString());


                con.Close();
                //SqlCommand com1 = new SqlCommand("select distinct(subject) from org_question_paper where set_id='"+setid+"' ", con);

                SqlCommand com1 = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where org_name='" + org + "' and set_id='" + setid + "' group by subject order by qno asc", con);

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
                    int qe = int.Parse(c1.Fillstring("Select min(q_no) From org_question_paper Where org_name='" + org + "' and set_id='" + setid + "' and subject='" + sub + "' "));


                    int ql = int.Parse(c1.Fillstring("Select max(q_no) From org_question_paper Where org_name='" + org + "' and set_id='" + setid + "' and subject='" + sub + "' "));


                    Label tot = (Label)row.FindControl("totques");
                    int x = ql - qe + 1;
                    tot.Text = x.ToString();
            

                    //int noanscount = int.Parse(c1.Fillstring("select count(answer) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "'and answer='' ")) + int.Parse(c1.Fillstring("select count(isnull(answer,0)) from org_question_paper as qp join student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and se.attemp_no=" + at_no + " and qp.subject='" + sub + "'and answer is null "));
                    int noanscount = int.Parse(c1.Fillstring("select count(ques_mark) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where qp.org_name='" + org + "'  and se.org_name='" + org + "' and se.student_id='" + student_id + "' and qp.set_id='" + setid + "'  and qp.subject='" + sub + "'and se.ques_mark IN ('MNA', 'N', 'NA') "));
                    Label fl = (Label)row.FindControl("toques");
                    fl.Text = noanscount.ToString();

                    int anscount = int.Parse(c1.Fillstring("select count(ques_mark) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where qp.org_name='" + org + "'  and se.org_name='" + org + "' and se.student_id='" + student_id + "' and qp.set_id='" + setid + "'  and qp.subject='" + sub + "'and se.ques_mark IN ('SA','MSA') "));
                    //int anscount = x - noanscount;
                    Label fq = (Label)row.FindControl("fromques");
                    fq.Text = anscount.ToString();

                    int markr = int.Parse(c1.Fillstring("select count(ques_mark) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where qp.org_name='" + org + "'  and se.org_name='" + org + "' and se.student_id='" + student_id + "' and qp.set_id='" + setid + "' and qp.subject='" + sub + "'and se.ques_mark = 'MSA' ")) + int.Parse(c1.Fillstring("select count(ques_mark) from org_question_paper as qp join org_student_exam as se on qp.set_id=se.set_id and qp.q_no=se.q_no where se.student_id='" + student_id + "' and qp.set_id='" + setid + "'  and qp.subject='" + sub + "'and se.ques_mark = 'MNA' "));
                    Label mk = (Label)row.FindControl("markrev");
                    mk.Text = markr.ToString();


                    //float totmark = int.Parse(c1.Fillstring("Select sum(correct_marks) From org_question_paper Where set_id='" + setid + "' and subject='" + sub + "' "));
                    //Label ttm = (Label)row.FindControl("totmark");
                    //ttm.Text = totmark.ToString();

                }

                int totnoans = int.Parse(c1.Fillstring("select count(ques_mark) from org_student_exam where org_name='" + org + "'  and student_id='" + student_id + "' and set_id='" + setid + "'  and  ques_mark IN ('MNA', 'N', 'NA') "));
                int mrv = int.Parse(c1.Fillstring("select count(ques_mark) from org_student_exam where org_name='" + org + "'  and student_id ='" + student_id + "' and set_id='" + setid + "'  and  ques_mark IN ('MSA', 'MNA') "));

                int totans = ts - totnoans;
                GridView1.FooterRow.Cells[2].Text = ts.ToString();
                GridView1.FooterRow.Cells[3].Text = totans.ToString();
                GridView1.FooterRow.Cells[4].Text = totnoans.ToString();
                GridView1.FooterRow.Cells[5].Text = mrv.ToString();




                int i = 1;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label lbl = (Label)row.FindControl("Label1");
                    lbl.Text = i.ToString();
                    i++;
                }



            }




            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();


            //save_exam();

            //Response.Redirect("examresult.aspx");

        }





        protected void finalsubmitexam_click(object sender, EventArgs e)
        {
            string student_id = Session["id"].ToString();
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            // Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            //Session["remtime"] = remtime.Text;
            testfinalsubmit.Enabled = false;
            save_exam();

            string disp = c1.Fillstring("Select resultdisplay From org_student_result Where set_id='" + setid + "'and org_name='" + org + "' and student_id='" + student_id + "' and examname='" + ename + "' and subjectname='" + esub + "' ");

            if (disp=="Yes")
            {
                Response.Redirect("org_student_test_result.aspx");
            }
            else
            {
                Response.Redirect("org_thank_you.aspx");
            }
            

        }





        protected void markreview_Click(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            // Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            //qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where org_name='" + org + "'  and set_id='" + setid + "' "));
            qstart = 1;
            int q = int.Parse(Label1.Text);
            string ans = "";
            
            student_id = Session["id"].ToString();
            int qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "'  and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

            save_answer1(qn, q);
            if (q != qend)
            {

                q = q + 1;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "'  and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

                ans = retrieve_answer(qn);

                string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qn + " and org_name='" + org + "' and set_id='" + setid + "'");


                if (qtype == "INPUT")
                {
                    inputanswer.Text = ans;
                }
                else
                {
                    if (ans == "A")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton1.Checked = true;
                    }
                    else if (ans == "B")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton2.Checked = true;
                    }
                    else if (ans == "C")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton3.Checked = true;
                    }
                    else if (ans == "D")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                    }
                }
                getquestion(qn, q);

            }
            else
            {

                q = qstart;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "'  and sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

                ans = retrieve_answer(qn);
                string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + qn + " and org_name='" + org + "' and set_id='" + setid + "'");


                if (qtype == "INPUT")
                {
                    inputanswer.Text = ans;
                }
                else
                {
                    if (ans == "A")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton1.Checked = true;
                    }
                    else if (ans == "B")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton2.Checked = true;
                    }
                    else if (ans == "C")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton3.Checked = true;
                    }
                    else if (ans == "D")
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                        RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton1.Checked = false;
                        RadioButton2.Checked = false;
                        RadioButton3.Checked = false;
                        RadioButton4.Checked = false;
                    }
                }
                getquestion(qn, q);
            }
            //Session["curques"] = q.ToString();

        }

        protected void subjectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            //Session["remtime"] = remtime.Text;
            string sub = subjectname.SelectedValue;
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            
            int sn = int.Parse(c1.Fillstring("select min(sno) from org_student_exam Where org_name='" + org + "'  and student_id = '" + student_id + "' and set_id='" + setid + "'  and subj ='" + sub + "' "));
            int q = int.Parse(c1.Fillstring("select q_no from org_student_exam Where org_name='" + org + "'  and sno = " + sn + " and student_id = '" + student_id + "' and set_id='" + setid + "' "));

            string ans = "";



            ans = retrieve_answer(q);
            string qtype = c1.Fillstring("select ques_type from org_question_paper Where q_no = " + q + " and org_name='" + org + "' and set_id='" + setid + "'");


            if (qtype == "INPUT")
            {
                inputanswer.Text = ans;
            }
            else
            {
                if (ans == "A")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton1.Checked = true;
                }
                else if (ans == "B")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton2.Checked = true;
                }
                else if (ans == "C")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton3.Checked = true;
                }
                else if (ans == "D")
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                    RadioButton4.Checked = true;
                }
                else
                {
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = false;
                    RadioButton3.Checked = false;
                    RadioButton4.Checked = false;
                }
            }
            getquestion(q, sn);
            //Session["curques"] = q.ToString();

        }
    }
}