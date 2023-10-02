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
using System.Text;

namespace ITS
{
    public partial class org_student_record : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {

            rollmask.InnerText= "(User Id of student ="+Session["mask"].ToString()+"RollNo)";
            try
            {
                if (IsPostBack != true)
                {

                    getcompany();



                }
            }
            catch
            {
               
            }
        }




       

        protected void getcompany()
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            SqlCommand com = new SqlCommand("select batch_name from org_batchname where org_name='" + org + "' and user_type='" + utype + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            batchlist.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist.DataBind();
            batchlist.Items.Insert(0, "Select");


            batchlist1.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist1.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist1.DataBind();
            batchlist1.Items.Insert(0, "Select");

            batchlist0.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist0.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist0.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist0.DataBind();
            batchlist0.Items.Insert(0, "Select");

            batchlist2.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist2.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist2.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist2.DataBind();
            batchlist2.Items.Insert(0, "Select");

            batchlistt.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlistt.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlistt.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlistt.DataBind();
            batchlistt.Items.Insert(0, "Select");
            
            batchlist3.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist3.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist3.DataBind();
            batchlist3.Items.Insert(0, "Select");

            batchlist4.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlist4.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlist4.DataBind();
            batchlist4.Items.Insert(0, "Select");

            delbatchlist.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            delbatchlist.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            delbatchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delbatchlist.DataBind();
            delbatchlist.Items.Insert(0, "Select");


        }

