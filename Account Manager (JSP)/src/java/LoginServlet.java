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
 * @author Zain Asghar
 */
public class LoginServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    
    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        
        PrintWriter out = response.getWriter();
        String username,password;
        username=request.getParameter("username").toString();
        password=request.getParameter("password").toString();
        
        ServletConfig sc = getServletConfig(); //Method of Servlet
        String URL = sc.getInitParameter("URL");
  
        ServletContext scon = sc.getServletContext(); // by ServletConfig object
        String db = scon.getInitParameter("db");
        
        
        
         try{
           
           String pass=getPass(username,URL,db);
           if(pass.equals(password) )
           {
                
                    HttpSession session = request.getSession();
                    session.setAttribute("user", username);
                    response.sendRedirect("dashboard.jsp");
                    
                    
           }
           else
           {
               out.println("<script type=\"text/javascript\">");
               out.println("alert('User or password incorrect');");
               out.println("location='index.jsp';");
               out.println("</script>");
      
           }
        }
        catch(Exception e)
        {
            out.println(e);
        }
    }
    public String getPass(String user,String URL,String db) throws Exception
	{
           Class.forName("com.mysql.jdbc.Driver");       
           
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
               System.out.println(username + " " + password);
               con.close();
               return password;  
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
