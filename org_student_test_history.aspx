<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_student_test_history.aspx.cs" Inherits="ITS.org_student_test_history" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exam List</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Popper JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body style="background-color:lightblue;">
    <form id="form1" runat="server">
        <div>
            <h4>All the tests you have attempted</h4>
             <p style="color:red;">*Click on select link for view the answer key(if released)</p>
            <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
     <asp:GridView ID="GridView1" BackColor="white" ShowFooter="true" AutoGenerateColumns="true" CssClass="table table-striped"  runat="server" PageSize="10" AutoGenerateSelectButton="true" SelectText="Start Test" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
   <HeaderStyle BackColor="white" />
   <AlternatingRowStyle BackColor="LightGray" />
   <FooterStyle BackColor="skyblue" Font-Bold="true" />
   <rowstyle height="10px" />
  
                <%-- <Columns>  
                    
       
                      <asp:TemplateField HeaderText="Exam Name">  
                    <ItemTemplate>  
                        <asp:Label ID="examname" runat="server" Text='<%# Bind("examname") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  



                <asp:TemplateField HeaderText="Subject Name ">  
                      

                    <ItemTemplate>  
                        <asp:Label ID="subjectname" runat="server" Text='<%# Bind("subjectname") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

               <%-- <asp:TemplateField HeaderText="Section">  
                    <ItemTemplate>  
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("subject") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 

              

                 <asp:TemplateField HeaderText="Total marks">  
                    <ItemTemplate>  
                        <asp:Label ID="totmarks" runat="server" Text='<%# Bind("total_marks") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                

                        <asp:TemplateField HeaderText="Student Status">  
                    <ItemTemplate>  
                        <asp:Label ID="ststatus" runat="server" Text='<%# Bind("studentstatus") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>


                              <asp:TemplateField HeaderText="Exam Status">  
                    <ItemTemplate>  
                        <asp:Label ID="exmstatus" runat="server" Text='<%# Bind("examstatus") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
                

                 <asp:TemplateField HeaderText="Link Close Time">  
                    <ItemTemplate>  
                        <asp:Label ID="appdate" runat="server" Text='<%# Bind("linkclosetime") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
                     
                     
               



               
               
               
               
            </Columns>  --%>
      
    
    
    </asp:GridView>
     </asp:Panel>









            <br />
            <br />
            <h4>
                All the tests you have missed</h4>
              <asp:Panel ID="Panel2" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
     <asp:GridView ID="GridView2" BackColor="white" ShowFooter="true" AutoGenerateColumns="true" CssClass="table table-striped"  runat="server" PageSize="10"  >
   <HeaderStyle BackColor="white" />
   <AlternatingRowStyle BackColor="LightGray" />
   <FooterStyle BackColor="skyblue" Font-Bold="true" />
   <rowstyle height="10px" />
  
                 <%--<Columns>  

       
                      <asp:TemplateField HeaderText="Appraisal As">  
                    <ItemTemplate>  
                        <asp:Label ID="fromques" runat="server" Text='<%# Bind("appraisal_as_role") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  



                <asp:TemplateField HeaderText="Appraisal By(code) ">  
                      

                    <ItemTemplate>  
                        <asp:Label ID="empbyid" runat="server" Text='<%# Bind("empbycode") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

               <%-- <asp:TemplateField HeaderText="Section">  
                    <ItemTemplate>  
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("subject") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 

                 

                 <asp:TemplateField HeaderText="Appraisal By(Name)">  
                    <ItemTemplate>  
                        <asp:Label ID="empbyname" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                 <asp:TemplateField HeaderText="Appraisal Of(code)">  
                    <ItemTemplate>  
                        <asp:Label ID="empofid" runat="server" Text='<%# Bind("empofcode") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Appraisal Of(Name)">  
                    <ItemTemplate>  
                        <asp:Label ID="empofname" runat="server" Text=''></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                        <asp:TemplateField HeaderText="Submission Status">  
                    <ItemTemplate>  
                        <asp:Label ID="appstatus" runat="server" Text='<%# Bind("submission_status") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>

                

                 <asp:TemplateField HeaderText="Submission Date">  
                    <ItemTemplate>  
                        <asp:Label ID="appdate" runat="server" Text='<%# Bind("submission_date") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
                     
                     
               



               
               
               
               
            </Columns>  
      --%>
    
    
    </asp:GridView>
     </asp:Panel>







        </div>
    </form>
</body>
</html>