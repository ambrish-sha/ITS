<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="org_set_creation.aspx.cs" Inherits="ITS.org_set_creation" %>

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
    <style type="text/css">
        .style1
        {
            font-family: Century;
            color: #FFFFFF;
            text-align: center;
        }
        .style2
        {
            font-family: Century;
            color: black;
            text-align: center;
            font-size: x-large;
        }
    </style>
     <script type = "text/javascript" >
         function preventBack() { window.history.forward(); }
         setTimeout("preventBack()", 0);
         window.onunload = function () { null };  
     </script> 
</head>
<body style="background-color:lightblue;">
    <form id="form1" runat="server">
    <div class="container" >
         <h1 class="style2"><strong>Create New Paper Set</strong></h1>
   
    <div></div>

    <div class="form-group">
    <label for="setid">Set ID:</label>
    <input type="text" class="form-control" id="setid" runat="server" placeholder="Enter set id" name="setid" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="form-group">
    <label for="examcat">Total Quesion:</label>
    <input type="text" class="form-control" id="examcat" runat="server" placeholder="Enter Total question" name="examcat" required>
    
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="form-group">
    <label for="totalmarks">Total Marks:</label>
    <input type="text" class="form-control" id="totalmarks" runat="server" placeholder="Enter Total Marks" name="totalmarks" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="form-group">
    <label for="totalduration">Total Duration(Minute):</label>
    <input type="text" class="form-control" id="totalduration" runat="server" placeholder="Enter Total Duration(Minut)" name="totalduration" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="form-group">
    <label for="correctmarks">Correct Marks For Each Question:</label>
    <input type="text" class="form-control" id="correctmarks" runat="server" placeholder="Enter Marks for Correct " name="correctmarks" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="form-group">
    <label for="wrongmarks">Wrong Marks For Each Question:</label>
    <input type="text" class="form-control" id="wrongmarks" runat="server" placeholder="Enter Marks for wrong" name="wrongmarks" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="form-group">
    <label for="examname">Exam Name:</label>
    <select class="form-control" id="examname" runat="server" name="examname">
        <option value="" disabled selected>Choose Exam Name</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

        


   <div class="form-group">
    <label for="subjectname">Subject Name:</label>





   <asp:DropDownList ID="subjectname" class="form-control" runat="server" 
           AutoPostBack="True" onselectedindexchanged="subjectname_SelectedIndexChanged"></asp:DropDownList>

    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="form-group">
    <label for="topicname">Topic Name:</label>
   <select class="form-control" id="topicname" runat="server" name="topicname">
        <option value="" disabled selected>Choose Topic</option>
       
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>



 
        <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" 
            onclick="Button1_Click" formnovalidate />


             &nbsp;&nbsp;&nbsp;&nbsp;


             <asp:Button ID="Button2" class="btn btn-primary" runat="server" 
            Text="Delete" onclick="Button2_Click" />


             <h3>Paper Set List </h3>


<div class="row"  style="border:2px solid black;">
  <div class="col-sm-1">

   
    <label for="exmname">Exam Name:</label>
     </div>
   <div class="col-sm-2">
   <asp:DropDownList ID="exmname" class="form-control" style="margin:2px;" runat="server" 
         AutoPostBack="True" OnSelectedIndexChanged="exmname_SelectedIndexChanged" formnovalidate  
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
    <label for="sbj">Subject:</label>
     </div>
   <div class="col-sm-2">
    <asp:DropDownList ID="sbj" class="form-control" style="margin:2px;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="sbj_SelectedIndexChanged" formnovalidate ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


     <div class="col-sm-1">
    <label for="tpk">Topic:</label>
     </div>
   <div class="col-sm-2">
    <asp:DropDownList ID="tpk" class="form-control" style="margin:2px;" runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="tpk_SelectedIndexChanged" formnovalidate></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>




 
 

   

    </div>

  
  <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView1" BackColor="AliceBlue" autogenerateselectbutton="True" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="10" onselectedindexchanged="GridView1_SelectedIndexChanged">
   
                
    
   
    
    </asp:GridView>
     </asp:Panel>
  
    </div>
    </form>




    <%--<p id="log">Awaiting focus check.</p>--%>
<%--<button onclick="openWindow()">Open a new window</button>--%>


    <div></div>
</body>
</html>
