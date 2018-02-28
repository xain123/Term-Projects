using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       private ElectronicStoreEntities db = new ElectronicStoreEntities();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.parent = db.Categories.Where(e => e.Parent ==0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();


            ViewBag.products = db.Products.Where(e => e.T_id ==1).ToList();
            ViewBag.images = db.Images.ToList();



            //product tabs
            var headerCat = db.Categories.Where(e => e.Parent == 0).Take(5);
            ViewBag.headerCat = headerCat;
            List<Product> list = new List<Product>();
            foreach(var c in headerCat )
            {
                var subCat = db.Categories.Where(e => e.Parent == c.C_id);
                foreach(var sc in subCat)
                {
                    var products = db.Products.Where(e => e.C_id == sc.C_id && e.T_id != 3).Take(3);
                    foreach(var ip in products)
                    {
                        ip.C_id = c.C_id;//placeing main CID instead of sub CID
                        list.Add(ip);
                    }
                    break;
                }

            }

            ViewBag.products = list;
            ViewBag.newProducts = db.Products.Where(e => e.T_id == 1).ToList();
            ViewBag.images = db.Images.ToList();
            return View();
        }
        public ActionResult About()
        {
            ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();
            return View();
        }
        public ActionResult Error()
        {
           
            return View();
        }

        public ActionResult About2()
        {

            return View();
        }
        public ActionResult Cart()
        {

            if(Session["User"] == null)
            {
                return Redirect("/Home/Index");
            }

            ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

            User u = (User)Session["User"];

               var viewModel =
                  from p in db.Products
                  join i in db.Images on p.P_id equals i.P_id
                  join c in db.Carts on p.P_id equals c.P_id
                  where i.Is_Main == 1 && c.U_id == u.U_id

                  select new CartView { Product = p, Image = i, Cart = c };
            
                
            return View(viewModel);
        }
        public ActionResult Checkout()
        {
            User u = (User)Session["User"];
            if (Session["User"] == null )
            {
                return Redirect("/Home/Index");
            }
            var check = db.Carts.Where(e => e.U_id == u.U_id);

            if ( check.Count() ==0 )
            {
                return Redirect("/Home/Index");
            }

            Address a = db.Addresses.Where(e => e.U_id == u.U_id).FirstOrDefault();
            if (a != null)
            {
                ViewBag.addres = a;
                ViewBag.add = a.Address1;
            }
            ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

            var viewModel =
                 from p in db.Products

                 join c in db.Carts on p.P_id equals c.P_id
                 where c.U_id == u.U_id

                 select new CartView { Product = p, Cart = c };

            return View(viewModel);
        }
        public ActionResult Mail()
        {
            ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Mail(Mail m)
        {
            ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();
            m.M_id = 1;
            m.Date = DateTime.Now.ToString("M/d/yyyy");
            try
            {
                m.New = 1;
                db.Mails.Add(m);
                

                string pass = Request["password"];
                SendEmail(m.Message, m.Email, pass);
                db.SaveChanges();
                TempData["v_mail"] = "Mail Sent!";
                return View();
            }
            catch (Exception e)
            {
                TempData["v_mail"] = "Your Google Account Privecy is Not Allowing To send Mail!";
                return View();
            }
        }

        public ActionResult Products0()
        {
            return Redirect("/Home/Index");
        }



        [HttpPost]
        public ActionResult Products0(int a=0)
        {
            try
            {
                ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
                ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

                string ProductName = Request["Search"];


                if (ProductName == null)
                {
                    return Redirect("/Home/Index");
                }

                Product pro = db.Products.Where(e => e.Name == ProductName).FirstOrDefault();

                int id = Convert.ToInt32( pro.C_id);
                ViewBag.cat = id;

               

                //side bars in product page
                ViewBag.mainCat = db.Categories.Where(e => e.Parent == 0);
                ViewBag.subCat = db.Categories.Where(e => e.Parent != 0);
                ViewBag.brands = db.Brands;

                var cc = db.Products.Where(e => e.Name == ProductName).ToList();
                ViewBag.products = cc;


                ViewBag.images = db.Images.ToList();

                return View();
            }
            catch (Exception e)
            {
                return Redirect("/Home/Index");

            }

        }

        public ActionResult Products(int id = 0)
        {
            try
            {
                ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
                ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

                if (id == 0)
                {
                    return Redirect("/Home/Index");
                }


                ViewBag.cat = id;

                var check = db.Categories.Find(id);
                if (check.Parent == 0)
                {
                    List<Product> products = new List<Product>();
                    var cat = db.Categories.Where(e => e.Parent == id);
                    foreach (var x in cat)
                    {
                        var p = db.Products.Where(e => e.C_id == x.C_id);
                        foreach (var c in p)
                        {
                            products.Add(c);
                        }
                    }
                    //side bars in product page
                    ViewBag.mainCat = db.Categories.Where(e => e.Parent == 0);
                    ViewBag.subCat = db.Categories.Where(e => e.Parent != 0);
                    ViewBag.brands = db.Brands;


                    ViewBag.products = products;
                    ViewBag.images = db.Images.ToList();

                    return View();
                }

                //side bars in product page
                ViewBag.mainCat = db.Categories.Where(e => e.Parent == 0);
                ViewBag.subCat = db.Categories.Where(e => e.Parent != 0);
                ViewBag.brands = db.Brands;

                var cc = db.Products.Where(e => e.C_id == id).ToList();
                ViewBag.products = cc;


                ViewBag.images = db.Images.ToList();

                return View();
            }
            catch (Exception e)
            {
                return Redirect("/Home/Index");

            }

        }

        public ActionResult Products2(int cat=0 , int brand=0)
        {
            try
            {
                ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
                ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

                if (cat == 0 || brand == 0)
                {
                    return Redirect("/Home/Index");
                }
                ViewBag.cat = cat;
                ViewBag.bra = brand;

                //side bars in product page
                ViewBag.mainCat = db.Categories.Where(e => e.Parent == 0);
                ViewBag.subCat = db.Categories.Where(e => e.Parent != 0);
                ViewBag.brands = db.Brands;



                List<Product> products = new List<Product>();
                var cate = db.Categories.Where(e => e.Parent == cat);
                foreach (var x in cate)
                {
                    var p = db.Products.Where(e => e.C_id == x.C_id && e.B_id == brand);
                    foreach (var c in p)
                    {
                        products.Add(c);
                    }
                }


                ViewBag.products = products;
                ViewBag.images = db.Images.ToList();
                return View();
            }
            catch (Exception e)
            {
                return Redirect("/Home/Index");

            }

        }

        public ActionResult Products3(int cat =0, int brand=0, int below=0, int above=0)
        {
            try
            {
                ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
                ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

                if (cat == 0 || below < 0 || above < 0)
                {
                    return Redirect("/Home/Index");
                }

                ViewBag.cat = cat;
                ViewBag.bra = brand;
                //side bars in product page
                ViewBag.mainCat = db.Categories.Where(e => e.Parent == 0);
                ViewBag.subCat = db.Categories.Where(e => e.Parent != 0);
                ViewBag.brands = db.Brands;

                List<Product> products = new List<Product>();
                IQueryable<Product> p = null;

                var check = db.Categories.Find(cat);
                if (check.Parent == 0)
                {
                    var cate = db.Categories.Where(e => e.Parent == cat);
                    foreach (var x in cate)
                    {
                        if (brand == 0)
                        {
                            p = db.Products.Where(e => e.C_id == x.C_id);
                        }
                        else
                        {
                            p = db.Products.Where(e => e.C_id == x.C_id && e.B_id == brand);
                        }
                        foreach (var c in p)
                        {
                            if (above == 0)
                            {
                                if (c.Price <= below)
                                {
                                    products.Add(c);
                                }
                            }
                            else if (below == 0)
                            {
                                if (c.Price >= above)
                                {
                                    products.Add(c);
                                }
                            }
                            else
                            {
                                if (c.Price >= below && c.Price <= above)
                                {
                                    products.Add(c);
                                }
                            }
                        }
                    }

                    ViewBag.products = products;
                    ViewBag.images = db.Images.ToList();

                    return View();
                }
                else
                {
                    if (brand == 0)
                    {
                        p = db.Products.Where(e => e.C_id == cat);
                    }
                    else
                    {
                        p = db.Products.Where(e => e.C_id == cat && e.B_id == brand);
                    }
                    foreach (var c in p)
                    {
                        if (above == 0)
                        {
                            if (c.Price <= below)
                            {
                                products.Add(c);
                            }
                        }
                        else if (below == 0)
                        {
                            if (c.Price >= above)
                            {
                                products.Add(c);
                            }
                        }
                        else
                        {
                            if (c.Price >= below && c.Price <= above)
                            {
                                products.Add(c);
                            }
                        }
                    }
                }

                ViewBag.products = products;
                ViewBag.images = db.Images.ToList();
                return View();
            }
            catch(Exception e)
            {
                return Redirect("/Home/Index");

            }
        }

        [HttpPost]
        public JsonResult ShipingDetailsAjax(string name, string phone, string address, string city, string state, string zip)
            
        {
            Object data = null;
            var message = "";
            try
            {
                User u = (User)Session["User"];
                Address check = db.Addresses.Where(e => e.U_id == u.U_id).FirstOrDefault();  
                if(check == null)
                {
                    Address a = new Address();
                    a.U_id = u.U_id;
                    a.Name = name;
                    a.Phone = phone;
                    a.Address1 = address;
                    a.City = city;
                    a.State = state;
                    a.Zip = Convert.ToInt32(zip);
                    a.A_id = 1;
                    db.Addresses.Add(a);
                    db.SaveChanges();
                    message = "saved";
                    
                }
                else
                {
                    check.Name = name;
                    check.Phone = phone;
                    check.Address1 = address;
                    check.City = city;
                    check.State = state;
                    check.Zip = Convert.ToInt32(zip);
                    db.SaveChanges();
                    message = "updated";
                }



                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Some Thing Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult CompleteAddressAjax(string name, string cnic)

        {
            Object data = null;
            var message = "";
            try
            {
                User u = (User)Session["User"];
                Address check = db.Addresses.Where(e => e.U_id == u.U_id).FirstOrDefault();
               
                check.Resiver_name = name;
                check.Resiver_cnic = cnic;
                db.SaveChanges();
                message = "updated";
                
                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Some Thing Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult PlaceOrderAjax(string captcha)

        {
            Object data = null;
            var message = "";
            try
            {
                string response = captcha;

                string secretKey = "6Ldx_iQUAAAAANOg9tYwABMd6C2os33YQ5pPt2EY";
                var client = new WebClient();
                var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(result);
                var status = (bool)obj.SelectToken("success");

                if (status)
                {
                    User u = (User)Session["User"];

                    Order o = db.Orders.Where(e => e.U_id == u.U_id && e.Last == 1).FirstOrDefault();
                    if(o != null)
                    {
                        o.Last = 0;
                        db.SaveChanges();
                    }

                    var cart = db.Carts.Where(e => e.U_id == u.U_id).ToList();
                    Address add = db.Addresses.Where(e => e.U_id == u.U_id).FirstOrDefault();
                    double grandTotal = 0;

                    foreach (var x in cart)
                    {
                        Product p = db.Products.Find(x.P_id);
                        double subtotal = (int)x.Quantity * (int)p.Price;
                        grandTotal = subtotal + grandTotal;
                    }
                    Order order = new Order();
                    order.O_id = 2;
                    order.U_id = u.U_id;
                    order.A_id = add.A_id;
                    order.Date = DateTime.Now.ToString();
                    order.S_id = 1;
                    order.Last = 1;
                    order.Grand_total = grandTotal;
                    db.Orders.Add(order);
                    db.SaveChanges();

                    var orderId = db.Orders.Where(e => e.U_id == u.U_id && e.Last == 1).FirstOrDefault();

                    foreach (var x in cart)
                    {
                        Product p = db.Products.Find(x.P_id);
                        Order_details orderDetail = new Order_details();
                        orderDetail.Od_id = 1;
                        orderDetail.O_id = orderId.O_id;
                        orderDetail.P_id = x.P_id;
                        orderDetail.Quantity = x.Quantity;
                        int price = (int)x.Quantity * (int)p.Price;
                        orderDetail.Price = price;
                        db.Order_details.Add(orderDetail);
                    }
                    db.SaveChanges();
                    var remove = db.Carts.Where(e => e.U_id == u.U_id);
                    foreach( var x in remove)
                    {
                        db.Carts.Remove(x);
                    }
                    db.SaveChanges();
                    message = "Your Order is Placed!";

                }
                else
                {
                    message = "Google reCaptcha Validation Failed!";
                }


                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Some Thing Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Single(string name = null)
        {
            //categories in nave bar
            ViewBag.parent = db.Categories.Where(e => e.Parent == 0).ToList();
            ViewBag.chlid = db.Categories.Where(e => e.Parent != 0).ToList();

            if (name == null)
            {
                return Redirect("/Home/Index");
            }

            Product p = db.Products.Find(name);
            ViewBag.product = p;
            ViewBag.image = db.Images.Where(e => e.P_id == name).Take(3).ToList();


            //Ratings
            ViewBag.reviews = db.Reviews.Where(e => e.P_id == name);
            ViewBag.reviewsCount = db.Reviews.Where(e => e.P_id == name).Count();


            //for related items
            ViewBag.products = db.Products.Where(e => e.C_id == p.C_id).ToList();
            ViewBag.images = db.Images.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult LoginAjax(string email, string password)
        {
            Object data = null;
            var message = "";
            try
            {
                User u = db.Users.Single(e => e.Email.Equals(email));
                if (password.Equals(u.Password))
                {
                    Session["User"] = u;
                   
                    message = "Loged in!";
                }
                else
                {
                    u = null;
                    message = "Incorrect Email/Password";
                    
                }
                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "You are not Registerd";
                data = new
                {
                    output = message
                };

            }
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SingupAjax(string name, string email, string pass, string cpass)
        {
            Object data = null;
            var message = "";
            try
            {
                if (pass.Equals(cpass))
                {
                    User check = db.Users.FirstOrDefault(e => e.Email.Equals(email));
                    if (check == null)
                    {
                        User u = new User();
                        u.Nmae = name;
                        u.Email = email;
                        u.Password = pass;
                        u.Is_admin = 0;
                        u.U_id = 1;

                        db.Users.Add(u);
                        db.SaveChanges();
                        message = "Account Created!";
                    }
                    else
                    {
                        message = "User Already Exist";
                    }
                }
                else
                {
                    message = "Password Does not Match";
                }
                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Something Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LogoutAjax()
        {
            Session["User"] = null;
            Object data = null;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult NewsLetterAjax(string email)
        {
            Object data = null;
            var message = "";
            try
            {
                News_letter check = db.News_letter.FirstOrDefault(e => e.Email.Equals(email));
                if (check == null)
                {
                    News_letter n = new News_letter();
                    n.Email = email;
                    n.N_id = 1;

                    db.News_letter.Add(n);
                    db.SaveChanges();
                    message = "Sucessfully Subscrided!";
                }

                else
                {
                    message = "You are Already Subscrided";
                }
                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Some Thing Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ProductsModelAjax(string p_id)
        {
            Object data = null;
            var flag = false;
            try
            {

                flag = true;
                Product p = db.Products.Find(p_id);
                Image i = db.Images.Where(e => e.P_id == p_id && e.Is_Main == 1).FirstOrDefault();




                data = new
                {
                    valid = flag,
                    name = p.Name,
                    description = p.Description,
                    oldprice = p.Old_price,
                    price = p.Price,
                    pid = p.P_id,
                    image = "/UploadedFiles/"+i.Image_name

                };
            }
            catch (Exception e)
            {
                flag = false;
                data = new
                {
                    valid = flag,
                    name = "",
                    description = "",
                    oldprice = 0,
                    price = 0,
                    pid = "",
                    image = ""
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult addToCartAjax(string p_id, string quantity)
        {
            Object data = null;
            var flag = false;
            if (quantity == "")
                quantity = null;
            try
            {
                var u =(User) Session["User"];
                Product p = db.Products.Find(p_id);
                int stock = 1;//out of stock

                if (p.T_id != 3)
                {
                    stock = 0;//not out of stock

                    int quan = Convert.ToInt16(quantity);
                    if (quan == 0)
                    {
                        quan = 1;
                    }
                    Cart check = db.Carts.Where(e => e.P_id == p_id && e.U_id == u.U_id).FirstOrDefault();
                    if (check != null)
                    {
                        try
                        {
                            check.Quantity = check.Quantity + quan;
                            db.SaveChanges();
                            flag = true;
                            data = new
                            {
                                valid = flag
                            };
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception e)
                        {
                            data = new
                            {
                                valid = flag
                            };
                            return Json(data, JsonRequestBehavior.AllowGet);

                        }
                    }

                    Cart c = new Cart();
                    c.Cart_id = 1;
                    c.U_id = u.U_id;
                    c.P_id = p_id;
                    c.Quantity = quan;


                    db.Carts.Add(c);
                    db.SaveChanges();
                }


                flag = true;
                data = new
                {
                    valid = flag,
                    message = "Out Of Stock",
                    stockOut =stock
                };
            }
            catch (Exception e)
            {
                data = new
                {
                    valid = flag
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteFromCartAjax(string cid)
        {
            Object data = null;
           
            try
            {
                int cart_id = Convert.ToInt32(cid);
                Cart c = db.Carts.Find(cart_id);
                db.Carts.Remove(c);
                db.SaveChanges();
              
            }
            catch (Exception e)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateQuantityAjax(string cid, string flag)
        {
            Object data = null;
            try
            {
                int cartid = Convert.ToInt32(cid);
                Cart c = db.Carts.Find(cartid);

                if (flag.Equals("inc"))
                {
                    c.Quantity = c.Quantity + 1;
                }
                else if (flag.Equals("dec"))
                {
                    c.Quantity = c.Quantity - 1;
                }
                db.SaveChanges();
                Product p = db.Products.Where(e => e.P_id == c.P_id).FirstOrDefault();
                int t = (int)p.Price * (int)c.Quantity;

                string total = t.ToString("#,##0");


                data = new
                {
                    amount = total
                };
            }
            catch (Exception e)
            {
               
                data = new
                {
                    amount = 0

                };

            }
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult UpdatePasswordAjax(string CurrentPass, string NewPassword, string ConfirmPassword)
        {

        Object data = null;
            var message = "";
            try
            {
                User u = (User)Session["User"];
                if (NewPassword.Equals(ConfirmPassword))
                {
                    User uu = db.Users.Find(u.U_id);

                    if (uu.Password == CurrentPass)
                    {
                        uu.Password = NewPassword;
                        db.SaveChanges();

                        message = "Your Password is Updated!";

                    }
                    else
                    {
                        message = "Incorrect Current Password!";

                    }
                }
                else
                {
                    message = "Password Does not Match";
                }
                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Something Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCartQuantityAjax()
        {
            db.Configuration.ProxyCreationEnabled = false;

            Object data = null;
            var q = 0;
            Boolean flag = false;//for categories
            try
            {
                if (Session["User"] != null)
                {
                    User u = (User)Session["User"];
                    var cart = db.Carts.Where(e => e.U_id == u.U_id).ToList();
                    q = cart.Count();
                }




                var c = db.Categories.Where(e => e.Parent == 0);//main category


                flag = true;
                data = new
                {
                    valid = flag,
                    count = q,
                    categories = c

                };
                
            }
            catch (Exception e)
            {
                q = -1;
                data = new
                {
                    valid = flag,
                    count = q
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddRatingAjax(string p_id, string rating, string name, string email, string ratingText)

        {
            Object data = null;
            var message = "";
            try
            {

                Review r = new Review();
                r.R_id = 1;
                r.P_id = p_id;
                r.Name = name;
                r.Email = email;
                r.Review1 = ratingText;
                r.Date = DateTime.Now.ToString("yyyy-MM-dd");
                r.Stars = Convert.ToDouble(rating);
                db.Reviews.Add(r);
                db.SaveChanges();
                message = "Your Review is Added!";

                data = new
                {
                    output = message
                };
            }
            catch (Exception e)
            {
                message = "Some Thing Went Wrong!";
                data = new
                {
                    output = message
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult MainRatingAjax(String p_id)
        {

            Object data = null;
            var q = 0;
            try
            {

                int totalReviews = db.Reviews.Where(e => e.P_id == p_id).Count();
                if(totalReviews == 0)
                {
                    double zero = 0;
                    data = new
                    {
                        count = zero
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);

                }

                var aa = db.Reviews.Where(e => e.P_id == p_id);
                double sum =0;
                foreach(var x in aa)
                {
                    sum = sum + Convert.ToDouble( x.Stars);
                }



                double avg = sum / totalReviews;
                data = new
                {
                    count = avg
                };

            }
            catch (Exception e)
            {
                q = -1;
                data = new
                {
                    count = q
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IndividualRatingAjax(string p_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Object data = null;
            Boolean flag = false;
            try
            {
                var lists = db.Reviews.Where(e => e.P_id == p_id).ToList();

                flag = true;
                data = new
                {
                    valid = flag,
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


        public JsonResult SearchLive(String term)
        {

            List<string> products;
            products = db.Products.Where(x => x.Name.StartsWith(term)).Select(
                e => e.Name).Distinct().ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public static void SendEmail(string emailBody, string ClientEmail, string ClientPassword)
        {
            MailMessage mailMessage = new MailMessage(ClientEmail, "xainasghar786@gmail.com");
            mailMessage.Subject = "From client";
            mailMessage.Body = emailBody;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials =new  System.Net.NetworkCredential()
            {
                UserName = ClientEmail, 
                Password = ClientPassword
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
