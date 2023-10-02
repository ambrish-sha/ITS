<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="org_student_record.aspx.cs" Inherits="ITS.org_student_record" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Admin</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Popper JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body style="background-color:azure;">
    <form id="form1" runat="server">
    <div class="container" >
    <h3 style="text-align:center;">Student Record Management</h3>

    <br />

         <h6>Add/Delete New Batch(eg. 2021-2024 or 2022)</h6>
    <div class="row"   style="border:2px solid black; background-color:powderblue;">
  <div class="col-sm-1">
    <label for="batch0">Batch:</label>
    </div>
    <div class="col-sm-3">
  <input type="text" class="form-control" placeholder="Enter Batch Name" runat="server" id="batch0">
  </div>

  

    <div class="col-sm-2">
  <asp:Button ID="submitbatchname" class="btn btn-success" runat="server" 
          Text="submit"  formnovalidate OnClick="submitbatchname_Click"   />
        </div>
        </div>
        <div class="row"   style="border:2px solid black; background-color:powderblue;">
         <div class="col-sm-1">
   <label for="delbatchlist">Batch</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="delbatchlist" class="form-control"  runat="server" AutoPostBack="false"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
    
   <div class="col-sm-2">
  <asp:Button ID="batchdelete" class="btn btn-danger" runat="server" 
          Text="Delete" OnClick="batchdelete_Click"     />
        </div>
  
</div>
<br />
    <h6>Add/Delete New Course Name</h6>
    <div class="row"   style="border:2px solid black; background-color:powderblue;">

        <div class="col-sm-1">
   <label for="batchlist">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-1">
    <label for="coursetname">Course:</label>
    </div>
    <div class="col-sm-3">
  <input type="text" class="form-control" placeholder="Enter Course Name" runat="server" id="coursename">
  </div>

  

    <div class="col-sm-3">
  <asp:Button ID="cmpsubmit" class="btn btn-success" runat="server" 
          Text="submit"  formnovalidate OnClick="cmpsubmit_Click"  />
    
  </div>
        </div>
  <div class="row"   style="border:2px solid black; background-color:powderblue;">
  <div class="col-sm-1">
   <label for="delcourselist">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="delcourselist" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="courselist0_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


       <div class="col-sm-3">
  <asp:Button ID="delcourse" class="btn btn-danger" runat="server" 
          Text="Delete"  formnovalidate OnClick="delcourse_Click"   />
    
  </div>
</div>
<br />
        <br />


         <h6>Add/Delete Branch Name</h6>
 <div class="row"  style="border:2px solid black; background-color:powderblue;">
     <div class="col-sm-1">
   <label for="batchlist0">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist0" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist0_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 <div class="col-sm-1">
   <label for="courselist0">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist0" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="courselist0_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   

  <div class="col-sm-1">
    <label for="branchname">Branch:</label>
     </div>
   <div class="col-sm-3">
  <input type="text" class="form-control" placeholder="Enter Branch Name" runat="server" id="branchname">
  </div>

   
     </div>
        <div class="row"  style="border:2px solid black; background-color:powderblue;">
    <div class="col-sm-3">
  
  <asp:Button ID="Button8" class="btn btn-success" runat="server" 
          Text="submit"   formnovalidate OnClick="Button8_Click"/>
    
  </div>
            </div>
        <div class="row"   style="border:2px solid black; background-color:powderblue;">

             <div class="col-sm-1">
   <label for="delbranchlist">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="delbranchlist" class="form-control"  runat="server" AutoPostBack="True" ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

            <div class="col-sm-3">
  
  <asp:Button ID="delbranch" class="btn btn-danger" runat="server" 
          Text="Delete"   formnovalidate OnClick="delbranch_Click" />
    
  </div>
  
</div>







        

   


  




























