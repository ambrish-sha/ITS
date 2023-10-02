<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="org_question_paper.aspx.cs" Inherits="ITS.org_question_paper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <meta name="keywords" content="Mock Test, Online Test Series, Model Question Paper, AKTU, B.Ed, MBA, B.Pharma, Previous Year Question Paper, Question paper, Sample Paper, Practice Mock, mock test in Hindi, pdf notes, Question Paper, FREE Mock Test, Online Test Series, Exam Preparation Books, PDF Notes, Free Online Test Series, Mock Tests For Competitive Exams in India, Free online exam preparation, free online test for competitive exams, free mock test, model papers for all exams, Competitive exam online practice Test, Previous year paper with solutions, Online test for competitive exams, online mock test for competitive exam, online study for competitive exam, online entrance test, online entrance exam practice, entrance exam online practice test, free online competitive exam test, free online entrance exam, free online entrance test, Online Exams, FREE Online Mock Test Series in Hindi - English, Practice and Preparation Test, Important Objective Question Bank for all Competitive and Entrance Exams, Mock Test,  MCQ Questions, Previous Year Paper, Booklet, Govt Exam Books, Competitive exams books, Entrance Exams Books, bank exam books, bank po books, best books for bank exams, best test series for ssc, practice mock test series, online mock test, ibps mock test, ssc chsl free mock test, sbi clerk free mock test, sbi po free mock test, rrb je mock test 2019 free, rrb je free mock test, ssc cgl mock test online free, ssc cgl free mock test. https://www.testedu.in/" />
    <meta name="description" content="Test Edu Best for (FREE) Mock Test or Online Test Series 2021 and Important Questions with Answer. Previous Year Question Paper, Books, Printed Material, Question Paper, Sample Paper for all Competative, Engineering, MBA, B.Pharma and Govt. exams in 2021." />
    <meta name="page_type" content="np-template-header-footer-from-plugin" />
    <meta name="author" content="Test Edu" />
    <title>Test Edu - Your Online Partner</title>
    <link rel="icon" type="image/png" href="../images/favicon.ico" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Popper JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
      
    <script src="jquery-1.4.1.min.js" type="text/javascript">
    </script>
    <script src="ScrollableGrid.js" type="text/javascript">
    </script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%=GridView1.ClientID %>').Scrollable();
        }
    )
    </script>
     <script type = "text/javascript" >
         function preventBack() { window.history.forward(); }
         setTimeout("preventBack()", 0);
         window.onunload = function () { null };  
    </script> 
</head>
<body style="background-color:lightblue;">
    <form id="form1"  runat="server">
    <div class="container" >

     

    <br />





    <h3 style="text-align:center;">Assign Questions for Paper Set</h3>
    <br />
    
<div class="row">
   <div class="col-sm-4">
   <label for="setid">Select Set Id:</label>
        <asp:DropDownList ID="setid" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="setid_SelectedIndexChanged"></asp:DropDownList>
  <%--<select class="form-control" id="" runat="server" name="examname" required>
   
      </select>--%>
   <%-- <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>--%>
  </div>

  <div class="col-sm-3">
  <asp:Button ID="searchsetid" Visible="false" runat="server" class="btn btn-primary" 
          Text="Search Set ID" onclick="searchsetid_Click" formnovalidate />
  </div>

</div>

<div class="row">

  <div class="col-sm-4">
   <label for="examname">Exam Name:</label>
  <select class="form-control" id="examname" runat="server" name="examname" required>
        <option value="" disabled selected>Choose Exam Name</option>
        
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-4">
   <label for="subjectname">Subject:</label>
    <asp:DropDownList ID="subjectname" class="form-control"  runat="server" AutoPostBack="True" onselectedindexchanged="subjectname_SelectedIndexChanged" required></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


  <div class="col-sm-4">
   <label for="topicname">Topic:</label>
  <select class="form-control" id="topicname" runat="server" name="topicname" required>
        <option value="" disabled selected>Choose Topic</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  

  </div>



  <div class="row">

   <div class="col-sm-4">
   <label for="totalquestion">Total Question:</label>
  <input type="text" class="form-control" placeholder="Total Question in Set" 
           runat="server" id="totalquestion" readonly="readonly">
  </div>


  <div class="col-sm-4">
   <label for="correctmarks">Marks for Correct:</label>
  <input type="text" class="form-control" placeholder="Marks for Correct answer" runat="server" id="correctmarks">
  </div>

  <div class="col-sm-4">
   <label for="wrongmarks">Marks for wrong:</label>
  <input type="text" class="form-control" placeholder="Marks for Wrong answer " runat="server" id="wrongmarks">
  </div>

  

 
  
 
  