        protected void cmpsubmit_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist.Text;
            string cmp = coursename.Value;
            try
            {

                
                if (cmp != "" && btch != "")
                {
                    c1.InsDelup("insert into org_coursename(org_name,user_type,course_name,batch_name) values( '"+org+"','"+utype+"','" + cmp + "','"+btch+"')");

                    coursename.Value = "";


                    string message = "course name have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                   getcompany();

                }
                else
                {
                    string message = "Fill course name";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {
                string message = "course name already exist";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com1 = new SqlCommand("select course_name as CourseName from org_coursename where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();



           
           
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + btch + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delcourselist.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            delcourselist.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            delcourselist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delcourselist.DataBind();
            delcourselist.Items.Insert(0, "Select");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string cmp = courselist0.Text;
            string dep = branchname.Value;
            try
            {

                
                if (cmp != "" && dep != "")
                {
                    c1.InsDelup("insert into org_branchname (org_name,user_type,course_name,branch_name,batch_name) values('" + org + "','" + utype + "', '" + cmp + "','" + dep + "','"+btch+"')");

                    courselist0.Text = "Select";
                    branchname.Value = "";


                    string message = "Branch name saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



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
            catch (Exception)
            {
                string message = "course name and branch already exist";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }



            SqlCommand com1 = new SqlCommand("select course_name as CourseName,branch_name as BranchName from org_branchname where org_name='" + org + "' and user_type='" + utype + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();



            
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + btch + "' and course_name='" + cmp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delbranchlist.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            delbranchlist.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            delbranchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delbranchlist.DataBind();
            delbranchlist.Items.Insert(0, "Select");
        }

        protected void postsubmit_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string cmp = courselist1.Text;
            string dep = branchlist1.Text;
            string post = yearsem.Value;
            try
            {
                
                if (cmp != "" && dep != "" && post != "")
                {
                    c1.InsDelup("insert into org_yearsem (org_name,user_type,course_name,branch_name,yearsem,batch_name) values('"+org+"','"+utype+"', '" + cmp + "','" + dep + "','" + post + "','"+btch+"')");

                    yearsem.Value = "";


                    string message = "year/sem  saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);



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
            catch (Exception)
            {
                string message = "course name and branch name and year/sem already exist";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            
            SqlCommand com1 = new SqlCommand("select course_name as CourseName,branch_name as BranchName,yearsem as YearOrSem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "'", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();



            
            
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and course_name='" + cmp + "' and batch_name='" + btch + "' and branch_name='" + dep + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delyearsemlist.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            delyearsemlist.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            delyearsemlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delyearsemlist.DataBind();
            delyearsemlist.Items.Insert(0, "Select");
        }

        protected void companylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;
            string comp = courselist1.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and batch_name='"+btch+"' and course_name='" + comp + "' ", con);
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

        protected void companylist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlistt.Text;
            string comp = courselist.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and batch_name='"+btch+"' and course_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            branchlist.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
           branchlist.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            branchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            branchlist.DataBind();
            branchlist.Items.Insert(0, "Select");
        }

        public string CreatePassword(int length)
        {
            const string valid = "1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string btch = batchlistt.Text;
            string course = courselist.Text;
            string branch = branchlist.Text;
            string ys = yearsemlist.Text;
            string pass = "";


            if (pwdtype.Text == "Random")
            {
                pass = CreatePassword(6);
            }
            else if (pwdtype.Text == "Default")
            {
                pass = defpass.Value;

            }



            string rlno = Session["mask"].ToString() + stroll.Value;
            string sname = stname.Value;
            string ut = "Student";
            string sts = ststatus.Value;
            string semail = stemail.Value;
            try
            {
               

                if (course != "" && branch != "" && ys != "" && pass != "" && rlno != "" && semail != "")
                {
                    c1.InsDelup("insert into org_student_info(org_name,user_type,st_rollno,st_course,st_branch,st_yearsem,st_name,st_email,st_status,st_batch) values( '" + org + "','" + ut + "','" + rlno + "','" + course + "','" + branch + "','" + ys + "','" + sname + "','" + semail + "','" + sts + "','"+btch+"')");
                    c1.InsDelup("insert into org_mstLogin (uid,pwd,org_name,userType,status,cp_status) values( '" + rlno + "','" + pass + "','"+org+"','"+ut+"','"+sts+"','1')");

                    stroll.Value = "";
                    stname.Value = "";
                    stemail.Value = "";


                    string message = "Student Information saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                   


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
            catch (Exception)
            {
                string message = "Student already exist";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' and si.st_course='" + course + "' and si.st_branch='" + branch + "' and si.st_yearsem='" + ys + "' and si.st_batch='" + btch + "' order by si.st_rollno ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

       

       
        
       

        protected void Button10_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        private void ExportGridToExcel()
        {
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GridView2.AllowPaging = false;

            //GridView2.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells
            //for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
            //{
            //    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            //}
            //GridView2.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();


            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Appraisaldata" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

       
        
       

        

       

       

        protected void Button6_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();

            string btch = batchlist2.Text;
            string comp = courselist2.Text;
            string branch = branchlist2.Text;
            string ysem = yearsemlist2.Text;
            

            
            SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' and si.st_course='" + comp + "' and si.st_branch='" + branch + "' and si.st_yearsem='" + ysem + "' and si.st_batch='" + btch + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {



            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();

            SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void branchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlistt.Text;

            string comp = courselist.Text;
            string branch = branchlist.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='"+btch+"' and branch_name='"+branch+"' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            yearsemlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            yearsemlist.DataBind();
            yearsemlist.Items.Insert(0, "Select");
        }

        protected void yearsemlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void submitbatchname_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            try
            {


                string cmp = batch0.Value;
                if (cmp != "")
                {
                    c1.InsDelup("insert into org_batchname(org_name,user_type,batch_name) values( '" + org + "','" + utype + "','" + cmp + "')");

                    batch0.Value = "";


                    string message = "batch name have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    getcompany();

                }
                else
                {
                    string message = "Fill batch name";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            catch (Exception)
            {
                string message = "batch name already exist";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            SqlCommand com = new SqlCommand("select batch_name from org_batchname where org_name='" + org + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset 
            delbatchlist.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            delbatchlist.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            delbatchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delbatchlist.DataBind();
            delbatchlist.Items.Insert(0, "Select");
 
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

        protected void courselist0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist0.Text;
            string comp = courselist0.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + btch + "' and course_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delbranchlist.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            delbranchlist.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            delbranchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delbranchlist.DataBind();
            delbranchlist.Items.Insert(0, "Select");
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

        protected void batchlistt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlistt.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            courselist.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            courselist.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            courselist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            courselist.DataBind();
            courselist.Items.Insert(0, "Select");
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

        protected void Button6_Click1(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
           
            string btch = batchlist3.Text;
            string comp = courselist3.Text;
            string branch = branchlist3.Text;
            string ysem = yearsemlist3.Text;
            string roll = studentlist3.Text;

            if (roll != "" && roll != "Select")
            {
                c1.InsDelup("delete from org_student_info where org_name='" + org + "' and st_course='" + comp + "' and st_branch='" + branch + "' and st_yearsem='" + ysem + "' and st_batch='" + btch + "' and st_rollno='" + roll + "' ");
                c1.InsDelup("delete from org_mstLogin where org_name='" + org + "' and uid='" + roll + "'");
                string message = "Student Deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


            }
            else
            {
                string message = "Fill all entry";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' and si.st_course='" + comp + "' and si.st_branch='" + branch + "' and si.st_yearsem='" + ysem + "' and si.st_batch='" + btch + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
            

            
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

        protected void courselist3_SelectedIndexChanged(object sender, EventArgs e)
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
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='" + btch + "'  ", con);
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

        protected void yearsemlist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string comp = courselist3.Text;
            string branch = branchlist3.Text;
            string ysem = yearsemlist3.Text;
            SqlCommand com = new SqlCommand("select st_rollno from org_student_info where org_name='" + org + "' and st_course='" + comp + "' and st_branch='" + branch + "' and st_yearsem='" + ysem + "' and st_batch='" + btch + "'  ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            studentlist3.DataTextField = ds.Tables[0].Columns["st_rollno"].ToString(); // text field name of table dispalyed in dropdown       
            studentlist3.DataValueField = ds.Tables[0].Columns["st_rollno"].ToString();
            // to retrive specific  textfield name   
            studentlist3.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            studentlist3.DataBind();
            studentlist3.Items.Insert(0, "Select");
        }

        protected void studentlist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist3.Text;
            string comp = courselist3.Text;
            string branch = branchlist3.Text;
            string ysem = yearsemlist3.Text;
            string roll = studentlist3.Text;
           
            string chk = c1.Fillstring("select st_name from org_student_info where org_name='" + org + "' and st_course='" + comp + "' and st_branch='" + branch + "' and st_yearsem='" + ysem + "' and st_batch='" + btch + "' and st_rollno='" + roll + "'  ");


            studentname3.Text = chk; // text field name of table dispalyed in dropdown       
           
        }

        protected void branchlist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string comp = courselist2.Text;
            string branch = branchlist2.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='" + btch + "'  ", con);
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

        protected void courselist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string comp = courselist4.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' ", con);
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
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and branch_name='" + branch + "' and batch_name='" + btch + "'  ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            yearsemlist4.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            yearsemlist4.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
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
            string ysem = yearsemlist4.Text;
            SqlCommand com = new SqlCommand("select st_rollno from org_student_info where org_name='" + org + "' and st_course='" + comp + "' and st_branch='" + branch + "' and st_yearsem='" + ysem + "' and st_batch='" + btch + "'  ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            studentlist4.DataTextField = ds.Tables[0].Columns["st_rollno"].ToString(); // text field name of table dispalyed in dropdown       
            studentlist4.DataValueField = ds.Tables[0].Columns["st_rollno"].ToString();
            // to retrive specific  textfield name   
            studentlist4.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            studentlist4.DataBind();
            studentlist4.Items.Insert(0, "Select");
            studentlist4.Items.Insert(1, "All");
        }

        protected void studentlist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist4.Text;
            string comp = courselist4.Text;
            string branch = branchlist4.Text;
            string ysem = yearsemlist4.Text;
            string roll = studentlist4.Text;
            string chk = "";
            if (roll != "All")
            {

                chk = c1.Fillstring("select st_name from org_student_info where org_name='" + org + "' and st_course='" + comp + "' and st_branch='" + branch + "' and st_yearsem='" + ysem + "' and st_batch='" + btch + "' and st_rollno='" + roll + "'  ");
            }
            else
            {
                chk = "All";
            }

            studentname4.Text = chk;
        }

        protected void updatestatus_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string btch = batchlist4.Text;
            string course = courselist4.Text;
            string branch = branchlist4.Text;
            string ys = yearsemlist4.Text;

            string rlno = studentlist4.Text;
            
            
            string sts = selectstatus.Value;
            
            //try
            //{
                

                if (btch!="" && course != "" && branch != "" && ys != "" && rlno != "" && sts!="" )
                {
                    if (rlno != "All")
                    {
                    c1.InsDelup("update org_mstLogin set status='" + sts + "' where uid = '" + rlno + "' and org_name='" + org + "'");

                    string message = "Login status updated successfully.";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }

                    else
                    {
                        string sql1 = "Select st_rollno From org_student_info Where st_batch='"+btch+"' and st_course ='" + course + "' and st_branch ='" + branch + "' and st_yearsem ='" + ys + "' and org_name='" + org + "' ";
                    con.Open();
                    SqlCommand comm1 = new SqlCommand(sql1, con);
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        while (reader1.Read())
                        {
                            string roll_no = reader1["st_rollno"].ToString();
                        
                            c1.InsDelup("update org_mstLogin set status='" + sts + "' where uid = '" + roll_no + "' and org_name='" + org + "'");
                            
                        }
                    string message = "Login status of all updated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);


                    reader1.Close();

                    con.Close();

                }
                    studentlist4.Text = "Select";
                    studentname4.Text = "";
                    selectstatus.Value = "Select";


                    




                }
                else
                {
                    string message = "Fill all entry";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            //}
            //catch (Exception)
            //{
            //    string message = "Something WrongS";
            //    string script = "window.onload = function(){ alert('";
            //    script += message;
            //    script += "')};";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            //}

            SqlCommand com1 = new SqlCommand("select uid as userId ,pwd as Password,status as LoginStatus from org_mstLogin where org_name='" + org + "' and uid='"+rlno+"' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }

        protected void pwdtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pwdtype.Text == "Random")
            {
                defpass.Disabled = true;

            }
            else if (pwdtype.Text == "Default")
            {
                defpass.Disabled = false;

            }
            else
            {
                defpass.Disabled = true;
            }
        }

        protected void batchdelete_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            if (delbatchlist.Text != "Select" && delbatchlist.Text != "")
            {
                c1.InsDelup("delete from org_batchname where batch_name='" + delbatchlist.Text + "' and org_name='" + org + "'");


                string message = "Batch deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Select Batch name";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com = new SqlCommand("select batch_name from org_batchname where org_name='" + org + "'", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset 
            delbatchlist.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            delbatchlist.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            delbatchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delbatchlist.DataBind();
            delbatchlist.Items.Insert(0, "Select");
        }

        protected void batchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string comp = batchlist.Text;
            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + comp + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delcourselist.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            delcourselist.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            delcourselist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delcourselist.DataBind();
            delcourselist.Items.Insert(0, "Select");
        }

        protected void delcourse_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string bl = batchlist.Text;
            string cl = delcourselist.Text;
            if (cl != "Select" && cl!="")
            {
                c1.InsDelup("delete from org_coursename where batch_name='" + bl+ "' and course_name='"+cl+"' and org_name='" + org + "'");


                string message = "Course deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Select Course Name";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com = new SqlCommand("select course_name from org_coursename where org_name='" + org + "' and batch_name='" + bl + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delcourselist.DataTextField = ds.Tables[0].Columns["course_name"].ToString(); // text field name of table dispalyed in dropdown       
            delcourselist.DataValueField = ds.Tables[0].Columns["course_name"].ToString();
            // to retrive specific  textfield name   
            delcourselist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delcourselist.DataBind();
            delcourselist.Items.Insert(0, "Select");
        }

        protected void delbranch_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string bl = batchlist0.Text;
            string cl = courselist0.Text;
            string brl = delbranchlist.Text;
            if (brl != "Select" && brl!="")
            {
                c1.InsDelup("delete from org_branchname where batch_name='" + bl + "' and course_name='" + cl + "' and branch_name='"+delbranchlist.Text+"' and org_name='" + org + "'");


                string message = "Branch deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Select Branch Name";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }


            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "'  and batch_name='" + bl + "' and course_name='" + cl + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delbranchlist.DataTextField = ds.Tables[0].Columns["branch_name"].ToString(); // text field name of table dispalyed in dropdown       
            delbranchlist.DataValueField = ds.Tables[0].Columns["branch_name"].ToString();
            // to retrive specific  textfield name   
            delbranchlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delbranchlist.DataBind();
            delbranchlist.Items.Insert(0, "Select");
        }

        protected void branchlist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist1.Text;

            string comp = courselist1.Text;
            string branch = branchlist1.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' and branch_name='" + branch + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delyearsemlist.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            delyearsemlist.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            delyearsemlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delyearsemlist.DataBind();
            delyearsemlist.Items.Insert(0, "Select");
        }

        protected void delyearsem_Click(object sender, EventArgs e)
        {

            string org = Session["orgname"].ToString();
            string bl = batchlist1.Text;
            string cl = courselist1.Text;
            string brl = branchlist1.Text;
            string ys = delyearsemlist.Text;
            if (ys != "Select"&& ys!="")
            {
                c1.InsDelup("delete from org_yearsem where batch_name='" + bl + "' and course_name='" + cl + "' and branch_name='" + brl + "' and yearsem='"+delyearsemlist.Text+"' and org_name='" + org + "'");


                string message = "Year/Sem deleted successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string message = "Select Year/sem Name";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }






            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and course_name='" + cl + "' and batch_name='" + bl + "' and branch_name='" + brl + "' ", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  

            delyearsemlist.DataTextField = ds.Tables[0].Columns["yearsem"].ToString(); // text field name of table dispalyed in dropdown       
            delyearsemlist.DataValueField = ds.Tables[0].Columns["yearsem"].ToString();
            // to retrive specific  textfield name   
            delyearsemlist.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            delyearsemlist.DataBind();
            delyearsemlist.Items.Insert(0, "Select");
        }

        protected void courselist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlist2.Text;
            string comp = courselist2.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' ", con);
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
    }
}