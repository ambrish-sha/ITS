<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ITS.ChangePassword" %>

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
           <h1 class="style2"><strong>Change Password</strong></h1>
   
    <div class="form-group">
    <label for="useridd">UserId:</label>
    <input type="text" class="form-control" disabled="true" id="useridd" runat="server" placeholder="" value="" name="Uid" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
          <div class="form-group">
    <label for="op">Old Password:</label>
    <input type="password" class="form-control" id="op" runat="server" placeholder="Enter old password" value="" name="op" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
          <div class="form-group">
    <label for="np">New Password:</label>
    <input type="password" class="form-control" id="np" runat="server" placeholder="Enter new password" value="" name="np" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

           <div class="form-group">
    <label for="cnp">Confirm new password:</label>
    <input type="text" class="form-control" id="cnp" runat="server" placeholder="Confirm paswword" value="" name="cnp" required>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>





 
  
  
  <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Update" 
            onclick="Button1_Click" />

 


             <br />
            <br />
    </div>
    </div>
    </form>
</body>
</html>
