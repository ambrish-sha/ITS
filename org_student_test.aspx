<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_student_test.aspx.cs" Inherits="ITS.org_student_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


<%--    <link rel="icon" href="images/favicon.ico" />

     <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/animations.css">
    <link rel="stylesheet" href="css/font-awesome.css">
    <link rel="stylesheet" href="css/main2.css" class="color-switcher-link">
    <script src="js/vendor/modernizr-2.6.2.min.js"></script>--%>





    <meta name="viewport" content="width=device-width, initial-scale=1">
<%--    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, shrink-to-fit=no" />--%>
    <meta charset="utf-8"/>
    <meta name="keywords" content="Mock Test, Online Test Series, Model Question Paper, AKTU, B.Ed, MBA, B.Pharma, Previous Year Question Paper, Question paper, Sample Paper, Practice Mock, mock test in Hindi, pdf notes, Question Paper, FREE Mock Test, Online Test Series, Exam Preparation Books, PDF Notes, Free Online Test Series, Mock Tests For Competitive Exams in India, Free online exam preparation, free online test for competitive exams, free mock test, model papers for all exams, Competitive exam online practice Test, Previous year paper with solutions, Online test for competitive exams, online mock test for competitive exam, online study for competitive exam, online entrance test, online entrance exam practice, entrance exam online practice test, free online competitive exam test, free online entrance exam, free online entrance test, Online Exams, FREE Online Mock Test Series in Hindi - English, Practice and Preparation Test, Important Objective Question Bank for all Competitive and Entrance Exams, Mock Test,  MCQ Questions, Previous Year Paper, Booklet, Govt Exam Books, Competitive exams books, Entrance Exams Books, bank exam books, bank po books, best books for bank exams, best test series for ssc, practice mock test series, online mock test, ibps mock test, ssc chsl free mock test, sbi clerk free mock test, sbi po free mock test, rrb je mock test 2019 free, rrb je free mock test, ssc cgl mock test online free, ssc cgl free mock test. https://www.testedu.in/" />
    <meta name="description" content="Test Edu Best for (FREE) Mock Test or Online Test Series 2021 and Important Questions with Answer. Previous Year Question Paper, Books, Printed Material, Question Paper, Sample Paper for all Competative, Engineering, MBA, B.Pharma and Govt. exams in 2021." />
    <meta name="page_type" content="Education from Test Edu"/>
    <meta name="author" content="Test Edu"/>
    <title>TestEdu-Mock Test</title>
    <link rel="icon" href="images/favicon.ico"/>    
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

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
<body style="background-color:white" oncontextmenu="return false" onselectstart="return false"
      onkeydown="if ((arguments[0] || window.event).ctrlKey) return false" >

<%--<div class="preloader">
        <div class="preloader_image"></div>
    </div>--%>

    <form id="form1" runat="server">
    <div class="container-fluid" >
    
   

    
   
   <div class="row" style="background-color:lavender;">
  <div class="col-sm-3">

   <asp:Label ID="studentname" runat="server" Text="hello"></asp:Label>
 
  </div>
  <div class="col-sm-3">
   <asp:Label ID="examname" runat="server" Text="exam name"></asp:Label>
  
  </div>

  <div class="col-sm-3">
   <asp:Label ID="totalmarks" runat="server" Text="tm"></asp:Label>
 
  </div>
  
 

  
 
  
  
  
   <div class="col-sm-3">
   <label >Remaining Time:</label>
      <asp:Label ID="remtime" Font-Size="18px" Font-Bold="true" ForeColor="DarkRed" runat="server" Text=""></asp:Label>
 
  </div>
 
