<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_student_test_result.aspx.cs" Inherits="ITS.org_student_test_result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta charset="utf-8"/>
    <meta name="keywords" content="Mock Test, Online Test Series, Model Question Paper, AKTU, B.Ed, MBA, B.Pharma, Previous Year Question Paper, Question paper, Sample Paper, Practice Mock, mock test in Hindi, pdf notes, Question Paper, FREE Mock Test, Online Test Series, Exam Preparation Books, PDF Notes, Free Online Test Series, Mock Tests For Competitive Exams in India, Free online exam preparation, free online test for competitive exams, free mock test, model papers for all exams, Competitive exam online practice Test, Previous year paper with solutions, Online test for competitive exams, online mock test for competitive exam, online study for competitive exam, online entrance test, online entrance exam practice, entrance exam online practice test, free online competitive exam test, free online entrance exam, free online entrance test, Online Exams, FREE Online Mock Test Series in Hindi - English, Practice and Preparation Test, Important Objective Question Bank for all Competitive and Entrance Exams, Mock Test,  MCQ Questions, Previous Year Paper, Booklet, Govt Exam Books, Competitive exams books, Entrance Exams Books, bank exam books, bank po books, best books for bank exams, best test series for ssc, practice mock test series, online mock test, ibps mock test, ssc chsl free mock test, sbi clerk free mock test, sbi po free mock test, rrb je mock test 2019 free, rrb je free mock test, ssc cgl mock test online free, ssc cgl free mock test. https://www.testedu.in/" />
    <meta name="description" content="Test Edu Best for (FREE) Mock Test or Online Test Series 2021 and Important Questions with Answer. Previous Year Question Paper, Books, Printed Material, Question Paper, Sample Paper for all Competative, Engineering, MBA, B.Pharma and Govt. exams in 2021." />
    <meta name="page_type" content="Education from Test Edu"/>
    <meta name="author" content="Test Edu"/>
    <title>TestEdu-Examination Result</title>
    <link rel="icon" href="images/favicon.ico"/>    
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body style="background-color:white;" >
    <form id="form1" runat="server">
        

<div class="container-fluid">

        <div class="text-center" >
            <h3>YOUR SCORE CARD</h3>
        </div>
      
       




        <div class="row" style="background-color:lightgreen; padding:2px;">

       
 
    

    <div class="col-sm-3">
  <div class="text-center">
      <asp:Label ID="Label5"  runat="server" Text="Exam name-"></asp:Label>
        <asp:Label ID="examname"   runat="server" Text="Label"></asp:Label>
     </div>
    </div>
    <div class="col-sm-3">
    
      <div class="text-center">
          <asp:Label ID="Label4"  runat="server" Text="Subject- "></asp:Label>
       <asp:Label ID="subjectname"  runat="server" Text="Label"></asp:Label>
     </div>
    </div>

     <div class="col-sm-3">
   <div class="text-center">
       <asp:Label ID="setidno"   runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    </div>
    </div>


  <br /> 
   
         <div class="row">
          <div class="col-sm-12">
          <div class="row">
  <div class="col-sm-3">
    <div class="card bg-warning" style= " max-width:250px; margin:15px;  height:200px;">
      <div class="card-body text-center">
      <p class="card-text text-center">Your Marks</p>
           <asp:Label ID="Label2ym" Font-Size="50px"  runat="server" Text=""></asp:Label> <asp:Label ID="Label3" Font-Size="50px"  runat="server" Text=" / "></asp:Label>  
        <asp:Label ID="Label1" Font-Size="50px" runat="server" Text=""></asp:Label>
         
      
      </div>
    </div>
    </div>

   


    <div class="col-sm-3">
   <div class="card bg-success"style= " max-width:250px; margin:15px; height:200px;">
      <div class="card-body text-center">
        <p class="card-text text-center">Correct Answer</p>
          <asp:Label ID="corans" Font-Size="70px"  runat="server" Text=""></asp:Label>
      </div>
    </div>
    </div>

              <div class="col-sm-3">
    <div class="card bg-warning" style= " max-width:250px; margin:15px;  height:200px;">
      <div class="card-body text-center">
      <p class="card-text text-center">Wrong Answer</p>
        <asp:Label ID="wroans" Font-Size="70px" runat="server" Text=""></asp:Label> 
      
      </div>
    </div>
    </div>


              <div class="col-sm-3">
   <div class="card bg-warning"style= " max-width:250px; margin:15px; height:200px;">
      <div class="card-body text-center">
        <p class="card-text text-center">Not Attempt</p>
          <asp:Label ID="naans" Font-Size="70px"  runat="server" Text=""></asp:Label>
      </div>
    </div>
    </div>
   
    </div>
    </div>
    </div>




 
















    <div class="row">
      <div class="col-sm-10">
     <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="View section wise result" 
          onclick="Button2_Click" />
      
    </div>
  <div class="col-sm-2">
    
      <asp:Button ID="Button1" runat="server" class="btn btn-danger" Text="Back to Home" 
          onclick="Button1_Click" />
    </div>
    </div>




<br />


<div class="row" id ="sectionwiseresult" runat="server">
      <div class="col-sm-12">
     <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto">

      <asp:GridView ID="GridView1" BackColor="AliceBlue" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped"  runat="server" PageSize="10" >
   <HeaderStyle BackColor="Gray" />
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



                 <asp:TemplateField HeaderText="Answered">  
                    <ItemTemplate>  
                        <asp:Label ID="totans" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Not Answered">  
                    <ItemTemplate>  
                        <asp:Label ID="totnoans" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  



                 <asp:TemplateField HeaderText="Correct ">  
                    <ItemTemplate>  
                        <asp:Label ID="corans" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Wrong">  
                    <ItemTemplate>  
                        <asp:Label ID="wrans" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  




                 <asp:TemplateField HeaderText="Total Marks">  
                    <ItemTemplate>  
                        <asp:Label ID="totmark" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                  <asp:TemplateField HeaderText="Your Marks">  
                    <ItemTemplate>  
                        <asp:Label ID="yourmark" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

               
               
               
            </Columns>  
      
    
    
    </asp:GridView>
    </asp:Panel>

    </div>
    </div>


     
        
 
  <br />
    <br />




    
       

    </div>


  
        
    </form>
</body>
</html>