</div>


  

  
 

<div class="row">
   

    


  <div class="col-sm-4">
   <label for="totalduration">Total Duration:</label>
  <input type="text" class="form-control" placeholder="Enter Total Duration of Exam" 
          runat="server" id="totalduration" readonly="readonly">
  </div>
 
 <%-- <div class="col-sm-3">
   <label for="language">Language:</label>
  <select class="form-control" id="language" runat="server" name="language" required>
        <option value="" disabled selected>Choose Language</option>
         <option value="ENGLISH">ENGLISH</option>
       <option value="HINDI">HINDI</option>
      
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-3">
   <label for="questype">Question Type:</label>
  <select class="form-control" id="questype" runat="server" name="questype" required>
        <option value="" disabled selected>Question Type</option>
       <option value="MCQ">MCQ</option>
       <option value="INPUT">INPUT</option>
       <option value="TF">TF</option>
       <option value="MS">TF</option>
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>--%>

  <div class="col-sm-4">
   <label for="totalmarks">Total marks :</label>
  <input type="text" class="form-control" placeholder="Total Marks " runat="server" 
          id="totalmarks" readonly="readonly">
  </div>
 
  
</div>




<br />

<div class="row">
  <div class="col-sm-3">
   
  <input type="text" class="form-control" placeholder="Enter Question ID" runat="server" id="questionid">
  </div>

  <div class="col-sm-3">
  <asp:Button ID="searchquestion" class="btn btn-primary" runat="server" 
          Text="Search Question" onclick="searchquestion_Click" formnovalidate />
          </div>

          <div class="col-sm-3">
  <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Add question to Paperset" 
            onclick="Button1_Click" />
    
  </div>

    <div class="col-sm-3">
  <asp:Button ID="deleteques" class="btn btn-danger" runat="server" 
          Text="Delete Question" onclick="deleteques_Click" formnovalidate />
    
  </div>
  
</div>
        



<br />


<h3> Select Question From Here </h3>

    <br />


    <div class="row">
  
  <div class="col-sm-1">
      <label for="subjectsearch">Subject:</label>
     </div>
  <div class="col-sm-2">
  
 <asp:DropDownList ID="subjectsearch" class="form-control"  runat="server" 
          AutoPostBack="True" 
          onselectedindexchanged="subjectsearch_SelectedIndexChanged" ></asp:DropDownList>

    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="col-sm-1">
     <label for="topicsearch">Topic:</label>
     </div>

   <div class="col-sm-2">
    
  <select class="form-control" id="topicsearch" runat="server" name="topicname">
        <option value="" disabled selected>Choose Topic</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="col-sm-2">
    
  <select class="form-control" id="qtypesearch" runat="server" name="topicname">
        <option value="" disabled selected>Ques type</option>
         <option value="MCQ">MCQ</option>
       <option value="INPUT">INPUT</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
   
   
   <div class="col-sm-2">
  
    <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Search" 
           onclick="Button2_Click" formnovalidate />
    </div>

    <div class="col-sm-2">
   
    <asp:Button ID="Button3" class="btn btn-primary" runat="server" 
            Text="All questions" onclick="Button3_Click" formnovalidate
          />
    </div>
  