</div>




        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>



                <div class="row" style="">
                    <div class="col-sm-9">
                        <div class="row">

                            <div class="col-sm-6">

                                <div class="row" style="">


                                    <div class="col-sm-12" style="background-color: lightskyblue">
                                        <asp:Label ID="Label3" for="subjectname" Style="font-size: 18px;" runat="server" Text="Section: "></asp:Label>
                                        <asp:DropDownList ID="subjectname" Style="max-width: 350px; font-size: 16px;" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="subjectname_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </div>







                                    <div class="col-sm-12" style="">
                                        <asp:Panel ID="Panel1" runat="server" Style="padding: 7px; max-height: 350px;"
                                            BorderColor="Black" BackColor="white" BorderStyle="None" ScrollBars="Auto">

                                            <asp:Label runat="server" ID="questno" Style="font-weight: bold"></asp:Label>
                                            /
                                            <asp:Label ID="totalques" runat="server" Style="font-weight: bold" Text="total ques"></asp:Label>
                                            <br />
                                            <%-- <p runat="server" id="questno1" style="font-weight: bold">Question:- </p>--%>
                                            <p runat="server" style="font-size: 17px;" id="questxt"></p>

                                            <asp:Image ID="Image1" CssClass="" Style="margin: 6px; max-width: 95%; max-height: 200px;" runat="server" />

                                            <%-- <p runat="server" id="P1"> A: <asp:RadioButton ID="RadioButton1" runat="server" 
          GroupName="rad"  /></p><p runat="server" id="P5"></p>
          
          <asp:Image ID="Image2" style="margin:6px; max-height:200px;max-width:600px;" runat="server" /> 
        

  <p runat="server" id="P2"> B: <asp:RadioButton ID="RadioButton2" runat="server" 
          GroupName="rad"  /></p><p runat="server" id="P6"></p>
         
          <asp:Image ID="Image3" style=" margin:6px; max-height:200px;max-width:600px;" runat="server" />  
      

  <p runat="server" id="P3"> C: <asp:RadioButton ID="RadioButton3" runat="server" 
          GroupName="rad" /></p><p runat="server" id="P7"></p> 
       
  <asp:Image ID="Image4" style=" margin:6px; max-height:200px;max-width:600px;" runat="server" /> 

  
  <p runat="server" id="P4"> D: <asp:RadioButton ID="RadioButton4" runat="server" 
          GroupName="rad"  /></p><p runat="server" id="P8"></p>
        
  <asp:Image ID="Image5" style=" margin:6px; max-height:200px;max-width:600px;" runat="server" /> --%>
                                        </asp:Panel>
                                    </div>
                                </div>

                                <br />






                            </div>



                            <div class="col-sm-6" style="">
                                <div class="row">

                                    <div class="col-sm-12" style="background-color: lightskyblue">


                                        <asp:Label runat="server" ID="P" Style="font-weight: bold; font-size: 18px;" Text="SUBMIT YOUR RESPONSE"></asp:Label><br />
                                    </div>
                                    <%--  <div class="col-sm-12" style="background-color: lightgreen">
   
  
 
 
  </div>--%>



                                    <div class="col-sm-12" style="">
                                        <asp:Panel ID="Panel3" runat="server" Style="padding: 10px; max-height: 350px;"
                                            BorderColor="Black" BackColor="white" BorderStyle="None" ScrollBars="Auto">
                                            <%-- <p runat="server" id="P9" style="font-weight: bold"></p>
  <p runat="server" id="P10"></p>

  <asp:Image ID="Image6" CssClass="" style="margin:6px; width:95%; max-height:200px;" runat="server" />  --%>
                                            <asp:Label ID="correctmarks" Style="color: Green; font-weight: bold; font-size: 14px;" runat="server" Text="correct marks"></asp:Label>
                                            & 
                                            <asp:Label ID="wrongmarks" Style="color: Red; font-weight: bold; font-size: 14px;" runat="server" Text="wrong marks"></asp:Label>

                                            <br />

                                            <div runat="server" id="mcqtypeques">
                                                <br />
                                                <p runat="server" style="font-size: 17px;" id="P1">
                                                    A:
                                                    <asp:RadioButton ID="RadioButton1" runat="server"
                                                        GroupName="rad" Style="font-size: 17px" />
                                                </p>
                                                <p runat="server" style="font-size: 17px;" id="P5"></p>

                                                <asp:Image ID="Image2" Style="margin: 6px; max-height: 200px; max-width: 95%;" runat="server" />


                                                <p runat="server" style="font-size: 17px;" id="P2">
                                                    B:
                                                    <asp:RadioButton ID="RadioButton2" runat="server"
                                                        GroupName="rad" Style="font-size: 17px" />
                                                </p>
                                                <p runat="server" style="font-size: 17px;" id="P6"></p>

                                                <asp:Image ID="Image3" Style="margin: 6px; max-height: 200px; max-width: 95%;" runat="server" />


                                                <p runat="server" style="font-size: 17px;" id="P3">
                                                    C:
                                                    <asp:RadioButton ID="RadioButton3" runat="server"
                                                        GroupName="rad" Style="font-size: 17px" />
                                                </p>
                                                <p runat="server" style="font-size: 17px;" id="P7"></p>

                                                <asp:Image ID="Image4" Style="margin: 6px; max-height: 200px; max-width: 95%;" runat="server" />


                                                <p runat="server" style="font-size: 17px;" id="P4">
                                                    D:
                                                    <asp:RadioButton ID="RadioButton4" runat="server"
                                                        GroupName="rad" Style="font-size: 17px" />
                                                </p>
                                                <p runat="server" style="font-size: 17px;" id="P8"></p>

                                                <asp:Image ID="Image5" Style="margin: 6px; max-height: 200px; max-width: 95%;" runat="server" />



                                            </div>
                                            <div runat="server" id="inputtypeques">
                                                <label for="inputanswer">Enter your input:</label>
                                                <asp:TextBox ID="inputanswer" runat="server"></asp:TextBox>
                                                <br />
                                                <label id="hintinput" runat="server"></label>
                                            </div>

                                        </asp:Panel>
                                    </div>
                                </div>






                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <label>.</label>
                            </div>
                            <div class="col-sm-6" style="text-align: center;">
                                <div class="text-center" style="text-align: center;">
                                    <img id="loader1" style="display: none; width: 100px; height: 40px" src="../assets/img/loading.gif">
                                </div>
                            </div>
                        </div>

                        <div class="row" style="border-color: gainsboro;">
                            <div class="col-sm-3">
                                <div class="text-center">
                                    <asp:Button ID="clearresponce" class="btn btn-primary" Style="margin: 5px; font-size: 15px;" runat="server"
                                        Text="Clear Response" OnClientClick="showLoader1();" OnClick="clearresponce_Click" Width="140px" />
                                </div>
                            </div>


                            <div class="col-sm-3">
                                <div class="text-center">
                                    <asp:Button ID="saveandprev" class="btn btn-success" Style="margin: 5px; font-size: 15px;" runat="server"
                                        Text="Save & Prev" OnClientClick="showLoader1();" OnClick="saveandprev_Click" Width="140px" />
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="text-center">
                                    <asp:Button ID="saveandnext" class="btn btn-success" Style="margin: 5px; font-size: 15px;" runat="server"
                                        Text="Save & Next" OnClientClick="showLoader1();" OnClick="saveandnext_Click" Width="140px" />
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="text-center">
                                    <asp:Button ID="markreview" class="btn btn-warning" runat="server"
                                        Style="margin: 5px; font-size: 15px;" Text="Mark Review" Width="140px" OnClientClick="showLoader1();"
                                        OnClick="markreview_Click" />
                                </div>
                            </div>


                        </div>


                    </div>
















                    <div class="col-sm-3">
                        <div class="row">

                            <div class="col-sm-12" style="background-color: lightskyblue">
                                <div class="text-center" style="text-align: center">
                                    <p runat="server" id="P10" style="color: red; font-size: 16px; font-weight: bold;">QUESTION PALLETE</p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">

                                <asp:Panel ID="Panel2" runat="server" Style="padding: 8px;" Height="340px"
                                    BorderColor="black" BackColor="lightskyblue"
                                    ScrollBars="Auto">
                                </asp:Panel>


                            </div>
                        </div>

                        <%-- <div class="row">
  <div class="col-sm-2">
  
     <asp:Button ID="Button1"  runat="server" style = "margin:5px;" class="btn btn-info" OnClientClick="return false;" Text=""  />
 
  </div>
  <div class="col-sm-4">
  <asp:Label ID="Label6" Font-Size="12px" runat="server" Text="Not visited"></asp:Label>
   
