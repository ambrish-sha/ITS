<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadStudentRecord.aspx.cs" Inherits="ITS.uploadStudentRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <style>
        .container1 {
          position: relative;
          width: 100%;
          overflow: hidden;
          padding-top:100%; /* 16:9 Aspect Ratio */
        }

        .responsive-iframe {
          position: absolute;
          top: 0;
          left: 0;
          bottom: 0;
          right: 0;
          width: 100%;
          height: 100%;
          border: none;
        }

        .scrolling {  
                position: absolute;  
            }  
              
        .gvWidthHight {  
                /*overflow: scroll; */ 
                height: 100%;  
                width: 100%;  
            }

        .WrapText {  
            width: 100%;  
            word-break: break-word;  
        }  
       
        input[type=text] {
          outline:0;
          padding: 6px 6px;
          margin: 8px 0;
          box-sizing: border-box;
          border: none;
          border-bottom: 1px solid black;
        }

        /*-------------------------------------*/

      
      
        body { font-size:80.5% }  
 
        #Employee {  
            font:11px Times New Roman;   
            width:auto;  
            display:block;  
            padding:10px 0 0 0;  
        }  
  
        .text {  
            width:auto;  
            padding:2px 4px;  
            font:inherit;  
            font-weight:bold;  
            text-align:left;  
            border:solid 2px #BFBFBF;  
            background:yellow;  
            text-transform:uppercase;  
        }  
              
        .Grid {  
            width:100%;   
            font:inherit;   
            margin:5px 0 10px 0;   
            background-color:#FFF;   
            border:solid 2px #525252;  
            text-transform:uppercase;  
        }  
        .Grid td {  
            font:inherit;   
            padding:2px;   
            border:solid 1px #C1C1C1;   
            color:#333;   
            text-align:center;  
        }  
        .Grid th {  
            padding:5px;   
            color:blue;   
            background:#424234  3px #525233;   
            font:inherit;  
            font-weight:bold;  
        }  
              
        .Gridbutton {  
            cursor:pointer;   
            text-align:center;   
            color: white;   
            font:inherit;  
            background-color: blue;  
            border:solid 1px #3079ED;   
            -moz-border-radius:5px;   
            -webkit-border-radius:5px;   
            line-height:20px;  
        }  
        
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <meta name="keywords" content="Mock Test, Online Test Series, Model Question Paper, AKTU, B.Ed, MBA, B.Pharma, Previous Year Question Paper, Question paper, Sample Paper, Practice Mock, mock test in Hindi, pdf notes, Question Paper, FREE Mock Test, Online Test Series, Exam Preparation Books, PDF Notes, Free Online Test Series, Mock Tests For Competitive Exams in India, Free online exam preparation, free online test for competitive exams, free mock test, model papers for all exams, Competitive exam online practice Test, Previous year paper with solutions, Online test for competitive exams, online mock test for competitive exam, online study for competitive exam, online entrance test, online entrance exam practice, entrance exam online practice test, free online competitive exam test, free online entrance exam, free online entrance test, Online Exams, FREE Online Mock Test Series in Hindi - English, Practice and Preparation Test, Important Objective Question Bank for all Competitive and Entrance Exams, Mock Test,  MCQ Questions, Previous Year Paper, Booklet, Govt Exam Books, Competitive exams books, Entrance Exams Books, bank exam books, bank po books, best books for bank exams, best test series for ssc, practice mock test series, online mock test, ibps mock test, ssc chsl free mock test, sbi clerk free mock test, sbi po free mock test, rrb je mock test 2019 free, rrb je free mock test, ssc cgl mock test online free, ssc cgl free mock test. https://www.testedu.in/" />
    <meta name="description" content="Test Edu Best for (FREE) Mock Test or Online Test Series 2021 and Important Questions with Answer. Previous Year Question Paper, Books, Printed Material, Question Paper, Sample Paper for all Competative, Engineering, MBA, B.Pharma and Govt. exams in 2021." />
    <meta name="page_type" content="np-template-header-footer-from-plugin" />
    <meta name="author" content="Test Edu" />
    <title>Test Edu - Corporate Employability Test</title>
    <link rel="icon" type="image/png" href="../images/favicon.ico" />
		
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script> 
        <script src="//geodata.solutions/includes/countrystatecity.js"></script>
</head>
<body>    
    <form id="form1" runat="server">    
     
        
    <br />
    <div class="container-fluid">


        <h6>Add New Student</h6>
 <div class="row"  style="border:2px solid black; background-color:powderblue;">
   <div class="col-sm-1">
   <label for="batchlistt">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlistt" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlistt_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 <div class="col-sm-1">
   <label for="courselist">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist" class="form-control"  runat="server" AutoPostBack="True"  OnSelectedIndexChanged="companylist2_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
   <label for="branchlist">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchlist_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


     </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">

     <div class="col-sm-1">
   <label for="yearsemlist">Year/Sem:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist" class="form-control"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="yearsemlist_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
</div>
        <br />
         <legend>Upload Candidate/Student Data (Make sure file must be in specifed format and it should be CSV)</legend>

         <div class="row">
        <div class="col">
            <!-- Prepended text-->
            <%--<div class="form-group">--%>
              <div class="col-md-10">
                <div class="input-group">
                  <label class="col-md-3 control-label" for="txtEnqNo">Select File(CSV)</label>
                  <%--<input runat="server" id="txtEnqNo" name="txtEnqNo" class="form-control" placeholder="" type="text" readonly/>--%>
                  <asp:FileUpload ID="FileUpload1" runat="server" accept=".csv"/>
                  <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click"/>   
                </div>
               </div>
            </div>
        <%--</div>--%>
       </div>
       <span>&nbsp;</span>
       <div class="row">
        <div class="col">
            <!-- Prepended text-->
            <%--<div class="form-group">--%>
              <div class="col-md-10">
                <div class="input-group">
                  <label class="col-md-17 control-label" for="file_format_example" style="font-weight: bold; font-style: italic; color: #FF0000">Example Sheet Format (Coulmns should - UserId	Password	Name	Status	Email)
</label>                 
                </div>                  
               </div>
            </div>
        <%--</div>--%>
       </div>
      <span>&nbsp;</span>
       <div class="row">
        <div class="col">
            <!-- Prepended text-->
            <%--<div class="form-group">--%>
              <div class="col-md-10">
                <div class="input-group">



                  <asp:Image ID="file_format_example" runat="server" 
                        ImageUrl="~/images/stcsvformat.png" Height="20%" Width="100%"/>
                   
                   
                     </div>










                </div>                  
               </div>
            </div>
         <br />
                   
                    <h5> Updloaded Students List</h5>
                    <br />

          <asp:Panel ID="Panel1" runat="server" Height="400px" Width="100%" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView1" BackColor="AliceBlue" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="20" >
   
                
    
   
    
    </asp:GridView>

     </asp:Panel>


                    

        </div>
   














    
    </form>    
</body>   
</html>