</div>

   







        
    <br />

    <asp:Panel ID="Panel1" runat="server" Height="500px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
        
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    <asp:GridView ID="GridView1" BackColor="AliceBlue" AutoGenerateColumns="false" 
            CssClass="table table-striped" autogenerateselectbutton="True" runat="server" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onPageIndexChanging="OnPaging" AllowPaging="True" PageSize="50">
   
                 <Columns>  

             <asp:TemplateField HeaderText="Select">
             <HeaderTemplate>

      <asp:CheckBox ID="checkAll" runat="server" text="select all" onclick = "checkAll(this);"/>

    </HeaderTemplate>  
                  <%--  <EditItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                    </EditItemTemplate> --%> 
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="ID">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("q_id") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("q_id") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Exam Name">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("exame_name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("exame_name") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Subject">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("subject") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("subject") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="topic">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("topic") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("topic") %>'></asp:Label>  
                    </ItemTemplate>  
                    </asp:TemplateField> 

                <asp:TemplateField HeaderText="Question" >   
               
                    <EditItemTemplate >  
                        <asp:TextBox ID="TextBox5" runat="server" Width="250px" Text='<%# Bind("question") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label5" runat="server" Width="250px" Text='<%# Bind("question") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Question Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image1" ImageUrl='<%#GetImage(Eval("question_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  




                <asp:TemplateField HeaderText="Option A">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("option_a") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("option_a") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

               
                <%--<asp:TemplateField HeaderText="Option A Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image2" ImageUrl='<%#GetImage(Eval("option_a_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  --%>


                <asp:TemplateField HeaderText="Option B">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("option_b") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("option_b") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                 
                <%-- <asp:TemplateField HeaderText="Option B Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image3" ImageUrl='<%#GetImage(Eval("option_b_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> --%> 



                <asp:TemplateField HeaderText="Option C">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("option_c")%>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("option_c") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 


               <%--  <asp:TemplateField HeaderText="Option C Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image4" ImageUrl='<%#GetImage(Eval("option_c_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> --%>




                <asp:TemplateField HeaderText="Option D">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("option_d") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("option_d") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 
                
                 <%-- <asp:TemplateField HeaderText="Option D Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image5" ImageUrl='<%#GetImage(Eval("option_d_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> --%>

                 <asp:TemplateField HeaderText="Correct Option">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("correct_option") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("correct_option") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="description">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("description") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 
                
<%--                  <asp:TemplateField HeaderText="description image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image6" ImageUrl='<%#GetImage(Eval("desc_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>--%>
                
                <asp:TemplateField HeaderText="Input Hint">  
                   
                    <ItemTemplate>  
                         <asp:Label ID="inputhintgrid" runat="server" Text='<%# Bind("input_hint") %>'></asp:Label>
                    </ItemTemplate>  
                </asp:TemplateField>  
               
               
            </Columns>  
      
    
    
                 <PagerSettings FirstPageText="First" LastPageText="Last" 
                     Mode="NumericFirstLast" />
      
    
    
    </asp:GridView>
    </asp:Panel>

    <div class="row">
  
  
  <div class="col-sm-4">
  <asp:Button ID="movetoquespaper" class="btn btn-danger" runat="server" 
          Text="Send to all in set paper " onclick="movetoquespaper_Click"  
           />
    
  </div>
  </div>



<br />



<br />





    <h3>Preview Question Details</h3>
    <br />



<div class="row">
  <div class="col-sm-6">
   <label for="questiontext">Question</label>
    <textarea class="form-control" id="questiontext" placeholder="Enter Question" rows="5" runat="server" name="questiontext" ></textarea>
  </div>

  <div class="col-sm-6">
  <label for="questiontext">Question image</label>
  <img src="" class="img-rounded" runat="server" id="quesimage" style=" width: 600px; max-height:200px; max-width:600px;"   alt="No Image">
 </div>
</div>




   
  



<div class="row">
  <div class="col-sm-6">
   <label for="optiona">Answer Option A:</label>
  <textarea class="form-control" id="optiona" placeholder="Enter Option A" runat="server" rows="3" name="optiona" ></textarea>
  </div>

  <div class="col-sm-6">
  <label for="optiona">Answer Option A image:</label>
  <img src="" class="img-rounded" runat="server" id="Img1" style=" max-height:200px;max-width:600px;"  alt="No Image">
 </div>
  
</div>


<div class="row">
  <div class="col-sm-6">
   <label for="optionc">Answer Option B:</label>
   <textarea class="form-control" id="optionb" placeholder="Enter Option B" runat="server" rows="3" name="optionb" ></textarea>
  </div>

  <div class="col-sm-6">
   <label for="optionc">Answer Option B image:</label>
  <img src="" class="img-rounded" runat="server" id="Img2" style=" max-height:200px;max-width:600px;"    alt="No Image">
 </div>
 
</div>


<div class="row">
  <div class="col-sm-6">
   <label for="uptionc">Answer Option C:</label>
  <textarea class="form-control" id="optionc" placeholder="Enter Option C" runat="server" rows="3" name="optionc" ></textarea>
  </div>

  <div class="col-sm-6">
  <label for="uptionc">Answer Option C image:</label>
  <img src="" class="img-rounded" runat="server" id="Img3" style=" max-height:200px;max-width:600px;"    alt="No Image">
 </div>
 
</div>

