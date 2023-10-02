<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_test_schedule_list.aspx.cs" Inherits="ITS.org_test_schedule_list" %>

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
            <h4>Current Test Pending</h4>
            <p style="color:red;">*Click on select link for start the exam</p>
            <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
     <asp:GridView ID="GridView1" BackColor="white" ShowFooter="true" AutoGenerateColumns="true" CssClass="table table-striped"  runat="server" PageSize="10" AutoGenerateSelectButton="true" SelectText="Start Test" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
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
            





        </div>
    </form>
</body>
</html>
