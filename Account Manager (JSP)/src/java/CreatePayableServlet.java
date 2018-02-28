/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import javax.servlet.*;
import javax.servlet.http.*;
import java.text.SimpleDateFormat;

/**
 *
 * @author Home
 */
public class CreatePayableServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String cnic,fname,lname,payable,email,phone,company,nextturn;
        fname=request.getParameter("fname1").toString();
        lname=request.getParameter("lname1").toString();
        phone=request.getParameter("pnum1").toString();
        email=request.getParameter("email1").toString();
        cnic=request.getParameter("cnic1").toString();
        company=request.getParameter("comp1").toString();
        payable=request.getParameter("pay1").toString();
        nextturn =request.getParameter("nextturn1").toString();
        
        java.util.Date date=null;
        try{
            date =  new SimpleDateFormat("yyyy-MM-dd").parse(nextturn);
     
        }
        catch(Exception e)
        {
            out.println(e);
        }
        
        
        
        
        ServletConfig sc = getServletConfig(); //Method of Servlet
        String URL = sc.getInitParameter("URL");
        ServletContext scon = sc.getServletContext(); // by ServletConfig object
        String db = scon.getInitParameter("db");
        
         try
         {
           
             HttpSession session = request.getSession();
             String username = session.getAttribute("user").toString();
             int userid = getUserId(username,URL,db);
             
          if(setReceivable(fname,lname ,phone ,cnic ,company ,email,payable,userid,date ))
          {
               out.println("<script type=\"text/javascript\">");
               out.println("alert('Account Created');");
               out.println("location='create_payable.jsp';");
               out.println("</script>");
          }        
        }
        catch(Exception e)
        {
            out.println(e);
        }
    }
    
     public int getUserId(String user,String URL, String db)throws Exception
    {
        Class.forName("com.mysql.jdbc.Driver");       
        
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
    
    
    public boolean setReceivable(String fname,String lname,String phone,String cnic,String company,String email,String payable,int userid,java.util.Date date) throws Exception
	{
           Class.forName("com.mysql.jdbc.Driver");       
           String URL = "jdbc:mysql://localhost:3306/";
           String db ="ams";
           String u_name = "root";
           String u_pwd="";		
           Connection con = DriverManager.getConnection(URL+db,u_name,u_pwd);
           
				String sql_query = "insert into account_payable (first_name,last_name,phone,cnic,company,email,amount_payable,status_id,user_id,next_turn) values (?,?,?,?,?,?,?,?,?,?);";
                                PreparedStatement ps = con.prepareStatement(sql_query);
				
                                ps.setString(1,fname);
                                ps.setString(2,lname);                   
                                ps.setString(3,phone);
                                ps.setString(4,cnic);
                                ps.setString(5,company);
                                ps.setString(6,email);
                                ps.setString(7,payable);
                                ps.setInt(8,1);
                                ps.setInt(9,userid);
                                ps.setDate(10, new java.sql.Date(date.getTime()));
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
