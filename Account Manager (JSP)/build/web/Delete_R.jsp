
<%@page import="java.sql.*, java.util.*"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@  page errorPage="errorpage.jsp" language="java"   %>  
<%   
           int recev_id = Integer.parseInt(request.getParameter("recv_id"));         
           System.out.println("gesssstIdData  " + recev_id);
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);			
           String sql_query = "UPDATE account_receivable SET status_id = ? where recev_id = ? " ;
           PreparedStatement ps = con.prepareStatement(sql_query);
           ps.setInt(1,2); 
           ps.setInt(2,recev_id);
            int count = ps.executeUpdate();
		
            if(count >0)
            {
                out.println("deletd");                    
                	  
       	}
 %> 