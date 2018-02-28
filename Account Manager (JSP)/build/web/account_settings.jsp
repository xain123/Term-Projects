<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Account Settings</title>

        <link rel="stylesheet" href="css/bootstrap.min.css">
        <link href="css/custom.css" rel="stylesheet">
        <link href="css/custom2.css" rel="stylesheet">
        <link rel="stylesheet" href="css/bootstrap-theme.min.css">
        <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css">

        <script src="js/vendor/jquery-1.11.2.min.js"></script>
        <script src="js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/main.js"></script>
        <script src="js/settings.js"></script> 

        <%@page import="java.sql.*, java.util.*"%>
        <%@  page errorPage="errorpage.jsp" language="java"   %>
       

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
      
      
      <%! 
          
          
           public boolean checkusername(String user)throws Exception
            {
                Class.forName("com.mysql.jdbc.Driver");       
                String URL = "jdbc:mysql://localhost:3306/";
                String db ="ams";
                String u_name = "root";
                String u_pwd="";		
                Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);

                String sql = "select * from users where user_name = ?";
                PreparedStatement ps = con.prepareStatement(sql);
                ps.setString(1, user);        
                ResultSet rs = ps.executeQuery(); 
                

               if (rs.isBeforeFirst() ) 
                {
                    return false;
                }  
                else
                {
                    return true;
                }   
            }

          
          
          
        
        public int getUserId(String user)throws Exception
        {
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);

            String sql = "select user_id from users where user_name = ?";
            PreparedStatement ps = con.prepareStatement(sql);
            ps.setString(1, user);        
            ResultSet rs = ps.executeQuery(); 
            int userid = 0;

            rs.next(); 
            userid = rs.getInt("user_id");
            con.close();
            return userid;
        }

         public String getPass(String user) throws Exception
	{
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
           
           String sql = "select password from users where user_name = ?";
           PreparedStatement ps = con.prepareStatement(sql);
           ps.setString(1, user);        
           ResultSet rs = ps.executeQuery();
	   String username=null;
           String password=null;
	   
	        
           if (!rs.isBeforeFirst() ) 
           {    
             return "";
           }
           else
           {
               rs.next();
               password = rs.getString("password");
               
               con.close();
               return password;  
           }
        }



      %>

      <% 
         session = request.getSession();
         String username = session.getAttribute("user").toString();       
         int userid = getUserId(username);
   
         Class.forName("com.mysql.jdbc.Driver");     
         String URL = "jdbc:mysql://localhost:3306/";
         String db ="ams";
         String u_name = "root";
         String u_pwd="";
         

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
        <a class = "navbar-brand" href="#">Account Settings</a>
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


              <li class = "dropdown active">
                 <a href="#" class = "dropdown-toggle" data-toggle="dropdown">Settings<b class = "caret" ></b> <!--Dropdown-toggle will do cloapsing and contract back  b add triangle -->
                 <ul class = "dropdown-menu" >
                  
                  <li><a href="index.jsp">Log Out</a></li>
                  <li class = "dropdown-header"><hr></li>
                  <li><a href="account_settings.jsp">Account Settings</a></li>
                  <li class = "dropdown-header"><hr></li>
                 </ul>
              </li>
          </ul>
        </div>
      </div>
    </nav>
   

   <div class="collapse navbar-collapse" id="#bs-sidebar-navbar-collapse-1">
                      <ul class="nav navbar-nav">
                        <li ><a href="javascript:void(0);" onclick="show(1);">Name<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>
                        <li ><a href="javascript:void(0);" onclick="show(2); ">User Name<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>       
                        <li ><a href="javascript:void(0);" onclick="show(3); ">Contact<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>
                        <li ><a href="javascript:void(0);" onclick="show(4); ">Password<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>
                      </ul>
                    </div>

    <div class="jumbotron vertical-center">
      <div class="row">
        
        <div class ="container">

            <div class="col-sm-offset-2 col-md-8" style="padding-left: 90px">  
              <div class="jumbotron vertical-center" style="background:white ; min-height: 200px;width: 100%;  ">
                <nav class="navbar navbar-default sidebar t" role="navigation">
                 <div class="container-fluid">
                    <div class="navbar-header">
                      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-sidebar-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                      </button>      
                    </div>


                    <div class="collapse navbar-collapse" id="#bs-sidebar-navbar-collapse-1">
                      <ul class="nav navbar-nav">
                        <li ><a href="javascript:void(0);" onclick="show(1);name();">Name<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>
                        <li ><a href="javascript:void(0);" onclick="show(2); user();">User Name<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>       
                        <li ><a href="javascript:void(0);" onclick="show(3); contact();">Contact<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>
                        <li ><a href="javascript:void(0);" onclick="show(4); password();">Password<span style="font-size:16px;" class="pull-right hidden-xs "></span></a></li>
                      </ul>
                    </div>
                  </div>
                </nav>




                     <!-- ######################################################################################################################### -->

                     <form action="account_settings.jsp" method="post" id ="name_form"  style="padding-left: 100px; padding-top: 5px;display: none; " class ="form-horizontal" role="form">
                
                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                          <input type="txt" placeholder="First Name" class="form-control" id ="fname" name="fname1" required>
                        </div>
                      </div>
                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                          <input type="txt" placeholder="Last Name" class="form-control" id ="lname" name="lname1" required>
                        </div>
                      </div>

                    <button type ="submit" class="btn btn-success" name="submit" value="name">Apply Change</button>
                  </form>
                     <%
                        String x = request.getParameter("submit");
                       if(x!=null && x.equals("name"))
                       {
                           String fname,lname;
                           fname=request.getParameter("fname1").toString();
                           lname=request.getParameter("lname1").toString();
                           if((fname!=null||fname !="")  && (lname!=null||lname!=""))
                           {   Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
                               String sql_query1 = "UPDATE users SET first_name=?, last_name=? WHERE user_id=?;";
                               PreparedStatement ps = con.prepareStatement(sql_query1);
				
                                ps.setString(1,fname);
                                ps.setString(2,lname);                   
                                ps.setInt(3,userid);
                                int count = ps.executeUpdate();
		
				if(count >0)
				{
                                    
                                    out.println("<script type=\"text/javascript\">");
                                    out.println("alert('Name Has Been Updated');");
                                    out.println("</script>");   
					  
				}
                           }
                           
                           
                       }


                      %>
                 
                      
                   <form id ="user_form" method=post style="padding-left: 100px; padding-top: 5px; display: none;" class ="form-horizontal" role="form">
                
                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                            <input type="txt" placeholder="New Username" class="form-control" id ="username" name="username1" required>
                        </div>
                      </div>

                    <button type ="submit" class="btn btn-success"name="submit1" value="username" >Apply Change</button>
                  </form>
                  <%
                       String y = request.getParameter("submit1");
                       if(y!=null && y.equals("username"))
                       {
                           String username1;
                           username1=request.getParameter("username1").toString();
                           if((username1!=null||username1 !=""))
                           {
                               if(checkusername(username1))
                               {    
                                   Connection con1 = DriverManager.getConnection(URL+db,u_name,u_pwd);
                                    String sql_query2 = "UPDATE users SET user_name=? WHERE user_id=?;";
                                    PreparedStatement ps1 = con1.prepareStatement(sql_query2);

                                     ps1.setString(1,username1);
                                     ps1.setInt(2,userid);
                                     int count = ps1.executeUpdate();

                                     if(count >0)
                                     {   
                                         session.setAttribute("user",username1);
                                         username=username1;
                                         userid = getUserId(username);
                                         out.println("<script type=\"text/javascript\">");
                                         out.println("alert('UserName Has Been Updated');");
                                         out.println("</script>");   

                                     }
                                }
                               else
                               {
                                   
                                    out.println("<script type=\"text/javascript\">");
                                    out.println("alert('UserName is not Available');");
                                    out.println("</script>"); 
                               }
                           }
                           
                       }


                      %>
                  
                  
                  
                  
                  
                  
                  
                  

                  <form  method ="post" id ="contact_form" style="padding-left: 100px; padding-top: 5px; display: none;" class ="form-horizontal" role="form">
                
                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                            <input type="number" placeholder="Phone Number" class="form-control" id ="pnum" name="contact" required>
                        </div>
                      </div>
                    <button type ="submit" class="btn btn-success" name="contact1"  value="contact1">Apply Change</button>
                  </form>
                  
                      <%
                        String s = request.getParameter("contact1");
                        
                       if(s!=null && s.equals("contact1"))
                       {
                           String phone;
                           phone=request.getParameter("contact").toString();
                           
                           if((phone!=null||phone !="")  && (phone!=null||phone!=""))
                           {   Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
                               String sql_query1 = "UPDATE users SET contact=? WHERE user_id=?;";
                               PreparedStatement ps = con.prepareStatement(sql_query1);
				
                                ps.setString(1,phone);                
                                ps.setInt(2,userid);
                                int count = ps.executeUpdate();
		
				if(count >0)
				{
                                    
                                    out.println("<script type=\"text/javascript\">");
                                    out.println("alert('Contact Has Been Updated');");
                                    out.println("</script>");   
					  
				}
                           }
                           
                           
                       }
                       %>
                      
                      
                      
                      
                      
                  <form method="post" id ="pass_form" style="padding-left: 100px; padding-top: 5px; display: none;" class ="form-horizontal" role="form">
                
                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                            <input type="Password" placeholder="Current Password" class="form-control" id ="oldpass" name="oldpass1" required>
                        </div>
                      </div>

                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                            <input type="Password" placeholder="New Password" class="form-control" id ="newpwd" name="newpwd" required>
                        </div>
                      </div>
                      
                      <div class="form-group">
                        <div class="col-sm-offset-0 col-md-12">
                            <input type="Password" placeholder="Confirm Password" class="form-control" id ="cpwd" name="cpwd" required>
                        </div>
                      </div>
                      

                    <button type ="submit" class="btn btn-success" name="password" value="pass">Apply Change</button>
                  </form>

                  <%
                        String m = request.getParameter("password");
                       if(m!=null && m.equals("pass"))
                       {
                           
                       
                           String cpass,oldpass,newpass;
                           oldpass=request.getParameter("oldpass1").toString();
                           newpass=request.getParameter("newpwd").toString();
                           cpass=request.getParameter("cpwd").toString();
                           String pass=getPass(username);
                           if(pass.equals(oldpass) )
                           {
                               if(newpass.equals(cpass) )
                               {
                                    Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
                                    String sql_query1 = "UPDATE users SET password=? WHERE user_id=?;";
                                    PreparedStatement ps = con.prepareStatement(sql_query1);

                                    ps.setString(1,newpass);
                                    ps.setInt(2,userid);                   

                                    int count = ps.executeUpdate();

                                    if(count >0)
                                    {

                                        out.println("<script type=\"text/javascript\">");
                                        out.println("alert('Password Has Been Updated');");
                                        out.println("</script>");   

                                    }
                                    
                               }
                               else
                                    {
                                        out.println("<script type=\"text/javascript\">");
                                        out.println("alert('Password do not Match');");
                                        out.println("</script>");  
                                    }
                           }
                           else
                           {
                               out.println("<script type=\"text/javascript\">");
                               out.println("alert('Incorect Current Pass');");
                               out.println("</script>");
                           
                           }
                           
                       } 
                       


                      %>




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
</html>