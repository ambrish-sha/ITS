using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;


namespace ITS
{
    public class Connect1
    {
        public Connect1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        string ip;
        public string IP
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
            }
        }
        // static string ipser = LOGIN_FORM.iptext;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["testedu_connection"].ConnectionString);

        //SqlConnection con = new SqlConnection("Data Source=128.100.6.199,1433\\SQLEXPRESS;Initial Catalog=onlinetest;User ID=sa;Password=atul12345");
        //SqlConnection con = new SqlConnection("Data Source="+ Connect.IP +",1433\\SQLEXPRESS;Initial Catalog=onlinetest;User ID=sa;Password=atul12345");

        //SqlConnection con = new SqlConnection("Data Source=ATULPS\\SQLEXPRESS;Initial Catalog=onlinetest;User ID=sa;Password=atul12345 ");
        // con

        public void InsDelup(string str)
        {
            SqlCommand cmd = new SqlCommand(str, con);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();


        }

        /*
                public DataGrid fillgrid(DataGrid ddl, string str)
                {
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ddl.DataSource = ds;
                    //ddl.DataBind();
                    return ddl;

                }

                public DataSet FillDs(string Str)
                {

                    SqlDataAdapter da = new SqlDataAdapter(Str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }

                public void fillCombo(ComboBox cmb, string qry, string fldName, string fldId)
                {
                    //MessageBox.Show("" + LOGIN_FORM.iptext);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(qry, con);
                    da.Fill(ds);
                    cmb.DataSource = ds.Tables[0];
                    cmb.ValueMember = fldId;
                    cmb.DisplayMember = fldName;
                    con.Close();
                }
                public void fillList(ListBox Lst, string qry, string fldName, string fldId)
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(qry, con);
                    da.Fill(ds);
                    Lst.DataSource = ds.Tables[0];
                    Lst.ValueMember = fldId;
                    Lst.DisplayMember = fldName;
                    con.Close();
                }
                public Boolean intVali(System.Windows.Forms.KeyPressEventArgs e)
                {
                    string vali;
                    vali = "0123456789.";
                    if (e.KeyChar <= 26)
                        return false;
                    char[] ch = vali.ToCharArray();
                    for (int x = 0; x < ch.Length; x++)
                    {
                        if (e.KeyChar == ch[x])
                        {
                            return false;
                        }
                    }
                    MessageBox.Show("Illegal character...");
                    return true;
                }
                public Boolean intValiL(System.Windows.Forms.KeyPressEventArgs e)
                {
                    string vali;
                    vali = "0123456789.L";
                    if (e.KeyChar <= 26)
                        return false;
                    char[] ch = vali.ToCharArray();
                    for (int x = 0; x < ch.Length; x++)
                    {
                        if (e.KeyChar == ch[x])
                        {
                            return false;
                        }
                    }
                    MessageBox.Show("Illegal character...");
                    return true;
                }



                //___________________________________________________________________________________________________________________________________________________________
                public Boolean general(System.Windows.Forms.KeyPressEventArgs e)
                {
                    string vali;
                    vali = "0123456789-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/,.@  ";
                    if (e.KeyChar <= 26)
                        return false;
                    char[] ch = vali.ToCharArray();
                    for (int x = 0; x < ch.Length; x++)
                    {
                        if (e.KeyChar == ch[x])
                        {
                            return false;
                        }
                    }
                    MessageBox.Show("Illegal character...");
                    return true;
                }

                //___________________________________________________________________________________________________________________________________________________________
                public Boolean phoneVali(System.Windows.Forms.KeyPressEventArgs e)
                {
                    string vali;
                    vali = "0123456789-";
                    if (e.KeyChar <= 26)
                        return false;
                    char[] ch = vali.ToCharArray();
                    for (int x = 0; x < ch.Length; x++)
                    {
                        if (e.KeyChar == ch[x])
                        {
                            return false;
                        }
                    }
                    MessageBox.Show("Illegal character...");
                    return true;
                }

                public Boolean CharrVali(System.Windows.Forms.KeyPressEventArgs e)
                {

                    string vali;
                    vali = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (e.KeyChar <= 26)
                        return false;
                    char[] ch = vali.ToCharArray();
                    for (int x = 0; x < ch.Length; x++)
                    {
                        if (e.KeyChar == ch[x])
                        {
                            return false;
                        }
                    }
                    MessageBox.Show("Illegal character...");
                    return true;

                }

                public TextBox FillText(TextBox txt, string str)
                {
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int len = ds.Tables[0].Rows.Count;
                    if (len > 0)
                    {
                        txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    }
                    return txt;
                }

                public TextBox FillTextGp(TextBox txtboxname, string strQry, string fldname)
                {
                    SqlDataAdapter da = new SqlDataAdapter(strQry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int len = ds.Tables[0].Rows.Count;
                    if (len > 0)
                    {
                        txtboxname.Text = ds.Tables[0].Rows[0][fldname].ToString();
                    }
                    return txtboxname;
                }
                public RichTextBox FillRTextGp(RichTextBox txtboxname, string strQry, string fldname)
                {
                    SqlDataAdapter da = new SqlDataAdapter(strQry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int len = ds.Tables[0].Rows.Count;
                    if (len > 0)
                    {
                        txtboxname.Text = ds.Tables[0].Rows[0][fldname].ToString();
                    }
                    return txtboxname;
                }
                public ComboBox FillCTextGp(ComboBox txtboxname, string strQry, string fldname)
                {
                    SqlDataAdapter da = new SqlDataAdapter(strQry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int len = ds.Tables[0].Rows.Count;
                    if (len > 0)
                    {
                        txtboxname.Text = ds.Tables[0].Rows[0][fldname].ToString();
                    }
                    return txtboxname;
                }
                public DateTimePicker FillDTPickerGp(DateTimePicker txtboxname, string strQry, string fldname)
                {
                    SqlDataAdapter da = new SqlDataAdapter(strQry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int len = ds.Tables[0].Rows.Count;
                    if (len > 0)
                    {
                        txtboxname.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][fldname].ToString());
                    }
                    return txtboxname;
                }
                public CheckBox FillChkGp(CheckBox chkname, string strQry, string fldname)
                {
                    SqlDataAdapter da = new SqlDataAdapter(strQry, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int len = ds.Tables[0].Rows.Count;
                    if (len > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0][fldname]) == 1)
                            chkname.Checked = true;
                        if (Convert.ToInt32(ds.Tables[0].Rows[0][fldname]) == 0)
                            chkname.Checked = false;
                    }
                    return chkname;
                }*/
        public string Fillstring(string str)
        {
            string txt = "";

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int len = ds.Tables[0].Rows.Count;
            if (len > 0)
            {
                txt = ds.Tables[0].Rows[0][0].ToString();

            }
            return txt;
        }
        /* public double rateget(string str, string rate)
         {
             string rr = "";
             double ra = 0;

             DataSet ds = new DataSet();
             SqlDataAdapter da = new SqlDataAdapter(str, con);
             da.Fill(ds);
             int len = ds.Tables[0].Rows.Count;
             if (len > 0)
             {
                 rr = ds.Tables[0].Rows[0][rate].ToString();
                 ra = Convert.ToDouble(rr);
             }
             con.Close();
             return ra;
         }
         public SqlDataReader readdata(string str)
         {
             if (con.State != ConnectionState.Open)
             {
                 con.Open();
             }
             SqlCommand cmd = new SqlCommand(str, con);
             SqlDataReader read;
             read = cmd.ExecuteReader();
             return read;
         }

         public void CopyLVToCb(ListView lv)
         {
             StringBuilder buffer = new StringBuilder();
             for (int i = 0; i < lv.Columns.Count; i++)
             {
                 buffer.Append(lv.Columns[i].Text);
                 buffer.Append("\t");
             }
             buffer.Append("\n");
             for (int i = 0; i < lv.Items.Count; i++)
             {
                 for (int j = 0; j < lv.Columns.Count; j++)
                 {
                     buffer.Append(lv.Items[i].SubItems[j].Text);
                     buffer.Append("\t");
                 }
                 buffer.Append("\n");
             }
             Clipboard.SetText(buffer.ToString());
         }

         public String NumToWords(String numb, bool isCurrency)
         {
             String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
             String endStr = (isCurrency) ? ("Only") : ("");
             try
             {
                 int decimalPlace = numb.IndexOf(".");
                 if (decimalPlace > 0)
                 {
                     wholeNo = numb.Substring(0, decimalPlace);
                     points = numb.Substring(decimalPlace + 1);
                     if (Convert.ToInt32(points) > 0)
                     {
                         andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents
                         endStr = (isCurrency) ? ("Paise " + endStr) : ("");
                         pointStr = translateCents(points);
                     }
                 }
                 val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
             }
             catch { ;}
             return val;
         }
         private String translateWholeNumber(String number)
         {
             string word = "";
             try
             {
                 bool beginsZero = false;//tests for 0XX
                 bool isDone = false;//test if already translated
                 double dblAmt = (Convert.ToDouble(number));
                 //if ((dblAmt > 0) && number.StartsWith("0"))
                 if (dblAmt > 0)
                 {//test for zero or digit zero in a nuemric
                     beginsZero = number.StartsWith("0");
                     int numDigits = number.Length;
                     int pos = 0;//store digit grouping
                     String place = "";//digit grouping name:hundres,thousand,etc...
                     switch (numDigits)
                     {
                         case 1://ones' range
                             word = ones(number);
                             isDone = true;
                             break;
                         case 2://tens' range
                             word = tens(number);
                             isDone = true;
                             break;
                         case 3://hundreds' range
                             pos = (numDigits % 3) + 1;
                             if (!beginsZero) place = " Hundred ";
                             break;
                         case 4://thousands' range
                         case 5: pos = (numDigits % 4) + 1;
                             if (!beginsZero) place = " Thousand ";
                             break;
                         case 6://Lakhs' range
                         case 7: pos = (numDigits % 6) + 1;
                             if (!beginsZero) place = " Lakh ";
                             break;
                         case 8: //Crores's range
                         case 9: pos = (numDigits % 8) + 1;
                             if (!beginsZero) place = " Crores ";
                             break;
                         case 10:

                         //add extra case options for anything above Billion...
                         default:
                             isDone = true;
                             break;
                     }
                     if (!isDone)
                     {//if transalation is not done, continue...(Recursion comes in now!!)
                         word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                         //check for trailing zeros
                         if (beginsZero) word = "" + word.Trim();

                     }
                     //ignore digit grouping names
                     if (word.Trim().Equals(place.Trim())) word = "";
                 }
             }
             catch { ;}
             return word.Trim();
         }
         private String tens(String digit)
         {
             int digt = Convert.ToInt32(digit);
             String name = null;
             switch (digt)
             {
                 case 10: name = "Ten"; break;
                 case 11: name = "Eleven"; break;
                 case 12: name = "Twelve"; break;
                 case 13: name = "Thirteen"; break;
                 case 14: name = "Fourteen"; break;
                 case 15: name = "Fifteen"; break;
                 case 16: name = "Sixteen"; break;
                 case 17: name = "Seventeen"; break;
                 case 18: name = "Eighteen"; break;
                 case 19: name = "Nineteen"; break;
                 case 20: name = "Twenty"; break;
                 case 30: name = "Thirty"; break;
                 case 40: name = "Fourty"; break;
                 case 50: name = "Fifty"; break;
                 case 60: name = "Sixty"; break;
                 case 70: name = "Seventy"; break;
                 case 80: name = "Eighty"; break;
                 case 90: name = "Ninety"; break;
                 default:
                     if (digt > 0)
                     {
                         name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                     }
                     break;
             }
             return name;
         }
         private String ones(String digit)
         {
             int digt = Convert.ToInt32(digit);
             String name = "";
             switch (digt)
             {
                 case 1: name = "One"; break;
                 case 2: name = "Two"; break;
                 case 3: name = "Three"; break;
                 case 4: name = "Four"; break;
                 case 5: name = "Five"; break;
                 case 6: name = "Six"; break;
                 case 7: name = "Seven"; break;
                 case 8: name = "Eight"; break;
                 case 9: name = "Nine"; break;
             }
             return name;
         }
         private String translateCents(String cents)
         {
             String cts = "", digit = "", engOne = "";
             for (int i = 0; i < cents.Length; i++)
             {
                 digit = cents[i].ToString();
                 if (digit.Equals("0"))
                 {
                     engOne = "Zero";
                 }
                 else
                 {
                     engOne = ones(digit);
                 }
                 cts += " " + engOne;
             }
             return cts;
         }


         private String HindiNumbers(String digit)
         {
             int digt = Convert.ToInt32(digit);
             String name = "";
             switch (digt)
             {
                 case 1: name = ",d"; break;
                 case 2: name = "nks"; break;
                 case 3: name = "rhu"; break;
                 case 4: name = "pkj"; break;
                 case 5: name = "iWakp"; break;
                 case 6: name = "N%"; break;
                 case 7: name = "lkr"; break;
                 case 8: name = "vkB"; break;
                 case 9: name = "ukS"; break;
                 case 10: name = "nl"; break;
                 case 11: name = "X;kjg"; break;
                 case 12: name = "ckjg"; break;
                 case 13: name = "rsjg"; break;
                 case 14: name = "pkSng"; break;
                 case 15: name = "iUnzg"; break;
                 case 16: name = "lksyg"; break;
                 case 17: name = "l=g"; break;
                 case 18: name = "vBkjg"; break;
                 case 19: name = "mUUkhl"; break;
                 case 20: name = "chl"; break;
                 case 21: name = "bDdhl"; break;
                 case 22: name = "ckbl"; break;
                 case 23: name = "rsbl"; break;
                 case 24: name = "pkSchl"; break;
                 case 25: name = "iPphl"; break;
                 case 26: name = "NCchl"; break;
                 case 27: name = "lRrkbZl"; break;
                 case 28: name = "vBkbZl"; break;
                 case 29: name = "mUrhl"; break;
                 case 30: name = "rhl"; break;
                 case 31: name = "bDrhl"; break;
                 case 32: name = "crhl"; break;
                 case 33: name = "rSarhl"; break;
                 case 34: name = "pkSarhl"; break;
                 case 35: name = "iSarhl"; break;
                 case 36: name = "NRrhl"; break;
                 case 37: name = "lSarhl"; break;
                 case 38: name = "vM+rhl"; break;
                 case 39: name = "mUrkyhl"; break;
                 case 40: name = "pkyhl"; break;
                 case 41: name = "bDrkyhl"; break;
                 case 42: name = "c;kyhl"; break;
                 case 43: name = "=s;kfyl"; break;
                 case 44: name = "pkSokfyl"; break;
                 case 45: name = "iSrkyhl"; break;
                 case 46: name = "fN;kyhl"; break;
                 case 47: name = "lSarkyhl"; break;
                 case 48: name = "vM+rkyhl"; break;
                 case 49: name = "mUupkl"; break;
                 case 50: name = "ipkl"; break;
                 case 51: name = "bD;kou"; break;
                 case 52: name = "ckou"; break;
                 case 53: name = "=siu"; break;
                 case 54: name = "pkSou"; break;
                 case 55: name = "ipiu"; break;
                 case 56: name = "NIiu"; break;
                 case 57: name = "lrkou"; break;
                 case 58: name = "vëkou"; break;
                 case 59: name = "mulB"; break;
                 case 60: name = "lkB"; break;
                 case 61: name = "bDlB"; break;
                 case 62: name = "cklB"; break;
                 case 63: name = "rhjlB"; break;
                 case 64: name = "pkSalB"; break;
                 case 65: name = "iSalB"; break;
                 case 66: name = "NWaklB"; break;
                 case 67: name = "lM++lB"; break;
                 case 68: name = "vM+lB"; break;
                 case 69: name = "mUugr~j"; break;
                 case 70: name = "lRrj"; break;
                 case 71: name = "bDgRrj"; break;
                 case 72: name = "cgRrj"; break;
                 case 73: name = "frgRrj"; break;
                 case 74: name = "pkSgRrj"; break;
                 case 75: name = "ipgRrj"; break;
                 case 76: name = "fNgRrj"; break;
                 case 77: name = "lRrgRrj"; break;
                 case 78: name = "vBRrj"; break;
                 case 79: name = "mU;klh"; break;
                 case 80: name = "vLlh"; break;
                 case 81: name = "bD;klh"; break;
                 case 82: name = "c;klh"; break;
                 case 83: name = "=s;klh"; break;
                 case 84: name = "pkSjklh"; break;
                 case 85: name = "ipklh"; break;
                 case 86: name = "fN;klh"; break;
                 case 87: name = "lrklh"; break;
                 case 88: name = "vBklh"; break;
                 case 89: name = "uoklh"; break;
                 case 90: name = "uCos"; break;
                 case 91: name = "bD;kuos"; break;
                 case 92: name = "cku~os"; break;
                 case 93: name = "frjkUosa"; break;
                 case 94: name = "pkSjkUos"; break;
                 case 95: name = "iapkUosa"; break;
                 case 96: name = "fN;kUosa"; break;
                 case 97: name = "lR;kUos"; break;
                 case 98: name = "vëkUosa"; break;
                 case 99: name = "fuU;kUosa"; break;
             }
             return name;
         }

         public String NumToWordsHindi(String numb)
         {
             string wholeNo = numb; if (numb.IndexOf(".") > 0) wholeNo = numb.Substring(0, numb.IndexOf("."));
             string word = "";
             try
             {
                 bool beginsZero = false;//tests for 0XX
                 bool isDone = false;//test if already translated
                 double dblAmt = (Convert.ToDouble(wholeNo));
                 //if ((dblAmt > 0) && number.StartsWith("0"))
                 if (dblAmt > 0)
                 {//test for zero or digit zero in a nuemric
                     beginsZero = wholeNo.StartsWith("00");
                     int numDigits = wholeNo.Length;
                     int pos = 0;//store digit grouping
                     String place = "";//digit grouping name:hundres,thousand,etc...
                     switch (numDigits)
                     {
                         case 1://ones' range
                             word = HindiNumbers(wholeNo);
                             isDone = true;
                             break;
                         case 2://tens' range
                             word = HindiNumbers(wholeNo);
                             isDone = true;
                             break;
                         case 3://hundreds' range
                             pos = (numDigits % 3) + 1;
                             if (!wholeNo.StartsWith("0")) place = " lkS ";
                             break;
                         case 4://thousands' range
                             pos = (numDigits % 4) + 1;
                             if (!wholeNo.StartsWith("0")) place = " gtkj ";
                             break;
                         case 5: pos = (numDigits % 4) + 1;
                             if (!beginsZero) place = " gtkj ";
                             break;
                         case 6://Lakhs' range
                             pos = (numDigits % 6) + 1;
                             if (!wholeNo.StartsWith("0")) place = " yk[k ";
                             break;
                         case 7: pos = (numDigits % 6) + 1;
                             if (!beginsZero) place = " yk[k ";
                             break;
                         case 8: //Crores's range
                             pos = (numDigits % 8) + 1;
                             if (!wholeNo.StartsWith("0")) place = " djksM ";
                             break;
                         case 9: pos = (numDigits % 8) + 1;
                             if (!beginsZero) place = " djksM ";
                             break;
                         case 10:

                         //add extra case options for anything above Billion...
                         default:
                             isDone = true;
                             break;
                     }
                     if (!isDone)
                     {//if transalation is not done, continue...(Recursion comes in now!!)
                         word = NumToWordsHindi(wholeNo.Substring(0, pos)) + place + NumToWordsHindi(wholeNo.Substring(pos));
                         //check for trailing zeros
                         if (beginsZero) word = "" + word.Trim();

                     }
                     //ignore digit grouping names
                     if (word.Trim().Equals(place.Trim())) word = "";
                 }
             }
             catch { ;}
             return word.Trim();
         }


         public string DateVali(string str)
         {
             string txt = "";

             if (str == "-") txt = "";
             else if (str.Length == 1 && Convert.ToInt16(str) > 3) txt = "0" + str + "-";
             else if (str.Length == 2)
             {
                 if (str.Substring(1, 1) != "-" && Convert.ToInt16(str) <= 0) txt = str.Substring(0, 1);
                 else if (str.Substring(1, 1) != "-" && Convert.ToInt16(str) > 31) txt = "03-" + str.Substring(1, 1);
                 else if (str.Substring(1, 1) == "-" && str.Substring(0, 1) == "0") txt = "0";
                 else if (str.Substring(1, 1) != "-" && Convert.ToInt16(str) > 0) txt = str;
                 else if (str.Substring(1, 1) == "-") txt = "0" + str;
             }
             else if (str.Length == 3 && str.Substring(2, 1) != "-")
                 txt = str.Substring(0, 2) + "-" + str.Substring(2, 1);
             else if (str.Length == 6 && str.Substring(5, 1) != "-")
                 txt = str.Substring(0, 5) + "-" + str.Substring(5, 1);
             else if (str.Length == 4 && str.Substring(3, 1) != "-")
             {
                 if (str.Length == 4 && Convert.ToInt16(str.Substring(3, 1)) > 1)
                     txt = str.Substring(0, 3) + "0" + str.Substring(3, 1) + "-";
                 else txt = str;
             }
             else if (str.Length == 5)
             {
                 if (str.Substring(4, 1) != "-" && (Convert.ToInt16(str.Substring(3, 2)) <= 0 || Convert.ToInt16(str.Substring(3, 2)) > 12)) txt = str.Substring(0, 4);
                 else if (str.Substring(4, 1) == "-" && str.Substring(3, 1) == "0") txt = str.Substring(0, 4);
                 else if (str.Substring(4, 1) == "-" && str.Substring(3, 1) == "1") txt = str.Substring(0, 3) + "01-";
                 else if (str.Substring(4, 1) != "-" && Convert.ToInt16(str.Substring(3, 2)) > 0) txt = str;
             }

             else if (str.Length == 4 && str.Substring(3, 1) == "-")
                 txt = str.Substring(0, 3);
             else txt = str;
             return txt;
         }
         public string DateValiLostFocus(string str)
         {

             string txt = "";
             if (str.Length < 4) txt = "";
             else if (str.Length == 4)
                 txt = str.Substring(0, 3) + "01-" + DateTime.Now.Year.ToString();
             else if (str.Length == 5)
                 txt = str.Substring(0, 5) + "-" + DateTime.Now.Year.ToString();
             else if (str.Length == 6)
                 txt = str.Substring(0, 6) + DateTime.Now.Year.ToString();
             else if (str.Length == 7)
                 txt = str.Substring(0, 6) + "200" + str.Substring(6, 1);
             else if (str.Length == 8)
             {
                 if (Convert.ToInt16(str.Substring(6, 2)) < 50)
                     txt = str.Substring(0, 6) + "20" + str.Substring(6, 2);
                 else txt = str.Substring(0, 6) + "19" + str.Substring(6, 2);
             }
             else if (str.Length == 9)
             {
                 if (str.Substring(6, 1) == "1")
                     txt = str.Substring(0, 6) + "19" + str.Substring(7, 2);
                 else txt = str.Substring(0, 6) + str.Substring(6, 1) + "0" + str.Substring(7, 2);
             }
             else if (str.Length == 10)
                 txt = str;
             return txt;
         }

         public DateTime ConvertDate(string str)
         {
             DateTime dt = new DateTime(Convert.ToInt32(str.Substring(6, 4)), Convert.ToInt16(str.Substring(3, 2)), Convert.ToInt16(str.Substring(0, 2)));
             return dt;
         }
         public bool IsDate(string str)
         {
             try
             {
                 DateTime dt = new DateTime(Convert.ToInt32(str.Substring(6, 4)), Convert.ToInt16(str.Substring(3, 2)), Convert.ToInt16(str.Substring(0, 2)));
                 return true;
             }
             catch
             {
                 return false;
             }
         }








         ////////////////////////////////////////////////////////////////////////////////////////////////




         //public  string cstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\C#\C# _MJ_project\ss_acc\ss_acc\sunshine1.accdb";
         // public OleDbConnection cn;
         public SqlCommand cmd;
         // public SqlDataAdapter da;
         // public DataSet ds;
         //public SqlDataReader dr;
         public int nonquery(string query)
         {
             // cn = new OleDbConnection(cstr);
             cmd = new SqlCommand(query, con);
             if (con.State == ConnectionState.Closed)
                 con.Open();
             int n = cmd.ExecuteNonQuery();
             con.Close();
             return n;
         }

         public object scalar(string query)
         {
             //cn = new OleDbConnection(cstr);
             cmd = new SqlCommand(query, con);
             if (con.State == ConnectionState.Closed)
                 con.Open();
             object o = cmd.ExecuteScalar();
             con.Close();
             return o;

         }*/
        //public int TotalNumberOfQuestions()
        //{
        //    return Adapter.TotalNumberOfQuestions().GetValueOrDefault(); ; 
        //}

        //public int TotalNumberOfProducts()
        //{
        //    return Adapter.TotalNumberOfProducts().GetValueOrDefault();
        //}
    }
}