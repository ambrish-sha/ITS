using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Text;

namespace ITS
{
    public partial class org_student_test_control : System.Web.UI.Page
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string course = courselist1.Text;
            string branch = branchlist1.Text;
            string yearsem = yearsemlist1.Text;
            string en = examnamelist1.Text;
            string sub = subname.Value;
            try
            {

                if (utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && en != "Select" && en != "" && sub!="")
                {

                    string cmp = c1.Fillstring("Select course_name From org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and subject_name ='" + sub + "' and batch_name='"+btch+"' and exam_name='"+en+"' and org_name='"+org+"'");
                if (cmp == "" && sub != "")
                {
                    c1.InsDelup("insert into org_test_subject_name(course_name,branch_name,yearsem,subject_name,org_name,exam_name,batch_name) values( '" + course + "' ,'" + branch + "','" + yearsem + "','" + sub + "','" + org + "','"+en+"','"+btch+"')");

                    subname.Value = "";


                    string message = "Subject have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    

                }
                else
                {
                    string message = "Subject already exist";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                }
                else
                {
                    string message = "Fill All Entry";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {
                string message = "Subject already exist";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "'  and org_name='" + org + "' and exam_name='" + en + "' and batch_name='" + btch + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delsubjectlist.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
            delsubjectlist.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
            // to retrive specific  textfield name   
            delsubjectlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delsubjectlist.DataBind();
            delsubjectlist.Items.Insert(0, "Select");

            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as Subjectname from org_test_subject_name where org_name='" + org + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
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


            batchlist1.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist1.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist1.DataBind();
            batchlist1.Items.Insert(0, "Select");


            batchlist3.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist3.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist3.DataBind();
            batchlist3.Items.Insert(0, "Select");

            batchlist0.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist0.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist0.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist0.DataBind();
            batchlist0.Items.Insert(0, "Select");

            batchlist4.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist4.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist4.DataBind();
            batchlist4.Items.Insert(0, "Select");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsem = yearsemlist2.Text;
            string en = examnamelist2.Text;
            string sn = subjectlist2.Text;
            string sid = setid1.Text;
            try
            {
               


                if (utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && sn != "Select" && en != "" && sn != "" && sid!="")
                {

                    string cmp = c1.Fillstring("Select count(set_id) From org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + en + "' and subject_name='"+sn+"' and batch_name='"+btch+"' and org_name='" + org + "'");
            if (cmp == "0")
            {
                c1.InsDelup("insert into org_test_subject_setid(course_name,branch_name,yearsem,exam_name,org_name,subject_name,set_id,batch_name) values( '" + course + "' ,'" + branch + "','" + yearsem + "','" + en + "','" + org + "','"+sn+"','"+sid+"','"+btch+"')");

                setid1.Text = "Select";


                string message = "Set id have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



            }
            else
            {
                string message = "Set Id already allocated for this subject";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }



            }
                else
            {
                string message = "Fill All Entry";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }
            catch (Exception)
            {
                string message = "Something wrong/Server Error";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }


        SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as SubjectName,set_id as SetID from org_test_subject_setid where org_name='" + org + "'", con);
        con.Open();
        SqlDataReader rd = com1.ExecuteReader();
        GridView1.DataSource = rd;
        GridView1.DataBind();
        con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();

            string btch = batchlist3.Text;
            string course = courselist3.Text;
            string branch = branchlist3.Text;
            string yearsem = yearsemlist3.Text;
            string ename = examnamelist3.Text;
            string sname = subjectlist3.Text;
           
            string ak = anskey.Value;
            string exst = examstts.Value;
            string es = "Not started";
            string resdis = resdisp.Value;
            string send = sendemail1.Value;
            try
            {

                DateTime od = DateTime.Parse(startdate.Value);
                DateTime ed = DateTime.Parse(enddate.Value);

                if (utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && ak != "Select" && ename != "" && sname != "" && exst != "Select" && resdis!="Select" && od.ToString() !="" && ed.ToString()!="" && send!="")
                {
                   

                    string sid = c1.Fillstring("Select set_id From org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + ename + "' and subject_name='"+sname+"' and batch_name='"+btch+"' and org_name='" + org + "'");
                int rem = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where set_id ='" + sid + "' and org_name='" + org + "'"));
            int tm = int.Parse(c1.Fillstring("Select total_marks From org_exam_set_info Where set_id ='" + sid + "' and org_name='" + org + "'"));


            string cmp = c1.Fillstring("Select count(course) From org_student_result Where course ='" + course + "' and branch ='" + branch + "' and yearsem ='" + yearsem + "' and examname ='" + ename + "'and subjectname='" + sname + "' and set_id='" + sid + "' and org_name='" + org + "' and batch_name='"+btch+"'");
                if (cmp == "0")
                {

                c1.InsDelup("insert into org_exam_schedule(course_name,branch_name,yearsem,exam_name,subject_name,org_name,set_id,status,starttime,endtime,batch_name,resdisp,anskey) values( '" + course + "' ,'" + branch + "','" + yearsem + "','" + ename + "','" + sname + "','" + org + "','" + sid + "','" + exst + "','" + od.ToString("yyyy-MM-dd HH:mm:ss") + "','" + ed.ToString("yyyy-MM-dd HH:mm:ss") + "','"+btch+ "','" + resdis + "','" + ak + "')");


                string sql1 = "Select st_rollno,st_name,st_email From org_student_info Where st_batch='"+btch+"' and st_course ='" + course + "' and st_branch ='" + branch + "' and st_yearsem ='" + yearsem + "' and org_name='" + org + "' ";

                    con.Open();
                    SqlCommand comm1 = new SqlCommand(sql1, con);
                    SqlDataReader reader1 = comm1.ExecuteReader();
                    while (reader1.Read())
                        {
                        string roll_no = reader1["st_rollno"].ToString();

                        c1.InsDelup("insert into org_student_result(course,branch,yearsem,examname,subjectname,org_name,student_id,set_id,remaning_min,examstatus,studentstatus,linkopentime,linkclosetime,atendance,attempt_no,resultdisplay,total_marks,batch_name,answerkey,opencount) values( '" + course + "' ,'" + branch + "','" + yearsem + "','" + ename + "','"+sname+"','" + org + "','"+roll_no+"','"+sid+"','"+rem+"','"+es+"','Active','"+od.ToString("yyyy-MM-dd HH:mm:ss") + "','"+ed.ToString("yyyy-MM-dd HH:mm:ss") + "','Absent',0,'"+resdis+"','"+tm+"','"+btch+"','"+ak+"',0)");
                        string pwd = c1.Fillstring("Select pwd From org_mstLogin Where  org_name='" + org + "' and uid='" + roll_no + "'");

                            if (send == "Yes")
                            {
                                string emailidd = reader1["st_email"].ToString();


                                if (emailidd != "")
                                {
                                    string stname = reader1["st_name"].ToString();

                                    //string usernm = Session["userName"].ToString();

                                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                                    stname = myTI.ToTitleCase(stname);


                                    string to = emailidd; //To address    
                                    string from = "info@testedu.in"; //From address    
                                    MailMessage message1 = new MailMessage(from, to);

                                    string mailbody = "Dear <b>" + stname + "</b>,<br/><br/> Your exam is scheduled on the date on <b>" + od.ToString() + "</b> for <b>" + sname + " </b>. Link will be open from <b> " + od.ToString() + "</b> to <b>" + ed.ToString() + "</b>. Your user ID is <b>" + roll_no + "</b> and your password is <b>" + pwd + "</b>. Open the link https://testedu.in/Default.aspx  for login. <br/><br/> <b> Admin <br/> " + org + "</b> <br></br> ";
                                    message1.Subject = "Your test schedule by " + org;
                                    message1.Body = mailbody;
                                    message1.BodyEncoding = Encoding.UTF8;
                                    message1.IsBodyHtml = true;
                                    SmtpClient client = new SmtpClient("mail.testedu.in", 587); //Gmail smtp    
                                    System.Net.NetworkCredential basicCredential1 = new
                                    System.Net.NetworkCredential("info@testedu.in", "Test@12345");
                                    client.EnableSsl = false;
                                    client.UseDefaultCredentials = false;
                                    client.Credentials = basicCredential1;
                                    try
                                    {
                                        client.Send(message1);
                                    }

                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }

                            }






                    }





                    reader1.Close();
                    
                    con.Close();























                        
                    
                    
                    startdate.Value = "";
                    enddate.Value = "";
                   

                    string message = "Test scheduled successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                }
                else
                {
                    string message = "Exam Name already exist";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }


            }
                else
            {
                string message = "Fill All Entry";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }
            catch (Exception)
            {
                string message = "Select open and close Date/Server Error";
        string script = "window.onload = function(){ alert('";
        script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }


            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as SubjectName,set_id as SetID,starttime as StartTime,endtime as EndTime,resdisp as ResultDisplay,anskey as AnswerKey  from org_exam_schedule where org_name='" + org + "' order by endtime", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void cmplist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string comp = courselist1.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            branchlist1.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            branchlist1.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            branchlist1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            branchlist1.DataBind();
            branchlist1.Items.Insert(0, "Select");
        }

        protected void postlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string comp = courselist1.Text;
            string branch = branchlist1.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' and branch_name='" + branch + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist1.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist1.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            yearsemlist1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            yearsemlist1.DataBind();
            yearsemlist1.Items.Insert(0, "Select");
        }

        protected void cmplist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string comp = courselist2.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='"+btch+"' ", con);
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
            string btch = batchlist2.Text;
            string comp = courselist2.Text;
            string branch = branchlist2.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' and branch_name='" + branch + "'", con);
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

        protected void cmplist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string comp = courselist3.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            branchlist3.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            branchlist3.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            branchlist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            branchlist3.DataBind();
            branchlist3.Items.Insert(0, "Select");
        }

        protected void branchlist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string comp = courselist3.Text;
            string branch = branchlist3.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' and branch_name='" + branch + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist3.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist3.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            yearsemlist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            yearsemlist3.DataBind();
            yearsemlist3.Items.Insert(0, "Select");
        }

        protected void semid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string comp = courselist2.Text;
            string branch = branchlist2.Text;
            string ys = yearsemlist2.Text;
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='" + btch + "' and yearsem='" + ys + "' ", con);
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

        protected void yearsemlist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string comp = courselist3.Text;
            string branch = branchlist3.Text;
            string ys = yearsemlist3.Text;
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + comp + "' and branch_name='" + branch + "' and yearsem='" + ys + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            examnamelist3.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            examnamelist3.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            examnamelist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            examnamelist3.DataBind();
            examnamelist3.Items.Insert(0, "Select");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string course = courselist0.Text;
            string branch = branchlist0.Text;
            string yearsem = yearsemlist0.Text;
            string ename = examname.Value;

           
            try
            {
                if (utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && yearsem != "Select" && ename != "")
                {

                    string cmp = c1.Fillstring("Select course_name From org_test_examname Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + ename + "'and batch_name='" + btch + "' and org_name='" + org + "'");
                    if (cmp == "" && ename != "")
                    {
                        c1.InsDelup("insert into org_test_examname(course_name,branch_name,yearsem,exam_name,org_name,batch_name) values( '" + course + "' ,'" + branch + "','" + yearsem + "','" + ename + "','" + org + "','" + btch + "')");

                        examname.Value = "";


                        string message = "Exam Name have been saved successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                    }
                    else
                    {
                        string message = "Exam Name already exist";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }
                }
                else
                {
                    string message = "Fill All Entry";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {
                string message = "Server Error";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + course + "' and branch_name='" + branch + "' and batch_name='" + btch + "' and yearsem='" + yearsem + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delexamnamelist.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            delexamnamelist.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            delexamnamelist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delexamnamelist.DataBind();
            delexamnamelist.Items.Insert(0, "Select");

            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName from org_test_examname where org_name='" + org + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void courselist0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string comp = courselist0.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            branchlist0.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            branchlist0.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            branchlist0.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            branchlist0.DataBind();
            branchlist0.Items.Insert(0, "Select");
        }

        protected void branchlist0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string comp = courselist0.Text;
            string branch = branchlist0.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist0.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist0.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            yearsemlist0.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            yearsemlist0.DataBind();
            yearsemlist0.Items.Insert(0, "Select");
        }

        protected void yearsemlist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string comp = courselist1.Text;
            string branch = branchlist1.Text;
            string ys = yearsemlist1.Text;
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "' and course_name='" + comp + "' and branch_name='" + branch + "' and yearsem='"+ys+"' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            examnamelist1.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            examnamelist1.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            examnamelist1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            examnamelist1.DataBind();
            examnamelist1.Items.Insert(0, "Select");
        }

        protected void examnamelist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsm = yearsemlist2.Text;
            string en = examnamelist2.Text;
            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsm + "'  and org_name='" + org + "' and exam_name='"+en+"' and batch_name='"+btch+"' ", con);
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

        protected void examnamelist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string course = courselist3.Text;
            string branch = branchlist3.Text;
            string yearsm = yearsemlist3.Text;
            string en = examnamelist3.Text;
            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsm + "'  and org_name='" + org + "' and batch_name='" + btch + "' and exam_name='" + en + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            subjectlist3.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
            subjectlist3.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
            // to retrive specific  textfield name   
            subjectlist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            subjectlist3.DataBind();
            subjectlist3.Items.Insert(0, "Select");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string course = courselist3.Text;
            string branch = branchlist3.Text;
            string yearsem = yearsemlist3.Text;
            string ename = examnamelist3.Text;
            string sname = subjectlist3.Text;
            string send = sendemail1.Value;
           
            string exst = examstts.Value;
            string es = "Not started";
            string resdis = resdisp.Value;
            string ak = anskey.Value;
            try
            {



                DateTime od = DateTime.Parse(startdate.Value);
                DateTime ed = DateTime.Parse(enddate.Value);

                if (send!="" && utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && ak != "Select" && ename != "" && sname != "" && exst != "Select" && resdis != "Select" && od.ToString() != "" && ed.ToString() != "")
            {


                string sid = c1.Fillstring("Select set_id From org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + ename + "' and subject_name='" + sname + "' and org_name='" + org + "' and batch_name='"+btch+"'");
            int rem = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where set_id ='" + sid + "' and org_name='" + org + "'"));
            int tm = int.Parse(c1.Fillstring("Select total_marks From org_exam_set_info Where set_id ='" + sid + "' and org_name='" + org + "'"));


            string cmp = c1.Fillstring("Select count(course) From org_student_result Where course ='" + course + "' and branch ='" + branch + "' and yearsem ='" + yearsem + "' and examname ='" + ename + "'and subjectname='" + sname + "' and set_id='" + sid + "' and batch_name='"+btch+"' and org_name='" + org + "'");
            if (cmp != "0")
            {

                c1.InsDelup("update org_exam_schedule set set_id ='" + sid + "',status = '" + exst + "',starttime = '" + od.ToString("yyyy-MM-dd HH:mm:ss") + "',endtime = '" + ed.ToString("yyyy-MM-dd HH:mm:ss") + "',resdisp='"+resdis+"',anskey='"+ak+"'  where course_name = '" + course + "' and branch_name = '" + branch + "' and yearsem = '" + yearsem + "'  and exam_name = '" + ename + "' and subject_name = '" + sname + "' and batch_name='"+btch+"' and org_name = '" + org + "'");


                string sql1 = "Select st_rollno,st_email,st_name From org_student_info Where st_batch='"+btch+"' and st_course ='" + course + "' and st_branch ='" + branch + "' and st_yearsem ='" + yearsem + "' and org_name='" + org + "' ";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                while (reader1.Read())
                {
                    string roll_no = reader1["st_rollno"].ToString();

                    c1.InsDelup("update org_student_result set set_id = '" + sid + "'  ,studentstatus = 'Active',linkopentime = '" + od.ToString("yyyy-MM-dd HH:mm:ss") + "',linkclosetime = '" + ed.ToString("yyyy-MM-dd HH:mm:ss") + "',resultdisplay = '" + resdis + "',answerkey='"+ak+"',total_marks='"+tm+"' where batch_name='"+btch+"' and course ='" + course + "' and branch= '" + branch + "' and yearsem = '" + yearsem + "' and examname = '" + ename + "' and subjectname = '" + sname + "' and org_name = '" + org + "'  and  student_id = '" + roll_no + "'");

                            string pwd = c1.Fillstring("Select pwd From org_mstLogin Where  org_name='" + org + "' and uid='" + roll_no + "'");

                            if (send == "Yes")
                            {
                                string emailidd = reader1["st_email"].ToString();


                                if (emailidd != "")
                                {
                                    string stname = reader1["st_name"].ToString();

                                    //string usernm = Session["userName"].ToString();

                                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                                    stname = myTI.ToTitleCase(stname);


                                    string to = emailidd; //To address    
                                    string from = "info@testedu.in"; //From address    
                                    MailMessage message1 = new MailMessage(from, to);

                                    string mailbody = "Dear <b>" + stname + "</b>,<br/><br/> Your exam is scheduled on the date on <b>" + od.ToString() + "</b> for <b>" + sname + " </b>. Link will be open from <b> " + od.ToString() + "</b> to <b>" + ed.ToString() + "</b>. Your user ID is <b>" + roll_no + "</b> and your password is <b>" + pwd + "</b>. Open the link https://testedu.in/Default.aspx  for login. Ignore this mail if you have already attempt this test. <br/><br/> <b> Admin <br/> " + org + "</b> <br></br> ";
                                    message1.Subject = "Updated test schedule by " + org;
                                    message1.Body = mailbody;
                                    message1.BodyEncoding = Encoding.UTF8;
                                    message1.IsBodyHtml = true;
                                    SmtpClient client = new SmtpClient("mail.testedu.in", 587); //Gmail smtp    
                                    System.Net.NetworkCredential basicCredential1 = new
                                    System.Net.NetworkCredential("info@testedu.in", "Test@12345");
                                    client.EnableSsl = false;
                                    client.UseDefaultCredentials = false;
                                    client.Credentials = basicCredential1;
                                    try
                                    {
                                        client.Send(message1);
                                    }

                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }

                            }





                        }





                        reader1.Close();

                con.Close();


























                startdate.Value = "";
                enddate.Value = "";


                string message = "Test scheduled updated successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



            }
            else
            {
                string message = "Teast schedule not exist for update";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
                }
                else
                {
                    string message = "Fill All Entry";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }

            }
            catch (Exception)
            {
                string message = "Select open and close Date/Server Error";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as SubjectName,set_id as SetID,starttime as StartTime,endtime as EndTime,resdisp as ResultDisplay,anskey as AnswerKey  from org_exam_schedule where org_name='" + org + "' order by endtime", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void courselist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string comp = courselist4.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            branchlist4.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            branchlist4.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            branchlist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            branchlist4.DataBind();
            branchlist4.Items.Insert(0, "Select");
        }

        protected void branchlist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string comp = courselist4.Text;
            string branch = branchlist4.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist4.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist4.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrie specific  textfield name   
            yearsemlist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            yearsemlist4.DataBind();
            yearsemlist4.Items.Insert(0, "Select");
        }

        protected void yearsemlist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string comp = courselist4.Text;
            string branch = branchlist4.Text;
            string ys = yearsemlist4.Text;
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + comp + "' and branch_name='" + branch + "' and yearsem='" + ys + "' and batch_name='" + btch + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            examnamelist4.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            examnamelist4.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            examnamelist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            examnamelist4.DataBind();
            examnamelist4.Items.Insert(0, "Select");


            SqlCommand com1 = new SqlCommand("select st_rollno from org_student_info where org_name='" + org + "'  and st_course='" + comp + "' and st_branch='" + branch + "' and st_yearsem='" + ys + "' and st_batch='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);  // fill dataset  

            studentlist4.DataTextField = ds1.Tables[0].Columns["st_rollno"].ToString(); // text field name of table dispalyed in dropdown       
            studentlist4.DataValueField = ds1.Tables[0].Columns["st_rollno"].ToString();
            // to retrive specific  textfield name   
            studentlist4.DataSource = ds1.Tables[0];      //assigning datasource to the dropdownlist  
            studentlist4.DataBind();
            studentlist4.Items.Insert(0, "Select");

        }

        protected void examnamelist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string course = courselist4.Text;
            string branch = branchlist4.Text;
            string yearsm = yearsemlist4.Text;
            string en = examnamelist4.Text;
            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsm + "'  and org_name='" + org + "' and exam_name='" + en + "' and batch_name='" + btch + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            subjectlist4.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
            subjectlist4.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
            // to retrive specific  textfield name   
            subjectlist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            subjectlist4.DataBind();
            subjectlist4.Items.Insert(0, "Select");
        }

        protected void subjectlist3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string course = courselist4.Text;
            string branch = branchlist4.Text;
            string yearsem = yearsemlist4.Text;
            string ename = examnamelist4.Text;
            string sname = subjectlist4.Text;
            string strol = studentlist4.Text;
          
            string ak = anskeyup.Value;
            string sts = stts.Value;
            string es = "Not started";
            string resdis = resdisp4.Value;
            string send = sendemail2.Value;
            try
            {


                DateTime od = DateTime.Parse(opentime4.Value);
                DateTime ed = DateTime.Parse(endtime4.Value);



                if (send !=""&& utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && ak != "Select" && ename != "" && sname != "" && sts != "Select" && resdis != "Select" && od.ToString() != "" && ed.ToString() != "")
                {
                    string sid = c1.Fillstring("Select set_id From org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + ename + "' and subject_name='" + sname + "' and batch_name='"+btch+"' and org_name='" + org + "'");
            int rem = int.Parse(c1.Fillstring("Select total_minut From org_exam_set_info Where set_id ='" + sid + "' and org_name='" + org + "'"));
            int tm = int.Parse(c1.Fillstring("Select total_marks From org_exam_set_info Where set_id ='" + sid + "' and org_name='" + org + "'"));


            string cmp = c1.Fillstring("Select count(course) From org_student_result Where course ='" + course + "' and branch ='" + branch + "' and yearsem ='" + yearsem + "' and examname ='" + ename + "'and subjectname='" + sname + "' and set_id='" + sid + "' and batch_name='"+btch+"' and org_name='" + org + "'");
            if (cmp != "0")
            {

                

         

                    c1.InsDelup("update org_student_result set set_id = '" + sid + "',remaning_min = '" + rem + "' ,examstatus = '" + es + "' ,studentstatus = '"+sts+"',linkopentime = '" + od.ToString("yyyy-MM-dd HH:mm:ss") + "',linkclosetime = '" + ed.ToString("yyyy-MM-dd HH:mm:ss") + "',atendance='Absent',resultdisplay = '" + resdis + "',answerkey='"+ak+"',total_marks='"+tm+"', obtain_marks=Null,correct_answer=Null,wrong_answer=Null,un_answer=Null,date=Null,submitexam_time=Null,attempt_no=0, opencount=0   where course ='" + course + "' and branch= '" + branch + "' and yearsem = '" + yearsem + "' and batch_name='"+btch+"' and examname = '" + ename + "' and subjectname = '" + sname + "' and org_name = '" + org + "'  and  student_id = '" + strol + "'");

                c1.InsDelup("delete from org_student_exam where  org_name = '" + org + "'  and  student_id = '" + strol + "' and set_id='"+sid+"'");
                c1.InsDelup("delete from org_student_exam_temp where org_name = '" + org + "'  and  student_id = '" + strol + "' and set_id='" + sid + "'");


                        string pwd = c1.Fillstring("Select pwd From org_mstLogin Where  org_name='" + org + "' and uid='" + strol + "'");

                        if (send == "Yes")
                        {
                            string emailidd = c1.Fillstring("Select st_email From org_student_info Where  org_name='" + org + "' and st_rollno='" + strol + "' and st_course ='" + course + "' and st_branch= '" + branch + "' and st_yearsem = '" + yearsem + "' and st_batch='" + btch + "'");



                            if (emailidd != "")
                            {
                                string stname = c1.Fillstring("Select st_name From org_student_info Where  org_name='" + org + "' and st_rollno='" + strol + "' and st_course ='" + course + "' and st_branch= '" + branch + "' and st_yearsem = '" + yearsem + "' and st_batch='" + btch + "'");


                                //string usernm = Session["userName"].ToString();

                                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                                stname = myTI.ToTitleCase(stname);


                                string to = emailidd; //To address    
                                string from = "info@testedu.in"; //From address    
                                MailMessage message1 = new MailMessage(from, to);

                                string mailbody = "Dear <b>" + stname + "</b>,<br/><br/> Your exam is scheduled on the date on <b>" + od.ToString() + "</b> for <b>" + sname + " </b>. Link will be open from <b> " + od.ToString() + "</b> to <b>" + ed.ToString() + "</b>. Your user ID is <b>" + strol + "</b> and your password is <b>" + pwd + "</b>. Open the link https://testedu.in/Default.aspx  for login. Ignore this mail if you have already attempt this test. <br/><br/> <b> Admin <br/> " + org + "</b> <br></br> ";
                                message1.Subject = "Updated test schedule by " + org;
                                message1.Body = mailbody;
                                message1.BodyEncoding = Encoding.UTF8;
                                message1.IsBodyHtml = true;
                                SmtpClient client = new SmtpClient("mail.testedu.in", 587); //Gmail smtp    
                                System.Net.NetworkCredential basicCredential1 = new
                                System.Net.NetworkCredential("info@testedu.in", "Test@12345");
                                client.EnableSsl = false;
                                client.UseDefaultCredentials = false;
                                client.Credentials = basicCredential1;
                                try
                                {
                                    client.Send(message1);
                                }

                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }

                        }








                        studentlist4.Text = "Select";
                opentime4.Value = "";
                endtime4.Value = "";


                string message = "Student test updated successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



            }
            else
            {
                string message = "Student not exist for update";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            }
                else
            {
                string message = "Fill All Entry";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }
            catch (Exception)
            {
                string message = "Select open and close Date/Server Error";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }



        }

        protected void studentlist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strol = studentlist4.Text;
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            stname.Value = c1.Fillstring("Select st_name From org_student_info Where org_name ='" + org + "' and st_rollno ='" + strol + "'");

        }

        protected void batchlist0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlist0.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            courselist0.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            courselist0.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            courselist0.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            courselist0.DataBind();
            courselist0.Items.Insert(0, "Select");
        }

        protected void batchlist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlist1.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            courselist1.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            courselist1.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            courselist1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            courselist1.DataBind();
            courselist1.Items.Insert(0, "Select");
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

        protected void batchlist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlist3.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            courselist3.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            courselist3.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            courselist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            courselist3.DataBind();
            courselist3.Items.Insert(0, "Select");
        }

        protected void batchlist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlist4.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            courselist4.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            courselist4.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            courselist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            courselist4.DataBind();
            courselist4.Items.Insert(0, "Select");
        }

        protected void yearsemlist0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string comp = courselist0.Text;
            string branch = branchlist0.Text;
            string ys = yearsemlist0.Text;
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='" + btch + "' and yearsem='" + ys + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delexamnamelist.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            delexamnamelist.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            delexamnamelist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delexamnamelist.DataBind();
            delexamnamelist.Items.Insert(0, "Select");
        }

        protected void examnamelist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string course = courselist1.Text;
            string branch = branchlist1.Text;
            string yearsm = yearsemlist1.Text;
            string en = examnamelist1.Text;
            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsm + "'  and org_name='" + org + "' and exam_name='" + en + "' and batch_name='"+btch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delsubjectlist.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
            delsubjectlist.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
            // to retrive specific  textfield name   
            delsubjectlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delsubjectlist.DataBind();
            delsubjectlist.Items.Insert(0, "Select");
        }

        protected void subjectlist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsm = yearsemlist2.Text;
            string en = examnamelist2.Text;
            string sub = subjectlist2.Text;


            SqlCommand com = new SqlCommand("select set_id from org_exam_set_info Where  org_name='" + org + "' order by set_id ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            setid1.DataTextField = ds.Tables[0].Columns["set_id"].ToString(); // text field name of table dispalyed in dropdown       
            setid1.DataValueField = ds.Tables[0].Columns["set_id"].ToString();
            // to retrive specific  textfield name   
            setid1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            setid1.DataBind();
            setid1.Items.Insert(0, "Select");


            string st = c1.Fillstring("select set_id from org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsm + "'  and org_name='" + org + "' and exam_name='" + en + "' and batch_name='" + btch + "' and subject_name='" + sub + "' ");
           if (st !="")
            {
                setid1.Text = st;
            }
            else
            {
                setid1.Text = "Select";
            }
            
        }

        protected void Updatesetid_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsem = yearsemlist2.Text;
            string en = examnamelist2.Text;
            string sn = subjectlist2.Text;
            string sid = setid1.Text;
            try
            {
                

                if (utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && sn != "Select" && en != "" && sn != "" && sid != "")
                {
                    string cmp = c1.Fillstring("Select count(set_id) From org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + en + "' and subject_name='" + sn + "' and batch_name='" + btch + "' and org_name='" + org + "'");
                if (cmp != "0")
                {
                    c1.InsDelup("update org_test_subject_setid set set_id='"+sid+ "' where course_name='" + course + "'and branch_name='" + branch + "'and yearsem='" + yearsem + "'and exam_name='" + en + "'and org_name='" + org + "' and subject_name='" + sn + "'and batch_name='" + btch + "'");

                    setid1.Text = "Select";


                    string message = "Set id have been updated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                }
                else
                {
                    string message = "Set Id not exist";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
                }
                else
                {
                    string message = "Fill All Entry";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception ex)
            {
                string message = "Something wrong/Server Error"+ex.ToString();
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as SubjectName,set_id as SetID from org_test_subject_setid where org_name='" + org + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void subjectlist4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void delexam_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string comp = courselist0.Text;
            string branch = branchlist0.Text;
            string ys = yearsemlist0.Text;
            if (delexamnamelist.Text != "Select" && delexamnamelist.Text != "")
            {
                c1.InsDelup("delete from org_test_examname where batch_name='" + btch + "' and course_name='"+comp+"' and branch_name='"+branch+"' and yearsem='"+ys+"' and exam_name='"+delexamnamelist.Text+"' and org_name='" + org + "'");


                string message = "Exam Name deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Select Exam name";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            
            SqlCommand com = new SqlCommand("select exam_name from org_test_examname where org_name='" + org + "'  and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='" + btch + "' and yearsem='" + ys + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delexamnamelist.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
            delexamnamelist.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
            // to retrive specific  textfield name   
            delexamnamelist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delexamnamelist.DataBind();
            delexamnamelist.Items.Insert(0, "Select");

            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName from org_test_examname where org_name='" + org + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void delsubject_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string comp = courselist1.Text;
            string branch = branchlist1.Text;
            string ys = yearsemlist1.Text;
            string ename = examnamelist1.Text;
            if (delsubjectlist.Text != "Select" && delsubjectlist.Text != "")
            {
                c1.InsDelup("delete from org_test_subject_name where batch_name='" + btch + "' and course_name='" + comp + "' and branch_name='" + branch + "' and yearsem='" + ys + "' and exam_name='" + ename + "' and subject_name='"+delsubjectlist.Text+"' and org_name='" + org + "'");


                string message = "Subject Name deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Select Subject name";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com = new SqlCommand("select subject_name from org_test_subject_name Where course_name ='" + comp + "' and branch_name ='" + branch + "' and yearsem ='" + ys + "'  and org_name='" + org + "' and exam_name='" + ename + "' and batch_name='" + btch + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delsubjectlist.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
            delsubjectlist.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
            // to retrive specific  textfield name   
            delsubjectlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delsubjectlist.DataBind();
            delsubjectlist.Items.Insert(0, "Select");

            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as Subjectname from org_test_subject_name where org_name='" + org + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as SubjectName,set_id as SetID,starttime as StartTime,endtime as EndTime,resdisp as ResultDisplay,anskey as AnswerKey  from org_exam_schedule where org_name='" + org + "' order by endtime", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void delsetid_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string course = courselist2.Text;
            string branch = branchlist2.Text;
            string yearsem = yearsemlist2.Text;
            string en = examnamelist2.Text;
            string sn = subjectlist2.Text;
            string sid = setid1.Text;
            try
            {
              
                if (utype != "" && btch != "" && course != "" && branch != "" && yearsem != "" && sn != "Select" && en != "" && sn != "" && sid != "")
                {

                    string cmp = c1.Fillstring("Select count(set_id) From org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + en + "' and subject_name='" + sn + "' and set_id='" + sid + "' and batch_name='" + btch + "' and org_name='" + org + "'");
                if (cmp != "0")
                {
                    c1.InsDelup("delete from org_test_subject_setid Where course_name ='" + course + "' and branch_name ='" + branch + "' and yearsem ='" + yearsem + "' and exam_name ='" + en + "' and subject_name='" + sn + "' and set_id='" + sid + "' and batch_name='" + btch + "' and org_name='" + org + "'");

                    setid1.Text = "Select";
                    subjectlist2.Text = "Select";

                    string message = "Set id have been Deleted successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                }
                else
                {
                    string message = "Set Id not exist";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
                else
            {
                string message = "Fill All Entry";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }
            catch (Exception ex)
            {
                string message = "Something wrong/Server Error" + ex.ToString();
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com1 = new SqlCommand("select batch_name as BatchName,course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem, exam_name as ExamName,subject_name as SubjectName,set_id as SetID from org_test_subject_setid where org_name='" + org + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }
    }
}