</div>

<div class="col-sm-2">
  
     <asp:Button ID="Button7"  runat="server" style = "margin:5px;" class="btn btn-primary" OnClientClick="return false;" Text=""  />
 
  </div>
  <div class="col-sm-4">
  <asp:Label ID="Label7" Font-Size="12px" runat="server" Text="Visited but not answered"></asp:Label>
   
</div>

</div>
<div class="row">
  <div class="col-sm-2">
  
     <asp:Button ID="Button8"  runat="server" style = "margin:5px;" class="btn btn-success" OnClientClick="return false;" Text=""  />
 
  </div>
  <div class="col-sm-4">
  <asp:Label ID="Label8" Font-Size="12px" runat="server" Text="Answered"></asp:Label>
   
</div>

<div class="col-sm-2">
  
     <asp:Button ID="Button9"  runat="server" style = "margin:5px;" class="btn btn-warning" OnClientClick="return false;" Text=""  />
 
  </div>
  <div class="col-sm-4">
  <asp:Label ID="Label9" Font-Size="12px" runat="server" Text="Mark for review"></asp:Label>
   
</div>

</div>

                        --%>







                        <div class="row">
                            <div class="col-sm-12">

                                <%-- <div class="text-center">
      <asp:Image ImageUrl="img/btninfo1.png"  ID="Image6" CssClass="margin:10px; " BorderColor="black" BorderStyle="Dotted"   runat="server" />
        
          </div>--%>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

                            </div>
                            <div class="col-sm-12">

                                <div class="text-center">

                                    <asp:Button ID="finalsubmit" class="btn btn-danger" runat="server" Text="SUBMIT TEST" OnClientClick="showLoader1();"
                                        OnClick="finalsubmit_Click" Width="156px" />
                                </div>


                            </div>


                        </div>
                    </div>




                    <%--<asp:label ID="Label4" runat="server" text="Label" Visible="false"></asp:label></div> 
  <input type="hidden" name="hidCust1" id="rmtm" runat="server" enableviewstate="true" />--%>
                </div>




            </ContentTemplate>


        </asp:UpdatePanel>

 
  
  <!-- Bootstrap Modal Dialog -->
