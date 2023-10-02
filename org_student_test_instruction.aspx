<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="org_student_test_instruction.aspx.cs" Inherits="ITS.org_student_test_instruction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <%--<link rel="icon" href="images/favicon.ico" />--%>

     <%--<link rel="stylesheet" href="css/bootstrap.min.css">--%>
    <%--<link rel="stylesheet" href="css/animations.css">--%>
   <%-- <link rel="stylesheet" href="css/font-awesome.css">--%>
   <%-- <link rel="stylesheet" href="css/main2.css" class="color-switcher-link">--%>
   <%-- <script src="js/vendor/modernizr-2.6.2.min.js"></script>--%>





    
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, shrink-to-fit=no" />
    <meta charset="utf-8"/>
    <meta name="keywords" content="Mock Test, Online Test Series, Model Question Paper, AKTU, B.Ed, MBA, B.Pharma, Previous Year Question Paper, Question paper, Sample Paper, Practice Mock, mock test in Hindi, pdf notes, Question Paper, FREE Mock Test, Online Test Series, Exam Preparation Books, PDF Notes, Free Online Test Series, Mock Tests For Competitive Exams in India, Free online exam preparation, free online test for competitive exams, free mock test, model papers for all exams, Competitive exam online practice Test, Previous year paper with solutions, Online test for competitive exams, online mock test for competitive exam, online study for competitive exam, online entrance test, online entrance exam practice, entrance exam online practice test, free online competitive exam test, free online entrance exam, free online entrance test, Online Exams, FREE Online Mock Test Series in Hindi - English, Practice and Preparation Test, Important Objective Question Bank for all Competitive and Entrance Exams, Mock Test,  MCQ Questions, Previous Year Paper, Booklet, Govt Exam Books, Competitive exams books, Entrance Exams Books, bank exam books, bank po books, best books for bank exams, best test series for ssc, practice mock test series, online mock test, ibps mock test, ssc chsl free mock test, sbi clerk free mock test, sbi po free mock test, rrb je mock test 2019 free, rrb je free mock test, ssc cgl mock test online free, ssc cgl free mock test. https://www.testedu.in/" />
    <meta name="description" content="Test Edu Best for (FREE) Mock Test or Online Test Series 2021 and Important Questions with Answer. Previous Year Question Paper, Books, Printed Material, Question Paper, Sample Paper for all Competative, Engineering, MBA, B.Pharma and Govt. exams in 2021." />
    <meta name="page_type" content="Education from Test Edu"/>
    <meta name="author" content="Test Edu"/>
    <title>TestEdu-Examination Instruction Panel</title>
    <link rel="icon" href="~/images/favicon.ico"/>    
   <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Popper JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>



<script type="text/javascript" language="javascript">
    function preback() { window.history.forward(); }
    setTimeout("preback()", 0);
    window.onunload = function () { null };
</script>


</head>









<body style="background-color:white;">

    <div class="preloader">
        <div class="preloader_image"></div>
    </div>
    <form id="form1" runat="server">
        

<div class="container-fluid">

        <div class="text-center" >
            <p style="color:Red;">Please read the following information carefully</p>
        </div>
     
       <h5>Exam and Candidate Information</h5>
   
         <div class="row"  style="background-color:lightgreen; border-bottom-color:Red">
  <div class="col-sm-3">

   <asp:Label ID="studentid" runat="server" Text="Studentid"></asp:Label>
 
  </div>
  <div class="col-sm-3">
  <asp:Label ID="studentname" runat="server" Text="Student name"></asp:Label>
  
  </div>



  <div class="col-sm-3">
  <asp:Label ID="examname" runat="server" Text="Exam Name"></asp:Label>
  
  </div>


  <div class="col-sm-3">
  <asp:Label ID="subjectname" runat="server" Text="Subject name"></asp:Label>
  
  </div>
</div>


   <div class="row"  style="background-color:lightgreen;">
  <div class="col-sm-3">
      <asp:Label ID="remtime"  runat="server" Text="remaning time"></asp:Label>
 </div>
  
   <div class="col-sm-3">
   <asp:Label ID="totalmarks" runat="server" Text="total marks"></asp:Label>
  </div>

  <div class="col-sm-3">
  <asp:Label ID="correctmarks" runat="server" Text="correct marks"></asp:Label>
 
  </div>
  <div class="col-sm-3">
   <asp:Label ID="wrongmarks" runat="server" Text="wrong marks"></asp:Label>
 
  </div>

 
 
</div>



 <div class="row" style="background-color:lightgreen;">
  <div class="col-sm-3">
  
      <asp:Label ID="attemptno"  runat="server" Text="attemptno"></asp:Label>
 
  </div>
  <div class="col-sm-3">
  <asp:Label ID="topic" runat="server" Text="topic"></asp:Label>
   
</div>

