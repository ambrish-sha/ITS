using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ITS
{
    public partial class org_exam_creation : System.Web.UI.Page
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
                    SqlCommand com1 = new SqlCommand("select exam_name from org_exam_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(ex.Message);
            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
            string message = "";
            string script = "";
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string exname = examename.Value;
            string chk = c1.Fillstring("Select exam_name From org_exam_name Where org_name='"+org+"' and user_type='"+utype+"' and exam_name = '" + exname + "' ");

            if (chk == "")
            {
                c1.InsDelup("insert into org_exam_name (exam_name, org_name,user_type) values( N'" + exname + "','"+org+"','"+utype+"')");

                message = "Your details have been saved successfully.";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


                SqlCommand com1 = new SqlCommand("select exam_name from org_exam_name where org_name='" + org + "' and user_type='" + utype + "'", con);
                con.Open();
                SqlDataReader rd = com1.ExecuteReader();
                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();

                examename.Value = "";

            }

            else
            {
                message = "This exam name already exist!!.";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try { 
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string exname = examename.Value;
            c1.InsDelup("delete from org_exam_name where org_name='" + org + "' and user_type='" + utype + "' and exam_name= '" + exname + "'");

            SqlCommand com1 = new SqlCommand("select exam_name from org_exam_name where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();

            examename.Value = "";

            string message = "Your details Deleted successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
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
            try { 
            examename.Value = GridView1.SelectedRow.Cells[1].Text;
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
    }
}