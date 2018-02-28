using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Text;


namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private ElectronicStoreEntities db = new ElectronicStoreEntities();

        // GET: Admin
    
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }

            var orders = db.Orders.Where(e => e.S_id == 2);
            var orders2 = db.Orders;

            var CurrentMonthsale1 = 0;
            var CurrentMonthOrders1 = 0;
            foreach (var x in orders)
            {
                if (DateTime.Parse(x.Date).Year == DateTime.Now.Year && DateTime.Parse(x.Date).Month == DateTime.Now.Month)
                {
                    CurrentMonthsale1 = CurrentMonthsale1 + Convert.ToInt32(x.Grand_total);
                }

            }
            foreach (var x in orders2)
            {
                if (DateTime.Parse(x.Date).Year == DateTime.Now.Year && DateTime.Parse(x.Date).Month == DateTime.Now.Month)
                {
                    CurrentMonthOrders1++;
                }

            }
            var CurrentMonthProfit1 = CurrentMonthsale1 * 0.3;
            var returned = db.Orders.Where(e => e.S_id == 5).Count();
            var CurrentMohthloss1 = returned * 400;

            ViewBag.CurrentMonthsale = CurrentMonthsale1;
            ViewBag.CurrentMonthOrders = CurrentMonthOrders1;
            ViewBag.CurrentMonthProfit = CurrentMonthProfit1;
            ViewBag.CurrentMohthloss = CurrentMohthloss1;
            
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(int a =0)
        {
            try
            {
                string email = Request["emailP"];
                //User usr = db.Users.Where(e => e.Email == email).FirstOrDefault();
                Employe emp = db.Employes.Where(e => e.Email == email).FirstOrDefault();
                /* if(usr != null)
                 {
                     Guid guid = Guid.NewGuid();
                     Reset_Password_request res = new Reset_Password_request();

                     res.U_id = usr.U_id;
                     res.Requested_Date = DateTime.Now;
                     res.Id = guid.ToString();

                     db.Reset_Password_request.Add(res);
                     db.SaveChanges();
                     SendEmail(email, guid.ToString(), usr.Nmae);

                 }*/
                if (emp != null)
                {
                    Guid guid = Guid.NewGuid();
                    Reset_Password_request res = new Reset_Password_request();

                    res.U_id = emp.A_id;
                    res.Requested_Date = DateTime.Now;
                    res.Id = guid.ToString();

                    db.Reset_Password_request.Add(res);
                    db.SaveChanges();

                    SendEmail(email, guid.ToString(), emp.Name);
                    TempData["validation_forget"] = "An Email Has been Sent!";

                }
                else
                {

                    TempData["validation_forget"] = "Password Resetting Failed!";
                }

            }
            catch(Exception e)
            {
                TempData["validation_forget"] = "SomeThing Went Wrong!";
            }
            return View();
        }


        public static void SendEmail(string Emailto, string guid, string username)
        {
            MailMessage mailMessage = new MailMessage("bcsf14a040@pucit.edu.pk", Emailto);
            mailMessage.Subject = "Reset Your Password";
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + username + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>");


            var request = System.Web.HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;
            if (appUrl != "/")
                appUrl = "/" + appUrl;
            var baseUrl = string.Format("{0}://{1}{2}/Admin/ChangePassword", request.Url.Scheme, request.Url.Authority, appUrl);

            sbEmailBody.Append(baseUrl+"?uid=" + guid);
            sbEmailBody.Append("<br/><br/>");

            // sbEmailBody.Append("<a target=/"_blank" href="https://www.linkedin.com/in/zain-asghar-3b2683142/">PAKtech Solutions</a>");

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = sbEmailBody.ToString();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "bcsf14a040@pucit.edu.pk",
                Password = "03126951331"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public ActionResult ChangePassword(string uid =null)
        {
            if(uid ==null)
            {
                return Redirect("/Admin/Login");
            }
            Reset_Password_request res = db.Reset_Password_request.Find(uid);
            if(res != null)
            {
                Session["reset"] = res;
                var email = db.Employes.Find(res.U_id);
                ViewBag.email = email.Email;
                return View();
            }

            return Redirect("/Admin/Login");
        }





        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            
            User u = db.Users.Where(e => e.Email.Equals(email)).FirstOrDefault();
            Employe emp = db.Employes.Where(e => e.Email == email).FirstOrDefault();
            if (u != null)
            {
                if (password.Equals(u.Password))
                {
                    if (u.Is_admin == 1)
                    {
                        Session["Admin"] = u;


                        return Redirect("~/Admin/Index");
                    }
                    else
                    {
                        ViewBag.loginValidate = "You are not Admin";
                        ViewBag.email = email;
                        return View();
                    }

                }
                else
                {
                    ViewBag.loginValidate = "Incorrect Password";
                    ViewBag.email = email;
                    return View();
                }

            }
           else if(emp !=null)
            {
                if (password.Equals(emp.Password))
                {

                    User uu = new User();
                    uu.Email = emp.Email;
                    uu.Nmae = emp.Name;

                    uu.Is_admin = 0;
                    Session["Admin"] = uu;
                    return Redirect("~/Admin/Index");

                }
                else
                {
                    ViewBag.loginValidate = "Incorrect Password";
                    ViewBag.email = email;
                    return View();
                }
            }


            ViewBag.loginValidate = "You Are not an Authorized User";
            ViewBag.email = email;

            return View();
        }

        public ActionResult Inbox()
        {

            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.mail = db.Mails.ToList();
            
            return View();
        }
        
        public ActionResult Product()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }


            var viewModel =
                     from a in db.Products
                     join b in db.Images on a.P_id equals b.P_id
                     where b.Is_Main == 1

                     select new ProductView { Product = a, Image = b };

            return View(viewModel);
        }

        public ActionResult All_Orders(int id =0)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            var viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     select new OrderView { Order = a, Address = b };
            if (id == 0)
            {
                return Redirect("/Admin/Index");
            }
            switch(id)
            {
                case 1:
                    ViewBag.heading = "All Orders";
                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     select new OrderView { Order = a, Address = b };


                    ViewBag.page = 1;
                    break;
                case 2:
                    ViewBag.heading = "Pending Orders";

                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     where a.S_id == 1
                     select new OrderView { Order = a, Address = b };

                    break;
                case 3:
                    ViewBag.heading = "Confirmed Orders";
                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     where a.S_id == 3
                     select new OrderView { Order = a, Address = b };
                    break;
                case 4:
                    ViewBag.heading = "Delivered Orders";
                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     where a.S_id == 2
                     select new OrderView { Order = a, Address = b };
                    break;
                case 5:
                    ViewBag.heading = "Canceled Orders";
                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     where a.S_id == 4
                     select new OrderView { Order = a, Address = b };
                    break;
                case 6:
                    ViewBag.heading = "Returned Orders";
                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     where a.S_id == 5
                     select new OrderView { Order = a, Address = b };
                    break;
                default:
                    ViewBag.heading = "All Orders";
                    viewModel =
                     from a in db.Orders
                     join b in db.Addresses on a.A_id equals b.A_id
                     select new OrderView { Order = a, Address = b };
                    break;

            }


            return View(viewModel);

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add_Product(Product p)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }

            ViewBag.category_list = (db.Categories.Where(e => e.Parent != 0)).ToList();
            ViewBag.brand_list = db.Brands.ToList();

            Product check = db.Products.FirstOrDefault(e => e.P_id.Equals(p.P_id));

            if (check == null)
            {
                try
                {
                    string cat = Request["C_name"];
                    string bar = Request["B_name"];
                    Category c = db.Categories.FirstOrDefault(e => e.Name.Equals(cat));
                    Brand b = db.Brands.FirstOrDefault(e => e.Name.Equals(bar));
                    p.C_id = c.C_id;
                    p.B_id = b.B_id;
                    p.T_id = Convert.ToInt16(Request["Tag"]);
                    db.Products.Add(p);

                    //###############   Image Uploading ##################################################################
                    
                    if (Request.Files["Main_Image"] != null)
                    {
                        HttpPostedFileBase file = Request.Files["Main_Image"];

                        string pid = p.P_id;
                        string mainImage = "main.jpg";
                        mainImage = pid + mainImage;
                        file.SaveAs(Server.MapPath("~/UploadedFiles/" + mainImage));
                        Image i = new Image();
                        i.I_id = 1;
                        i.P_id = p.P_id;
                        i.Is_Main = 1;
                        i.Image_name = mainImage;
                        db.Images.Add(i);
                    }
                    else
                    {
                        TempData["v_addProduct"] = "Add Main Image!";
                       
                        return View();
                    }
                    if (Request.Files.Count < 4)
                    {
                        TempData["v_addProduct"] = "Please Select 3 Sub Images!";
                        return View();
                    }
                    for (int ii = 1; ii < Request.Files.Count; ii++)
                    {

                        HttpPostedFileBase file2 = Request.Files[ii];
                        string subImage = String.Concat(p.P_id, ii);
                        subImage += ".jpg";
                        file2.SaveAs(Server.MapPath("~/UploadedFiles/" + subImage));
                        Image i2 = new Image();
                        i2.I_id = 1;
                        i2.P_id = p.P_id;
                        i2.Image_name = subImage;
                        i2.Is_Main = 0;
                        db.Images.Add(i2);
                    }
                    //#######################################################################################################

                    db.SaveChanges();
                    TempData["Id"] = p.P_id;
                    TempData["v_addProduct"] = "Product is Added!";
                    return View();
                }
                catch(Exception e)
                {
                    TempData["v_addProduct"] = "Something Went Wrong!";
                    return View();
                }
            }
            else
            {
                TempData["v_addProduct"] = "Product Already Exist!";
                return View();
            }
        }

        public ActionResult Save(string P_id)
        {
            try
            {
                //###############   Image Uploading ##################################################################
                if (P_id == null)
                {
                    TempData["v_addImage"] = "Add Product First!";
                    return Redirect("/Admin/Add_Product");
                }
                if (Request.Files["Imagew"] != null)
                {
                    HttpPostedFileBase file = Request.Files["Imagew"];

                    string pid = P_id;
                    string mainImage = "main.jpg";
                    mainImage = pid + mainImage;
                    file.SaveAs(Server.MapPath("~/UploadedFiles/" + mainImage));
                    Image i = new Image();
                    i.I_id = 1;
                    i.P_id = P_id;
                    i.Is_Main = 1;
                    i.Image_name = mainImage;
                    db.Images.Add(i);
                }
                else
                {
                    TempData["v_addImage"] = "Add Main Image!";
                    return Redirect("/Admin/Add_Product");
                }
                if(Request.Files.Count < 4)
                {
                    TempData["v_addImage"] = "Please Select 3 Sub Images!";
                    return Redirect("/Admin/Add_Product");
                }
                for (int ii = 1; ii < Request.Files.Count; ii++)
                {
                    
                    HttpPostedFileBase file2 = Request.Files[ii];
                    string subImage = String.Concat(P_id, ii);
                    subImage += ".jpg";
                    file2.SaveAs(Server.MapPath("~/UploadedFiles/" + subImage));
                    Image i2 = new Image();
                    i2.I_id = 1;
                    i2.P_id = P_id;
                    i2.Image_name = subImage;
                    i2.Is_Main = 0;
                    db.Images.Add(i2);
                }
                TempData["v_addImage"] = "Images Are Added!";
                db.SaveChanges();
                //#######################################################################################################
            }
            catch (Exception e)
            {
                TempData["v_addImage"] = "Something Went Wrong!";

            }
            return Redirect("/Admin/Add_Product");
        }
       
        public ActionResult Add_Product()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.category_list = (db.Categories.Where(e => e.Parent != 0)).ToList();
            ViewBag.brand_list = db.Brands.ToList();

            return View();
        }

        public ActionResult Update_Product()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            Product p = new Product();
            ViewBag.catagory ="";
            ViewBag.brand = "";
            ViewBag.tag = 0;
            ViewBag.proData = p;
            ViewBag.category_list = null;
            ViewBag.brand_list = null;
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update_Product(Product pp)
        {
            Session["mail"] = db.Mails.Where(e => e.New == 1).ToList();
            string button = Request["button"];
            if (button.Equals("search"))
            {
                try
                {
                    string pid = Request["P_id"];

                    Product p = db.Products.Find(pid);
                    if (p == null)
                    {
                        TempData["v_searchProduct"] = "No Record Found";
                    }
                    else
                    {
                        Category c =db.Categories.FirstOrDefault(e => e.C_id == p.C_id);
                        Brand b = db.Brands.FirstOrDefault(e => e.B_id == p.B_id);
                        Tag t = db.Tags.FirstOrDefault(e => e.T_id == p.T_id);
                        ViewBag.catagory = c.Name;
                        ViewBag.brand = b.Name;
                        ViewBag.tag = t.T_id;

                        ViewBag.category_list = (db.Categories.Where(e => e.Parent != 0)).ToList();
                        ViewBag.brand_list = db.Brands.ToList();
                        ViewBag.proData = p;
                    }
                }
                catch (Exception e)
                {
                    TempData["v_searchProduct"] = "Something Went Wrong!";
                    return View();

                }
            }
            else if (button.Equals("update"))
            {
                try
                {
                    Product ppp = new Product();
                    ViewBag.catagory = "";
                    ViewBag.brand = "";
                    ViewBag.tag = 0;
                    ViewBag.proData = ppp;
                    ViewBag.category_list = null;
                    ViewBag.brand_list = null;


                    string cat = Request["C_name"];
                    string bar = Request["B_name"];
                    Category c = db.Categories.FirstOrDefault(e => e.Name.Equals(cat));
                    Brand b = db.Brands.FirstOrDefault(e => e.Name.Equals(bar));

                    Product update = db.Products.Find(pp.P_id);
                    update.Description = pp.Description;
                    update.Product_info = pp.Product_info;
                    update.Name = pp.Name;
                    update.Stock = pp.Stock;
                    update.Price = pp.Price;
                    update.Old_price = pp.Old_price;
                    update.C_id = c.C_id;
                    update.B_id = b.B_id;
                    update.T_id = Convert.ToInt16(Request["Tag"]);



                    //###############   Image Uploading ##################################################################

                    if (Request.Files.Count == 4 && (Request.Files["Main_Image"] != null))
                    {
                        var image = db.Images.Where(e => e.P_id == pp.P_id).ToList();
                        foreach (var x in image)
                        {
                            if (System.IO.File.Exists(Server.MapPath("~/UploadedFiles/" + x.Image_name)))
                            {
                                System.IO.File.Delete(Server.MapPath("~/UploadedFiles/" + x.Image_name));
                            }
                            db.Images.Remove(x);
                        }

                        if (Request.Files["Main_Image"] != null)
                        {
                            

                            HttpPostedFileBase file = Request.Files["Main_Image"];

                            string pid = pp.P_id;
                            string mainImage = "main.jpg";
                            mainImage = pid + mainImage;
                            file.SaveAs(Server.MapPath("~/UploadedFiles/" + mainImage));
                            Image i = new Image();
                            i.I_id = 1;
                            i.P_id = pp.P_id;
                            i.Is_Main = 1;
                            i.Image_name = mainImage;
                            db.Images.Add(i);
                        }
                        else
                        {
                            TempData["v_addProduct"] = "Add Main Image!";

                            return View();
                        }
                        if (Request.Files.Count < 4)
                        {
                            TempData["v_addProduct"] = "Please Select 3 Sub Images!";
                            return View();
                        }
                        for (int ii = 1; ii < Request.Files.Count; ii++)
                        {

                            HttpPostedFileBase file2 = Request.Files[ii];
                            string subImage = String.Concat(pp.P_id, ii);
                            subImage += ".jpg";
                            file2.SaveAs(Server.MapPath("~/UploadedFiles/" + subImage));
                            Image i2 = new Image();
                            i2.I_id = 1;
                            i2.P_id = pp.P_id;
                            i2.Image_name = subImage;
                            i2.Is_Main = 0;
                            db.Images.Add(i2);
                        }
                    }
                    //#######################################################################################################




                    db.SaveChanges();
                    TempData["v_updateProduct"] = "Product Is Updated!";

                }
                catch (Exception e)
                {
                    TempData["v_updateProduct"] = "Something Went Wrong!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Add_Category()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.main_category_list =  (db.Categories.Where(e => e.Parent == 0)).ToList();
            return View();
        }

        [ActionName("Add_Category")]
        [HttpPost]
        public ActionResult Add_Main_Category(string button)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            if (button.Equals("main_category"))
            {
                Category c = new Category();
                c.C_id = 1;
                c.Parent = 0;
                c.Name = Request["Name"];
                c.T_id = Convert.ToInt16(Request["T_id"]);

                Category check = db.Categories.FirstOrDefault(e => e.Name.Equals(c.Name));
                c.Name = c.Name.ToTitleCase(TitleCase.All);
                if (check == null)
                {
                    try
                    {
                        db.Categories.Add(c);
                        db.SaveChanges();
                        TempData["v_mainCategory"] = "Category Added!";
                        return Redirect("~/Admin/Add_Category");
                    }
                    catch (Exception e)
                    {
                        TempData["v_mainCategory"] = "Something Went Wrong!";
                        return Redirect("~/Admin/Add_Category");
                    }
                }
                else
                {
                    TempData["v_mainCategory"] = "Category Already Exist!";
                    return Redirect("~/Admin/Add_Category");

                }
            }
            else if (button.Equals("sub_category"))
            {

                string sub = Request["Name"];
                Category check = db.Categories.FirstOrDefault(e => e.Name.Equals(sub));

                if (check == null)
                {
                    Category subCat = new Category();
                    string mainCat = Request["M_name"];
                    Category main = db.Categories.FirstOrDefault(e => e.Name.Equals(mainCat));

                    subCat.Name = sub.ToTitleCase(TitleCase.All);
                    subCat.C_id = 1;
                    subCat.Parent = main.C_id;
                    subCat.T_id = Convert.ToInt16(Request["T_id"]);
                    try
                    {
                        db.Categories.Add(subCat);
                        db.SaveChanges();
                        TempData["v_subCategory"] = "Category Added!";
                        return Redirect("~/Admin/Add_Category");
                    }
                    catch
                    {
                        TempData["v_subCategory"] = "Something Went Wrong!";
                        return Redirect("~/Admin/Add_Category");
                    }
                }
                else
                {
                    TempData["v_subCategory"] = "Category Already Exist!";
                    return Redirect("~/Admin/Add_Category");
                }
            }
            else if (button.Equals("brand"))
            {
                string bName = Request["Name"];
                bName = bName.ToTitleCase(TitleCase.All);
                Brand check = db.Brands.FirstOrDefault(e => e.Name.Equals(bName));
                if( check == null)
                {
                    try
                    {
                        Brand b = new Brand();
                        b.Name = bName;
                        b.B_id = 1;
                        db.Brands.Add(b);
                        db.SaveChanges();
                        TempData["v_brand"] = "Brand Added!";
                        return Redirect("~/Admin/Add_Category");
                    }
                    catch (Exception e)
                    {
                        TempData["v_brand"] = "Something Went Wrong!";
                        return Redirect("~/Admin/Add_Category");
                    }
                }
                else
                {
                    TempData["v_brand"] = "Brand Already Exist!";
                    return Redirect("~/Admin/Add_Category");
                }
            }
            return Redirect("~/Admin/Add_Category");
        }

        public ActionResult Update_Category()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.main_category_list = (db.Categories.Where(e => e.Parent == 0)).ToList();

            return View();
        }
        public ActionResult Delete_Product()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            Product p = new Product();
            ViewBag.catagory = "";
            ViewBag.brand = "";
            ViewBag.tag = 0;
            ViewBag.proData = p;
            ViewBag.category_list = null;
            ViewBag.brand_list = null;
            return View();
        }
        [HttpPost]
        public ActionResult Delete_Product(Product pp)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            Product pa = new Product();
            ViewBag.catagory = "";
            ViewBag.brand = "";
            ViewBag.tag = 0;
            ViewBag.proData = pa;
            ViewBag.category_list = null;
            ViewBag.brand_list = null;
            string button = Request["button"];
            if (button.Equals("search"))
            {
                try
                {
                    string pid = Request["P_id"];

                    Product p = db.Products.Find(pid);
                    if (p == null)
                    {
                        TempData["v_searchProduct"] = "No Record Found";
                    }
                    else
                    {
                        Category c = db.Categories.FirstOrDefault(e => e.C_id == p.C_id);
                        Brand b = db.Brands.FirstOrDefault(e => e.B_id == p.B_id);
                        Tag t = db.Tags.FirstOrDefault(e => e.T_id == p.T_id);
                        ViewBag.catagory = c.Name;
                        ViewBag.brand = b.Name;
                        ViewBag.tag = t.T_id;

                        ViewBag.category_list = (db.Categories.Where(e => e.Parent != 0)).ToList();
                        ViewBag.brand_list = db.Brands.ToList();
                        ViewBag.proData = p;
                    }
                }
                catch (Exception e)
                {
                    TempData["v_searchProduct"] = "Something Went Wrong!";
                    return View();

                }
            }
            else if (button.Equals("delete"))
            {
                try
                {

                    string pid = Request["P_id"];
                    if(pid == null || pid == "")
                    {
                        TempData["v_updateProduct"] = "Invalid Form Data!";
                        return View();
                    }
                    Product ppp = db.Products.Find(pid);
                    var image = db.Images.Where(e => e.P_id == ppp.P_id).ToList();
                    foreach (var x in image)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/UploadedFiles/" + x.Image_name)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/UploadedFiles/" + x.Image_name));
                        }
                        db.Images.Remove(x);
                    }
                    db.Products.Remove(ppp);
                    db.SaveChanges();


                    TempData["v_updateProduct"] = "Product Is Deleted!";

                }
                catch (Exception e)
                {
                    TempData["v_updateProduct"] = "Something Went Wrong!";
                    return View();
                }
            }

            return View();
        }

        public ActionResult Delete_Category()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.main_category_list =  (db.Categories.Where(e => e.Parent == 0)).ToList();

            return View();
        }

        public JsonResult SearchLive(String term)
        {
            
            List<string> products;
            products = db.Products.Where(x => x.P_id.StartsWith(term)).Select(
                e => e.P_id).Distinct().ToList();
           
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public ActionResult News_Letter()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }

            return View(db.News_letter.ToList());
        }

        [HttpPost]
        public JsonResult pidAvailabilityAjax(string p_id)
        {
            Object data = null;
            int flag = 0;
            try
            {

                Product check = db.Products.FirstOrDefault(e => e.P_id.Equals(p_id));

                if (check == null)
                {
                    flag = 1;
                }
                data = new
                {
                    available = flag
                };
            }
            catch (Exception e)
            {
                flag = -1;
                data = new
                {
                    available = flag
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateProductAjax(string p_id)
        {
            Object data = null;
            var url = "";
            var flag = false;
            try
            {
                flag = true;
                TempData["pidAvailabilityAjax_ajax"] = p_id;
                data = new
                {
                    valid = flag,
                    urlToRedirect = Url.Content("~/Admin/Update_Product")

                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                    urlToRedirect = Url.Content("~/Admin/Product")
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult deleteProductAjax(string p_id)
        {
            Object data = null;
            var url = "";
            var flag = false;
            try
            {
                flag = true;
                TempData["pidAvailabilityAjax_ajax"] = p_id;
                data = new
                {
                    valid = flag,
                    urlToRedirect = Url.Content("~/Admin/Delete_Product")

                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                    urlToRedirect = Url.Content("~/Admin/Product")
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddressDetailsAjax(string A_id)
        {
            Object data = null;
            Boolean flag = false;
            try
            {
                int id = Convert.ToInt32(A_id);
                Address a = db.Addresses.Find(id);
                flag = true;
                data = new
                {
                    valid = flag,
                    address =  a.Address1,
                    name = a.Resiver_name,
                    cnic = a.Resiver_cnic
                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult OrderDetailsAjax(string O_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Object data = null;
            Boolean flag = false;
            try
            {
                int id = Convert.ToInt32(O_id);
                //var viewModel = db.Order_details.Where(e => e.O_id == id).ToList();

                var viewModel =
                 from p in db.Products
                 join i in db.Images on p.P_id equals i.P_id
                 join o in db.Order_details on p.P_id equals o.P_id
                 where i.Is_Main == 1 && o.O_id == id
                 select new OrderDetailView { Product = p, Image = i, Order_details = o };

                var lists = JsonConvert.SerializeObject(viewModel,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

                flag = true;
                data = new
                {
                    valid=flag,
                    list = lists
                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                    list = ""
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetOrderCountAjax()
        {
            Object data = null;
            Boolean flag = false;
            try
            {
                //side bar orders
                Double all1 = db.Orders.Count();
                Double pending1 = db.Orders.Where(e => e.S_id == 1).Count();
                Double deliverd1 = db.Orders.Where(e => e.S_id == 2).Count();
                Double confirmed1 = db.Orders.Where(e => e.S_id == 3).Count();
                Double canceled1 = db.Orders.Where(e => e.S_id == 4).Count();
                Double returned1 = db.Orders.Where(e => e.S_id == 5).Count();


                //Nav bar orders
                int pendingPer1 = Convert.ToInt32( (pending1 / all1) * 100);
                int deliveredPer1 = Convert.ToInt32((deliverd1 / all1) * 100);
                int confirmedPer1 = Convert.ToInt32((confirmed1 / all1) * 100);
                int canceledPer1 = Convert.ToInt32((canceled1 / all1) * 100);
                int returnedPer1 = Convert.ToInt32((returned1 / all1) * 100);

                //Nav Bar Message
                var mail1 = db.Mails.Where(e => e.New == 1);






                flag = true;
                data = new
                {
                    valid = flag,
                    all = all1,
                    pending = pending1,
                    confirmed = confirmed1,
                    deliverd = deliverd1,
                    canceled = canceled1,
                    returned = returned1,

                    pendingPer = pendingPer1,
                    deliveredPer = deliveredPer1,
                    confirmedPer = confirmedPer1,
                    canceledPer = canceledPer1,
                    returnedPer = returnedPer1,

                    mail = mail1
                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateOrderStatusAjax(string status, string o_id)
        {
            Object data = null;
            Boolean flag = false;
            try
            {

                int S_id = Convert.ToInt16(status);
                int O_id = Convert.ToInt32(o_id);

                Order o = db.Orders.Find(O_id);
                o.S_id = S_id;
                db.SaveChanges();
                
                flag = true;
                data = new
                {
                    valid = flag,
                    
                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ShowSubCatAjax(string c_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            object data = null;
            Boolean flag = false;
            try
            {
                int p = Convert.ToInt32(c_id);
                var sub = db.Categories.Where(e => e.Parent == p);
                flag = true;
                data = new
                {
                    valid = flag,
                    list = sub
                };
            }
            catch( Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSubCatAjax(string c_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            object data = null;
            string message1 = "";
            try
            {
                int s_c_id = Convert.ToInt32(c_id);
                var pro = db.Products.Where(e => e.C_id == s_c_id);
                foreach(var p in pro)
                {
                    var image = db.Images.Where(e => e.P_id == p.P_id).ToList();
                    foreach (var x in image)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/UploadedFiles/" + x.Image_name)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/UploadedFiles/" + x.Image_name));
                        }
                        db.Images.Remove(x);
                    }
                    db.Products.Remove(p);
                }

                Category c = db.Categories.Find(s_c_id);
                db.Categories.Remove(c);

                db.SaveChanges();


                message1 = "Sub Category is Deleted";
                data = new
                {
                    message = message1
                };
            }
            catch (Exception e)
            {
                message1 = "Something Went Wrong";
                data = new
                {
                    message = message1
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMainCatAjax(string c_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            object data = null;
            string message1 = "";
            try
            {
                int s_c_id = Convert.ToInt32(c_id);
                var cat = db.Categories.Where(e => e.Parent == s_c_id);

                foreach (var m in cat)
                {

                    var pro = db.Products.Where(e => e.C_id == m.C_id);
                    foreach (var p in pro)
                    {
                        var image = db.Images.Where(e => e.P_id == p.P_id).ToList();
                        foreach (var x in image)
                        {
                            if (System.IO.File.Exists(Server.MapPath("~/UploadedFiles/" + x.Image_name)))
                            {
                                System.IO.File.Delete(Server.MapPath("~/UploadedFiles/" + x.Image_name));
                            }
                            db.Images.Remove(x);
                        }
                        db.Products.Remove(p);
                    }

                    Category c = db.Categories.Find(m.C_id);
                    db.Categories.Remove(c);
                }
                Category main = db.Categories.Find(s_c_id);
                db.Categories.Remove(main);
                db.SaveChanges();


                message1 = "Main Category is Deleted";
                data = new
                {
                    message = message1
                };
            }
            catch (Exception e)
            {
                message1 = "Something Went Wrong";
                data = new
                {
                    message = message1
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateMainCatAjax(string c_id ,string newName)
        {
            db.Configuration.ProxyCreationEnabled = false;
            object data = null;
            string message1 = "";
            try
            {
                int s_c_id = Convert.ToInt32(c_id);

                Category c = db.Categories.Find(s_c_id);
                c.Name = newName.ToTitleCase(TitleCase.All);
                db.SaveChanges();

                message1 = "Main Category Name Is Updated!";
                data = new
                {
                    message = message1
                };
            }
            catch (Exception e)
            {
                message1 = "Something Went Wrong";
                data = new
                {
                    message = message1
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateSubCatAjax(string c_id, string newName)
        {
            db.Configuration.ProxyCreationEnabled = false;
            object data = null;
            string message1 = "";
            try
            {
                int s_c_id = Convert.ToInt32(c_id);

                Category c = db.Categories.Find(s_c_id);
                c.Name = newName.ToTitleCase(TitleCase.All);
                db.SaveChanges();

                message1 = "Sub Category Name Is Updated!";
                data = new
                {
                    message = message1
                };
            }
            catch (Exception e)
            {
                message1 = "Something Went Wrong";
                data = new
                {
                    message = message1
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMailAjax(string m_id)
        {
            Object data = null;
            Boolean flag = false;
            try
            {

                int M_id = Convert.ToInt32(m_id);

                var mail = db.Mails.Find(M_id);
                db.Mails.Remove(mail);
                db.SaveChanges();
                flag = true;
                data = new
                {
                    valid = flag,

                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateMailStatusAjax(string status, string m_id)
        {
            Object data = null;
            Boolean flag = false;
            try
            {

                int S_id = Convert.ToInt16(status);
                int M_id = Convert.ToInt32(m_id);

                Mail m = db.Mails.Find(M_id);
                m.New = S_id;
                db.SaveChanges();

                flag = true;
                data = new
                {
                    valid = flag,

                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetIndexDataAjax()
        {
            Object data = null;
            Boolean flag = false;
            try
            {

                var regUser1 = (db.Users.Count()) - 1;
                var newMessage1 = db.Mails.Where(e => e.New == 1).Count();
                var followers1 = db.News_letter.Count();



                var orders = db.Orders.Where(e => e.S_id == 2);
                var orders2 = db.Orders;

                var CurrentMonthsale1 = 0;
                var CurrentMonthOrders1 = 0;
                foreach(var x in orders)
                {
                    if (DateTime.Parse(x.Date).Year == DateTime.Now.Year && DateTime.Parse(x.Date).Month == DateTime.Now.Month)
                    {
                        CurrentMonthsale1 = CurrentMonthsale1 + Convert.ToInt32( x.Grand_total);
                    }
                    
                }
                foreach (var x in orders2)
                {
                    if (DateTime.Parse(x.Date).Year == DateTime.Now.Year && DateTime.Parse(x.Date).Month == DateTime.Now.Month)
                    {
                        CurrentMonthOrders1++;
                    }

                }
                var CurrentMonthProfit1 = CurrentMonthsale1 * 0.3;
                var returned = db.Orders.Where(e => e.S_id == 5).Count();
                var CurrentMohthloss1 = returned * 400;

                flag = true;
                data = new
                {
                    valid = flag,

                    regUser = regUser1,
                    newMessage = newMessage1,
                    followers = followers1,

                    CurrentMonthsale = CurrentMonthsale1,
                    CurrentMonthOrders = CurrentMonthOrders1,
                    CurrentMonthProfit = CurrentMonthProfit1,
                    CurrentMohthloss = CurrentMohthloss1
                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,

                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return Redirect("~/Admin/Login");
        }

        public ActionResult Settings()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            return View();
        }
        public ActionResult AddEmploye()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Admin/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddEmploye(Employe emp)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    
                    Employe check = db.Employes.Where(e => e.Email == emp.Email).FirstOrDefault();
                    if (check == null)
                    {
                        emp.A_id = 1;
                        db.Employes.Add(emp);
                        db.SaveChanges();
                        TempData["validation"] = "Employe Is Added";

                    }
                    else
                    {
                        TempData["validation"] = "Email Already Exist";
                    }
                }
                catch(Exception e)
                {
                    TempData["validation"] = "SomeThing Went Wrong";
                }

                return View();

            }
            return View(emp);
        }




        [HttpPost]
        public JsonResult ResetPassAjax(string email, string pass)
        {
            Object data = null;
            Boolean flag = false;
            try
            {

                Employe emp = db.Employes.Where(e => e.Email == email).FirstOrDefault();
                if(emp != null)
                {
                    emp.Password = pass;
                    db.SaveChanges();
                    var req = (Reset_Password_request)Session["reset"];

                    var rr = db.Reset_Password_request.Find(req.Id);
                    db.Reset_Password_request.Remove(rr);
                    db.SaveChanges();
                    Session["reset"] = null;
                }

                flag = true;
                data = new
                {
                    valid = flag,
                    message ="Password Is Updated!",
                    url = Url.Content("~/Admin/Login")

                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                    message = "Something Went Wrong!"
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangePassAjax(string oldpass, string pass)
        {
            Object data = null;
            Boolean flag = false;
            try
            {

                string mess;
                User u = (User)Session["Admin"];
                Employe emp = db.Employes.Where(e => e.Email == u.Email).FirstOrDefault();

                if(emp.Password == oldpass)
                {
                    emp.Password = pass;
                    db.SaveChanges();
                    mess = "Password Is Updated!";

                }
                else
                {
                    mess = "Incorrect Old Password!";

                }

                flag = true;
                data = new
                {
                    valid = flag,
                    message = mess,
                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                    message = "Something Went Wrong!"
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}