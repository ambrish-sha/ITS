<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_student_home.aspx.cs" Inherits="ITS.org_student_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta charset="utf-8"/>
    <meta name="keywords" content="Mock Test, Online Test Series, Model Question Paper, AKTU, B.Ed, MBA, B.Pharma, Previous Year Question Paper, Question paper, Sample Paper, Practice Mock, mock test in Hindi, pdf notes, Question Paper, FREE Mock Test, Online Test Series, Exam Preparation Books, PDF Notes, Free Online Test Series, Mock Tests For Competitive Exams in India, Free online exam preparation, free online test for competitive exams, free mock test, model papers for all exams, Competitive exam online practice Test, Previous year paper with solutions, Online test for competitive exams, online mock test for competitive exam, online study for competitive exam, online entrance test, online entrance exam practice, entrance exam online practice test, free online competitive exam test, free online entrance exam, free online entrance test, Online Exams, FREE Online Mock Test Series in Hindi - English, Practice and Preparation Test, Important Objective Question Bank for all Competitive and Entrance Exams, Mock Test,  MCQ Questions, Previous Year Paper, Booklet, Govt Exam Books, Competitive exams books, Entrance Exams Books, bank exam books, bank po books, best books for bank exams, best test series for ssc, practice mock test series, online mock test, ibps mock test, ssc chsl free mock test, sbi clerk free mock test, sbi po free mock test, rrb je mock test 2019 free, rrb je free mock test, ssc cgl mock test online free, ssc cgl free mock test. https://www.testedu.in/" />
    <meta name="description" content="Test Edu Best for (FREE) Mock Test or Online Test Series 2021 and Important Questions with Answer. Previous Year Question Paper, Books, Printed Material, Question Paper, Sample Paper for all Competative, Engineering, MBA, B.Pharma and Govt. exams in 2021." />
    <meta name="page_type" content="Education from Test Edu"/>
    <meta name="author" content="Test Edu"/>
    <title>Student Home</title>
    <link rel="icon" href="images/favicon.ico"/>    
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container-fluid">
           <br />



            <div class="row" >

        <div class="col-sm-12" >
            <div class="card text-white bg-info mb-4" style="">
  <div style="text-align:center;" class="card-header">Account Information</div>
  <div class="card-body">
      <p runat="server" id="porg" class="card-title" ></p>
      <p runat="server" id="pid" class="card-title"></p>
      <p runat="server" id="pname" class="card-title"></p>
        <p runat="server" id="pbatch" class="card-title"></p>
      <p runat="server" id="pcourse" class="card-title"></p>
      <p runat="server" id="pbranch" class="card-title"></p>
      <p runat="server" id="pyearsem" class="card-title"></p>
   
  </div>
</div>
            </div>

            </div>
         

              <div class="row" >

        <div class="col-sm-4" style="text-align:center;">
            <div class="card text-white bg-success mb-4" style="max-width: 24rem; height:12rem;">
  <div class="card-header">Total Test Scheduled for You</div>
  <div class="card-body">
    <h1 runat="server" id="card1" class="card-title">200</h1>
   
  </div>
</div>

            </div>

                   <div class="col-sm-4" style="text-align:center;">
                       <div class="card text-white bg-warning mb-4" style="max-width: 24rem; height:12rem;">
  <div class="card-header">Total Test Attempted</div>
  <div class="card-body">
    <h1 runat="server" id="card2" class="card-title">500</h1>
    
  </div>
</div>

            </div>

                   <div class="col-sm-4" style="text-align:center;">
                       <div class="card text-white bg-primary mb-4" style="max-width: 24rem; height:12rem;">
  <div class="card-header">Total Test Missed</div>
  <div class="card-body">
    <h1 runat="server" id="card3" class="card-title">10</h1>
    
  </div>
</div>

            </div>
                  </div>
           <br />
          
                         <div class="row" >

        <div class="col-sm-4" style="text-align:center;">
            <div class="card text-white bg-success mb-4" style="max-width: 24rem; height:12rem;">
  <div class="card-header">Current Available Test</div>
  <div class="card-body">
    <h1 runat="server" id="card4" class="card-title">25</h1>
   
  </div>
</div>

            </div>

                   <div class="col-sm-4" style="text-align:center;">
                       <div class="card text-white bg-warning mb-4" style="max-width: 24rem; height:12rem;">
  <div class="card-header">&nbsp;Average Obtain marks</div>
  <div class="card-body">
    <h1 runat="server" id="card5" class="card-title">300</h1>
   
  </div>
</div>

            </div>

                   <div class="col-sm-4" style="text-align:center;">
                       <div class="card text-white bg-primary mb-4" style="max-width: 24rem; height:12rem;">
  <div class="card-header">Average Total marks</div>
  <div class="card-body">
    <h1 runat="server" id="card6" class="card-title">30</h1>
    
  </div>
</div>

            </div>
                  </div>


        </div>
    </form>
</body>
</html>
