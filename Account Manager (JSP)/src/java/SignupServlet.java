/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.*;
import java.sql.*;
import javax.servlet.*;
import javax.servlet.http.*;


/**
 *
 * @author Home
 */
public class SignupServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)throws ServletException, IOException 
    {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String user,fname,lname,password,email,phone;
        fname=request.getParameter("fname1").toString();
        lname=request.getParameter("lname1").toString();
        user=request.getParameter("user1").toString();
        phone=request.getParameter("phone1").toString();
        email=request.getParameter("email1").toString();
        password=request.getParameter("pwd1").toString();
        
        
        ServletConfig sc = getServletConfig(); //Method of Servlet
        String URL = sc.getInitParameter("URL");
        ServletContext scon = sc.getServletContext(); // by ServletConfig object
        String db = scon.getInitParameter("db");
        
         try{
           
          
          int c =checkusername(user);
          
          if(c == 0)
          {
             if(setUser(fname,lname ,user ,phone ,email ,password,URL,db ))
             {
               out.println("<script type=\"text/javascript\">");
               out.println("alert('Your Account Has Created');");
               out.println("location='index.jsp';");
               out.println("</script>");
             }
             else
             {
                 response.sendRedirect("index.jsp");
             }
          }
          else
          {
               out.println("<script type=\"text/javascript\">");
               out.println("alert('The Username Is not available.');");
               out.println("location='index.jsp';");
               out.println("</script>");
          }
          
          
          
        }
        catch(Exception e)
        {
            out.println(e);
        }
    }
    public int checkusername(String user)throws Exception
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
        int count = 0;

        while (rs.next()) 
        {
             ++count;
        }
         return count;
    }
    
    
    
    public boolean setUser(String fname,String lname,String user,String phone,String email,String password,String URL,String db) throws Exception
	{
           Class.forName("com.mysql.jdbc.Driver");       
           
           String u_name = "root";
           String u_pwd="";		
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
           
				String sql_query = "insert into users (first_name,last_name,user_name,contact,email,password) values (?,?,?,?,?,?);";
                                PreparedStatement ps = con.prepareStatement(sql_query);
				
                                ps.setString(1,fname);
                                ps.setString(2,lname);                   
                                ps.setString(3,user);
                                ps.setString(4,phone);
                                ps.setString(5,email);
                                ps.setString(6,password);
                                int count = ps.executeUpdate();
		
				if(count >0)
				{
                                        con.close();
					  return true;
				}
				else
				{   
                                        con.close();
					return false;
				}
		
					
           
         
	          
        }
    

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
