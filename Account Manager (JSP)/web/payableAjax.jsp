<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.sql.*, java.util.*,java.util.Date,java.text.SimpleDateFormat,java.text.DateFormat, java.lang.*, java.util.Date, java.util.*,java.sql.Timestamp"%>
<%@  page errorPage="errorpage.jsp" language="java"   %>   
<%   
           int pay_id = Integer.parseInt(request.getParameter("id"));         
          int amount = Integer.parseInt(request.getParameter("amount"));
           String date = request.getParameter("date");
           System.out.println("sss " + pay_id + " " +amount + " " + date );
           
           Date date2 =null;
            date2 =  new SimpleDateFormat("yyyy-MM-dd").parse(date);
           
           System.out.println(" date formatd " +date2);
           
           
           Class.forName("com.mysql.jdbc.Driver");     
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);			
           String sql_query = "select * from account_payable where pay_id = ? and status_id = ?" ;
           PreparedStatement ps = con.prepareStatement(sql_query);
           ps.setInt(1,pay_id); 
           ps.setInt(2,1);
           ResultSet rs = ps.executeQuery(); 
           rs.next();
           
           Date date3=new java.util.Date(rs.getDate("next_turn").getTime());
           int  amount3 =Integer.parseInt(rs.getString("amount_payable"));
           
           
           int amount4 = amount3-amount;
           String finaamount =  Integer.toString(amount4);
            Date finaDate =null;
            
            int diffInDays = (int) ((date2.getTime() - date3.getTime()) / (1000 * 60 * 60 * 24));
           
            
           if(diffInDays >0)
           {
               finaDate = date2;
           }
           else
           {
               finaDate = new Date();
           }
           String sql_query1 = "UPDATE account_payable SET amount_payable=?, next_turn=? WHERE pay_id=?;";
           PreparedStatement ps2 = con.prepareStatement(sql_query1);
				
           ps2.setString(1,finaamount);
           ps2.setDate(2, new java.sql.Date(finaDate.getTime()));
           ps2.setInt(3,pay_id);
           
           ps2.executeUpdate();
           out.println("s");    
 %>  