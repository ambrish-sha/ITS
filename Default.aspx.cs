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
    public partial class Default : System.Web.UI.Page
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
                    Session["empcd"] = "";
                }
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session["empcd"] = "";

            try
            {

                string un = empcode.Value;
                string pd = pwd.Value;
                if (un != "" && pd != "")
                {
                    String empwd = c1.Fillstring("Select pwd From org_mstLogin Where uid = '" + un + "' ");
                    String utp = c1.Fillstring("Select userType From org_mstLogin Where uid = '" + un + "' ");
                    String stts = c1.Fillstring("Select status From org_mstLogin Where uid = '" + un + "' ");
                   

                    if (empwd != "")
                    {
                        string og = c1.Fillstring("Select org_name From org_mstLogin Where uid = '" + un + "' ");
                        DateTime exp = DateTime.Parse(c1.Fillstring("Select validtill From org_mstLogin Where org_name = '" + og + "' and userType='Admin' "));
                        DateTime dt = DateTime.Now;

                        if (stts != "Deactive" && (dt <= exp))
                        {
                            if ((pd == empwd) && (utp == "dev"))
                            {
                                Session["user_id"] = un;
                                Response.Redirect("org_dev_dashboard.aspx");
                            }
                            else if ((pd == empwd) && (utp == "Admin"))
                            {
                                Session["user_id"] = un;
                                Session["usertype"] = "Admin";
                                Session["orgname"] = og;
                                Session["mask"] = c1.Fillstring("Select mask From org_mstLogin Where uid = '" + un + "' ");
                                Response.Redirect("org_admin_dashboard.aspx");
                            }
                            else if ((pd == empwd) && (utp == "Student"))
                            {
                                Session["stuid"] = un;
                                Session["usertype"] = utp;
                                Session["orgname"] = og;
                                Response.Redirect("org_student_dashboard.aspx");
                            }

                            else
                            {
                                string message = "Password Incorrect";
                                string script = "window.onload = function(){ alert('";
                                script += message;
                                script += "')};";
                                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                            }

                        }
                        else
                        {
                            string message = "Account is not Active";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                        }
                    }

                    


                    else
                    {
                        string message = "User Id not exist";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }
                    empcode.Value = "";
                    pwd.Value = "";
                }
                
                else
                {
                    string message = "Fill user id and password";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {
                string message = "Something Wrong try again with correct format";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


        }
    }
}