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
    public partial class org_set_creation : System.Web.UI.Page
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
                    examname.Items.Insert(0, "Select");

                    exmname.DataTextField = ds.Tables[0].Columns["exam_name"].ToString(); // text field name of table dispalyed in dropdown       
                    exmname.DataValueField = ds.Tables[0].Columns["exam_name"].ToString();
                    // to retrive specific  textfield name   
                    exmname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    exmname.DataBind();
                    exmname.Items.Insert(0, "Select");




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
                    subjectname.Items.Insert(0, "Select");

                    sbj.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
                    sbj.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
                    // to retrive specific  textfield name   
                    sbj.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    sbj.DataBind();
                    sbj.Items.Insert(0, "Select");



                    SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "'", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();
                }
            }
            catch
            {
                Response.Redirect("org_set_creation.aspx");
            }
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
                string message = "";
                string script = "";
                string stid = setid.Value;
                string chk = c1.Fillstring("Select set_id From org_exam_set_info Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + stid + "' ");


                if (chk == "")
                {

                    string ecat = examcat.Value;
                    float tm = float.Parse(totalmarks.Value);
                    int td = int.Parse(totalduration.Value);
                    float cm = float.Parse(correctmarks.Value);
                    float wm = float.Parse(wrongmarks.Value);
                    string exnm = examname.Value;
                    string subnm = subjectname.Text;
                    string tp = topicname.Value;

                    c1.InsDelup("insert into org_exam_set_info(org_name,user_type,set_id,exam_cat,total_marks,total_minut,correct_marks,wrong_marks,exam_name,subject,topic) values('"+org+"','"+utype+"','" + stid + "','" + ecat + "'," + tm + "," + td + "," + cm + "," + wm + ",N'" + exnm + "',N'" + subnm + "',N'" + tp + "')");
                    message = "Your details have been saved successfully.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);





                    SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "'", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();


                    setid.Value = "";
                    examcat.Value = "";
                    totalmarks.Value = "";
                    totalduration.Value = "";
                    correctmarks.Value = "";
                    wrongmarks.Value = "";



                }

                else
                {
                    message = "This set id already exist!!.";
                    script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }







            }
            catch
            {
                Response.Redirect("org_set_creation.aspx");
            }
        }

        protected void changesubject()
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
            topicname.Items.Insert(0, "Select");



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
            topicname.Items.Insert(0, "Select");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();

                setid.Value = GridView1.SelectedRow.Cells[1].Text;
                examcat.Value = GridView1.SelectedRow.Cells[2].Text;
                totalmarks.Value = GridView1.SelectedRow.Cells[3].Text;
                totalduration.Value = GridView1.SelectedRow.Cells[4].Text;
                correctmarks.Value = GridView1.SelectedRow.Cells[5].Text;
                wrongmarks.Value = GridView1.SelectedRow.Cells[6].Text;
                subjectname.Text = c1.Fillstring("Select subject From org_exam_set_info Where org_name='" + org + "' and user_type='" + utype + "' and set_id = '" + GridView1.SelectedRow.Cells[1].Text + "' ");
                examname.Value = GridView1.SelectedRow.Cells[7].Text;

                topicname.Value = GridView1.SelectedRow.Cells[9].Text;
            }
            catch
            {
                Response.Redirect("org_set_creation.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
                string stid = setid.Value;


                c1.InsDelup("delete from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and set_id= '" + stid + "'");

                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' ", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();


                string message = "Your details Deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                setid.Value = "";
                examcat.Value = "";
                totalmarks.Value = "";
                totalduration.Value = "";
                correctmarks.Value = "";
                wrongmarks.Value = "";

            }
            catch
            {
                Response.Redirect("org_set_creation.aspx");
            }
        }

        protected void exmname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            sbj.Text = "Select";
            tpk.Text = "Select";
            SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and exam_name='" + exmname.Text + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void sbj_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();

            string subject = sbj.Text;

            SqlCommand com = new SqlCommand("select topic_name from org_topic_name where org_name='" + org + "' and user_type='" + utype + "' and subject_name='" + subject + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            tpk.DataTextField = ds.Tables[0].Columns["topic_name"].ToString(); // text field name of table dispalyed in dropdown       
            tpk.DataValueField = ds.Tables[0].Columns["topic_name"].ToString();
            // to retrive specific  textfield name   
            tpk.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            tpk.DataBind();
            tpk.Items.Insert(0, "Select");



            if (exmname.Text == "")
            {
                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info org_name='" + org + "' and user_type='" + utype + "' and where subject='" + sbj.Text + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }
            else
            {
                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and exam_name='" + exmname.Text + "' and subject='" + sbj.Text + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void tpk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            if (exmname.Text == "" || sbj.Text == "")
            {
                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and topic='" + tpk.Text + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }
            else if (exmname.Text == "")
            {
                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and topic='" + tpk.Text + "' and subject='" + sbj.Text + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }

            else if (sbj.Text == "")
            {
                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and exam_name='" + exmname.Text + "' and topic='" + tpk.Text + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }
            else
            {
                SqlCommand com1 = new SqlCommand("select set_id,  exam_cat, total_marks, total_minut, correct_marks,   wrong_marks, exam_name,   subject, topic from org_exam_set_info where org_name='" + org + "' and user_type='" + utype + "' and exam_name='" + exmname.Text + "' and subject='" + sbj.Text + "' and topic='" + tpk.Text + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }
        }
    }
}