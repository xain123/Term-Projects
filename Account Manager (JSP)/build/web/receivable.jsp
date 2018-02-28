<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Manage Receivables</title>

        <link rel="stylesheet" href="css/bootstrap.min.css">
        <link href="css/custom.css" rel="stylesheet">
        <link href="css/paging.css" rel="stylesheet">
        <link rel="stylesheet" href="css/bootstrap-theme.min.css">
        <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css">

        <script src="js/vendor/jquery-1.11.2.min.js"></script>
        <script src="js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/main.js"></script>
        <script src="js/manage.js"></script>

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

            return userid;
        }



        public ResultSet getData(int userid) throws Exception
	{
           
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
                                  
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);			
           String sql_query = "select * from account_receivable where user_id = ?" ;
           PreparedStatement ps = con.prepareStatement(sql_query);
           ps.setInt(1,userid);
           ResultSet rs = ps.executeQuery();
           

           
           return rs;
      
        }
      
      %>
      
      <script type="text/javascript">
   
	
        function getId2(id)
        {
            
            
            sessionStorage.setItem("id",id);
            
        }
        
        
        function updateAjax(amount,date)
        {
            var id = sessionStorage.getItem("id");
            
           
            var http = new XMLHttpRequest();
            var url = "receivableAjax.jsp";
            var params = "id=" + id + "&amount=" +amount+ "&date="+ date  ;
            http.open("POST", url, true);

            //Send the proper header information along with the request
            http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

            http.send(params);
            http.onreadystatechange=function()
            {
                if(http.readyState === 4)
                {    
                     var str1 = http.responseText;

                     
                }

            };
           
            
            
        }
  
      </script>
    

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
        <a class = "navbar-brand" href="#">Manage Reciveables</a>
        <div class = "navbar-collapse collapse"> <!--This will add navigation collapse  -->
          <ul class = "nav navbar-nav navbar-right"> <!--unorderd list and aligned it to RHS -->
              <li ><a href="dashboard.jsp">Home</a></li><!--list item -->
              <li><a href="#">About</a></li>
              
              
              <li class = "dropdown active">
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




   <div class="container" style ="padding-top: 25px; padding-left: 250px">
		<div class="col-sm-offset-8 col-md-4">
		  <form class="navbar-form" role="search">
		    <div class="input-group add-on">
		      <input class="form-control" placeholder="Contact" name="srch-term" id="srch-term" type="text">
		      <div class="input-group-btn">
		        <!--<button class="btn btn-default" type="submit" ><i class="glyphicon glyphicon-search"></i></button>-->
		        <p data-placement="top" data-toggle="tooltip" > <button class="btn btn-default" type="submit" ><span class="glyphicon glyphicon-search"></span></button></p>
		      </div>
		    </div>
		  </form>  
		</div>
	</div> 


    

  <div class="container">
    <div class="row"> 
      <div class="col-md-12">  
        <div class="table-responsive">
          <table id="mytable" class="table table-bordred table-striped table-hover">
                   
            <thead>
                   
              <th><input type="checkbox" id="checkall" /></th>
              <th>Name</th>
              <th>Contact</th>
              <th>Receivables(RS)</th>
              <th>Next Turn</th>
              <th>Edit</th>        
              
            </thead>
              
            <tbody>
            <% 
                 session = request.getSession();
                 String username = session.getAttribute("user").toString();     
               try
               {  
                     int userid = getUserId(username);
                     ResultSet rs = getData(userid);
                   if (rs.isBeforeFirst() ) 
                   { 
                     while(rs.next())
                     {%>              
             

             

              <tr>
                <td><input type="checkbox" class="checkthis" /></td>
                <td><%=rs.getString("first_name")+" " +rs.getString("last_name")  %></td>
                <td><%=rs.getString("contact") %></td>
                <td><%=rs.getString("amount_recev") %></td>
                <td><%=rs.getString("next_turn") %></td>
                <td><p data-placement="top" data-toggle="tooltip" onclick ="getId2(<%=rs.getInt("recev_id")%>);" id ="recv2" ><button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit" ><span class="glyphicon glyphicon-pencil"></span></button></p></td>
                
              </tr> 
              
                    <%}
                  }
                  else{%>

                   <tr>
                      <td><input type="checkbox" class="checkthis" /></td>
                      <td><%="- - - -" %></td>
                      <td><%="- - - -"%></td>
                      <td><%="- - - -"%></td>
                      <td><%="- - - -" %></td>
                      <td><%="- - - -" %></td>
                      

                    </tr>  


                  <%}



              }
                 catch(Exception e)
              {
                  out.println(e);
              }      
            %>
              
              
            </tbody>
          </table>

          
        </div>     
      </div>
    </div>
  </div>
  
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script> 
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js"></script>
    <script type="text/javascript" src="paging.js"></script> 
    <script type="text/javascript">
                $(document).ready(function() {
                    $('#mytable').paging({limit:4});
                });
            </script>
            <script type="text/javascript">

     
    </script>
            
            
  <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
          <h4 class="modal-title custom_align" id="Heading">Enter Amount Received</h4>
        </div>
        <div class="modal-body">
            <form method="post">
             
                
                
          <div class="form-group">
            <input class="form-control " type="number" placeholder="Amount Received" name ="amount_recev" required>
          </div>
          <div class="form-group">
            <input class="form-control " type="date" placeholder="Next Turn" name="next_date" required>
          </div>
        </div>

        <div class="modal-footer ">
          <button type="submit" name ="update" value="xyz" class="btn btn-warning btn-lg"  style="width: 100%;"><span class="glyphicon glyphicon-ok-sign"></span>Update</button>
           </form>

        </div>
      </div>
    <!-- /.modal-content --> 
    </div>
      <!-- /.modal-dialog --> 
  </div>
    
  <%
      String x = request.getParameter("update");
                       
      if(x!=null && x.equals("xyz"))   
      {
          
      
      
      %>
            <jsp:useBean id="simple" class="Beans.recev" />
 
            <jsp:setProperty name="simple" property="*" />
    
           

        <%                   
            int amount2 = simple.getAmount_recev();
            String date2 = simple.getNext_date();
           
            
           
            %>
            
            <script>
                updateAjax(<%=amount2 %>,'<%=simple.getNext_date() %>');
            </script>
            
          <%  
              out.println("<script type=\"text/javascript\">");
              out.println("location='receivable.jsp';");
              out.println("alert('Record Has Been Updated.');");
              out.println("</script>");
}
        %>

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
