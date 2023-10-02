<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="org_question_bank.aspx.cs" Inherits="ITS.org_question_bank" %>

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
     <script type = "text/javascript" >
         function preventBack() { window.history.forward(); }
         setTimeout("preventBack()", 0);
         window.onunload = function () { null };  
     </script> 
</head>
<body style="background-color:lightblue;">
    <form id="form1"  runat="server">
    <div class="container" >
     <h3 style="text-align:center;">Add New question in question bank</h3>
    
<div class="row">
  <div class="col-sm-4">
   <label for="questionid">Question ID(Auto Assign):</label>
  <input type="text" class="form-control" placeholder="Question ID" 
          runat="server" id="questionid" readonly="readonly">
  </div>
  <div class="col-sm-4">
   <label for="examname">Exam Name:</label>
  <select class="form-control" id="examname" runat="server" name="examname" required >
        <option value="" disabled selected>Choose Exam Name</option>
        
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-4">
   <label for="subjectname">Subject:</label>
 <asp:DropDownList ID="subjectname" class="form-control"  runat="server"  AutoPostBack="True" onselectedindexchanged="subjectname_SelectedIndexChanged" required></asp:DropDownList>

    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  
  
</div>


<div class="row">

    <div class="col-sm-3">
   <label for="topicname">Topic:</label>
  <select class="form-control" id="topicname" runat="server" name="topicname"  required>
        <option value="" disabled selected>Choose Topic</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-3">
   <label for="queslevel">Question Level:</label>
 <select class="form-control" id="queslevel" runat="server" name="queslevel" required >
        <option value="" disabled selected>Choose Topic</option>
         <option value="Easy">Easy</option>
       <option value="Moderate">Moderate</option>
       <option value="Dificult">Dificult</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-3">
   <label for="language">Language:</label>
  <select class="form-control" id="language" runat="server" name="language" required >
        <option value="" disabled selected>Choose Topic</option>
         <option value="ENGLISH">ENGLISH</option>
       <option value="HINDI">HINDI</option>
      
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-3">
   <label for="questype">Question Type:</label>
  
  
      <asp:DropDownList class="form-control" ID="questype" runat="server" 
          AutoPostBack="True" required 
          onselectedindexchanged="questype_SelectedIndexChanged">
          <asp:ListItem>MCQ</asp:ListItem>
          <asp:ListItem>INPUT</asp:ListItem>
      </asp:DropDownList>
  
  
  
 <%-- <select class="form-control" id="questype1" runat="server" AutoPostBack="True"  name="questype" required onclick="return questype_onclick()">
        <option value="" disabled selected>Choose Topic</option>
       <option value="MCQ">MCQ</option>
       <option value="INPUT">INPUT</option>
       
      </select>--%>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
 
  
</div>


<br />
<br />






<div class="row">
  <div class="col-sm-8">
   <label for="questiontext">Question</label>
    <textarea class="form-control" id="questiontext" placeholder="Enter Question" rows="5" runat="server" name="questiontext" ></textarea>
  </div>
  <div class="col-sm-4">
    <label for="quesimage" class="form-label">Chose Question Image</label>
<input class="form-control form-control-sm" runat="server" id="quesimage" type="file" />
  </div>
</div>




   
  


<div runat="server" id = "mcqtype" >
<div class="row">
  <div class="col-sm-8">
   <label for="optiona">Answer Option A:</label>
  <textarea class="form-control" id="optiona" placeholder="Enter Option A" runat="server" rows="3" name="optiona" ></textarea>
  </div>
  <div class="col-sm-4">
    <label for="optionaimage" class="form-label">Chose Option A Image</label>
<input class="form-control form-control-sm" runat="server" id="optionaimage" type="file" />
  </div>
</div>


<div class="row">
  <div class="col-sm-8">
   <label for="optionc">Answer Option B:</label>
   <textarea class="form-control" id="optionb" placeholder="Enter Option B" runat="server" rows="3" name="optionb" ></textarea>
  </div>
  <div class="col-sm-4">
    <label for="optionbimage" class="form-label">Chose Option B Image</label>
<input class="form-control form-control-sm" id="optionbimage" runat="server" type="file" />
  </div>
</div>


<div class="row">
  <div class="col-sm-8">
   <label for="uptionc">Answer Option C:</label>
  <textarea class="form-control" id="optionc" placeholder="Enter Option C" runat="server" rows="3" name="optionc" ></textarea>
  </div>
  <div class="col-sm-4">
    <label for="optioncimage" class="form-label">Chose Option C Image</label>
<input class="form-control form-control-sm" id="optioncimage" runat="server" type="file" />
  </div>
</div>

<div class="row">
  <div class="col-sm-8">
   <label for="optiond">Answer Option D:</label>
 <textarea class="form-control" id="optiond" placeholder="Enter Option D" runat="server" rows="3" name="optiond" ></textarea>
  </div>
  <div class="col-sm-4">
    <label for="optiondimage" class="form-label">Chose Option D Image</label>
<input class="form-control form-control-sm" runat="server" id="optiondimage" type="file" />
  </div>
</div>

<div class="row">
  <div class="col-sm-8">
   <label for="correctoption">Correct Option(A,B,C and D):</label>
  
  <select class="form-control" id="correctoption" runat="server" name="correctoption" required>
        <option value="" disabled selected>Choose Correct Option</option>
       <option value="A">A</option>
       <option value="B">B</option>
       <option value="C">C</option>
       <option value="D">D</option>
      </select>
      <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>  
</div>
</div>


