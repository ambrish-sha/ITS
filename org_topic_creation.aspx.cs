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
    public partial class org_topic_creation : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["Logged"].Equals("No"))
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "redirect", "if(top!=self) {top.location.href = 'logout.aspx';}", true);
                //}
                if (IsPostBack != true)
                {
                    string org = Session["orgname"].ToString();
                    string utype = Session["usertype"].ToString();
                    SqlCommand com = new SqlCommand("select * from org_subject_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                    // table name   
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    da.Fill(ds);  // fill dataset  
                    subjectname.DataTextField = ds.Tables[0].Columns["subject_name"].ToString(); // text field name of table dispalyed in dropdown       
                    subjectname.DataValueField = ds.Tables[0].Columns["subject_name"].ToString();
                    // to retrive specific  textfield name   
                    subjectname.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                    subjectname.DataBind();
                    subjectname.Items.Insert(0, "Select");

                    SqlCommand com1 = new SqlCommand("select subject_name,topic_name from org_topic_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string message = "";
            string script = "";
            string subname = subjectname.Value;
            string topname = topic.Value;

            string chk = c1.Fillstring("Select topic_name From org_topic_name Where org_name='" + org + "' and user_type='" + utype + "' and subject_name = '" + subname + "' and topic_name='" + topname + "' ");

            if (chk == "")
            {

                c1.InsDelup("insert into org_topic_name (subject_name,topic_name,org_name,user_type) values( '" + subname + "', '" + topname + "','"+org+"','"+utype+"')");

                topic.Value = "";


                message = "Your details have been saved successfully.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            else
            {
                message = "This topic name already exist!!.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            SqlCommand com1 = new SqlCommand("select subject_name,topic_name from org_topic_name where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string subname = subjectname.Value;
            string topname = topic.Value;

            c1.InsDelup("delete from org_topic_name where org_name='" + org + "' and user_type='" + utype + "' and subject_name= N'" + subname + "' and topic_name =N'" + topname + "'");

            SqlCommand com1 = new SqlCommand("select subject_name,topic_name from org_topic_name where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            topic.Value = "";

            string message = "Your details Deleted successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            subjectname.Value = GridView1.SelectedRow.Cells[1].Text;
            topic.Value = GridView1.SelectedRow.Cells[2].Text;
        }
    }
}