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
    public partial class org_student_result : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        string name = "";
        int qstart;
        int qend;
        string setid = "";
        string student_id = "";
        int at_no;
        float cm;
        float wm;

        string answer = "";


        int min;
        static int sec = 00;



        private void getquestion(int n, int s)
        {
            string org = Session["orgname"].ToString();
            
            Session["curques"] = s;
            setid = Session["stid"].ToString();
            student_id = Session["stuid"].ToString();
          //at_no = 1;
            string ai = "", bi = "", ci = "", di = "", desi = "", emp = "", empurl = "";
            string a = "", b = "", c = "", d = "", t = "", desc = "", corr = "", url = "", qimage = "";
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
            string qtyp = c1.Fillstring("Select ques_type image from org_question_paper Where q_no = " + n + " and set_id='" + setid + "' and org_name='"+org+"' ");
            if (qtyp == "MCQ")
            {
                mcqtypeques.Visible = true;
                inputtypeques.Visible = false;
                string sql1 = "Select subject,correct_marks,wrong_marks, question,option_a,option_b,option_c,option_d,question_image,option_a_image,option_b_image,option_c_image,option_d_image,correct_option,description,desc_image  from org_question_paper Where q_no = " + n + " and set_id='" + setid + "' and org_name='" + org + "' ";
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
                    corr = reader1["correct_option"].ToString();
                    desc = reader1["description"].ToString();
                    int sec = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam_temp Where q_no = " + n + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='" + org + "' "));

                    int mint = Convert.ToInt32(sec / 60);
                    sec = sec - mint * 60;
                    timetake.Text = "Time taken on this question = " + mint + " Minutes " + sec + " Seconds";



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
                    im = reader1["desc_image"].ToString();
                    if (im != "")
                    {
                        byte[] img = (byte[])(reader1["desc_image"]);
                        qimage = Convert.ToBase64String(img, 0, img.Length);
                        desi = string.Format("data:image/png;base64," + qimage);
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
                string ihint = c1.Fillstring("Select input_hint image from org_question_paper Where q_no = " + n + " and set_id='" + setid + "' and org_name='" + org + "' ");
                hintinput.InnerText = "Hint:- " + ihint;



                string sql1 = "Select subject,correct_marks,wrong_marks,correct_option, question,option_a,option_b,option_c,option_d,question_image,option_a_image,option_b_image,option_c_image,option_d_image  from org_question_paper Where q_no = " + n + " and set_id='" + setid + "' and org_name='" + org + "' ";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows)
                {
                    subjectname.Text = reader1["subject"].ToString();
                    correctmarks.Text = "Marks for Correct: " + reader1["correct_marks"].ToString();
                    wrongmarks.Text = "Marks for Wrong: " + reader1["wrong_marks"].ToString();
                    corr = reader1["correct_option"].ToString();
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

            corans.Text = "Correct Answer: " + corr;
            if (desc != "")
            {
                descans.Text = "Description : " + desc;
            }
            else
            {
                descans.Text = "";
            }
            Image6.ImageUrl = desi;

            string answ = c1.Fillstring("select answer from org_student_exam_temp Where q_no = " + n + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='" + org + "'");
            yourans.Text = "Selected Option: " + answ;
            yourans.Style.Add("color", "black");
            if (answ != "")
            {
                if (corr != answ)
                {
                    yourans.Style.Add("color", "Red");
                }
                else
                {
                    yourans.Style.Add("color", "Green");
                }
            }
            // string text = "</head><body><p style='font-size:medium;'>" + t + "</p><img src='" + url + "'  width='100%' height='40%' alt='' onerror='this.onerror=null;'><p style='font-size:medium;'>  (A)." + a + " </p> <img src='" + ai + "'  width='50%' height='50%' alt='' onerror='this.onerror=null;'> <p style='font-size: medium;'>  (B)." + b + "</p><img src='" + bi + "'  width='50%' height='50%' alt='' onerror='this.onerror=null;'> <p style='font-size: medium;'>  (C)." + c + "</p><img src= '" + ci + "'  width='50%' height='50%' alt='' onerror='this.onerror=null;'><p style='font-size: medium;'>  (D)." + d + "</p><img src='" + di + "' alt='' onerror='this.onerror=null;'></body></html>  ";
            // quesspace.Attributes["srcdoc"] = text;
            DateTime dt = DateTime.Now;

            //c1.InsDelup("update org_student_exam_temp set start_time= '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where q_no = " + n + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");


        }


        private void save_answer(int no, int s)
        {

            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            //attno
            string qtp = c1.Fillstring("Select ques_type From org_question_paper Where q_no = " + no + " and set_id='" + setid + "'");
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
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and set_id='" + setid + "'");

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

                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam_temp Where q_no=" + no + " and set_id='" + setid + "'and student_id='" + student_id + "' and attemp_no=" + at_no + " "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam_temp Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + " "));
                int tottime = prevtime + sec;

                c1.InsDelup("update org_student_exam_temp set correct_option= '" + crr + "',answer='" + answer + "', total_time_take = " + tottime + " , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + " ");
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
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and set_id='" + setid + "'");

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

                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam_temp Where q_no=" + no + " and set_id='" + setid + "'and student_id='" + student_id + "' and attemp_no=" + at_no + " "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam_temp Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + " "));
                int tottime = prevtime + sec;
                c1.InsDelup("update org_student_exam_temp set correct_option= '" + crr + "', total_time_take = " + tottime + ",answer='" + answer + "' , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
            }

        }


        private void save_answer1(int no, int s)

        {
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            //attno
            string qtp = c1.Fillstring("Select ques_type From org_question_paper Where q_no = " + no + " and set_id='" + setid + "'");
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
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and set_id='" + setid + "' ");


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
                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam_temp Where q_no=" + no + " and set_id='" + setid + "'and student_id='" + student_id + "' and attemp_no=" + at_no + " "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam_temp Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + " "));
                int tottime = prevtime + sec;

                c1.InsDelup("update org_student_exam_temp set correct_option= '" + crr + "', total_time_take = " + tottime + " ,answer='" + answer + "' , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id ='" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + " ");

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
                string crr = c1.Fillstring("Select correct_option From org_question_paper Where q_no = " + no + " and set_id='" + setid + "'");



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
                DateTime dts = Convert.ToDateTime(c1.Fillstring("Select start_time From org_student_exam_temp Where q_no=" + no + " and set_id='" + setid + "'and student_id='" + student_id + "' and attemp_no=" + at_no + " "));
                TimeSpan ttt = dt - dts;
                int sec = int.Parse(ttt.Seconds.ToString());
                int prevtime = int.Parse(c1.Fillstring("Select total_time_take From org_student_exam_temp Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + " "));
                int tottime = prevtime + sec;



                c1.InsDelup("update org_student_exam_temp set correct_option= '" + crr + "' , total_time_take = " + tottime + " ,answer='" + answer + "' , ques_mark='" + anstype + "', submit_time='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' Where q_no = " + no + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
            }


        }


        private void save_exam()
        {
            string crr;
            string ans;
            float c_marks;
            float w_marks;
            setid = Session["stid"].ToString();
            student_id = Session["id"].ToString();
            //attno
            float marks = 0;
            int cno = 0;
            int wno = 0;
            int uno = 0;
            int k = 1;
            for (k = 1; k <= qend; k++)
            {

                string sql1 = "select correct_option,answer,correct_marks,wrong_marks from org_student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id = '" + setid + "' and attemp_no = " + at_no + "";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                reader1.Read();
                //if (reader1.HasRows)
                //{
                crr = reader1["correct_option"].ToString();
                ans = reader1["answer"].ToString();
                c_marks = float.Parse(reader1["correct_marks"].ToString());
                w_marks = float.Parse(reader1["wrong_marks"].ToString());

                //}
                con.Close();







                //    string crr = c1.Fillstring("select correct_option from org_student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                //string ans = c1.Fillstring("select answer from org_student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");
                //float c_marks = float.Parse(c1.Fillstring("select correct_marks from org_student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));
                //float w_marks = float.Parse(c1.Fillstring("select wrong_marks from org_student_exam_temp Where q_no = " + k + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

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



            // string[] rtt = (rmtm.Value).Split(':');
            // int rm = int.Parse(rtt[0]);
            int rm = min;

            c1.InsDelup("update student_result set obtain_marks= " + marks + ", date= " + DateTime.Today.ToString("dd-MM-yyyy") + ",correct_answer=" + cno + ",wrong_answer=" + wno + ",un_answer=" + uno + ", remaning_min=" + rm + " where student_id='" + student_id + "'and set_id='" + setid + "' and attempt_no=" + at_no + " ");

        }



        private int get_qid(int sno, string set_id)
        {
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();

            int id;
            id = int.Parse(c1.Fillstring("Select q_id From org_question_paper Where q_no = " + sno + " and set_id = '" + set_id + "' and org_name='"+org+"' "));

            return id;
        }

        private string retrieve_answer(int n)
        {
            string ename = Session["examname"].ToString();
            string esub = Session["testsubject"].ToString();
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();
            student_id = Session["stuid"].ToString();
            //attno
            string ans = "";
            ans = c1.Fillstring("select answer from org_student_exam_temp Where q_no = " + n + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+ "' ");
            return ans;
        }


        protected void voidPopulateControls()
        {
            string org = Session["orgname"].ToString();
            setid = Session["stid"].ToString();
            student_id = Session["stuid"].ToString();
            //attno
            string an;
            qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where set_id='" + setid + "' and org_name='"+org+"' "));
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

                an = c1.Fillstring("select ques_mark from org_student_exam_temp Where sno = " + i + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'");
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
            
            //try

            //{
                Session["curques"] = 1;
                string ename = Session["examname"].ToString();
                string org = Session["orgname"].ToString();
                string subjectt = Session["testsubject"].ToString();
                //qstart = 1;
                string l;

                setid = Session["stid"].ToString();
                student_id = Session["stuid"].ToString();
                //attno
                if (IsPostBack != true)
                {

                    l = c1.Fillstring("Select examstatus From org_student_result Where set_id='" + setid + "'and student_id='" + student_id + "' and org_name='"+org+"' ");

                    //qstart = 1;


                    if (l == "Finish")
                    {
                        qstart = int.Parse(Session["curques"].ToString());

                        min = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where set_id='" + setid + "' and org_name='"+org+"' "));
                        //remtime.Text = min.ToString() + ":" + sec.ToString();
                        //Label4.Text = min.ToString() + ":" + sec.ToString();


                       

                        studentname.Text = "Candidate Name: " + c1.Fillstring("Select st_name From org_student_info Where org_name='" + org + "' and st_rollno='" + student_id + "' ");
                        examname.Text = "Exam Name: " + ename;
                    subjnm.Text = "Sub: "+subjectt;
                    totalmarks.Text=  "Total Marks: "+c1.Fillstring("Select total_marks From org_exam_set_info Where set_id='" + setid + "' and org_name='" + org + "' ");
                    totalques.Text = c1.Fillstring("Select exam_cat From org_exam_set_info Where set_id='" + setid + "' and org_name='" + org + "' ");


                    SqlCommand com = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where set_id='" + setid + "' and org_name='"+org+"' group by subject order by qno asc", con);

                        // table name   
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataSet ds = new DataSet();
                        da.Fill(ds);  // fill dataset  
                        subjectname.DataTextField = ds.Tables[0].Columns["subject"].ToString(); // text field name of table dispalyed in dropdown       
                        subjectname.DataValueField = ds.Tables[0].Columns["subject"].ToString();
                        // to retrive specific  textfield name   
                        subjectname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                        subjectname.DataBind();

                        //DateTime dt = DateTime.Now;

                        //c1.InsDelup("update org_student_exam_temp set start_time= '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' where sno = " + qstart + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + "");



                        int qno = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + qstart + " and org_name='"+org+"' and student_id = '" + student_id + "' and set_id='" + setid + "'"));

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
                        //string stat = "stop";
                        //c1.InsDelup("update org_student_result set examstatus='" + stat + "' where set_id='" + setid + "'and student_id='" + student_id + "' and attempt_no=" + at_no + " ");

                    }

                    //else if (l == "finish")
                    //{
                    //qstart = int.Parse(Session["curques"].ToString());
                    //DateTime dn = DateTime.Now;
                    //    DateTime dc = Convert.ToDateTime(c1.Fillstring("Select date  From org_student_result Where set_id='" + setid + "'and student_id='" + student_id + "' and attempt_no=" + at_no + " "));
                    //    TimeSpan ttt = dn - dc;
                    //    string sec = ttt.Seconds.ToString();
                    //    string minut = ttt.Minutes.ToString();


                    //qstart = int.Parse(Session["curques"].ToString());
                    //min = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where set_id='" + setid + "' ")) - 1;
                    //int rtimem = min - int.Parse(minut);
                    //int rtimes = 59 - int.Parse(sec);
                    //if (rtimem < 0)
                    //{
                    //    save_exam();
                    //    Response.Redirect("index.aspx");

                    //}



                    //remtime.Text = rtimem.ToString() + ":" + rtimes.ToString();
                    //Label4.Text = min.ToString() + ":" + sec.ToString();


                    //    atmpno.Text = "Attempt No: " + at_no.ToString();

                    //    studentname.Text = "Candidate Name: " + c1.Fillstring("Select name From newRegistration Where email='" + student_id + "' ");
                    //    examname.Text = "Exam Name: " + c1.Fillstring("Select exam_name From org_question_paper Where set_id='" + setid + "' ");
                    //    totalmarks.Text = "Total Marks: " + c1.Fillstring("Select total_marks From org_exam_set_info Where set_id='" + setid + "' ");
                    //    totalques.Text = c1.Fillstring("Select exam_cat From org_exam_set_info Where set_id='" + setid + "' ");

                    //    SqlCommand com = new SqlCommand("select subject,MIN(q_no) as qno from org_question_paper where set_id='" + setid + "' group by subject order by qno asc", con);

                    //    // table name   
                    //    SqlDataAdapter da = new SqlDataAdapter(com);
                    //    DataSet ds = new DataSet();
                    //    da.Fill(ds);  // fill dataset  
                    //    subjectname.DataTextField = ds.Tables[0].Columns["subject"].ToString(); // text field name of table dispalyed in dropdown       
                    //    subjectname.DataValueField = ds.Tables[0].Columns["subject"].ToString();
                    //    // to retrive specific  textfield name   
                    //    subjectname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    //    subjectname.DataBind();





                    //    int qno = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + qstart + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

                    //    string ans = "";


                    //    ans = retrieve_answer(qno);
                    //    if (ans == "A")
                    //    {
                    //        RadioButton1.Checked = false;
                    //        RadioButton2.Checked = false;
                    //        RadioButton3.Checked = false;
                    //        RadioButton4.Checked = false;
                    //        RadioButton1.Checked = true;
                    //    }
                    //    else if (ans == "B")
                    //    {
                    //        RadioButton1.Checked = false;
                    //        RadioButton2.Checked = false;
                    //        RadioButton3.Checked = false;
                    //        RadioButton4.Checked = false;
                    //        RadioButton2.Checked = true;
                    //    }
                    //    else if (ans == "C")
                    //    {
                    //        RadioButton1.Checked = false;
                    //        RadioButton2.Checked = false;
                    //        RadioButton3.Checked = false;
                    //        RadioButton4.Checked = false;
                    //        RadioButton3.Checked = true;
                    //    }
                    //    else if (ans == "D")
                    //    {
                    //        RadioButton1.Checked = false;
                    //        RadioButton2.Checked = false;
                    //        RadioButton3.Checked = false;
                    //        RadioButton4.Checked = false;
                    //        RadioButton4.Checked = true;
                    //    }
                    //    else
                    //    {
                    //        RadioButton1.Checked = false;
                    //        RadioButton2.Checked = false;
                    //        RadioButton3.Checked = false;
                    //        RadioButton4.Checked = false;
                    //    }




                    //    getquestion(qno, qstart);
                    //    string stat = "stop";
                    //    c1.InsDelup("update org_student_result set examstatus='" + stat + "' where set_id='" + setid + "'and student_id='" + student_id + "' and attempt_no=" + at_no + " ");


                    //    //string message = "Do not refresh page ";
                    //    //string script = "window.onload = function(){ alert('";
                    //    //script += message;
                    //    //script += "')};";
                    //    //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    //    //Response.Redirect("studenthome.aspx");
                    //}





                    else
                    {
                        //string message = "You have already given this attempt or refresh page start next attempt";
                        //string script = "window.onload = function(){ alert('";
                        //script += message;
                        //script += "')};";
                        //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                        Response.Redirect("org_student_test_history.aspx");
                    }

                }

                voidPopulateControls();

            //}

            //catch (Exception)
            //{
            //    Response.Redirect("org_student_test_history.aspx");
            //}













        }


        public void buttonHandler(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            //Session["remtime"] = remtime.Text;
            Button btn = sender as Button;
            string ans = "";
            setid = Session["stid"].ToString();
            student_id = Session["stuid"].ToString();
          
            int sn = int.Parse(btn.Text);
            int q = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + sn + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));



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
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
        }

        protected void saveandprev_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            //Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where set_id='" + setid + "'and org_name='"+org+"' "));
            qstart = 1;
            int q = int.Parse(Label1.Text);
            string ans = "";
            student_id = Session["stuid"].ToString();
            //attno
            int qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));

            //save_answer(qn, q);

            if (q != qstart)
            {





                q = q - 1;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));

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
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));

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
            string org = Session["orgname"].ToString();
            // Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where set_id='" + setid + "' "));
            qstart = 1;
            int q = int.Parse(Label1.Text);
            string ans = "";
            student_id = Session["stuid"].ToString();
            //attno

            int qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));

            //save_answer(qn, q);
            if (q != qend)
            {

                q = q + 1;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));

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
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and org_name='"+org+"'"));


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

           // Response.Redirect("org_student_test_history.aspx");

        }





        protected void finalsubmitexam_click(object sender, EventArgs e)
        {
            //Session["remtime"] = remtime.Text;
            //save_exam();

            //Response.Redirect("examresult.aspx");

        }





        protected void markreview_Click(object sender, EventArgs e)
        {
            // Session["remtime"] = remtime.Text;
            setid = Session["stid"].ToString();
            qend = int.Parse(c1.Fillstring("Select exam_cat From org_exam_set_info Where set_id='" + setid + "' "));
            qstart = 1;
            int q = int.Parse(Label1.Text);
            string ans = "";
            //attno
            student_id = Session["id"].ToString();
            int qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

            save_answer1(qn, q);
            if (q != qend)
            {

                q = q + 1;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

                ans = retrieve_answer(qn);
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
                getquestion(qn, q);

            }
            else
            {

                q = qstart;
                qn = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where sno = " + q + " and student_id = '" + student_id + "' and set_id='" + setid + "' and attemp_no=" + at_no + ""));

                ans = retrieve_answer(qn);
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
                getquestion(qn, q);
            }
            //Session["curques"] = q.ToString();

        }

        protected void subjectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            //Session["remtime"] = remtime.Text;
            string subj = subjectname.SelectedValue;
            setid = Session["stid"].ToString();
            student_id = Session["stuid"].ToString();
            
            int sn = int.Parse(c1.Fillstring("Select min(q_no) From org_question_paper Where set_id='" + setid + "' and subject='" + subj + "' and org_name='"+org+"' "));
            int q = int.Parse(c1.Fillstring("select q_no from org_student_exam_temp Where q_no = " + sn + " and student_id = '" + student_id + "' and set_id='" + setid + "'  and org_name='" + org + "'"));

            string ans = "";



            ans = retrieve_answer(q);
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
            getquestion(q, sn);
            //Session["curques"] = q.ToString();

        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    string time = Label4.Text;
        //    string[] tm =time.Split(':');
        //    int min = int.Parse(tm[0]);
        //    int sec = int.Parse(tm[1]);
        //    if (sec > 0)
        //    {
        //        sec = sec - 1;
        //    }
        //    else
        //    {
        //        sec = 59;
        //        min = min + 1;
        //    }

        //    if (sec == 0 && min == 0)
        //    {
        //        Timer1.Dispose();
        //    }


        //}
    }
}