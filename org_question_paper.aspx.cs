using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace ITS
{
    public partial class org_question_paper : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (IsPostBack != true)
                {
                    string org = Session["orgname"].ToString();
                    string utype = Session["usertype"].ToString();
                    SqlCommand com = new SqlCommand("select * from org_exam_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                    // table name   
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    da.Fill(ds);  // fill dataset  
                    examname.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
                    examname.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
                    // to retrive specific  textfield name   
                    examname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    examname.DataBind();
                    examname.Items.Insert(0, "");




                    com = new SqlCommand("select * from org_subject_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                    // table name   
                    da = new SqlDataAdapter(com);
                    ds = new DataSet();
                    da.Fill(ds);  // fill dataset  
                    subjectname.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
                    subjectname.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
                    // to retrive specific  textfield name   
                    subjectname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    subjectname.DataBind();
                    subjectname.Items.Insert(0, "");




                    com = new SqlCommand("select * from org_subject_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                    // table name   
                    da = new SqlDataAdapter(com);
                    ds = new DataSet();
                    da.Fill(ds);  // fill dataset  
                    subjectsearch.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
                    subjectsearch.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
                    // to retrive specific  textfield name   

                    subjectsearch.DataSource = ds.Tables[0];
                    subjectsearch.DataBind();
                    subjectsearch.Items.Insert(0, "");





                    SqlCommand com2 = new SqlCommand("select set_id from org_exam_set_info Where  org_name='" + org + "' order by set_id ", con);
                    // table name   
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);  // fill dataset  

                    setid.DataTextField = ds2.Tables[0].Columns["set_id"].ToString(); // text field name of table dispalyed in dropdown       
                    setid.DataValueField = ds2.Tables[0].Columns["set_id"].ToString();
                    // to retrive specific  textfield name   
                    setid.DataSource = ds2.Tables[0];      //assigning datasource to the dropdownlist  
                    setid.DataBind();
                    setid.Items.Insert(0, "Select");

                    //loadgrid();

                }

            }
            catch
            {
                string message = "Login Again, If problem exist contact to developer";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

        }


        private void loadgrid()
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string ss = subjectsearch.Text;
            string ts = topicsearch.Value;
            if (ss != "" && ts != "")
            {
                SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and subject='" + ss + "' and topic='" + ts + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(com1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
            else
            {
                SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' ", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(com1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            loadgrid();
            GridView1.PageIndex = e.NewPageIndex;
            this.DataBind();

        }

        protected void subjectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string subject = subjectname.Text;

            SqlCommand com = new SqlCommand("select topic_name from org_topic_name where org_name='" + org + "' and user_type='" + utype + "' and subject_name='" + subject + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            topicname.DataTextField = ds.Tables[0].Columns["topic_name"].ToString(); // text field name of table dispalyed in dropdown       
            topicname.DataValueField = ds.Tables[0].Columns["topic_name"].ToString();
            // to retrive specific  textfield name   
            topicname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            topicname.DataBind();
            topicname.Items.Insert(0, "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string message = "";
            string script = "";
            string stid = setid.Text;
            string qidd = questionid.Value;

            if (qidd != "")
            {

                int qid = int.Parse(questionid.Value);

                int sno = int.Parse(c1.Fillstring("Select count(*) From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' "));
                if (sno == 0)
                {
                    sno = 0;
                }
                else
                {
                    sno = int.Parse(c1.Fillstring("Select max(q_no) From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' "));
                }

                if (sno != int.Parse(totalquestion.Value))
                {

                    sno = sno + 1;
                    int qno = sno;



                    string chk1 = c1.Fillstring("Select q_no From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' and q_id=" + qid + " ");

                    if (chk1 != "")
                    {

                        message = "This Question Id already exist in set!!.";
                        script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }

                    else
                    {



                        string chk = c1.Fillstring("Select q_no From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' and q_no=" + qno + " ");


                        if (chk == "")
                        {



                            string lang = "";
                            string qtype = "";
                            string qtext = "";
                            string opa = "";
                            string opb = "";
                            string opc = "";
                            string opd = "";
                            string corro = "";
                            string desc = "";
                            string hint = "";

                            string sql3 = "Select lang,ques_type,question,option_a,option_b,option_c,option_d,correct_option,description,input_hint From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + qid + " ";
                            con.Open();
                            SqlCommand comm3 = new SqlCommand(sql3, con);
                            SqlDataReader reader3 = comm3.ExecuteReader();
                            reader3.Read();
                            if (reader3.HasRows)
                            {

                                lang = reader3["lang"].ToString();
                                qtype = reader3["ques_type"].ToString();

                                qtext = reader3["question"].ToString();
                                opa = reader3["option_a"].ToString();
                                opb = reader3["option_b"].ToString();
                                opc = reader3["option_c"].ToString();
                                opd = reader3["option_d"].ToString();
                                corro = reader3["correct_option"].ToString();
                                desc = reader3["description"].ToString();
                                hint = reader3["input_hint"].ToString();

                            }
                            con.Close();


















                           
                            float cm = float.Parse(correctmarks.Value);
                            float wm = float.Parse(wrongmarks.Value);
                            //int qno = int.Parse(questionsno.Value);
                            string totques = totalquestion.Value;









                            string exnm = examname.Value;
                            string subnm = subjectname.Text;
                            string tp = topicname.Value;

                            c1.InsDelup("insert into org_question_paper (org_name,user_type,set_id,exam_cat,q_no,q_id,exam_name,subject,topic,question,option_a,option_b,option_c,option_d,correct_option,description,correct_marks,wrong_marks,lang,ques_type,input_hint) values('"+org+"','"+utype+"' '" + stid + "','" + totques + "'," + qno + "," + qid + ",N'" + exnm + "',N'" + subnm + "',N'" + tp + "',N'" + qtext + "',N'" + opa + "',N'" + opb + "',N'" + opc + "',N'" + opd + "',N'" + corro + "',N'" + desc + "'," + cm + "," + wm + ",N'" + lang + "','" + qtype + "','" + hint + "')");



                            c1.InsDelup("update org_question_paper set question_image= (select question_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_a_image= (select option_a_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_b_image= (select option_b_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_c_image= (select option_c_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_d_image= (select option_d_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),desc_image= (select desc_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + ") where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + stid + "' and q_no=" + qno + " ");







                            message = "Your details have been saved successfully.";
                            script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                            string std = setid.Text;
                            SqlCommand com1 = new SqlCommand("select * from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'", con);
                            con.Open();
                            SqlDataReader rd = com1.ExecuteReader();
                            GridView2.DataSource = rd;
                            GridView2.DataBind();
                            con.Close();

                            questionid.Value = "";
                            questiontext.Value = "";
                            optiona.Value = "";
                            optionb.Value = "";
                            optionc.Value = "";
                            optiond.Value = "";
                            correctoption.Value = "";
                            descanswer.Value = "";
                            quesimage.Src = "";
                            Img1.Src = "";
                            Img2.Src = "";
                            Img3.Src = "";
                            Img4.Src = "";
                            Img5.Src = "";




                        }
                        else
                        {

                            message = "This qno already exist!!.";
                            script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                        }

                    }



                }

                else
                {
                    message = "all question have created for this set!!.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }

            else
            {
                message = "Enter questin id!!.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }




        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            //int chk = int.Parse(c1.Fillstring("Select max(q_id) From org_question_bank"));
            //chk = chk + 1;
            //questionid.Value = chk.ToString();

            string sub = subjectsearch.Text; ;
            string topic = topicsearch.Value;
            string qtyp = qtypesearch.Value;

            SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and subject='" + sub + "' and topic='" + topic + "' and ques_type='" + qtyp + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();

        }

        protected void subjectsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string subject = subjectsearch.Text;

            SqlCommand com = new SqlCommand("select topic_name from org_topic_name where org_name='" + org + "' and user_type='" + utype + "' and subject_name='" + subject + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            topicsearch.DataTextField = ds.Tables[0].Columns["topic_name"].ToString(); // text field name of table dispalyed in dropdown       
            topicsearch.DataValueField = ds.Tables[0].Columns["topic_name"].ToString();
            // to retrive specific  textfield name   
            topicsearch.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            topicsearch.DataBind();
            topicsearch.Items.Insert(0, "Choose Topic");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();

            quesimage.Src = "";
            Img1.Src = "";
            Img2.Src = "";
            Img3.Src = "";
            Img4.Src = "";
            Img5.Src = "";
            int stid = int.Parse((GridView1.SelectedRow.FindControl("Label1") as Label).Text);


            questionid.Value = stid.ToString();



            string sql3 = "Select question,option_a,option_b,option_c,option_d,correct_option,description From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
            con.Open();
            SqlCommand comm3 = new SqlCommand(sql3, con);
            SqlDataReader reader3 = comm3.ExecuteReader();
            reader3.Read();
            if (reader3.HasRows)
            {



                questiontext.Value = reader3["question"].ToString();
                optiona.Value = reader3["option_a"].ToString();
                optionb.Value = reader3["option_b"].ToString();
                optionc.Value = reader3["option_c"].ToString();
                optiond.Value = reader3["option_d"].ToString();
                correctoption.Value = reader3["correct_option"].ToString();
                descanswer.Value = reader3["description"].ToString();


            }
            con.Close();


            string sql;
            SqlCommand comm;
            SqlDataReader reader;
            string im = c1.Fillstring("Select question_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ");
            if (im != "")
            {

                sql = "Select question_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                con.Open();
                comm = new SqlCommand(sql, con);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    string qimage = Convert.ToBase64String(img);

                    quesimage.Src = "data:image/png;base64," + qimage;


                }
                con.Close();

            }


            im = c1.Fillstring("Select option_a_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
            if (im != "")
            {

                sql = "Select option_a_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                con.Open();
                comm = new SqlCommand(sql, con);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    string qimage = Convert.ToBase64String(img);

                    Img1.Src = "data:image/png;base64," + qimage;


                }
                con.Close();

            }

            im = c1.Fillstring("Select option_b_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
            if (im != "")
            {



                sql = "Select option_b_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                con.Open();
                comm = new SqlCommand(sql, con);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    string qimage = Convert.ToBase64String(img);

                    Img2.Src = "data:image/png;base64," + qimage;


                }
                con.Close();

            }

            im = c1.Fillstring("Select option_c_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
            if (im != "")
            {

                sql = "Select option_c_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                con.Open();
                comm = new SqlCommand(sql, con);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    string qimage = Convert.ToBase64String(img);

                    Img3.Src = "data:image/png;base64," + qimage;


                }
                con.Close();

            }


            im = c1.Fillstring("Select option_d_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
            if (im != "")
            {

                sql = "Select option_d_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                con.Open();
                comm = new SqlCommand(sql, con);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    string qimage = Convert.ToBase64String(img);

                    Img4.Src = "data:image/png;base64," + qimage;


                }
                con.Close();

            }

            im = c1.Fillstring("Select desc_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
            if (im != "")
            {

                sql = "Select desc_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                con.Open();
                comm = new SqlCommand(sql, con);
                reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {

                    byte[] img = (byte[])(reader[0]);
                    string qimage = Convert.ToBase64String(img);

                    Img5.Src = "data:image/png;base64," + qimage;


                }
                con.Close();
            }








        }

        protected void searchsetid_Click(object sender, EventArgs e)
        {
           

        }

        protected void searchquestion_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            quesimage.Src = "";
            Img1.Src = "";
            Img2.Src = "";
            Img3.Src = "";
            Img4.Src = "";
            Img5.Src = "";
            string stiddd = questionid.Value;

            string message = "";
            string script = "";

            if (stiddd != "")
            {
                int stid = int.Parse(questionid.Value);
                string chk = c1.Fillstring("Select q_id From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ");

                if (chk != "")
                {



                   

                    string sql3 = "Select question,option_a,option_b,option_c,option_d,correct_option,description From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                    con.Open();
                    SqlCommand comm3 = new SqlCommand(sql3, con);
                    SqlDataReader reader3 = comm3.ExecuteReader();
                    reader3.Read();
                    if (reader3.HasRows)
                    {



                        questiontext.Value = reader3["question"].ToString();
                        optiona.Value = reader3["option_a"].ToString();
                        optionb.Value = reader3["option_b"].ToString();
                        optionc.Value = reader3["option_c"].ToString();
                        optiond.Value = reader3["option_d"].ToString();
                        correctoption.Value = reader3["correct_option"].ToString();
                        descanswer.Value = reader3["description"].ToString();
                  

                    }
                    con.Close();







                    string sql;
                    SqlCommand comm;
                    SqlDataReader reader;
                    string im = c1.Fillstring("Select question_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ");
                    if (im != "")
                    {

                        sql = "Select question_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                        con.Open();
                        comm = new SqlCommand(sql, con);
                        reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {

                            byte[] img = (byte[])(reader[0]);
                            string qimage = Convert.ToBase64String(img);

                            quesimage.Src = "data:image/png;base64," + qimage;


                        }
                        con.Close();

                    }


                    im = c1.Fillstring("Select option_a_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
                    if (im != "")
                    {

                        sql = "Select option_a_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                        con.Open();
                        comm = new SqlCommand(sql, con);
                        reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {

                            byte[] img = (byte[])(reader[0]);
                            string qimage = Convert.ToBase64String(img);

                            Img1.Src = "data:image/png;base64," + qimage;


                        }
                        con.Close();

                    }

                    im = c1.Fillstring("Select option_b_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
                    if (im != "")
                    {



                        sql = "Select option_b_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                        con.Open();
                        comm = new SqlCommand(sql, con);
                        reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {

                            byte[] img = (byte[])(reader[0]);
                            string qimage = Convert.ToBase64String(img);

                            Img2.Src = "data:image/png;base64," + qimage;


                        }
                        con.Close();

                    }

                    im = c1.Fillstring("Select option_c_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
                    if (im != "")
                    {

                        sql = "Select option_c_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                        con.Open();
                        comm = new SqlCommand(sql, con);
                        reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {

                            byte[] img = (byte[])(reader[0]);
                            string qimage = Convert.ToBase64String(img);

                            Img3.Src = "data:image/png;base64," + qimage;


                        }
                        con.Close();

                    }


                    im = c1.Fillstring("Select option_d_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
                    if (im != "")
                    {

                        sql = "Select option_d_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                        con.Open();
                        comm = new SqlCommand(sql, con);
                        reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {

                            byte[] img = (byte[])(reader[0]);
                            string qimage = Convert.ToBase64String(img);

                            Img4.Src = "data:image/png;base64," + qimage;


                        }
                        con.Close();

                    }

                    im = c1.Fillstring("Select desc_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + "  ");
                    if (im != "")
                    {

                        sql = "Select desc_image From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + stid + " ";
                        con.Open();
                        comm = new SqlCommand(sql, con);
                        reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {

                            byte[] img = (byte[])(reader[0]);
                            string qimage = Convert.ToBase64String(img);

                            Img5.Src = "data:image/png;base64," + qimage;


                        }
                        con.Close();
                    }










                }

                else
                {
                    message = "This question id does not exist!!.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            else
            {
                message = "Enter question id!!.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            }

        }

        protected void deleteques_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string qids = questionid.Value;
            string std = setid.Text;

            if (qids != "")
            {
                int quesid = int.Parse(questionid.Value);

                c1.InsDelup("delete from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "' and q_id=" + quesid + " ");


                SqlCommand com1 = new SqlCommand("select * from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView2.DataSource = rd;
                GridView2.DataBind();
                con.Close();

                questionid.Value = "";
                questionid.Value = "";
                questiontext.Value = "";
                optiona.Value = "";
                optionb.Value = "";
                optionc.Value = "";
                optiond.Value = "";
                correctoption.Value = "";
                descanswer.Value = "";
                quesimage.Src = "";
                Img1.Src = "";
                Img2.Src = "";
                Img3.Src = "";
                Img4.Src = "";
                Img5.Src = "";

                string message = "Your question Deleted successfully from paper.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Enter question id.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }

        protected void addinmid_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string message = "";
            string script = "";
            string stid = setid.Text;

            string qnos = questionsno.Value;


            if (qnos != "")
            {

                int qno = int.Parse(questionsno.Value);


                if (qno <= int.Parse(totalquestion.Value))
                {



                    int qid = int.Parse(questionid.Value);

                    string chk1 = c1.Fillstring("Select q_no From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' and q_id=" + qid + " ");

                    if (chk1 != "")
                    {

                        message = "This Question Id already exist in set!!.";
                        script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }

                    else
                    {



                        string chk = c1.Fillstring("Select q_no From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' and q_no=" + qno + " ");


                        if (chk == "")
                        {
                            string lang = "";
                            string qtype = "";
                            string qtext = "";
                            string opa = "";
                            string opb = "";
                            string opc = "";
                            string opd = "";
                            string corro = "";
                            string desc = "";
                            string hint = "";

                            string sql3 = "Select lang,ques_type,question,option_a,option_b,option_c,option_d,correct_option,description,input_hint From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + qid + " ";
                            con.Open();
                            SqlCommand comm3 = new SqlCommand(sql3, con);
                            SqlDataReader reader3 = comm3.ExecuteReader();
                            reader3.Read();
                            if (reader3.HasRows)
                            {

                              lang = reader3["lang"].ToString();
                                qtype = reader3["ques_type"].ToString();

                                qtext = reader3["question"].ToString();
                                opa = reader3["option_a"].ToString();
                               opb = reader3["option_b"].ToString();
                                opc = reader3["option_c"].ToString();
                                opd = reader3["option_d"].ToString();
                                corro = reader3["correct_option"].ToString();
                                desc = reader3["description"].ToString();
                                hint = reader3["input_hint"].ToString();

                            }
                            con.Close();




                            

                            float cm = float.Parse(correctmarks.Value);
                            float wm = float.Parse(wrongmarks.Value);
                            //int qno = int.Parse(questionsno.Value);
                            string totques = totalquestion.Value;






                           




                            string exnm = examname.Value;
                            string subnm = subjectname.Text;
                            string tp = topicname.Value;

                            c1.InsDelup("insert into org_question_paper (org_name,user_type,set_id,exam_cat,q_no,q_id,exam_name,subject,topic,question,option_a,option_b,option_c,option_d,correct_option,description,correct_marks,wrong_marks,lang,ques_type,input_hint) values('"+org+"','"+utype+"', '" + stid + "','" + totques + "'," + qno + "," + qid + ",N'" + exnm + "',N'" + subnm + "',N'" + tp + "',N'" + qtext + "',N'" + opa + "',N'" + opb + "',N'" + opc + "',N'" + opd + "',N'" + corro + "',N'" + desc + "'," + cm + "," + wm + ",N'" + lang + "','" + qtype + "','" + hint + "')");



                            c1.InsDelup("update org_question_paper set question_image= (select question_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_a_image= (select option_a_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_b_image= (select option_b_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_c_image= (select option_c_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_d_image= (select option_d_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),desc_image= (select desc_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + ") where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + stid + "' and q_no=" + qno + " ");







                            message = "Your details have been saved successfully.";
                            script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                            string std = setid.Text;
                            SqlCommand com1 = new SqlCommand("select * from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'", con);
                            con.Open();
                            SqlDataReader rd = com1.ExecuteReader();
                            GridView2.DataSource = rd;
                            GridView2.DataBind();
                            con.Close();

                            questionid.Value = "";
                            questiontext.Value = "";
                            optiona.Value = "";
                            optionb.Value = "";
                            optionc.Value = "";
                            optiond.Value = "";
                            correctoption.Value = "";
                            descanswer.Value = "";
                            quesimage.Src = "";
                            Img1.Src = "";
                            Img2.Src = "";
                            Img3.Src = "";
                            Img4.Src = "";
                            Img5.Src = "";




                        }
                        else
                        {

                            message = "This qno already exist!!.";
                            script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                        }

                    }



                }

                else
                {
                    message = "all question no is out of total question!!.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            else
            {
                message = "Enter question no before submission!!.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            }



        }

        protected void deleteall_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();

            string std = setid.Text;

            if (std != "")
            {

                c1.InsDelup("delete from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'  ");


                SqlCommand com1 = new SqlCommand("select * from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView2.DataSource = rd;
                GridView2.DataBind();
                con.Close();

                questionid.Value = "";
                questionid.Value = "";
                questiontext.Value = "";
                optiona.Value = "";
                optionb.Value = "";
                optionc.Value = "";
                optiond.Value = "";
                correctoption.Value = "";
                descanswer.Value = "";
                quesimage.Src = "";
                Img1.Src = "";
                Img2.Src = "";
                Img3.Src = "";
                Img4.Src = "";
                Img5.Src = "";

                string message = "all question Deleted successfully from this paper.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            }
            else
            {
                string message = "Set id is empty.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            }

        }

        protected void movetoquespaper_Click(object sender, EventArgs e)
        {
            try
            {

                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();

                string message = "";
                string script = "";
                string stid = setid.Text;
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                    if (checkbox.Checked)
                    {
                        checkbox.Checked = false;
                        int qid = int.Parse((gvrow.FindControl("Label1") as Label).Text);

                        int sno = int.Parse(c1.Fillstring("Select count(*) From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' "));
                        if (sno == 0)
                        {
                            sno = 0;
                        }
                        else
                        {
                            sno = int.Parse(c1.Fillstring("Select max(q_no) From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' "));
                        }

                        if (sno != int.Parse(totalquestion.Value))
                        {

                            sno = sno + 1;
                            int qno = sno;



                            string chk1 = c1.Fillstring("Select q_no From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' and q_id=" + qid + " ");

                            if (chk1 != "")
                            {

                                message = "This Question Id already exist in set!!.";
                                script = "window.onload = function(){ alert('";
                                script += message;
                                script += "')};";
                                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                            }

                            else
                            {



                                string chk = c1.Fillstring("Select q_no From org_question_paper Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' and q_no=" + qno + " ");


                                if (chk == "")
                                {


                                    float cm = float.Parse(correctmarks.Value);
                                    float wm = float.Parse(wrongmarks.Value);
                                    //int qno = int.Parse(questionsno.Value);
                                    string totques = totalquestion.Value;


                                    string sql3 = "Select lang,ques_type,question,option_a,option_b,option_c,option_d,correct_option,description,input_hint From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + qid + "";
                                    con.Open();
                                    SqlCommand comm3 = new SqlCommand(sql3, con);
                                    SqlDataReader reader3 = comm3.ExecuteReader();
                                    reader3.Read();

                                    string lang = "", qtype = "", qtext = "", opa = "", opb = "", opc = "", opd = "", corro = "", desc = "", hint = "";
                                    if (reader3.HasRows)
                                    {

                                        lang = reader3["lang"].ToString();
                                        qtype = reader3["ques_type"].ToString();
                                        qtext = reader3["question"].ToString();
                                        opa = reader3["option_a"].ToString();
                                        opb = reader3["option_b"].ToString();
                                        opc = reader3["option_c"].ToString();
                                        opd = reader3["option_d"].ToString();
                                        corro = reader3["correct_option"].ToString();
                                        desc = reader3["description"].ToString();
                                        hint = reader3["input_hint"].ToString();





                                    }
                                    con.Close();






                                    //string lang = c1.Fillstring("Select lang From org_question_bank Where q_id = " + qid + " ");
                                    //string qtype = c1.Fillstring("Select ques_type From org_question_bank Where q_id = " + qid + " ");
                                    //string qtext = c1.Fillstring("Select question From org_question_bank Where q_id = " + qid + " ");
                                    //string opa = c1.Fillstring("Select option_a From org_question_bank Where q_id = " + qid + " ");
                                    //string opb = c1.Fillstring("Select option_b From org_question_bank Where q_id = " + qid + " ");
                                    //string opc = c1.Fillstring("Select option_c From org_question_bank Where q_id = " + qid + " ");
                                    //string opd = c1.Fillstring("Select option_d From org_question_bank Where q_id = " + qid + " ");
                                    //string corro = c1.Fillstring("Select correct_option From org_question_bank Where q_id = " + qid + " ");
                                    //string desc = c1.Fillstring("Select description From org_question_bank Where q_id = " + qid + " ");
                                    //string hint = c1.Fillstring("Select input_hint From org_question_bank Where q_id = " + qid + " ");





                                    string exnm = examname.Value;
                                    string subnm = subjectname.Text;
                                    string tp = topicname.Value;

                                    //c1.InsDelup("insert into student_exam_temp_old (student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj) select student_id,set_id,attemp_no,q_id,q_no,answer,correct_option,correct_marks,wrong_marks,sno,start_time,submit_time,total_time_take,ques_mark,time_taken,subj from student_exam_temp where student_id='" + student_id + "'");

                                    //c1.InsDelup("insert into org_question_paper(set_id,exam_cat,q_no,q_id,exam_name,subject,topic,question,option_a,option_b,option_c,option_d,correct_option,description,correct_marks,wrong_marks,lang,ques_type,input_hint,question_image,option_a_image,option_b_image,option_c_image,option_d_image,desc_image) select set_id,exam_cat,q_no,q_id,exam_name,subject,topic,question,option_a,option_b,option_c,option_d,correct_option,description,correct_marks,wrong_marks,lang,ques_type,input_hint,question_image,option_a_image,option_b_image,option_c_image,option_d_image,desc_image from org_question_bank where q_id = "+qid+"");


                                    c1.InsDelup("insert into org_question_paper (org_name,user_type,set_id,exam_cat,q_no,q_id,exam_name,subject,topic,question,option_a,option_b,option_c,option_d,correct_option,description,correct_marks,wrong_marks,lang,ques_type,input_hint) values('"+org+"','"+utype+"', '" + stid + "','" + totques + "'," + qno + "," + qid + ",N'" + exnm + "',N'" + subnm + "',N'" + tp + "',N'" + qtext + "',N'" + opa + "',N'" + opb + "',N'" + opc + "',N'" + opd + "',N'" + corro + "',N'" + desc + "'," + cm + "," + wm + ",N'" + lang + "','" + qtype + "','" + hint + "')");



                                    c1.InsDelup("update org_question_paper set question_image= (select question_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_a_image= (select option_a_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_b_image= (select option_b_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_c_image= (select option_c_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),option_d_image= (select option_d_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "),desc_image= (select desc_image from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + ") where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + stid + "' and q_no=" + qno + " ");







                                    message = "Your details have been saved successfully.";
                                    script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                                    string std = setid.Text;
                                    SqlCommand com1 = new SqlCommand("select * from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'", con);
                                    con.Open();
                                    SqlDataReader rd = com1.ExecuteReader();
                                    GridView2.DataSource = rd;
                                    GridView2.DataBind();
                                    con.Close();

                                    questionid.Value = "";
                                    questiontext.Value = "";
                                    optiona.Value = "";
                                    optionb.Value = "";
                                    optionc.Value = "";
                                    optiond.Value = "";
                                    correctoption.Value = "";
                                    descanswer.Value = "";
                                    quesimage.Src = "";
                                    Img1.Src = "";
                                    Img2.Src = "";
                                    Img3.Src = "";
                                    Img4.Src = "";
                                    Img5.Src = "";




                                }
                                else
                                {

                                    message = "This qno already exist!!.";
                                    script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "')};";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



                                }

                            }



                        }

                        else
                        {
                            message = "all question have created for this set!!.";
                            script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                string message = "Some error occure " + ex.Message + "";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                Response.Redirect("org_question_paper.aspx");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(com1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

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
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView2.GridLines = GridLines.Both;
            GridView2.HeaderStyle.Font.Bold = true;
            GridView2.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }


        public string GetImage(object img)
        {
            if (img.ToString() != "")
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }
            else
            {
                return "";
            }

        }

        protected void setid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string stid = setid.Text;
            string message = "";
            string script = "";

            if (stid != "")
            {

                string chk = c1.Fillstring("Select set_id From org_exam_set_info Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' ");

                if (chk != "")
                {

                    string sql3 = "Select exam_name,topic,exam_cat,total_minut,wrong_marks,correct_marks,total_marks From org_exam_set_info Where set_id = '" + stid + "' and org_name='" + org + "' and user_type='" + utype + "' ";
                    con.Open();
                    SqlCommand comm3 = new SqlCommand(sql3, con);
                    SqlDataReader reader3 = comm3.ExecuteReader();
                    reader3.Read();
                    if (reader3.HasRows)
                    {



                        examname.Value = reader3["exam_name"].ToString();
                        topicname.Value = reader3["topic"].ToString();
                        totalquestion.Value = reader3["exam_cat"].ToString();
                        totalduration.Value = reader3["total_minut"].ToString();
                        wrongmarks.Value = reader3["wrong_marks"].ToString();
                        correctmarks.Value = reader3["correct_marks"].ToString();
                        totalmarks.Value = reader3["total_marks"].ToString();


                    }
                    con.Close();









                    string std = setid.Text;
                    SqlCommand com1 = new SqlCommand("select * from org_question_paper where org_name='" + org + "' and user_type='" + utype + "' and set_id='" + std + "'", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView2.DataSource = rd;
                    GridView2.DataBind();
                    con.Close();


                }

                else
                {
                    message = "This set id does not exist!!.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }

            }
            else
            {
                message = "Select set id";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

        }
    }
}