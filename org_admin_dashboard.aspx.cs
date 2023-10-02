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
    public partial class org_admin_dashboard : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            orgname.InnerText = org;
          
                
                if (org != "")
                {
                    span_user.InnerText = "Welcome- Admin";

                    myFrame.Attributes.Add("src", "/org_admin_home.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }

            }
            catch
            {
                Response.Redirect("Default.aspx");
            }

        }
    }
}
