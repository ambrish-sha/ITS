<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="org_student_test_control.aspx.cs" Inherits="ITS.org_student_test_control" %>

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
    <h2 style="text-align:center;">College Test Control</h2>

  <h5>CREATE EXAM NAME</h5>
<div class="row"  style="border:2px solid black;">

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
   <asp:DropDownList ID="courselist0" class="form-control"  runat="server" 
         AutoPostBack="True"  required OnSelectedIndexChanged="courselist0_SelectedIndexChanged" 
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
    <label for="branchlist0">Branch:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist0" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="branchlist0_SelectedIndexChanged" 
           ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  
 

  
   </div>

   <div class="row"  style="border:2px solid black;">

 <div class="col-sm-1">
    <label for="yearsemlist0">Year/Sem:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist0" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="yearsemlist0_SelectedIndexChanged" 
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 <div class="col-sm-1">
    <label for="examname">EXAM Name</label>
     </div>
   <div class="col-sm-3">
     <input type="text" class="form-control" placeholder="Enter Subject Name" runat="server" id="examname">
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  
  
  <div class="col-sm-2">
   
  <asp:Button ID="Button5" class="btn btn-primary" runat="server" Text="Submit" 
             formnovalidate OnClick="Button5_Click" />
            </div>

  </div>

   <div class="row"  style="border:2px solid black;">

       <div class="col-sm-1">
    <label for="delexamnamelist">Exam Name:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="delexamnamelist" class="form-control"  runat="server" 
           AutoPostBack="True"  required 
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
       <div class="col-sm-2">
   
  <asp:Button ID="delexam" class="btn btn-danger" runat="server" Text="Delete" 
             formnovalidate OnClick="delexam_Click"  />
            </div>
            </div>
  &nbsp;

  <br />



             <br />

              <h5>CREATE SUBJECT FOR EXAM </h5>
<div class="row"  style="border:2px solid black;">

     <div class="col-sm-1">
   <label for="batchlist1">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist1" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist1_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


 <div class="col-sm-1">

   
    <label for="courselist1">Course:</label>
     </div>
   <div class="col-sm-3">
   <asp:DropDownList ID="courselist1" class="form-control"  runat="server" 
         AutoPostBack="True"  required 
         onselectedindexchanged="cmplist_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
    <label for="branchlist1">Branch:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist1" class="form-control"  runat="server" 
           AutoPostBack="True"  required 
           onselectedindexchanged="postlist_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  
  
    
   </div>

   <div class="row"  style="border:2px solid black;">

       <div class="col-sm-1">
    <label for="yearsemlist1">Year/Sem:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist1" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="yearsemlist1_SelectedIndexChanged" 
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


 <div class="col-sm-1">
    <label for="examnamelist1">Exam Name:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="examnamelist1" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="examnamelist1_SelectedIndexChanged" 
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  <div class="col-sm-1">
    <label for="subname">Subject Name</label>
     </div>
   <div class="col-sm-3">
     <input type="text" class="form-control" placeholder="Enter Subject Name" runat="server" id="subname">
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
  </div>

   <div class="row"  style="border:2px solid black;">
  
  <div class="col-sm-2">
   
  <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Submit" 
            onclick="Button1_Click" formnovalidate />
            </div>
       </div>

   <div class="row"  style="border:2px solid black;">
       



             <div class="col-sm-1">
    <label for="delsubjectlist">Subject:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="delsubjectlist" class="form-control"  runat="server" AutoPostBack="True"  required></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
        <div class="col-sm-2">
   
  <asp:Button ID="delsubject" class="btn btn-danger" runat="server" Text="Delete" 
             formnovalidate OnClick="delsubject_Click"  />
            </div>
            </div>
  &nbsp;

  <br />
        <br />
  
  <h5>SET SET_ID TO SUBJECT </h5>




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
    <asp:DropDownList ID="subjectlist2" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="subjectlist2_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

        
            </div>
 
       <div class="row"  style="border:2px solid black;">


              <div class="col-sm-1">
   <label for="setid1">Set Id:</label>
    </div>
   
<div class="col-sm-3">
    <asp:DropDownList ID="setid1" class="form-control"  runat="server" AutoPostBack="false"  required ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  
 <div class="col-sm-2">
   
  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Submit" 
            formnovalidate OnClick="Button2_Click"  />
            </div>
            <div class="col-sm-2">
   
  <asp:Button ID="Updatesetid" class="btn btn-warning" runat="server" Text="Update" 
             formnovalidate OnClick="Updatesetid_Click"  />
            </div>

             <div class="col-sm-2">
   
  <asp:Button ID="delsetid" class="btn btn-danger" runat="server" Text="Delete" 
             formnovalidate OnClick="delsetid_Click"   />
            </div>


   </div>
  
 
           <br />


