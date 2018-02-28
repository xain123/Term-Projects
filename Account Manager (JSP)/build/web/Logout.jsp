<html>
<head>
<%@  page errorPage="errorpage.jsp" language="java" %>
</head>
<body>
	
	
	
	<% 
            session.invalidate();
            System.out.println("session...... " +session);
            response.sendRedirect("index.jsp");
	%>
        
</body>
</html>
 