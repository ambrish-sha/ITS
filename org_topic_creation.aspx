<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_topic_creation.aspx.cs" Inherits="ITS.org_topic_creation" %>

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
        .style2
        {
            font-family: Century;
            text-align: center;
            color:black;
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
    <div>
      <div class="container" >
           <h1 class="style2"><strong>Create New Topic</strong></h1>
   
    <div></div>

    <div class="form-group">
    <label for="subjectname">Select Subject Name:</label>
   <select class="form-control" id="subjectname" runat="server" name="subjectname">
        <option value=""  selected>Choose Subject</option>
        
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    <div class="form-group">
    <label for="topic">Enter Topic:</label>
    <input type="text" class="form-control" id="topic" runat="server" placeholder="Enter Topic" value="" name="topic" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>





 
  
  
  <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Submit" 
            onclick="Button1_Click" />
  &nbsp;
  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Delete" 
            onclick="Button2_Click" />



             <br />
            <br />
            <h3>Topic Name List</h3>
  
  <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView1" BackColor="AliceBlue" autogenerateselectbutton="True" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="20" onselectedindexchanged="GridView1_SelectedIndexChanged">
   
                
    
   
    
    </asp:GridView>
     </asp:Panel>
    </div>
    </div>
    </form>
</body>
</html>