<div runat="server" id = "inputtype" >
<div class="row">
<div class="col-sm-6">
   <label for="hintinput">Hint for input:</label>
      <asp:TextBox class="form-control" ID="hintinput" runat="server"></asp:TextBox>
  
  </div>  

  <div class="col-sm-6">
   <label for="correctinput">Correct Answer:</label>
      <asp:TextBox class="form-control" ID="correctinput" runat="server"></asp:TextBox>
  
  </div>  
</div>
</div>
<div class="row">
  <div class="col-sm-8">
   <label for="descanswer">Description of answer:</label>
 <textarea class="form-control" id="descanswer" placeholder="Description of answer" rows="3" runat="server" name="descanswer" ></textarea>
  </div>
  <div class="col-sm-4">
    <label for="descimage" class="form-label">Chose Description Image</label>
<input class="form-control form-control-sm" id="descimage" runat="server" type="file" />
  </div>
</div>




  <div></div>
  <br />
   <asp:Button ID="Button1" class="btn btn-success" runat="server" 
            Text="SUBMIT QUESTION" 
            onclick="Button1_Click"  />

             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

             <asp:Button ID="Button2" class="btn btn-primary" runat="server"  
            Text="UPDATE QUESTION" onclick="Button2_Click" />

             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

             

             <asp:Button ID="Button3" class="btn btn-danger" runat="server" 
            Text="DELETE QUESTION" onclick="Button3_Click"  formnovalidate />

             <br />
    <br />

    <h3> Show all question here </h3>
    <div class="row">
  <div class="col-sm-3">
        <asp:Button ID="Button4" runat="server" class="btn btn-primary" onclick="Button4_Click" 
            Text="Show all page" formnovalidate />
</div>
<div class="col-sm-2">
<label >Select Page</label>
</div>
<div class="col-sm-3">
              <asp:DropDownList class="form-control" ID="selectpage" placeholder="Select Page" runat="server" 
          AutoPostBack="True" 
          onselectedindexchanged="selectpage_SelectedIndexChanged">

      </asp:DropDownList>
</div>
</div>
     <br />
    <br />



       

     <asp:Panel ID="Panel1" runat="server" Height="600px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">

     <asp:GridView ID="GridView1" BackColor="AliceBlue" AutoGenerateColumns="false" 
             CssClass="table table-striped" autogenerateselectbutton="True" runat="server" 
             PageSize="50" onselectedindexchanged="GridView1_SelectedIndexChanged" onPageIndexChanging="OnPaging"
             AllowPaging="True"  PagerSettings-PageButtonCount="10">
   
                 <Columns>  

            

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

               
                <asp:TemplateField HeaderText="Option A Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image2" ImageUrl='<%#GetImage(Eval("option_a_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="Option B">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("option_b") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("option_b") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 

                 
                 <asp:TemplateField HeaderText="Option B Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image3" ImageUrl='<%#GetImage(Eval("option_b_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField>  



                <asp:TemplateField HeaderText="Option C">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("option_c")%>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("option_c") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 


                 <asp:TemplateField HeaderText="Option C Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image4" ImageUrl='<%#GetImage(Eval("option_c_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> 




                <asp:TemplateField HeaderText="Option D">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("option_d") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("option_d") %>'></asp:Label>  
                    </ItemTemplate>                                         
                </asp:TemplateField> 
                
                  <asp:TemplateField HeaderText="Option D Image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image5" ImageUrl='<%#GetImage(Eval("option_d_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> 

                
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
                
                  <asp:TemplateField HeaderText="description image">  
                   
                    <ItemTemplate>  
                        <asp:Image ID="Image6" ImageUrl='<%#GetImage(Eval("desc_image"))%>' style=" width:250px; max-height:100px;" runat="server" />
                    </ItemTemplate>  
                </asp:TemplateField> 

                  <asp:TemplateField HeaderText="Input Hint">  
                   
                    <ItemTemplate>  
                         <asp:Label ID="inputhintgrid" runat="server" Text='<%# Bind("input_hint") %>'></asp:Label>
                    </ItemTemplate>  
                </asp:TemplateField> 

               
            </Columns>  
      
    
    
                 <PagerSettings FirstPageText="First" LastPageText="Last" 
                     Mode="NumericFirstLast" />
      
    
    
    </asp:GridView>









   <%--  <asp:GridView ID="GridView1" BackColor="LightGreen" autogenerateselectbutton="True" 
             AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
             PageSize="20" onselectedindexchanged="GridView1_SelectedIndexChanged">
   
                
    
   
    
    </asp:GridView>--%>
     </asp:Panel>


    
  
     <br />
     <br />
    

    <div class="row">
  <div class="col-sm-4">
  <asp:TextBox ID="TextBox12" runat="server" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
  </div>

   <div class="col-sm-4">
          <asp:RadioButton ID="RadioButton1" runat="server" GroupName="serques" Text="Search By Question" /><br />
             <asp:RadioButton ID="RadioButton2" runat="server" GroupName="serques" Text="Search By OPA"  /><br />
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="serques" Text="Search By OPB"  /><br />
                   <asp:RadioButton ID="RadioButton4" runat="server" GroupName="serques" Text="Search By OPC"  /><br />
                      <asp:RadioButton ID="RadioButton5" runat="server" GroupName="serques" Text="Search By OPD"  /><br />
                       <asp:RadioButton ID="RadioButton6" runat="server" GroupName="serques"  Text="Search By DESC" />
  </div>
 

      
   <div class="col-sm-4">
     <asp:Button class="btn btn-success" ID="Button5" runat="server" onclick="Button5_Click" Text="SEARCH" formnovalidate />
  </div>

  </div>
     
    </div>
    </form>
   
   
    <div></div>
</body>
</html>