<div class="modal fade" style="" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    
                    <div class="modal-body">
                    <div class="text-center">
                        <h3>Your Current Exam Status</h3>
                       </div>
                    </div>


<div class="row">
      <div class="col-sm-12">
          <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto" style=" padding:10px;">
         

                    <asp:GridView ID="GridView1"  BackColor="lightgreen" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped"  runat="server" PageSize="10" >
   <HeaderStyle BackColor="skyblue" />
   <AlternatingRowStyle BackColor="orange" />
   <FooterStyle BackColor="OrangeRed" Font-Bold="true" />
  
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

                

                 <asp:TemplateField HeaderText="Total Ques">  
                    <ItemTemplate>  
                        <asp:Label ID="totques" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Answered">  
                    <ItemTemplate>  
                        <asp:Label ID="fromques" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Not Answered">  
                    <ItemTemplate>  
                        <asp:Label ID="toques" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="Mark for review">  
                    <ItemTemplate>  
                        <asp:Label ID="markrev" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                



                 <%--<asp:TemplateField HeaderText="Marks">  
                    <ItemTemplate>  
                        <asp:Label ID="totmark" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
--%>
               
               
               
            </Columns>  
      
    
    
    </asp:GridView>
     </asp:Panel>
  </div>
  </div>







                    <div class="modal-footer">

<div class="row">
      <div class="col-sm-4">
                    <div class="text-center">
                  <button class="btn btn-info"  data-dismiss="modal" style="margin:5px;" width="120px" aria-hidden="true">Back</button>
                       </div>
                         </div>
        

          <div class="col-sm-4">         
                         <div class="text-center">
                         <asp:Button ID="testfinalsubmit" class="btn btn-danger" style="margin:3px;" runat="server" Text="FINAL SUBMIT" 
           onclick="finalsubmitexam_click" OnClientClick="showLoader();"  width="136px"  />
          </div>
          </div>
        <div class="col-sm-4" style = " text-align :center;">         
                         <div class="text-center" style = " text-align :center;">
                          <img id="loader" style="display:none; width:100px; height:60px" src="../assets/img/result2.gif">
          </div>
          </div>
    

          </div>


                    </div>


                </div>


            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
 
             
             
             
             
             
              <br />
      

            

    </div>


       

    <script>


       
        function showLoader() {
            document.getElementById("loader").style.display = 'block';
        }
        function showLoader1() {
            document.getElementById("loader1").style.display = 'block';
        }

        function callsubmitbutton() {

            document.getElementById("testfinalsubmit").click();
        }
        var warning = 0;
        var timer2 = document.getElementById("remtime").textContent;
        var interval = setInterval(function () {
            /*checkPageFocus();*/

            var timer = timer2.split(':');
            //by parsing integer, I avoid all extra string processing
            var minutes = parseInt(timer[0], 10);
            var seconds = parseInt(timer[1], 10);
            --seconds;
            minutes = (seconds < 0) ? --minutes : minutes;
            seconds = (seconds < 0) ? 59 : seconds;
            seconds = (seconds < 10) ? '0' + seconds : seconds;
            //minutes = (minutes < 10) ?  minutes : minutes;





            document.getElementById("remtime").innerText = minutes + ':' + seconds;

            if (minutes < 0) clearInterval(interval);
            //check if both minutes and seconds are 0
            if ((seconds == 0) && (minutes == 0)) callsubmitbutton();
            timer2 = minutes + ':' + seconds;
        }, 1000);
   
       

    </script>



     



    </form>
    

</body>
</html>