<div class="row">
  <div class="col-sm-6">
   <label for="optiond">Answer Option D:</label>
 <textarea class="form-control" id="optiond" placeholder="Enter Option D" runat="server" rows="3" name="optiond" ></textarea>
  </div>

  <div class="col-sm-6">
   <label for="optiond">Answer Option D image:</label>
  <img src="" class="img-rounded" runat="server" id="Img4" style=" max-height:200px;max-width:600px;"   alt="No Image">
 </div>
  
</div>

<div class="row">
  <div class="col-sm-6">
   <label for="correctoption">Correct Option(A,B,C and D):</label>
  <input type="text" class="form-control" placeholder="Enter Correct Option" runat="server" id="correctoption">
  </div>  
</div>


<div class="row">
  <div class="col-sm-6">
   <label for="descanswer">Description of answer:</label>
 <textarea class="form-control" id="descanswer" placeholder="Enter Subject Name" rows="3" runat="server" name="descanswer" ></textarea>
  </div>
  <div class="col-sm-6">
  <label for="descanswer">Description image:</label>
  <img src="" class="img-rounded" runat="server" id="Img5" style=" max-height:200px;max-width:600px;"   alt="No Image">
 </div>
 </div>


  <br />

  <br />
  <h4>*Use below button only when you want to fill deleted question from set</h4>

  <div class="row">
  <div class="col-sm-4">
   
  <input type="text" class="form-control" placeholder="Question serial no " 
          runat="server" id="questionsno">
  </div>
  
  <div class="col-sm-4">
  <asp:Button ID="addinmid" class="btn btn-success" runat="server" 
          Text="Add question at specific Q_no" onclick="addinmid_Click" formnovalidate
           />
    
  </div>


   </div>




    <br />
     

  <div></div>
  <br />
   
    
    <h3>Show Paper Set Question Here</h3>

         
    <br />

    <asp:Panel ID="Panel2" runat="server" Height="500px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
        
    <asp:GridView ID="GridView2" BackColor="AliceBlue" AutoGenerateColumns="false" CssClass="table table-striped"  runat="server" PageSize="10" onselectedindexchanged="GridView1_SelectedIndexChanged">
   
                 <Columns>  
                 <asp:TemplateField HeaderText="set id">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2Tsetid" runat="server" Text='<%# Bind("set_id") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Lsetid" runat="server" Text='<%# Bind("set_id") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 


                  <asp:TemplateField HeaderText="Q no">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2Tqno" runat="server" Text='<%# Bind("q_no") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Lqno" runat="server" Text='<%# Bind("q_no") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
             

                <asp:TemplateField HeaderText="ID">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2tqid" runat="server" Text='<%# Bind("q_id") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2lqid" runat="server" Text='<%# Bind("q_id") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Exam Name">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2texnm" runat="server" Text='<%# Bind("exam_name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2lexnm" runat="server" Text='<%# Bind("exam_name") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Subject">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2tsub" runat="server" Text='<%# Bind("subject") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2lsub" runat="server" Text='<%# Bind("subject") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="topic">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2ttop" runat="server" Text='<%# Bind("topic") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2ltop" runat="server" Text='<%# Bind("topic") %>'></asp:Label>  
                    </ItemTemplate>  
                    </asp:TemplateField> 

                <asp:TemplateField HeaderText="Question" >   
               
                    <EditItemTemplate >  
                        <asp:TextBox ID="g2tques" runat="server" Width="250px" Text='<%# Bind("question") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2lques" runat="server" Width="250px" Text='<%# Bind("question") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Question Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="g2Image1" ImageUrl='<%#GetImage(Eval("question_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  




                <asp:TemplateField HeaderText="Option A">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2TextBox6" runat="server" Text='<%# Bind("option_a") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Label6" runat="server" Text='<%# Bind("option_a") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

               
               <%-- <asp:TemplateField HeaderText="Option A Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="g2Image2" ImageUrl='<%#GetImage(Eval("option_a_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  --%>


                <asp:TemplateField HeaderText="Option B">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2TextBox7" runat="server" Text='<%# Bind("option_b") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Label7" runat="server" Text='<%# Bind("option_b") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                 
                <%-- <asp:TemplateField HeaderText="Option B Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="g2Image3" ImageUrl='<%#GetImage(Eval("option_b_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  --%>



                <asp:TemplateField HeaderText="Option C">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2TextBox8" runat="server" Text='<%# Bind("option_c")%>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Label8" runat="server" Text='<%# Bind("option_c") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 