<br />
  
  <h5>SCHEDULE STUDENT EXAM </h5>






 <div class="row"  style="border:2px solid black;">


      <div class="col-sm-1">
   <label for="batchlist3">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist3" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist3_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
 <div class="col-sm-1">

   
    <label for="courselist13">Course:</label>
     </div>
   <div class="col-sm-3">
   <asp:DropDownList ID="courselist3" class="form-control"  runat="server" 
         AutoPostBack="True"  required onselectedindexchanged="cmplist2_SelectedIndexChanged" 
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
    <label for="branchlist3">Branch:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist3" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="branchlist3_SelectedIndexChanged"></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 
 

  
   </div>

   <div class="row"  style="border:2px solid black;">
        <div class="col-sm-1">
    <label for="yearsemlist3">Year/Sem:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist3" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="yearsemlist3_SelectedIndexChanged">
        <asp:ListItem Selected>Select</asp:ListItem>

    
    </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
       
      <div class="col-sm-1">
    <label for="examnamelist3">Exam Name:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="examnamelist3" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="examnamelist3_SelectedIndexChanged" 
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>




 <div class="col-sm-1">
    <label for="subjectid2">Subject</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="subjectlist3" class="form-control"  runat="server" AutoPostBack="false"  required OnSelectedIndexChanged="subjectlist3_SelectedIndexChanged">
        

    
    </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  

  
        </div>
       <div class="row"  style="border:2px solid black;">
        <div class="col-sm-1">
            <label for="startdate">Link Open</label>
      </div>
           <div class="col-sm-5">
                <input type="datetime-local" class="form-control"  runat="server" id="startdate" name="startdate">
  </div>

        <div class="col-sm-1">
            <label for="enddate">Link Close</label>
      </div>
           <div class="col-sm-5">
                <input type="datetime-local" class="form-control"  runat="server" id="enddate" name="enddate">
  </div>

          

            </div>
       <div class="row"  style="border:2px solid black;">


      <div class="col-sm-1">
   <label for="examstts">Exam Status:</label>
    </div>
   <div class="col-sm-3">
  <select class="form-control" id="examstts" runat="server" name="examstts" required>
        <option value="" disabled selected>Select</option>
       <option value="Active">Active</option>
       <option value="Deactive">Deactive</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>    

  <div class="col-sm-1">
   <label for="resdisp">Result Display:</label>
    </div>
   <div class="col-sm-3">
  <select class="form-control" id="resdisp" runat="server" name="resdisp" required>
        <option value="" disabled selected>Select</option>
       <option value="Yes">Yes</option>
       <option value="No">No</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>
             <div class="col-sm-1">
   <label for="anskey">Answer Key Release:</label>
    </div>
   <div class="col-sm-3">
  <select class="form-control" id="anskey" runat="server" name="resdisp" required>
        <option value="" disabled selected>Select</option>
       <option value="Yes">Yes</option>
       <option value="No">No</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>






             </div>
       <div class="row"  style="border:2px solid black;">
           <div class="col-sm-2">
   <label for="anskey">Want to send Email</label>
    </div>
            <div class="col-sm-3">
  <select class="form-control" id="sendemail1" runat="server" name="resdisp" required>
        <option value="" disabled selected>Select</option>
       <option value="Yes">Yes</option>
       <option value="No">No</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>
  
  <div class="col-sm-2">
   
  <asp:Button ID="Button3" class="btn btn-primary" runat="server" Text="Submit" 
            formnovalidate OnClick="Button3_Click"   />
            </div>

           <div class="col-sm-2">
   
  <asp:Button ID="Button6" class="btn btn-danger" runat="server" Text="Update" 
            formnovalidate OnClick="Button6_Click"    />
            </div>
            </div>



















  

<br />
<br />
  
  <h5>CHANGE ONE STUDENT EXAM STATUS </h5>

 

