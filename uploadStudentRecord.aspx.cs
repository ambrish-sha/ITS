using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;
using System.Text;
using System.Web.UI.WebControls;

namespace ITS
{
    public partial class uploadStudentRecord : System.Web.UI.Page
    {
        static string strcon = ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        Connect1 c1 = new Connect1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string org = Session["orgname"].ToString();
                if (IsPostBack != true)
                {

                    getcompany();
                    SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' ", con);
                    con.Open();
                    SqlDataReader rd = com1.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();



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



            batchlistt.DataTextField = ds.Tables[0].Columns["batch_name"].ToString(); // text field name of table dispalyed in dropdown       
            batchlistt.DataValueField = ds.Tables[0].Columns["batch_name"].ToString();
            // to retrive specific  textfield name   
            batchlistt.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            batchlistt.DataBind();
            batchlistt.Items.Insert(0, "Select");




        }
        private void connection()
        {
            //sqlconn = ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
            //con = new SqlConnection(sqlconn);
        }

        //Function to Insert Records  


        protected void Button1_Click(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = "Student";
            string duplicate = "";

            try
            {
                //Creating object of datatable  
                DataTable tblcsv = new DataTable();
                //creating columns  

                tblcsv.Columns.Add("UserId");
                tblcsv.Columns.Add("Password");
                tblcsv.Columns.Add("Name");
                tblcsv.Columns.Add("Status");
                tblcsv.Columns.Add("Email");

                if (batchlistt.Text != "Select" && branchlist.Text != "Select" && courselist.Text != "Select" && yearsemlist.Text != "Select")
                {

                    string CSVFilePath = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
                    string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    if (fileExtension == ".csv")
                    {
                        FileUpload1.SaveAs(CSVFilePath);

                        string ReadCSV = File.ReadAllText(CSVFilePath);

                        System.Text.StringBuilder numbers = new System.Text.StringBuilder();
                        int X = 0;

                        foreach (string csvRow in ReadCSV.Split('\n'))
                        {
                            if (csvRow != "" && X != 0)
                            {
                                numbers.Length = 0;


                                string[] words = csvRow.Split(',');

                                int length = words.Length;


                                int count = int.Parse(c1.Fillstring("Select count(st_name) From org_student_info Where org_name='" + org + "' and st_rollno ='" + words[0].ToString().Trim() + "' "));
                                if (count == 0)
                                {
                                    c1.InsDelup("insert into org_student_info(org_name,user_type,st_batch,st_course,st_branch,st_yearsem,st_rollno,st_name,st_status,st_email) values( '" + org + "','" + utype + "','" + batchlistt.Text + "','" + courselist.Text + "','" + branchlist.Text + "','" + yearsemlist.Text + "','" + words[0].ToString().Trim() + "','" + words[2].ToString().Trim() + "','" + words[3].ToString().Trim() + "','" + words[4].ToString().Trim() + "')");

                                    c1.InsDelup("insert into org_mstLogin (uid,pwd,org_name,userType,status,cp_status) values( '" + words[0].ToString().Trim() + "','" + words[1].ToString().Trim() + "','" + org + "','" + utype + "','" + words[3].ToString().Trim() + "','1')");
                                }
                                else
                                {
                                    duplicate = duplicate + words[0].ToString()+",";
                                }
                            }
                            X++;
                        }

                        Response.Write(@"<script language='javascript'>alert('Data Uploaded Successfully and duplicate entry are:-"+duplicate+"')</script>");

                    }
                    else
                    {

                        Response.Write(@"<script language='javascript'>alert('Invalid file, can be uploaded only CSV file.')</script>");
                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Select all entry')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + "')</script>");

            }


            SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' and si.st_course='" + courselist.Text + "' and si.st_branch='" + branchlist.Text + "' and si.st_yearsem='" + yearsemlist.Text + "' and si.st_batch='" + batchlistt.Text + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
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

        protected void companylist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlistt.Text;
            string comp = courselist.Text;
            SqlCommand com = new SqlCommand("select branch_name from org_branchname where org_name='" + org + "' and user_type='" + utype + "' and batch_name='" + btch + "' and course_name='" + comp + "' ", con);
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

        protected void branchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string org = Session["orgname"].ToString();
            string utype = Session["usertype"].ToString();
            string btch = batchlistt.Text;

            string comp = courselist.Text;
            string branch = branchlist.Text;
            SqlCommand com = new SqlCommand("select yearsem from org_yearsem where org_name='" + org + "' and user_type='" + utype + "' and course_name='" + comp + "' and batch_name='" + btch + "' and branch_name='" + branch + "' ", con);
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
            string org = Session["orgname"].ToString();
            SqlCommand com1 = new SqlCommand("select si.st_batch as BatchName,si.st_course as CourseName,si.st_branch as BranchName,si.st_yearsem as YearOrSem,si.st_rollno as RollNo,ml.pwd as Password,ml.status as LoginStatus,si.st_email as EmailID from org_student_info as si,org_mstLogin as ml where si.org_name=ml.org_name and si.st_rollno=ml.uid and si.org_name='" + org + "' and si.st_course='" + courselist.Text + "' and si.st_branch='" + branchlist.Text + "' and si.st_yearsem='" + yearsemlist.Text + "' and si.st_batch='" + batchlistt.Text + "' ", con);
            con.Open();
            SqlDataReader rd = com1.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            con.Close();
        }
    }
}