<div class="col-sm-3">
  
  <asp:Label ID="totalques" runat="server" Text="total ques"></asp:Label>
 
  </div>

  </div>
  
  
   <div class="row">
  <div class="col-sm-12">
   <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto">
        
    <asp:GridView ID="GridView1" BackColor="AliceBlue" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped"  runat="server" PageSize="10" >
   <HeaderStyle BackColor="Orange" />
   <AlternatingRowStyle BackColor="orange" />
   <FooterStyle BackColor="skyblue" Font-Bold="true" />
   <rowstyle height="10px" />
  
                 <Columns>  

       

                <asp:TemplateField HeaderText="S.No">  
                      
                    <ItemTemplate>  
                        <asp:Label ID="Label1" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Section">  
                    <ItemTemplate>  
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("subject") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Start S.No.">  
                    <ItemTemplate>  
                        <asp:Label ID="fromques" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="End S.No.">  
                    <ItemTemplate>  
                        <asp:Label ID="toques" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Total Ques">  
                    <ItemTemplate>  
                        <asp:Label ID="totques" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Marks">  
                    <ItemTemplate>  
                        <asp:Label ID="totmark" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

               
               
               
            </Columns>  
      
    
    
    </asp:GridView>

    </asp:Panel>

    </div></div>






 
 <h5>General Information(About Exam Interface)</h5>

 <div class="row">
 <div class="col-sm-8">
 <div class="row">

 

  <div class="col-sm-3">
  
     <asp:Button ID="Button2" style = "margin:5px;" Width="156px"  runat="server" class="btn btn-info" OnClientClick="return false;" Text="Clear Response"  />
 
  </div>
  <div class="col-sm-9">
  <asp:Label ID="Label2" runat="server" Text="For remove your selected answer"></asp:Label>
   
</div>
</div>

<div class="row">
  <div class="col-sm-3">
  
     <asp:Button ID="Button3"  runat="server" style = "margin:5px;" Width="156px" class="btn btn-success" OnClientClick="return false;" Text="Save & Prev"  />
 
  </div>
  <div class="col-sm-9">
  <asp:Label ID="Label1" runat="server" Text="Save your answer and move to the previous question"></asp:Label>
   
</div>
</div>

<div class="row">
  <div class="col-sm-3">
  
     <asp:Button ID="Button4"  runat="server" style = "margin:5px;" Width="156px" class="btn btn-success" OnClientClick="return false;" Text="Save & Next"  />
 
  </div>
  <div class="col-sm-9">
  <asp:Label ID="Label3" runat="server" Text="Save your answer and move to the next question"></asp:Label>
   
</div>
</div>

<div class="row">
  <div class="col-sm-3">
  
     <asp:Button ID="Button5"  runat="server" style = "margin:5px;" Width="156px" class="btn btn-warning" OnClientClick="return false;" Text="Mark as Review"  />
 
  </div>
  <div class="col-sm-9">
  <asp:Label ID="Label4" runat="server" Text="Save your answer and move to the next question with mark as review"></asp:Label>
   
</div>
</div>

<div class="row">
  <div class="col-sm-3">
  
     <asp:Button ID="Button6"  runat="server" style = "margin:5px;" Width="156px" class="btn btn-danger" OnClientClick="return false;" Text="SUBMIT EXAM"  />
 
  </div>
  <div class="col-sm-9">
  <asp:Label ID="Label5" runat="server" Text="For submit your exam"></asp:Label>
   
</div>

</div>
</div>


 <div class="col-sm-4">
 

  <div class="row">
  <div class="text-center">
 <asp:Image ID="Image1" runat="server"  ImageUrl="~/img/qp22.png"  />
 </div>
 </div>




</div>

</div>



<div class="row">
  <div class="col-sm-12">
  
    <asp:Label ID="Label11" runat="server"  ForeColor="Red" 
          Text="*You have to click on 'SUBMIT EXAM' button for final submission if you want to leave before time completion . If your exam time compleated then your exam will be submitted automatically."></asp:Label>
 
  </div>
  
</div>

<div class="row">


<div class="col-sm-12">
  
    <asp:Label ID="Label10" runat="server" 
        Text="*Do not change or back the tab, every ectivity will be recorded." 
        ForeColor="Red" ></asp:Label>
 
  </div>
    </div>




   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   
   <ContentTemplate>--%>
<div class="row">

<div class="col-sm-4">
  
     <div class="text-center">
   <asp:CheckBox ID="CheckBox1" Font-Bold="true" Font-Size="16px" runat="server" Text=" I have read all the information. " 
             oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
          </div>
 </div>

     <div class="col-sm-4" style="text-align: center;">
  
     <div class="text-center" style = " text-align :center;">
         <img id="loader" style="display:none; width:120px; height:60px" src="../assets/img/loading.gif">
 
          </div>
 </div>

     <div class="col-sm-4">
  
     <div class="text-center">
         
  <asp:Button ID="startexam" class="btn btn-danger" runat="server" Text="START EXAM"  
             width="156px" OnClientClick="showLoader();"  onclick="startexam_Click" Enabled="False"   />
          </div>
 </div>
   
   

 





  


<%--</ContentTemplate>
 </asp:UpdatePanel>--%>


     

    </div>
       
   
    <br />
    <br />
     <asp:Label ID="Label12" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
 </div>      
    </form>

   
<%--  <script src="js/compressed.js"></script>
    <script src="js/main.js"></script>
    <script src="js/myJS.js" type="text/javascript"></script>--%>

   
<%--<img id="loader" style="display:none;" src="loaderImage.gif"/>--%>
<script type="text/javascript">
    function showLoader() {
        document.getElementById("loader").style.display = 'block';
    }

</script>

    
</body>
</html>