<%--                 <asp:TemplateField HeaderText="Option C Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="g2Image4" ImageUrl='<%#GetImage(Eval("option_c_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> --%>




                <asp:TemplateField HeaderText="Option D">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2TextBox9" runat="server" Text='<%# Bind("option_d") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Label9" runat="server" Text='<%# Bind("option_d") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 
                
                  <%--<asp:TemplateField HeaderText="Option D Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="g2Image5" ImageUrl='<%#GetImage(Eval("option_d_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> --%>
              
      
                 <asp:TemplateField HeaderText="Correct Option">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2TextBox10" runat="server" Text='<%# Bind("correct_option") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Label10" runat="server" Text='<%# Bind("correct_option") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="description">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="g2TextBox11" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="g2Label11" runat="server" Text='<%# Bind("description") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 
                
                 <%-- <asp:TemplateField HeaderText="description image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="g2Image6" ImageUrl='<%#GetImage(Eval("desc_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> --%>

                  <asp:TemplateField HeaderText="Input Hint">  
                   
                    <ItemTemplate>  
                         <asp:Label ID="inputhintgrid1" runat="server" Text='<%# Bind("input_hint") %>'></asp:Label>
                    </ItemTemplate>  
                </asp:TemplateField> 


     </Columns>
    
    </asp:GridView>
    </asp:Panel>
     <br />


     <div class="row">
  
  
  <div class="col-sm-4">
  <asp:Button ID="deleteall" class="btn btn-danger" runat="server" 
          Text="Delete all question from this set" onclick="deleteall_Click"  formnovalidate
           />
    
  </div>

  <div class="col-sm-4">
  <asp:Button ID="Button4" class="btn btn-success" runat="server" 
          Text="download in excel" onclick="Button4_Click"  formnovalidate
           />
    
  </div>
  </div>

      <br />
    </div>
    

    <script type = "text/javascript">

        function Check_Click(objRef) {

            //Get the Row based on checkbox

            var row = objRef.parentNode.parentNode;

            if (objRef.checked) {

                //If checked change color to Aqua

                row.style.backgroundColor = "aqua";

            }

            else {

                //If not checked change back to original color

                if (row.rowIndex % 2 == 0) {

                    //Alternating Row Color

                    row.style.backgroundColor = "#C2D69B";

                }

                else {

                    row.style.backgroundColor = "white";

                }

            }



            //Get the reference of GridView

            var GridView = row.parentNode;



            //Get all input elements in Gridview

            var inputList = GridView.getElementsByTagName("input");



            for (var i = 0; i < inputList.length; i++) {

                //The First element is the Header Checkbox

                var headerCheckBox = inputList[0];



                //Based on all or none checkboxes

                //are checked check/uncheck Header Checkbox

                var checked = true;

                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {

                        checked = false;

                        break;

                    }

                }

            }

            headerCheckBox.checked = checked;



        }

</script>


<script type = "text/javascript">

    function checkAll(objRef) {

        var GridView = objRef.parentNode.parentNode.parentNode;

        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {

            //Get the Cell To find out ColumnIndex

            var row = inputList[i].parentNode.parentNode;

            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                if (objRef.checked) {

                    //If the header checkbox is checked

                    //check all checkboxes

                    //and highlight all rows

                    row.style.backgroundColor = "aqua";

                    inputList[i].checked = true;

                }

                else {

                    //If the header checkbox is checked

                    //uncheck all checkboxes

                    //and change rowcolor back to original

                    if (row.rowIndex % 2 == 0) {

                        //Alternating Row Color

                        row.style.backgroundColor = "#C2D69B";

                    }

                    else {

                        row.style.backgroundColor = "white";

                    }

                    inputList[i].checked = false;

                }

            }

        }

    }

</script> 


<script type = "text/javascript">

    function MouseEvents(objRef, evt) {

        var checkbox = objRef.getElementsByTagName("input")[0];

        if (evt.type == "mouseover") {

            objRef.style.backgroundColor = "orange";

        }

        else {

            if (checkbox.checked) {

                objRef.style.backgroundColor = "aqua";

            }

            else if (evt.type == "mouseout") {

                if (objRef.rowIndex % 2 == 0) {

                    //Alternating Row Color

                    objRef.style.backgroundColor = "#C2D69B";

                }

                else {

                    objRef.style.backgroundColor = "white";

                }

            }

        }

    }

</script>




    </form>


   
   
   
    <div></div>
</body>
</html>