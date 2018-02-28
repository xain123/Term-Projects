<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="Sat, 01 Dec 2001 00:00:00 GMT">
    
    <title>Dash Board</title>

        <link rel="stylesheet" href="css/bootstrap.min.css">
        <link href="css/custom.css" rel="stylesheet">
        <link href="css/animations.css" rel="stylesheet">
        <link rel="stylesheet" href="css/bootstrap-theme.min.css">
        <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css">

        <script src="js/vendor/jquery-1.11.2.min.js"></script>
        <script src="js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
        <script src="js/vendor/bootstrap.min.js"></script>
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
      
   <%
     response.setHeader( "Pragma", "no-cache" );
     response.setHeader( "Cache-Control", "no-cache" );
     response.setDateHeader( "Expires", 0 );
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
        <a class = "navbar-brand" href="#">Acounts Manager</a>
        <div class = "navbar-collapse collapse"> <!--This will add navigation collapse  -->
          <ul class = "nav navbar-nav navbar-right"> <!--unorderd list and aligned it to RHS -->
              <li class ="active"><a href="#">Home</a></li><!--list item -->
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

                 <li class = "dropdown">
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
   <%
       
   
   
   %>



   <div class="content all_pad agile">
  <div class="container">
    <h3 class="title">Some Facts About Us<span></span></h3>
    <div class="content_grids">
      <div class="col-md-3 capabil-grid wow fadeInDown animated animated text-center" data-wow-delay="0.4s">
        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='5700' data-delay='.5' data-increment="1">5700</div>
        <p>Winning Awards</p> 
      </div>
      <div class="col-md-3 capabil-grid mar-top wow fadeInUp animated animated text-center" data-wow-delay="0.4s">
        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='1700' data-delay='.5' data-increment="1">1700</div>
        <p>Clients Worked With</p>  
      </div>
      <div class="col-md-3 capabil-grid mar-top wow fadeInDown animated animated text-center" data-wow-delay="0.4s">
        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='9000' data-delay='.5' data-increment="1">9000</div>        
        <p>Completed Projects</p>
      </div>
      <div class="col-md-3 capabil-grid wow fadeInUp animated animated text-center" data-wow-delay="0.4s">
        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='2500' data-delay='.5' data-increment="1">2500</div>
        <p>Likes</p>
      </div>
      <div class="clearfix"></div>
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
