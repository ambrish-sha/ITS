<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="org_student_result_all.aspx.cs" Inherits="ITS.org_student_result_all" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Popper JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body style="background-color:lightblue">
    <form id="form1" runat="server">
    <div class="container" >
    <h2 style="text-align:center;">&nbsp;Test Result of All Students</h2>

        <br />
  



  <div class="row"  style="border:2px solid black;">
      <div class="col-sm-1">
   <label for="batchlist2">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist2" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist2_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>



 <div class="col-sm-1">

   
    <label for="courselist2">Course:</label>
     </div>
   <div class="col-sm-3">
   <asp:DropDownList ID="courselist2" class="form-control"  runat="server" 
         AutoPostBack="True"  required onselectedindexchanged="cmplist1_SelectedIndexChanged" 
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
    <label for="branchlist2">Branch:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist2" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="branchlist2_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  


       </div>
       <div class="row"  style="border:2px solid black;">

<div class="col-sm-1">
    <label for="yearsemlist2">Year/Sem:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist2" class="form-control"  runat="server" 
           AutoPostBack="True"  required 
           onselectedindexchanged="semid1_SelectedIndexChanged">
    
    

    </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


      <div class="col-sm-1">
    <label for="examnamelist2">Exam Name:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="examnamelist2" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="examnamelist2_SelectedIndexChanged" 
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


  <div class="col-sm-1">
    <label for="subjectlist2">Subject:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="subjectlist2" class="form-control"  runat="server" AutoPostBack="True"  required></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

        
            </div>
 
       <div class="row"  style="border:2px solid black;">


 <div class="col-sm-2">
   
  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Search" 
            formnovalidate OnClick="Button2_Click"  />
            </div>


   </div>
  
 
           <br />


<br />
  
            <br />
            <h1>Test Result List</h1>
  
  <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView1" BackColor="AliceBlue" autogenerateselectbutton="true" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="20" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
   
                
    
   
    
    </asp:GridView>
     </asp:Panel>
        <div class="col-sm-2">
    
      <asp:Button ID="exceldownload" runat="server" class="btn btn-danger" Text="Download in excel" 
           formnovalidate OnClick="exceldownload_Click"  />
    </div>
        <br />

    </div>
    <h3>Answer Key</h3>


  <br />
   
    <label>Select Data source</label>
  <select class="form-control" id="ansfrom" runat="server" name="topicname">
        <option value="" disabled selected>Select Data Source</option>
         <option value="cur">Current</option>
       <option value="old">Old</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>

        <br />
 
    <asp:Panel ID="Panel2" runat="server" Height="400px" BorderColor="Black" BackColor="ControlLight" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView3" BackColor="white" autogenerateselectbutton="false" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="20" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" >
   
                
    
   
    
    </asp:GridView>
     </asp:Panel>
      <br />
     <div class="col-sm-2">
    
      <asp:Button ID="downanswerkey" runat="server" class="btn btn-danger" Text="Download in excel" 
           formnovalidate OnClick="downanswerkey_Click"   />
    </div>





















   
         <div class="col-sm-4">
    
      <asp:Button ID="transfer" Visible="false" runat="server" class="btn btn-danger" Text="Transfer answer data into backup" 
           formnovalidate OnClick="transfer_Click"   />
    </div>


   
        </form>




  









</body>
</html>



