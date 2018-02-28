package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class index_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final JspFactory _jspxFactory = JspFactory.getDefaultFactory();

  private static java.util.List<String> _jspx_dependants;

  private org.glassfish.jsp.api.ResourceInjector _jspx_resourceInjector;

  public java.util.List<String> getDependants() {
    return _jspx_dependants;
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;

    try {
      response.setContentType("text/html");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;
      _jspx_resourceInjector = (org.glassfish.jsp.api.ResourceInjector) application.getAttribute("com.sun.appserv.jsp.resource.injector");

      out.write("<!doctype html>\n");
      out.write("<html class=\"no-js\" lang=\"en\"> \n");
      out.write("    <head>\n");
      out.write("        <meta charset=\"utf-8\">\n");
      out.write("        <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\">\n");
      out.write("        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n");
      out.write("        \n");
      out.write("        <title>Accounts Manager</title>\n");
      out.write("        \n");
      out.write("        <link rel=\"stylesheet\" href=\"css/bootstrap.min.css\">\n");
      out.write("        <link href=\"css/custom.css\" rel=\"stylesheet\">\n");
      out.write("        <link rel=\"stylesheet\" href=\"css/bootstrap-theme.min.css\">\n");
      out.write("        <link rel=\"stylesheet\" href=\"font-awesome/css/font-awesome.min.css\">\n");
      out.write("\n");
      out.write("\n");
      out.write("        <script src=\"js/vendor/jquery-1.11.2.min.js\"></script>\n");
      out.write("        <script src=\"js/vendor/modernizr-2.8.3-respond-1.4.2.min.js\"></script>\n");
      out.write("        <script src=\"js/vendor/bootstrap.min.js\"></script>\n");
      out.write("        <script src=\"js/main.js\"></script>\n");
      out.write("        <script src=\"js/login.js\"></script> \n");
      out.write("    </head>\n");
      out.write("    <body>\n");
      out.write("       \n");
      out.write("    <nav class=\"navbar navbar-inverse navbar-fixed-top\" role=\"navigation\">\n");
      out.write("      <div class=\"container\">\n");
      out.write("        <div class=\"navbar-header\">\n");
      out.write("          <button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar\" aria-expanded=\"false\" aria-controls=\"navbar\">\n");
      out.write("            <span class=\"sr-only\">Toggle navigation</span>\n");
      out.write("            <span class=\"icon-bar\"></span>\n");
      out.write("            <span class=\"icon-bar\"></span>\n");
      out.write("            <span class=\"icon-bar\"></span>\n");
      out.write("          </button>\n");
      out.write("          <a class=\"navbar-brand\" href=\"#\">Accounts Manager</a>\n");
      out.write("        </div>\n");
      out.write("        <div id=\"navbar\" class=\"navbar-collapse collapse\">\n");
      out.write("\n");
      out.write("          <form acion=\"LoginServlet\" id=\"form_id\" method=\"post\" name=\"myform\" class=\"navbar-form navbar-right\" role=\"form\">\n");
      out.write("            <div class=\"form-group\">\n");
      out.write("              <input type=\"text\" placeholder=\"Username\" class=\"form-control\" name=\"username\" id=\"username\">\n");
      out.write("            </div>\n");
      out.write("            <div class=\"form-group\">\n");
      out.write("              <input type=\"password\" placeholder=\"Password\" class=\"form-control\"name=\"password\" id =\"password\">\n");
      out.write("            </div>\n");
      out.write("            <button type=\"submit\" class=\"btn btn-success\" id=\"login\" onclick=\"signin_validate();\">Sign in</button>\n");
      out.write("          </form>\n");
      out.write("\n");
      out.write("        </div>\n");
      out.write("      </div>\n");
      out.write("    </nav>\n");
      out.write("\n");
      out.write("    \n");
      out.write("\n");
      out.write("\n");
      out.write("    <!-- Main jumbotron for a primary marketing message or call to action -->\n");
      out.write("   \n");
      out.write("    <div class=\"jumbotron \">  \n");
      out.write("        <div class=\"container\">\n");
      out.write("          <div class =\"row\">\n");
      out.write("            <div class =\"col-md-8\">\n");
      out.write("              <h3>Hello This is accounts manager</h3>\n");
      out.write("\n");
      out.write("            </div>\n");
      out.write("           \n");
      out.write("            <div class=\"container col-md-4\">\n");
      out.write("              <h2>Sign Up</h2>\n");
      out.write("              <h3>Itâs free and always will be.</h3><br>\n");
      out.write("              \n");
      out.write("\n");
      out.write("\n");
      out.write("              \n");
      out.write("\n");
      out.write("              <form class =\"form-horizontal\" role=\"form\">\n");
      out.write("\n");
      out.write("                <div class=\"form-group\">\n");
      out.write("                  \n");
      out.write("                    <div class =\"col-sm-offset-0 col-md-6\">\n");
      out.write("                      <input type=\"text\" placeholder=\"First Name\" class=\"form-control\" id=\"fname\"> \n");
      out.write("                    </div>\n");
      out.write("                     <div class =\"col-sm-offset-0 col-md-6\">\n");
      out.write("                      <input type=\"text\" placeholder=\"Last Name\" class=\"form-control\" id=\"lname\"> \n");
      out.write("                    </div>\n");
      out.write("                  \n");
      out.write("                </div>\n");
      out.write("\n");
      out.write("                <div class=\"form-group\">\n");
      out.write("                    <div class=\"col-md-12\">\n");
      out.write("                      <input type=\"text\" placeholder=\"User Name\" class=\"form-control\" id =\"user\">\n");
      out.write("\n");
      out.write("                    </div>\n");
      out.write("                  </div>\n");
      out.write("\n");
      out.write("                <div class = \"form-group\">\n");
      out.write("                  <div  class =\"col-sm-12\">\n");
      out.write("                    <input type=\"number\" placeholder=\"Phone Number\" class=\"form-control\" id=\"phone\">\n");
      out.write("                  </div>\n");
      out.write("                </div>\n");
      out.write("\n");
      out.write("                <div class = \"form-group\">\n");
      out.write("                  <div  class =\"col-sm-12\">\n");
      out.write("                    <input type=\"email\" placeholder=\"Email\" class=\"form-control\" id=\"email\">\n");
      out.write("                  </div>\n");
      out.write("                </div>\n");
      out.write("\n");
      out.write("                  <div class = \"form-group\">\n");
      out.write("                    <div  class =\"col-sm-12\">\n");
      out.write("                      <input type=\"password\" placeholder=\"Password\" class=\"form-control\" id=\"pwd\">\n");
      out.write("                    </div>\n");
      out.write("                  </div>\n");
      out.write("\n");
      out.write("                  <div class =\"form-group\">\n");
      out.write("                    <div class=\"col-md-12\">\n");
      out.write("                      <input type=\"password\" placeholder=\"Confirm Password\" class=\"form-control\" id=\"cpwd\">\n");
      out.write("                    </div>\n");
      out.write("\n");
      out.write("                  </div>\n");
      out.write("                  \n");
      out.write("                \n");
      out.write("                  <div class=\"checkbox\">\n");
      out.write("                    <label > <input type=\"checkbox\"/>Accept <a href=\"#\">Terms</a></label>\n");
      out.write("                  </div>\n");
      out.write("                  <h5>By clicking Sign Up, you agree to our <a href=\"#\">Terms</a> </h5>\n");
      out.write("                  <button type =\"submit\" class=\"btn btn-success\" id=\"signup\" onclick=\"signup_validate();\">Sign Up</button>\n");
      out.write("              </form>\n");
      out.write("            </div>\n");
      out.write("            </div>\n");
      out.write("          </div>\n");
      out.write("        </div>\n");
      out.write("    </div>\n");
      out.write("    \n");
      out.write("\n");
      out.write("   \n");
      out.write("\n");
      out.write("    <!--Fixed footer -->\n");
      out.write("\n");
      out.write("    <div style=\" padding-top: 70px\" >\n");
      out.write("        <div class =\"navbar navbar-inverse  navbar-fixed-bottom \" style=\"height:20px;width:100%\" >\n");
      out.write("          <div class = \"container\">\n");
      out.write("            <div class = \"navbar-text pull-left\">\n");
      out.write("              <p class=\"float-xs-right\"></p>\n");
      out.write("              <p>Account Manager &copy; 2016 &middot; <a href=\"#\">Privacy</a> &middot; <a href=\"#\">Terms</a> </p>\n");
      out.write("            </div> \n");
      out.write("             <div class = \"navbar-text pull-right\">\n");
      out.write("              <a href=\"#\"><i class=\"fa fa-facebook fa-lg\" aria-hidden=\"true\"></i>    </a>\n");
      out.write("              <a href=\"#\"><i class=\"fa fa-twitter fa-lg\" aria-hidden=\"true\"></i></i></a>\n");
      out.write("              <a href=\"#\"><i class=\"fa fa-camera-retro fa-lg\"aria-hidden=\"true\"></i>   </a>\n");
      out.write("              <a href=\"#\">Back to top</a>\n");
      out.write("            </div>  \n");
      out.write("          </div>\n");
      out.write("        </div>\n");
      out.write("    </div>\n");
      out.write("      <script src=\"js/login.js\"></script> \n");
      out.write("    </body>\n");
      out.write("</html>");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          out.clearBuffer();
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
        else throw new ServletException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
