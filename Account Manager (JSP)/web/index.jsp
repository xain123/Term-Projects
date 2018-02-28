<!doctype html>
<html class="no-js" lang="en"> 
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        
        <title>Accounts Manager</title>
        
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

          session=request.getSession(false);

        if(session!=null)
         {
          session.invalidate();
         }
          
      
       %>
        <%
     response.setHeader( "Pragma", "no-cache" );
     response.setHeader( "Cache-Control", "no-cache" );
     response.setDateHeader( "Expires", 0 );
    %>

        
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">Accounts Manager</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">

            <form action="LoginServlet" onsubmit="return signin_validate();" id="form_id" method="post" name="myform" class="navbar-form navbar-right" role="form">
            <div class="form-group">
              <input type="text" placeholder="Username" class="form-control" name="username" id="username">
            </div>
            <div class="form-group">
              <input type="password" placeholder="Password" class="form-control"name="password" id ="password">
            </div>
            <button type="submit" class="btn btn-success" id="login">Sign in</button>
          </form>

        </div>
      </div>
    </nav>

    


    <!-- Main jumbotron for a primary marketing message or call to action -->
   
    <div class="jumbotron ">  
        <div class="container">
          <div class ="row">
            <div class ="col-md-8">
              <h3>Hello This is accounts manager</h3>
               <div class="content all_pad agile">
                  <div class="container">
                    <h3 class="title" style="padding-bottom: 50px">Some Facts About Us<span></span></h3>
                    <div class="content_grids">
                      <div class="col-md-3 capabil-grid wow fadeInDown animated animated text-center" data-wow-delay="0.4s">
                        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='5700' data-delay='.5' data-increment="1">570</div>
                        <p>Winning Awards</p> 
                      </div>
                      <div class="col-md-3 capabil-grid mar-top wow fadeInUp animated animated text-center" data-wow-delay="0.4s">
                        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='1700' data-delay='.5' data-increment="1">1700</div>
                        <p>Clients Worked With</p>  
                      </div>
                      
                      <div class="col-md-3 capabil-grid wow fadeInUp animated animated text-center" data-wow-delay="0.4s">
                        <div class='numscroller numscroller-big-bottom' data-slno='1' data-min='0' data-max='2500' data-delay='.5' data-increment="1">2500</div>
                        <p>Likes</p>
                      </div>
                      <div class="clearfix"></div>
                      </div>
                    </div>
                </div>


            </div>
           
            <div class="container col-md-4">
              <h2>Sign Up</h2>
              <h3>Its free and always will be.</h3><br>
              


              

              <form action="SignupServlet" onsubmit="return signup_validate();" method="post" class ="form-horizontal" role="form">

                <div class="form-group">
                  
                    <div class ="col-sm-offset-0 col-md-6">
                      <input type="text" placeholder="First Name" class="form-control" id="fname" name="fname1"> 
                    </div>
                     <div class ="col-sm-offset-0 col-md-6">
                      <input type="text" placeholder="Last Name" class="form-control" id="lname" name="lname1"> 
                    </div>
                  
                </div>

                <div class="form-group">
                    <div class="col-md-12">
                      <input type="text" placeholder="User Name" class="form-control" id ="user"  name ="user1">

                    </div>
                  </div>

                <div class = "form-group">
                  <div  class ="col-sm-12">
                    <input type="number" placeholder="Phone Number" class="form-control" id="phone" name="phone1">
                  </div>
                </div>

                <div class = "form-group">
                  <div  class ="col-sm-12">
                    <input type="email" placeholder="Email" class="form-control" id="email" name="email1">
                  </div>
                </div>

                  <div class = "form-group">
                    <div  class ="col-sm-12">
                      <input type="password" placeholder="Password" class="form-control" id="pwd" name="pwd1">
                    </div>
                  </div>

                  <div class ="form-group">
                    <div class="col-md-12">
                      <input type="password" placeholder="Confirm Password" class="form-control" id="cpwd">
                    </div>

                  </div>
                  
                
                  <div class="checkbox" id ="check">
                   <!-- <label > <input type="checkbox"/>Accept <a href="#">Terms</a></label> -->
                  </div>
                  <h5>By clicking Sign Up, you agree to our <a href="#">Terms</a> </h5>
                  <button type ="submit" class="btn btn-success" id="signup">Sign Up</button>
              </form>
            </div>
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
      <script src="js/login.js"></script> 
    </body>
</html>