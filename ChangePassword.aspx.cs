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
    public partial class ChangePassword : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
            string ud = "";
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            if (utype=="Admin")
            {
                ud= Session["user_id"].ToString();
            }
            else if(utype == "Student")
            {
                ud = Session["stuid"].ToString();
            }
            useridd.Value = ud;
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
            string ud = "";
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            if (utype == "Admin")
            {
                ud = Session["user_id"].ToString();
            }
            else if (utype == "Student")
            {
                ud = Session["stuid"].ToString();
            }

            string opas = op.Value;
            string npas = np.Value;
            string cnpas = cnp.Value;
            if (opas!="" && npas!="" && cnpas !="")
            {
                string oldpass = c1.Fillstring("Select pwd From org_mstLogin Where org_name ='" + org + "' and userType ='" + utype + "' and uid ='" + ud + "' ");
                if (opas == oldpass)
                {
                    if (npas==cnpas)
                    {
                        c1.InsDelup("update org_mstLogin set pwd = '"+cnpas+"' Where org_name ='" + org + "' and userType ='" + utype + "' and uid ='" + ud + "'");
                        string message = "Password updated successfully";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                        op.Value = "";
                        np.Value = "";
                        cnp.Value = "";
                    }
                    else
                    {
                        op.Value = "";
                        np.Value = "";
                        cnp.Value = "";
                        string message = "new password not matched with confirmed password";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }
                }
                else
                {
                    op.Value = "";
                    np.Value = "";
                    cnp.Value = "";
                    string message = "Old password not correct";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            
            
            }
            else
            {
                string message = "Fill all entry";
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
    }
}