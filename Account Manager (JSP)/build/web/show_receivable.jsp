<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Account Receivables</title>

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
        <script src="js/paging.js"></script>
        
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



        public ResultSet getData(int userid, int type,String name) throws Exception
	{
           
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
                                  
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);			
           String sql_query = "select * from account_receivable where user_id = ? and status_id = ?" ;
           PreparedStatement ps = con.prepareStatement(sql_query);
           ps.setInt(1,userid); 
           ps.setInt(2,1);
           ResultSet rs = ps.executeQuery(); 


            ResultSet rs2=null;
           if(name != null)
            {   
            String sql_query2 = "select * from account_receivable where user_id = ? and status_id = ? and first_name =? " ;
            PreparedStatement ps2 = con.prepareStatement(sql_query2);
            ps2.setInt(1,userid); 
            ps2.setInt(2,1);
            ps2.setString(3, name );
            rs2 = ps2.executeQuery();
            }

            if(type==2)
            {
                return rs;
            }
            else
            {
                if(name !="" && !name.equals(null) )
                {   
                    return rs2;
                }
                else
                {
                   return rs;
                }
            }
        }

        public ResultSet getIdData(int recev_id) throws Exception
	{
           System.out.println("getIdData  " + recev_id);
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
                                  
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);			
           String sql_query = "select * from account_receivable where recev_id = ? and status_id = ?" ;
           PreparedStatement ps = con.prepareStatement(sql_query);
           ps.setInt(1,recev_id); 
           ps.setInt(2,1);
           ResultSet rs = ps.executeQuery(); 
           return rs;
        }

        public int getCookie(HttpServletRequest request)
        {
            int recev_id = -1;
            Cookie cookie = null;
            Cookie[] cookies = null;
            cookies = request.getCookies(); 
            if( cookies != null )
            {
              for (int i = 0; i < cookies.length; i++)
              {
                cookie = cookies[i];
                if((cookie.getName()).equals("id"))
                {
                    recev_id =Integer.parseInt(cookie.getValue());
                    System.out.println("cookvvddie " +  recev_id);
                    
                }
              }
                
          }
          return recev_id;
    }
      


      
      %>
      
       <% 
         Class.forName("com.mysql.jdbc.Driver");     
         String URL = "jdbc:mysql://localhost:3306/";
         String db ="ams";
         String u_name = "root";
         String u_pwd="";
      %>
      
<script type="text/javascript">
   
	
function getIdByAjax(id)
{
  
		var http = new XMLHttpRequest();
		var url = "getDataByID_R.jsp";
		var params = "recv_id=" + id;
		http.open("POST", url, true);

		//Send the proper header information along with the request
		http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

		http.send(params);		

		http.onreadystatechange=function()
                {
		   if(http.readyState === 4)
		   {    
                        var str = http.responseText;
			var fname,lname,email,contact,address;
                         var keys = str.split(";");
                         fname = (keys[0]).trim();
                         lname = keys[1];
                         email = keys[2];
                         contact = keys[3];
                         address = keys[4];
                         
                        /* document.getElementById("a").placeholder =fname;
                         document.getElementById("b").placeholder =lname;
                         document.getElementById("c").placeholder =email;
                         document.getElementById("d").placeholder =contact;
                         document.getElementById("e").placeholder =address;*/
                        document.getElementById("a").value =fname;
                         document.getElementById("b").value =lname;
                         document.getElementById("c").value =email;
                         document.getElementById("d").value =contact;
                         document.getElementById("e").value =address;
                         document.getElementById("f").value =id;
		   }
               };
		   
  
}

