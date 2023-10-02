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

namespace ITS
{
    public partial class org_question_bank : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
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

                qtypeinputchange();

                //SqlCommand com1 = new SqlCommand("select * from question_bank", con);
                //con.Open();

                //SqlDataAdapter sda = new SqlDataAdapter(com1);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
                //con.Close();


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

        private void loadgrid(int n)
        {
            try { 
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            int a = 50 * (n - 1) + 1;
            int b = a + 49;
            SqlCommand com1 = new SqlCommand("SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY q_id) AS row FROM org_question_bank where org_name='" + org + "' and user_type='" + utype + "') a WHERE row >= " + a + " AND row <= " + b + "", con);
            //SqlCommand com1 = new SqlCommand("select * from question_bank", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();

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

        protected void Button4_Click(object sender, EventArgs e)
        {
            try { 
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            int chkk = int.Parse(c1.Fillstring("Select count(*) From org_question_bank where org_name='" + org + "' and user_type='" + utype + "'"));
            int pg = Convert.ToInt32(chkk / 50) + 1;
            int x = 0;
            selectpage.Items.Clear();
            selectpage.Items.Add(x.ToString());
            for (int i = 1; i <= pg; i++)
            {
                selectpage.Items.Add(i.ToString());
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

        protected void selectpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            int pg = int.Parse(selectpage.SelectedItem.ToString());
            loadgrid(pg);
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

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            try { 
            GridView1.PageIndex = e.NewPageIndex;
            loadgrid(1);

            this.DataBind();
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

        protected void subjectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
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
            catch
            {
                string message = "Login Again, If problem exist contact to developer";
        string script = "window.onload = function(){ alert('";
        script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string message = "";
            string script = "";

            int chkk = int.Parse(c1.Fillstring("Select count(*) From org_question_bank where org_name='" + org + "' and user_type='" + utype + "'"));
            if (chkk == 0)
            {
                chkk = int.Parse(c1.Fillstring("Select quesidstart From org_mstLogin where org_name='" + org + "' and userType='" + utype + "'"));
            }
            
            else
            {
                chkk = int.Parse(c1.Fillstring("Select max(q_id) From org_question_bank where org_name='" + org + "' and user_type='" + utype + "'"));

                if(chkk < 400000000)
                {
                    chkk = int.Parse(c1.Fillstring("Select quesidstart From org_mstLogin where org_name='" + org + "' and userType='" + utype + "'"));
                }
            }


            chkk = chkk + 1;



            int qid = chkk;
            string chk = c1.Fillstring("Select q_id From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = '" + qid + "' ");

            if (chk == "")
            {

                string lang = language.Value;
                string level = queslevel.Value;
                string qtype = questype.Text;

                if (qtype == "MCQ")
                {


                    string ques = questiontext.Value;
                    string opa = optiona.Value;
                    string opb = optionb.Value;
                    string opc = optionc.Value;
                    string opd = optiond.Value;
                    string corrans = correctoption.Value;
                    string desc = descanswer.Value;
                    string exnm = examname.Value;
                    string subnm = subjectname.Text;
                    string tp = topicname.Value;





                    c1.InsDelup("insert into org_question_bank (org_name,user_type,q_id,exame_name,subject,topic,question_level,question,option_a,option_b,option_c,option_d,correct_option,description,lang,ques_type) values( '"+org+"','"+utype+"'," + qid + ",N'" + exnm + "',N'" + subnm + "',N'" + tp + "','" + level + "',N'" + ques + "',N'" + opa + "',N'" + opb + "',N'" + opc + "',N'" + opd + "',N'" + corrans + "',N'" + desc + "',N'" + lang + "','" + qtype + "')");


                    string img = quesimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = quesimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            //{
                            string query = "UPDATE  org_question_bank set question_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }




                    img = optionaimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optionaimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            //using (SqlConnection con = new SqlConnection(constr))
                            //{
                            string query = "UPDATE  org_question_bank set option_a_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }


                    img = optionbimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optionbimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            // string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            //  {
                            string query = "UPDATE  org_question_bank set option_b_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }


                    img = optioncimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optioncimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //  string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set option_c_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }


                    img = optiondimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optiondimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //  string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set option_d_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }

                    img = descimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = descimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            // string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            //using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set desc_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }








                    message = "Your details have been saved successfully.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


                    questionid.Value = "";
                    questiontext.Value = "";
                    optiona.Value = "";
                    optionb.Value = "";
                    optionc.Value = "";
                    optiond.Value = "";
                    correctoption.Value = "";
                    descanswer.Value = "";



                    //SqlCommand com1 = new SqlCommand("select * from question_bank", con);
                    //con.Open();
                    //SqlDataReader rd = com1.ExecuteReader();
                    //GridView1.DataSource = rd;
                    //GridView1.DataBind();
                    //con.Close();


                }
                if (qtype == "INPUT")
                {




                    string ques = questiontext.Value;
                    //string opa = optiona.Value;
                    //string opb = optionb.Value;
                    //string opc = optionc.Value;
                    //string opd = optiond.Value;
                    string corrans = correctinput.Text;
                    string hint = hintinput.Text;


                    string desc = descanswer.Value;
                    string exnm = examname.Value;
                    string subnm = subjectname.Text;
                    string tp = topicname.Value;






                    c1.InsDelup("insert into org_question_bank (org_name,user_type,q_id,exame_name,subject,topic,question_level,question,correct_option,description,lang,ques_type,input_hint) values('"+org+"','"+utype+"', " + qid + ",N'" + exnm + "',N'" + subnm + "',N'" + tp + "','" + level + "',N'" + ques + "',N'" + corrans + "',N'" + desc + "',N'" + lang + "','" + qtype + "','" + hint + "' )");


                    string img = quesimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = quesimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            //{
                            string query = "UPDATE  org_question_bank set question_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }





                    img = descimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = descimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            // string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            //using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set desc_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }








                    message = "Question have been saved successfully.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


                    questionid.Value = "";
                    questiontext.Value = "";
                    optiona.Value = "";
                    optionb.Value = "";
                    optionc.Value = "";
                    optiond.Value = "";
                    correctoption.Value = "";
                    descanswer.Value = "";
                    hintinput.Text = "";
                    correctinput.Text = "";



                    //SqlCommand com1 = new SqlCommand("select * from question_bank", con);
                    //con.Open();
                    //SqlDataReader rd = com1.ExecuteReader();
                    //GridView1.DataSource = rd;
                    //GridView1.DataBind();
                    //con.Close();









                }

            }

            else
            {
                message = "This question id already exist!!.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
                int qid = int.Parse((GridView1.SelectedRow.FindControl("Label1") as Label).Text);
                questionid.Value = qid.ToString();




                string sql1 = "Select exame_name,subject,topic,question_level,lang,ques_type,input_hint,correct_option,question,option_a,option_b,option_c,option_d,correct_option,description  From org_question_bank Where org_name='" + org + "' and user_type='" + utype + "' and q_id = " + qid + " ";
                con.Open();
                SqlCommand comm1 = new SqlCommand(sql1, con);
                SqlDataReader reader1 = comm1.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows)
                {
                    examname.Value = reader1["exame_name"].ToString();
                    subjectname.Text = reader1["subject"].ToString();
                    topicname.Value = reader1["topic"].ToString();

                    queslevel.Value = reader1["question_level"].ToString();
                    language.Value = reader1["lang"].ToString();
                    questype.Text = reader1["ques_type"].ToString();
                    hintinput.Text = reader1["input_hint"].ToString();
                    correctinput.Text = reader1["correct_option"].ToString();
                    qtypeinputchange();
                    questiontext.Value = reader1["question"].ToString();
                    optiona.Value = reader1["option_a"].ToString();
                    optionb.Value = reader1["option_b"].ToString();
                    optionc.Value = reader1["option_c"].ToString();
                    optiond.Value = reader1["option_d"].ToString();

                    correctoption.Value = reader1["correct_option"].ToString();
                    descanswer.Value = reader1["description"].ToString();



                }
                con.Close();
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


        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
                string message = "";
                string script = "";
                int qid = int.Parse(questionid.Value);



                string lang = language.Value;
                string level = queslevel.Value;
                string qtype = questype.Text;

                if (qtype == "MCQ")
                {


                    string ques = questiontext.Value;
                    string opa = optiona.Value;
                    string opb = optionb.Value;
                    string opc = optionc.Value;
                    string opd = optiond.Value;
                    string corrans = correctoption.Value;
                    string desc = descanswer.Value;
                    string exnm = examname.Value;
                    string subnm = subjectname.Text;
                    string tp = topicname.Value;

                    c1.InsDelup("update org_question_bank set exame_name=N'" + exnm + "',subject=N'" + subnm + "',topic=N'" + tp + "',question_level='" + level + "',question=N'" + ques + "',option_a=N'" + opa + "',option_b=N'" + opb + "',option_c=N'" + opc + "',option_d=N'" + opd + "',correct_option=N'" + corrans + "',description=N'" + desc + "',lang=N'" + lang + "',ques_type='" + qtype + "' where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "");


                    string img = quesimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = quesimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            //{
                            string query = "UPDATE org_question_bank set question_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }




                    img = optionaimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optionaimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            //using (SqlConnection con = new SqlConnection(constr))
                            //{
                            string query = "UPDATE  org_question_bank set option_a_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }


                    img = optionbimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optionbimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            // string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            //  {
                            string query = "UPDATE  org_question_bank set option_b_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }


                    img = optioncimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optioncimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //  string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set option_c_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }


                    img = optiondimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = optiondimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //  string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set option_d_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            // }
                        }

                    }

                    img = descimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = descimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            // string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            //using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set desc_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }








                    message = "Your details Updated successfully.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


                    questionid.Value = "";
                    questiontext.Value = "";
                    optiona.Value = "";
                    optionb.Value = "";
                    optionc.Value = "";
                    optiond.Value = "";
                    correctoption.Value = "";
                    descanswer.Value = "";
                    hintinput.Text = "";
                    correctinput.Text = "";


                }

                if (qtype == "INPUT")
                {
                    string ques = questiontext.Value;
                    string opa = "";
                    string opb = "";
                    string opc = "";
                    string opd = "";
                    string corrans = correctinput.Text;
                    string hint = hintinput.Text;
                    string desc = descanswer.Value;
                    string exnm = examname.Value;
                    string subnm = subjectname.Text;
                    string tp = topicname.Value;

                    c1.InsDelup("update org_question_bank set exame_name=N'" + exnm + "',subject=N'" + subnm + "',topic=N'" + tp + "',question_level='" + level + "',question=N'" + ques + "',option_a=N'" + opa + "',option_b=N'" + opb + "',option_c=N'" + opc + "',option_d=N'" + opd + "',correct_option=N'" + corrans + "',description=N'" + desc + "',lang=N'" + lang + "',ques_type='" + qtype + "', input_hint = '" + hint + "' where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + qid + "");

                    string img = quesimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = quesimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            //string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            // using (SqlConnection con = new SqlConnection(constr))
                            //{
                            string query = "UPDATE  org_question_bank set question_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }






                    img = descimage.Value;
                    if (img != "")
                    {
                        byte[] bytes;
                        using (Stream fs = descimage.PostedFile.InputStream)
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                            //This line of code is reading the bytes .    
                            // string constr = ConfigurationManager.ConnectionStrings["aps"].ConnectionString;
                            //using (SqlConnection con = new SqlConnection(constr))
                            // {
                            string query = "UPDATE  org_question_bank set desc_image= @Data where org_name='" + org + "' and user_type='" + utype + "' and q_id= " + qid + "";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            //}
                        }

                    }








                    message = "Your details Updated successfully.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


                    questionid.Value = "";
                    questiontext.Value = "";
                    hintinput.Text = "";
                    correctinput.Text = "";
                    correctoption.Value = "";
                    descanswer.Value = "";

                }

                //SqlCommand com1 = new SqlCommand("select * from question_bank", con);
                //con.Open();
                //SqlDataReader rd = com1.ExecuteReader();
                //GridView1.DataSource = rd;
                //GridView1.DataBind();
                //con.Close();

                int chkk = int.Parse(c1.Fillstring("Select count(*) From org_question_bank where org_name='" + org + "' and user_type='" + utype + "'"));
                if (chkk == 0)
                {
                    chkk = 21000000;
                }
                else
                {
                    chkk = int.Parse(c1.Fillstring("Select max(q_id) From org_question_bank where org_name='" + org + "' and user_type='" + utype + "'"));
                }

                chkk = chkk + 1;
                questionid.Value = chkk.ToString();

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();

                int quesid = int.Parse(questionid.Value);

                if (quesid.ToString() != "")
                {

                    c1.InsDelup("delete from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and q_id=" + quesid + " ");

                    //SqlCommand com1 = new SqlCommand("select * from question_bank", con);
                    //con.Open();
                    //SqlDataReader rd = com1.ExecuteReader();
                    //GridView1.DataSource = rd;
                    //GridView1.DataBind();
                    //con.Close();

                    questionid.Value = "";
                    questiontext.Value = "";
                    optiona.Value = "";
                    optionb.Value = "";
                    optionc.Value = "";
                    optiond.Value = "";
                    correctoption.Value = "";
                    descanswer.Value = "";

                    string message = "Your details Deleted successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                }
                else
                {
                    string message = "Select question for delete ";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
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




        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
                string sr = TextBox12.Text;
                if (sr != "")
                {
                    if (RadioButton1.Checked == true)
                    {

                        SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and question like '%" + sr + "%' ", con);
                        con.Open();
                        //SqlDataReader rd = com1.ExecuteReader();
                        //GridView1.DataSource = rd;
                        //GridView1.DataBind();
                        SqlDataAdapter sda = new SqlDataAdapter(com1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }
                    if (RadioButton2.Checked == true)
                    {

                        SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and option_a like '%" + sr + "%' ", con);
                        con.Open();
                        //SqlDataReader rd = com1.ExecuteReader();
                        //GridView1.DataSource = rd;
                        //GridView1.DataBind();
                        SqlDataAdapter sda = new SqlDataAdapter(com1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }

                    if (RadioButton3.Checked == true)
                    {

                        SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and option_b like '%" + sr + "%' ", con);
                        con.Open();
                        //SqlDataReader rd = com1.ExecuteReader();
                        //GridView1.DataSource = rd;
                        //GridView1.DataBind();
                        SqlDataAdapter sda = new SqlDataAdapter(com1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }

                    if (RadioButton4.Checked == true)
                    {

                        SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and option_c like '%" + sr + "%' ", con);
                        con.Open();
                        //SqlDataReader rd = com1.ExecuteReader();
                        //GridView1.DataSource = rd;
                        //GridView1.DataBind();
                        SqlDataAdapter sda = new SqlDataAdapter(com1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }

                    if (RadioButton5.Checked == true)
                    {

                        SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and option_d like '%" + sr + "%' ", con);
                        con.Open();
                        //SqlDataReader rd = com1.ExecuteReader();
                        //GridView1.DataSource = rd;
                        //GridView1.DataBind();
                        SqlDataAdapter sda = new SqlDataAdapter(com1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }

                    if (RadioButton6.Checked == true)
                    {

                        SqlCommand com1 = new SqlCommand("select * from org_question_bank where org_name='" + org + "' and user_type='" + utype + "' and description like '%" + sr + "%' ", con);
                        con.Open();
                        //SqlDataReader rd = com1.ExecuteReader();
                        //GridView1.DataSource = rd;
                        //GridView1.DataBind();
                        SqlDataAdapter sda = new SqlDataAdapter(com1);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }






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

        public void qtypeinputchange()
        {
            try { 
            if (questype.Text == "INPUT")
            {
                inputtype.Visible = true;
                mcqtype.Visible = false;
            }
            if (questype.Text == "MCQ")
            {
                inputtype.Visible = false;
                mcqtype.Visible = true;
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


        protected void questype_SelectedIndexChanged(object sender, EventArgs e)
        {
            qtypeinputchange();
        }
    }
}