<%@ page isErrorPage="true" import = "java.io.PrintWriter" %>
<html>
<head>
<title>
	Account Manager Error page
</title>
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
	<h2>Error Page</h2>
	<br>
	<h4>An error has occurred in the application</h4>
	<br><p>
	The stack trace of the error is:
	<p>
        <%= exception.toString() %>    
  	<%= exception.getStackTrace()[0].getLineNumber() - 9 %>
        
	<%-- exception.printStackTrace(new PrintWriter(out)); --%>
</body>
</html>	 