function deleteByAjax()
{
     var a =document.getElementById("gg").value;
    
    var http = new XMLHttpRequest();
    var url = "Delete_R.jsp";
    var params = "recv_id=" + a;
    http.open("POST", url, true);

    //Send the proper header information along with the request
    http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

    http.send(params);
    http.onreadystatechange=function()
    {
        if(http.readyState === 4)
        {    
             var str1 = http.responseText;
       
             var str2 = "deletd";
             var n = str1.localeCompare(str2);
             if(n===0)
             {
                 
                //alert('Record Has Been Deleted.');
                //location='show_receivable.jsp';
                //window.location.reload();
                //location.href = 'http://localhost:8080/Account_Manager/show_receivable.jsp';
             }
        }

    };
}
function deleteId(id)
{
     
   document.getElementById("gg").value =id;
  
        
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
        <a class = "navbar-brand" href="#">Account Receivables</a>
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
                    <form class="navbar-form" role="search" method="post">
		    <div class="input-group add-on">
		      <input class="form-control" placeholder="Name" name="srch-term" id="srch-term" type="text">
		      <div class="input-group-btn">
		        <!--<button class="btn btn-default" type="submit" ><i class="glyphicon glyphicon-search"></i></button>-->
		        <p data-placement="top" data-toggle="tooltip" > <button type="submit" name="sbar" value="search" class="btn btn-default" > <span class="glyphicon glyphicon-search"></span> </button></p>
		      </div>
		    </div>
		  </form>  
		</div>
	</div>


  <div class="container" >
    <div class="row"> 
      <div class="col-md-12">  
        <div class="table-responsive">
          <table id="mytable" class="table table-bordred table-striped table-hover" borader="1">
                   
            <thead>
                   
              <th><input type="checkbox" id="checkall" /></th>
              <th>Name</th>
              <th>Address</th>
              <th>Email</th>
              <th>Contact</th>
              <th>Receivables</th>
              <th>Edit</th>        
              <th>Delete</th>
            </thead>
            <tbody>             
    <% 
         session = request.getSession();
         String username = session.getAttribute("user").toString();     
       try
       {  
           int userid = getUserId(username);
           ResultSet rs =null ;
           String name =request.getParameter("srch-term");
                 
           
           String xy = request.getParameter("sbar");
           
            if(xy!=null && xy.equals("search") && name !=null)
             {
                
                 
                
                /* Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
                String sql_query = "select * from account_receivable where recev_id = ? and status_id = ? and first_name like ? " ;
                PreparedStatement ps = con.prepareStatement(sql_query);
                ps.setInt(1,userid); 
                ps.setInt(2,1);
                ps.setString(3,"'%"+ name + "%'");
                
                rs = ps.executeQuery();*/
                
                 rs = getData(userid,1,name);
             }
            else
            {
                System.out.println("normal");
            
                rs = getData(userid,2,null);
            }
            
            
           //rs = getData(userid);
           if (rs.isBeforeFirst() ) 
           { 
             while(rs.next())
             {%>
                  <tr>
                      
            
                <td><input type="checkbox" class="checkthis" /></td>
                <td><%=rs.getString("first_name")+" " +rs.getString("last_name")  %></td>
                <td><%=rs.getString("address") %></td>
                <td><%=rs.getString("email") %></td>
                <td><%=rs.getString("contact") %></td>
                <td><%=rs.getString("amount_recev") %></td>
                <td><p data-placement="top" data-toggle="tooltip"  ><button type="submit" onclick ="getIdByAjax(<%=rs.getInt("recev_id")%>);" id="esubmit"  class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit" ><span class="glyphicon glyphicon-pencil"></span></button></p></td>
                <td><p data-placement="top" data-toggle="tooltip" ><button type ="submit" onclick ="deleteId(<%=rs.getInt("recev_id")%>);" name="dsubmit"  class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete" ><span class="glyphicon glyphicon-trash"></span></button></p></td>
                
            </tr>   
             <%   }
            }
            else{%>

             <tr>
                <td><input type="checkbox" class="checkthis" /></td>
                <td><%="- - - -" %></td>
                <td><%="- - - -"%></td>
                <td><%="- - - -"%></td>
                <td><%="- - - -" %></td>
                <td><%="- - - -" %></td>
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
        
      
  <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="false">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="false"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
          <h4 class="modal-title custom_align" id="Heading">Edit Your Detail</h4>
        </div>
        <div class="modal-body">
            <form>
          <div class="form-group">
            <input class="form-control " type="text" placeholder="" name="mfname" id ="a" required>
          </div>
          <div class="form-group">
            <input class="form-control " type="text" placeholder="" name="mlname" id ="b" required>
          </div>
          <div class="form-group">
            <input class="form-control " type="Email" placeholder="" name="memail" id ="c" required>
          </div>
          <div class="form-group">
            <input class="form-control " type="number" placeholder="" name="mnumber" id ="d" required>
          </div>
          <div class="form-group">
            <textarea rows="2" class="form-control" placeholder="" name="maddress" id ="e" required></textarea>
          </div>
          <div class="form-group">
            <input class="form-control " type="hidden" name="mid" id ="f" >
          </div>
        </div>
          
            
            <div class="modal-footer ">
                <button  type="submit" name ="msubmit" value="mupdate" class="btn btn-warning btn-lg" style="width: 100%;"><span class="glyphicon glyphicon-ok-sign"></span>Update</button>
        </div>
       </form>  
      </div>
        
    <!-- /.modal-content --> 
    </div>
      <!-- /.modal-dialog --> 
  </div>
            
          
    
     <%
                       String x = request.getParameter("msubmit");
                       
                       if(x!=null && x.equals("mupdate"))
                       {
                           String fname,lname,email,number,address;
                           int mid;
                           fname=request.getParameter("mfname").toString();
                           lname=request.getParameter("mlname").toString();
                           email=request.getParameter("memail").toString();
                           number=request.getParameter("mnumber").toString();
                           address=request.getParameter("maddress").toString();
                           mid=Integer.parseInt(request.getParameter("mid").toString());
                           if((fname!=null||fname !="")  && (lname!=null||lname!=""))
                           {   Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
                               String sql_query1 = "UPDATE account_receivable SET first_name=?, last_name=?,contact=?,address =?,email =? WHERE recev_id=?;";
                               PreparedStatement ps = con.prepareStatement(sql_query1);
				
                                ps.setString(1,fname);
                                ps.setString(2,lname);                   
                                ps.setString(3,number);
                                ps.setString(4,address);
                                ps.setString(5,email);                   
                                ps.setInt(6,mid);
                                
                                int count = ps.executeUpdate();
		
				if(count >0)
				{
                                    
                                    out.println("<script type=\"text/javascript\">");
                                    out.println("alert('Record Has Been Updated.');");
                                    out.println("location='show_receivable.jsp';");
                                    out.println("</script>");	  
				}
                           }
                           
                           
                       }
            %>
    
            
    
         
   <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
          <h4 class="modal-title custom_align" id="Heading">Delete this entry</h4>
        </div>
        
        <div class="modal-body">
             <form>
            <input type="hidden" id ="gg" />
            </form>
          <div class="alert alert-danger"><span class="glyphicon glyphicon-warning-sign"></span> Are you sure you want to delete this Record?</div> 
        </div>

        <div class="modal-footer ">
          
            <form method="post">
          <button  type="submit" id="ee" name ="deleteRec" value="dupdate" onclick ="deleteByAjax();" class="btn btn-success" ><span class="glyphicon glyphicon-ok-sign"></span>Yes</button>  
            
          <button type="button" class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>No</button>
       </form>
        </div>
      </div>
    <!-- /.modal-content --> 
    </div>
      <!-- /.modal-dialog --> 
  </div>

            
                
           
            
            <%
                String y;
                        y = request.getParameter("deleteRec");
                       System.out.println(y);
                       if(y!=null && y.equals("dupdate"))
                       {
                           out.println("<script type=\"text/javascript\">");
                           out.println("location='show_receivable.jsp';");
                                    out.println("alert('Record Has Been Deleted.');");
                                    
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