<br />
<br />
 <h6>Add/Delete New Year/Semester</h6>
 <div class="row"  style="border:2px solid black; background-color:powderblue;">
     <div class="col-sm-1">
   <label for="batchlist1">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist1" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist1_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


 <div class="col-sm-1">
   <label for="courselist1">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist1" class="form-control"  runat="server" AutoPostBack="True"  OnSelectedIndexChanged="companylist_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
   <label for="branhlist1">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist1" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchlist1_SelectedIndexChanged" ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
     </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">
  <div class="col-sm-1">
    
   <label for="yearsem">Year/Semester</label>
     </div>
   <div class="col-sm-3">
  <input type="text" class="form-control" placeholder="Enter Year/Semester" runat="server" id="yearsem">
  </div>

   

    <div class="col-sm-2">
  
  <asp:Button ID="postsubmit" class="btn btn-success" runat="server" 
          Text="submit"   formnovalidate OnClick="postsubmit_Click"/>
    
  </div>

         </div>
        <div class="row"   style="border:2px solid black; background-color:powderblue;">

         <div class="col-sm-1">
   <label for="delyearsemlist">Year/Sem:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="delyearsemlist" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="yearsemlist_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

          <div class="col-sm-2">
  
  <asp:Button ID="delyearsem" class="btn btn-danger" runat="server" 
          Text="Delete"   formnovalidate OnClick="delyearsem_Click" />
    
  </div>
  
</div>
<br />
<br />


     <h6>Add New Student</h6>
 <div class="row"  style="border:2px solid black; background-color:powderblue;">
   <div class="col-sm-1">
   <label for="batchlistt">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlistt" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlistt_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 <div class="col-sm-1">
   <label for="courselist">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist" class="form-control"  runat="server" AutoPostBack="True"  OnSelectedIndexChanged="companylist2_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
   <label for="branchlist">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchlist_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


     </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">

     <div class="col-sm-1">
   <label for="yearsemlist">Year/Sem:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="yearsemlist_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


         <div class="col-sm-1">
   <label for="pwdtype">Password Type</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="pwdtype" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="pwdtype_SelectedIndexChanged" >
    <asp:ListItem Value="">Select</asp:ListItem>
       <asp:ListItem  Value="Default">Default</asp:ListItem>
       <asp:ListItem Value="Random">Random</asp:ListItem>
        </asp:DropDownList>
       <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
    

     <div class="col-sm-1">
   <label for="defpass">Default password</label>
   </div>
   <div class="col-sm-3">
    <input type="text" class="form-control" placeholder=" Default Password" runat="server" id="defpass">
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>



         </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">
         <div class="col-sm-1">
   <label for="ststatus">Login Status:</label>
   </div>
   <div class="col-sm-3">
    <select class="form-control" id="ststatus" runat="server" name="stutype" >
          <option selected value="">Select</option>
       <option  value="Active">Active</option>
         <option value="Deactive">Deactive</option>
         
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  <div class="col-sm-1">
    <label for="stroll">Roll No(Unique):</label>
     </div>
   <div class="col-sm-3">
  <input type="text" class="form-control" placeholder="Roll No" runat="server" id="stroll">
        
  </div>
       <div class="col-sm-4">  
            <label runat="server" id="rollmask"></label>
         </div>
    

 

     

     
          
       
     
     </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">


         <div class="col-sm-1">
   <label for="stname">Name:</label>
   </div>
   <div class="col-sm-3">
    <input type="text" class="form-control" placeholder="Name" runat="server" id="stname">
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
    <div class="col-sm-1">
   <label for="stemail">Email ID:</label>
   </div>
   <div class="col-sm-3">
    <input type="email" class="form-control" placeholder="Email iD" runat="server" id="stemail">
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    <div class="col-sm-2">
  
  <asp:Button ID="Button9" class="btn btn-success" runat="server" 
          Text="submit"   formnovalidate OnClick="Button9_Click"/>
    
  </div>
  
</div>




<br />

        <br />
        <h6>Change Login Status</h6>