<div class="row"  style="border:2px solid black;">

     <div class="col-sm-1">
   <label for="batchlist4">Batch:</label>
   </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="batchlist4" class="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="batchlist4_SelectedIndexChanged"   ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>


 <div class="col-sm-1">

   
    <label for="courselist4">Course:</label>
     </div>
   <div class="col-sm-3">
   <asp:DropDownList ID="courselist4" class="form-control"  runat="server" 
         AutoPostBack="True"  required OnSelectedIndexChanged="courselist4_SelectedIndexChanged"  
         ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

   <div class="col-sm-1">
    <label for="branchlist4">Branch:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="branchlist4" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="branchlist4_SelectedIndexChanged" ></asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

 
  

  
   </div>

   <div class="row"  style="border:2px solid black;">
       <div class="col-sm-1">
    <label for="yearsemlist4">Year/Sem:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="yearsemlist4" class="form-control"  runat="server" AutoPostBack="True"  required OnSelectedIndexChanged="yearsemlist4_SelectedIndexChanged" >
        

    
    </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>
       
      <div class="col-sm-1">
    <label for="examnamelist4">Exam Name:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="examnamelist4" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="examnamelist4_SelectedIndexChanged"  
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>




 <div class="col-sm-1">
    <label for="subjectlist4">Subject</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="subjectlist4" class="form-control"  runat="server" AutoPostBack="false"  required OnSelectedIndexChanged="subjectlist4_SelectedIndexChanged">
         
    </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

  
        </div>
       <div class="row"  style="border:2px solid black;">

           <div class="col-sm-1">
    <label for="studentlist4">Student Rollno:</label>
     </div>
   <div class="col-sm-3">
    <asp:DropDownList ID="studentlist4" class="form-control"  runat="server" 
           AutoPostBack="True"  required OnSelectedIndexChanged="studentlist4_SelectedIndexChanged"  
           >
    
       </asp:DropDownList>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
  </div>

       <div class="col-sm-1">
   <label for="setid1">Student Name</label>
    </div>
   <div class="col-sm-3">
  <input type="text" class="form-control" disabled="true" placeholder="" runat="server" id="stname">
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>




  <div class="col-sm-1">
   <label for="stts">Student Status</label>
    </div>
   <div class="col-sm-3">
  <select class="form-control" id="stts" runat="server" name="examstts" required>
        <option value="" disabled selected>Select</option>
       <option value="Active">Active</option>
       <option value="Deactive">Deactive</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>

  
        </div>
       <div class="row"  style="border:2px solid black;">
        <div class="col-sm-1">
            <label for="opentime1">Link Open</label>
      </div>
           <div class="col-sm-5">
                <input type="datetime-local" class="form-control"  runat="server" id="opentime4" name="startdate">
  </div>

        <div class="col-sm-1">
            <label for="endtime1">Link Close</label>
      </div>
           <div class="col-sm-5">
                <input type="datetime-local" class="form-control"  runat="server" id="endtime4" name="enddate">
  </div>

          

            </div>
       <div class="row"  style="border:2px solid black;">


          

  <div class="col-sm-2">
   <label for="resdisp4">Result Display:</label>
    </div>
   <div class="col-sm-2">
  <select class="form-control" id="resdisp4" runat="server" name="resdisp" required>
        <option value="" disabled selected>Select</option>
       <option value="Yes">Yes</option>
       <option value="No">No</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>

            <div class="col-sm-2">
   <label for="anskeyup">Answer Key Display:</label>
    </div>
   <div class="col-sm-2">
  <select class="form-control" id="anskeyup" runat="server" name="resdisp" required>
        <option value="" disabled selected>Select</option>
       <option value="Yes">Yes</option>
       <option value="No">No</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>

            <div class="col-sm-2">
   <label for="sendemail2">Want to send Email</label>
    </div>
            <div class="col-sm-2">
  <select class="form-control" id="sendemail2" runat="server" name="resdisp" required>
        <option value="" disabled selected>Select</option>
       <option value="Yes">Yes</option>
       <option value="No">No</option>
      
      </select>
    <div class="valid-feedback">Valid.</div>
    <div class="invalid-feedback">Please fill out this field.</div>
   </div>
               </div>
       <div class="row"  style="border:2px solid black;">


  
  

           <div class="col-sm-3">
   
  <asp:Button ID="Button7" class="btn btn-danger" runat="server" Text="Update/Reset Test" 
            formnovalidate OnClick="Button7_Click"     />
            </div>
            </div>



<br />
<br />
            <br />
            <h1>Exam Schedule List</h1>
        <p>
            <asp:Button ID="Button8" runat="server" class="btn btn-danger" formnovalidate=""  Text="Show All Test Schedule" OnClick="Button8_Click" />
        </p>
  
  <asp:Panel ID="Panel1" runat="server" Height="400px" BorderColor="Black" BorderStyle="Double" ScrollBars="Both">
    <asp:GridView ID="GridView1" BackColor="AliceBlue" autogenerateselectbutton="False" 
          AutoGenerateColumns="true" CssClass="table table-striped" runat="server" 
          PageSize="20" >
   
                
    
   
    
    </asp:GridView>
     </asp:Panel>
    </div>
    </form>
    <div></div>
</body>
</html>


