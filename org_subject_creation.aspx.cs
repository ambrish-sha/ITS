using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ITS
{
    public partial class org_subject_creation : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack != true)
            {
                string org = Session["orgname"].ToString();
                string utype = Session["usertype"].ToString();
                SqlCommand com1 = new SqlCommand("select subject_name from org_subject_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string message = "";
            string script = "";
            string subname = subject.Value;
            string chk = c1.Fillstring("Select subject_name From org_subject_name Where org_name='" + org + "' and user_type='" + utype + "' and subject_name = '" + subname + "' ");

            if (chk == "")
            {

                c1.InsDelup("insert into org_subject_name (subject_name,user_type,org_name) values( N'" + subname + "','"+utype+"','"+org+"')");

                message = "Your details have been saved successfully.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                subject.Value = "";
            }

            else
            {
                message = "This subject name already exist!!.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            SqlCommand com1 = new SqlCommand("select subject_name from org_subject_name where org_name='" + org + "' and user_type='" + utype + "'", con);
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
            string subname = subject.Value;
            c1.InsDelup("delete from org_subject_name where subject_name= '" + subname + "' and org_name='" + org + "' and user_type='" + utype + "'");

            SqlCommand com1 = new SqlCommand("select subject_name from org_subject_name where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            subject.Value = "";

            string message = "Your details Deleted successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject.Value = GridView1.SelectedRow.Cells[1].Text;
        }
    }
}