<div class="row"  style="border:2px solid black; background-color:powderblue;">

    <div class="col-sm-1">
   <label for="batchlist4">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist4" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist4_SelectedIndexChanged"    ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 <div class="col-sm-1">
   <label for="courselist4">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist4" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="courselist4_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
   <label for="branchlist4">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist4" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchlist4_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


     </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">

     <div class="col-sm-1">
   <label for="yearsemlist4">Year/Sem:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist4" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="yearsemlist4_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


 <div class="col-sm-1">

   
     &nbsp;Roll No

 </div>
   <div class="col-sm-3">
   <asp:DropDownList ID="studentlist4" class="form-control"  runat="server" 
         AutoPostBack="True" OnSelectedIndexChanged="studentlist4_SelectedIndexChanged"     
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    <div class="col-sm-1">

   
        Name

 </div>
    <div class="col-sm-3">

        <asp:TextBox Enabled="false" class="form-control" ID="studentname4" runat="server"></asp:TextBox>
    
     </div>

          </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">
          <div class="col-sm-1">
   <label for="yearsemlist4">Login Status:</label>
   </div>
         <div class="col-sm-3">
    <select class="form-control" id="selectstatus" runat="server" name="stutype" >
        <option selected value="">Select</option>
       <option value="Active">Active</option>
         <option value="Deactive">Deactive</option>
         
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    <div class="col-sm-2">
  <asp:Button ID="updatestatus" class="btn btn-danger" runat="server" Text="update" 
           Visible="true"  formnovalidate OnClick="updatestatus_Click"     />
        </div>
</div>
     




        <br />



             <br />
 <h6>Delete Student</h6>
<div class="row"  style="border:2px solid black; background-color:powderblue;">

    <div class="col-sm-1">
   <label for="batchlist3">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist3" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist3_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 <div class="col-sm-1">
   <label for="courselist3">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist3" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="courselist3_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
   <label for="branchlist3">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist3" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchlist3_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


     </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">

     <div class="col-sm-1">
   <label for="yearsemlist3">Year/Sem:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist3" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="yearsemlist3_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


 <div class="col-sm-1">

   
     Roll No

 </div>
   <div class="col-sm-3">
   <asp:DropDownList ID="studentlist3" class="form-control"  runat="server" 
         AutoPostBack="True" OnSelectedIndexChanged="studentlist3_SelectedIndexChanged"    
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    <div class="col-sm-1">

   
        Name

 </div>
    <div class="col-sm-3">

        <asp:TextBox Enabled="false" class="form-control" ID="studentname3" runat="server"></asp:TextBox>
    
     </div>

          </div>
     <div class="row"  style="border:2px solid black; background-color:powderblue;">

    <div class="col-sm-2">
  <asp:Button ID="Button6" class="btn btn-danger" runat="server" Text="Delete" 
           Visible="true"  formnovalidate OnClick="Button6_Click1"    />
        </div>
</div>
        <br />
        <br />



















<br />











             <br />
            <br />
            

<h5>Student List</h5>
<div class="row"  style="border:2px solid black; background-color:powderblue;">
    
    <div class="col-sm-1">
   <label for="batchlist2">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist2" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist2_SelectedIndexChanged"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   
   <div class="col-sm-1">
   <label for="courselist2">Course:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="courselist2" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="courselist2_SelectedIndexChanged" ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
   <label for="branchlist2">Branch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist2" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchlist2_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    </div>
    <div class="row"  style="border:2px solid black; background-color:powderblue;">

     <div class="col-sm-1">
   <label for="yearsemlist2">Year/Sem:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist2" class="form-control"  runat="server" AutoPostBack="True"  ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

    
    <div class="col-sm-2">
   
  <asp:Button ID="Button7" class="btn btn-success" Visible="true" runat="server" Text="Search" 
            formnovalidate OnClick="Button7_Click"   />
            </div>
         
 <div class="col-sm-2">
  <asp:Button ID="Button11" class="btn btn-warning" runat="server" Text="Click For All Student" 
           Visible="true"  formnovalidate OnClick="Button11_Click"   />
        </div>
        </div>

   
  <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView1" BackColor="AliceBlue" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="20" >
   
                
    
   
    
    </asp:GridView>

     </asp:Panel>
                      <asp:Button ID="Button10" CssClass="btn-danger" Visible="True" runat="server" Text="Download in Excel" OnClick="Button10_Click" />

    </div>
    <div></div>
    </form>
    <br />
    <br />
    </body>
</html>