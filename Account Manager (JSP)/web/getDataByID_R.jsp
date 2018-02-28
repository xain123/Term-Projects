<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.sql.*, java.util.*"%>
<%@  page errorPage="errorpage.jsp" language="java"   %>   
<%   
           int recev_id = Integer.parseInt(request.getParameter("recv_id"));         
          
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
           rs.next();
           String s= rs.getString("first_name") +";" +rs.getString("last_name")+";"+rs.getString("email")+";" +rs.getString("contact")+";" +rs.getString("address");
           out.println(s);
 %>  