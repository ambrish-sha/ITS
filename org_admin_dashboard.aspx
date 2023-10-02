<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="org_admin_dashboard.aspx.cs" Inherits="ITS.org_admin_dashboard" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Test - Admin</title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link rel="icon" type="image/png" href="images/favicon.ico"/>
    <%--<link rel="shortcut icon" href="favicon_16.ico"/>
    <link rel="bookmark" href="favicon_16.ico"/>--%>
    <!-- site css -->
    <link rel="stylesheet" href="../dist/css/site.min.css"/>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,800,700,400italic,600italic,700italic,800italic,300italic" rel="stylesheet" type="text/css"/>
    <!-- <link href='http://fonts.googleapis.com/css?family=Lato:300,400,700' rel='stylesheet' type='text/css'> -->
    <!-- HTML5 shim, for IE6-8 support of HTML5 elements. All other JS at the end of file. -->
    <!--[if lt IE 9]>
      <script src="js/html5shiv.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
   
    <script type="text/javascript" src="../dist/js/site.min.js"></script>
    <script type="text/javascript" language="javascript">
         function preback() { window.history.forward(); }
         setTimeout("preback()", 0);
         window.onunload = function () { null };
    </script> 
</head>
<body style="background-color:lightblue;">
     <h4 style=" text-align:center; color:black;" runat="server" id="orgname"></h4>
    <!--nav-->
    <form id="form1" runat="server">
        
        <nav role="navigation" class="navbar navbar-custom">
           
           <div class="container-fluid">
          <!-- Brand and toggle get grouped for better mobile display -->
          <div class="navbar-header">
               
            <button data-target="#bs-content-row-navbar-collapse-5" data-toggle="collapse" class="navbar-toggle" type="button">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
             
            <a href="#"  class="navbar-brand"> <span id="span_user" runat="server"></span></a>
          </div>
              
          <!-- Collect the nav links, forms, and other content for toggling -->
          <div id="bs-content-row-navbar-collapse-5" class="collapse navbar-collapse">
               
            <ul class="nav navbar-nav navbar-right">
              <%--<li class="active"><a href="getting-started.html">Getting Started</a></li>
              <li class="active"><a href="index.html">Documentation</a></li>--%>
              <!-- <li class="disabled"><a href="#">Link</a></li> -->
              <li class="dropdown">
                <a data-toggle="dropdown" class="dropdown-toggle" href="#">Expand <b class="caret"></b></a>
                <ul role="menu" class="dropdown-menu">
                  <li class="dropdown-header">Setting</li>
                  <%--<li><a href="#">Action</a></li>
                  <li class="divider"></li>
                  <li class="active"><a href="#">Separated link</a></li>
                  <li class="divider"></li>--%>
                  <li class="disabled"><a href="Default.aspx">Signout</a></li>
                </ul>
              </li>
            </ul>

          </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
        </nav>
    <!--header-->
    <div class="container-fluid" style="background-color:lightblue;">
    <!--documents-->
        <div class="row row-offcanvas row-offcanvas-left">
          <div class="col-xs-6 col-sm-3 sidebar-offcanvas" role="navigation">
            <ul class="list-group panel">
                <li class="list-group-item"><i class="glyphicon glyphicon-align-justify"></i> <b>Admin Panel</b></li>
                <%-- <li class="list-group-item"><input type="text" class="form-control search-query" placeholder="Search Something"></li>--%>
                <a href=""  class="list-group-item"><i class="glyphicon glyphicon-file"></i> My Profile</a>

                  <a href="org_exam_creation.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Create Exam</a>
                 <a href="org_subject_creation.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Create Subject</a>
                <a href="org_topic_creation.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Create Topic</a>
                
              
                
          
                
                <a href="org_question_bank.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Create Question</a>
                     <a href="org_set_creation.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Create Set</a> 
                <a href="org_question_paper.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Create Paper</a>
                
                <a href="org_student_record.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i>Manage Student Record</a>
                <a href="uploadStudentRecord.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i>Upload students from csv</a>
                
                <a href="org_student_test_control.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Control and Schedule Test</a>
                
                <a href="org_student_result_all.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Test Result</a>
                 <a href="../org_result_analysis.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Result Analysis</a>
                 <a href="org_test_schedule_list.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Question Wise Result Analysis</a>
                
                 <a href="ChangePassword.aspx" target="myFrame" class="list-group-item"><i class="glyphicon glyphicon-file"></i> Change Password</a>
                
               
                </ul>
          </div>
          <div class="col-xs-12 col-sm-9 content">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title"><a href="javascript:void(0);" class="toggle-sidebar"><span class="fa fa-angle-double-left" data-toggle="offcanvas" title="Maximize Panel">Click Here To Shrink/Expand Options</span></a> </h3>
              </div>
              <div class="panel-body">
                  <div class="content-row">
                 <%--   <h2 class="content-row-title">
                      <span><b>Admin Dashboard</b></span>
                    </h2>--%>
                   <%-- <div class="embed-responsive embed-responsive-16by9">--%>
                        <iframe id="myFrame" runat="server"  name="myFrame"  frameborder="0" style="height: 100%; margin: 0; width: 100%;" allowfullscreen src="assignedCallingDataSummary.aspx"></iframe>
                        <%--<iframe class="embed-responsive-item" name="myFrame"  frameborder="0"style="overflow:hidden;height:150%;width:150%;position:absolute;top:0px;left:0px;right:0px;bottom:0px" height="150%" width="150%"></iframe>--%>
                    <%--</div>  --%>                  
                  </div>         
              </div>
                <!-- panel body -->
            </div>
        </div><!-- content -->
      </div>
    </div>
    </form>
</body>
</html>