<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Account Payable</title>

        <link rel="stylesheet" href="css/bootstrap.min.css">
        <link href="css/custom2.css" rel="stylesheet">
        <link href="css/custom.css" rel="stylesheet">
        <link rel="stylesheet" href="css/bootstrap-theme.min.css">
        <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css">

        <script src="js/vendor/jquery-1.11.2.min.js"></script>
        <script src="js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/payandrecv.js"></script>
        <script src="js/main.js"></script>
        <script src="js/login.js"></script> 
  </head>
  <body>
      <% 
            session = request.getSession(false);
            System.out.println(session);
            if(session.isNew() == true)
            {
                response.sendRedirect("index.jsp");
            
            }
      
      
      %>
    <nav class ="navbar navbar-inverse navbar-fixed-top">
      <div class = "container">
        <button type="button" class ="navbar-toggle"
        data-toggle = "collapse"
        data-target = ".navbar-collapse">
        <span class="sr-only">Toggle Navigation</span> <!--Screen Reader only  -->
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        </button>
        <a class = "navbar-brand" href="#">Create Account Receivable</a>
        <div class = "navbar-collapse collapse"> <!--This will add navigation collapse  -->
          <ul class = "nav navbar-nav navbar-right"> <!--unorderd list and aligned it to RHS -->
              <li ><a href="dashboard.jsp">Home</a></li><!--list item -->
              <li><a href="#">About</a></li>
              
              
              <li class = "dropdown">
                 <a href="#" class = "dropdown-toggle" data-toggle="dropdown">Receivables<b class = "caret" ></b> <!--Dropdown-toggle will do cloapsing and contract back  b add triangle -->
                 <ul class = "dropdown-menu" >
                  <li><a href="receivable.jsp">Manage Account Receivable</a></li>
                  <li class = "dropdown-header"><hr></li>  
                  <li><a href="show_receivable.jsp">Show Account Receivable</a></li>
                  <li class = "dropdown-header"><hr></li>
                  <li><a href="create_receivable.jsp">Create Account Receivable</a></li>
                  <li class = "dropdown-header"><hr></li>
                 </ul>
                 </li>

                 <li class = "dropdown active">
                 <a href="#" class = "dropdown-toggle" data-toggle="dropdown">Payable<b class = "caret" ></b> <!--Dropdown-toggle will do cloapsing and contract back  b add triangle -->
                 <ul class = "dropdown-menu" >
                  <li><a href="payable.jsp">Manage Account Payable</a></li>
                  <li class = "dropdown-header"><hr></li>
                  <li><a href="show_payable.jsp">Show Account Payable</a></li>
                  <li class = "dropdown-header"><hr></li>
                  <li><a href="create_payable.jsp">Create Account Payable</a></li>                
                  <li class = "dropdown-header"><hr></li>
                 </ul>  
                </li>


              <li class = "dropdown">
                 <a href="#" class = "dropdown-toggle" data-toggle="dropdown">Settings<b class = "caret" ></b> <!--Dropdown-toggle will do cloapsing and contract back  b add triangle -->
                 <ul class = "dropdown-menu" >
                  
                  <li><a href="Logout.jsp">Log Out</a></li>
                  <li class = "dropdown-header"><hr></li>
                  <li><a href="account_settings.jsp">Account Settings</a></li>
                  <li class = "dropdown-header"><hr></li>
                 </ul>
              </li>
          </ul>
        </div>
      </div>
    </nav>






    <div class="jumbotron vertical-center">
      <div class="row">
      <div class ="container">
          <div class="col-sm-offset-4 col-md-6" style="padding: 20px">
                     <!-- ######################################################################################################################### -->

                   <form  action="CreatePayableServlet" method="post" onsubmit ="return creat_payable();" id ="vender_form" style="padding-left: 80px" class ="form-horizontal" role="form">
                      <fieldset class="scheduler-border">
                        <legend class="scheduler-border" >Account Payable</legend>
                       
                        <div class="form-group">
                  
                          <div class ="col-sm-offset-0 col-md-6">
                            <input type="text" placeholder="First Name" class="form-control" id="fname" name="fname1"> 
                          </div>
                           <div class ="col-sm-offset-0 col-md-5">
                            <input type="text" placeholder="Last Name" class="form-control" id="lname" name="lname1" > 
                          </div> 
                        </div>
                        <div class="form-group">
                           <div class="col-sm-offset-0 col-md-11">
                           <input type="txt" placeholder="Company" class="form-control" id ="comp" name ="comp1">
                           </div>
                        </div>
                        <div class="form-group">
                          <div class="col-sm-offset-0 col-md-11">
                              <input type="Number" placeholder="Phone Number" class="form-control" id ="pnum" name ="pnum1" >
                          </div>
                        </div>
                         <div class="form-group">
                          <div class="col-sm-offset-0 col-md-11">
                              <input type="email" placeholder="Email" class="form-control" id ="email" name ="email1" >
                          </div>
                        </div>
                        <div class="form-group">
                           <div class="col-sm-offset-0 col-md-11">
                              <input type="Number" placeholder="CNIC" class="form-control" id ="cnic" name ="cnic1" >
                           </div>
                        </div>
                        <div class="form-group">
                          <div class="col-sm-offset-0 col-md-11">
                              <input type="Number" placeholder="Amount Payable" class="form-control" id ="pay" name ="pay1" >
                          </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-0 col-md-11">
                             <input type="date" placeholder="Next Turn" class="form-control" id ="nextturn" name ="nextturn1" >
                            </div>
                        </div>

                              <button type ="submit" class="btn btn-success" >Create Account</button>
                      </fieldset>
                  </form>

              </div>
            </div>
            </div>
            </div>
      






    <!--Fixed footer -->
   
    <div style=" padding-top: 70px" >
        <div class ="navbar navbar-inverse  navbar-fixed-bottom " style="height:20px;width:100%" >
          <div class = "container">
            <div class = "navbar-text pull-left">
              <p class="float-xs-right"></p>
              <p>Account Manager &copy; 2016 &middot; <a href="#">Privacy</a> &middot; <a href="#">Terms</a> </p>
            </div> 
             <div class = "navbar-text pull-right">
              <a href="#"><i class="fa fa-facebook fa-lg" aria-hidden="true"></i>    </a>
              <a href="#"><i class="fa fa-twitter fa-lg" aria-hidden="true"></i></i></a>
              <a href="#"><i class="fa fa-camera-retro fa-lg"aria-hidden="true"></i>   </a>
              <a href="#">Back to top</a>
            </div>  
          </div>
        </div>
    </div>    
  </body>
</html>
