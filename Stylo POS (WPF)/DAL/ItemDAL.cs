using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BO;


namespace DAL
{
    public class ItemDAL
    {
        public int addItem(ItemBO item)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            where a.PID == item.Pid
                            select a;
                if (check.Any())
                {
                    return 3;
                }
                Item newItem = new Item
                {
                    PID = item.Pid,
                    Price = item.Price,
                    Category = item.Category,
                    Size = item.Size,
                    Color = item.Color,
                    Brand = item.Brand,
                    Date = item.Date,
                    Quantity = 1
                    
                };
                
                data.Items.InsertOnSubmit(newItem);
                try
                {
                    data.SubmitChanges();
                    return 0;
                }
                catch (Exception e)
                {
                   
                    return 1;
                }
            }
        }

        public List<ServiceForUpdateBO> ServiceReport()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from p in data.Items
                            join c in data.Services
                            on p.PID equals c.PID
                            select new
                            {
                                p.PID,
                                p.Price,
                                p.Category,
                                p.Size,
                                p.Color,
                                p.Brand,
                                p.Date,
                                c.Customer_Name,
                                c.Address,
                                c.Phone,
                                c.Charges,
                                c.Service_Date,
                                c.Return_Date
                            };
                if (check.Any())
                {
                    List<ServiceForUpdateBO> ls = new List<ServiceForUpdateBO>();
                    foreach (var i in check)
                    {
                        ServiceForUpdateBO itBO = new ServiceForUpdateBO();
                        itBO.Pid = i.PID;
                        itBO.Price = (int)i.Price;
                        itBO.Category = i.Category;
                        itBO.Size = (int)i.Size;
                        itBO.Color = i.Color;
                        itBO.Brand = i.Brand;

                        itBO.CustomerName = i.Customer_Name;
                        itBO.Address = i.Address;
                        itBO.Phone = i.Phone;
                        itBO.Charges = (int)i.Charges;
                        itBO.ServiceDate = i.Service_Date;
                        itBO.ReturnDate= i.Return_Date;
                        itBO.ReturnDate = i.Return_Date;
                        itBO.Date = i.Date;

                        //itBO.Quantity = (int)i.Quantity;
                        ls.Add(itBO);
                    }
                    return ls;

                }
                else
                {
                    return null;
                }
            }
        }

        public List<ServiceForUpdateBO> getServiceReportBW(string from, string to)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from p in data.Items
                            join c in data.Services
                            on p.PID equals c.PID
                            select new
                            {
                                p.PID,
                                p.Price,
                                p.Category,
                                p.Size,
                                p.Color,
                                p.Brand,
                                p.Date,
                                c.Customer_Name,
                                c.Address,
                                c.Phone,
                                c.Charges,
                                c.Service_Date,
                                c.Return_Date
                            };
                if (check.Any())
                {
                    List<ServiceForUpdateBO> ls = new List<ServiceForUpdateBO>();
                    foreach (var i in check)
                    {
                        if (DateTime.Parse(i.Service_Date) >= DateTime.Parse(from) && DateTime.Parse(i.Service_Date) <= DateTime.Parse(to))
                        {
                            ServiceForUpdateBO itBO = new ServiceForUpdateBO();
                            itBO.Pid = i.PID;
                            itBO.Price = (int)i.Price;
                            itBO.Category = i.Category;
                            itBO.Size = (int)i.Size;
                            itBO.Color = i.Color;
                            itBO.Brand = i.Brand;

                            itBO.CustomerName = i.Customer_Name;
                            itBO.Address = i.Address;
                            itBO.Phone = i.Phone;
                            itBO.Charges = (int)i.Charges;
                            itBO.ServiceDate = i.Service_Date;
                            itBO.ReturnDate = i.Return_Date;
                            itBO.ReturnDate = i.Return_Date;
                            itBO.Date = i.Date;

                            //itBO.Quantity = (int)i.Quantity;
                            ls.Add(itBO);
                        }
                    }
                    return ls;

                }
                else
                {
                    return null;
                }
            }
        }

        public List<SalesReportBo> getSaleReportBW(string from, string to)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from p in data.Items
                            join c in data.Sales
                            on p.PID equals c.PID
                            select new
                            {
                                p.PID,
                                p.Price,
                                p.Category,
                                p.Size,
                                p.Color,
                                p.Brand,
                                c.Sale_Date
                                
                            };
                if (check.Any())
                {
                    List<SalesReportBo> ls = new List<SalesReportBo>();
                    foreach (var i in check)
                    {
                        if (DateTime.Parse(i.Sale_Date) >= DateTime.Parse(from) && DateTime.Parse(i.Sale_Date) <= DateTime.Parse(to))
                        {
                            SalesReportBo itBO = new SalesReportBo();
                            itBO.Pid = i.PID;
                            itBO.Price = (int)i.Price;
                            itBO.Category = i.Category;
                            itBO.Size = (int)i.Size;
                            itBO.Color = i.Color;
                            itBO.Brand = i.Brand;
                            itBO.SaleDate = i.Sale_Date;
                            //itBO.Quantity = (int)i.Quantity;

                            ls.Add(itBO);
                        }
                    }
                    return ls;

                }
                else
                {
                    return null;
                }
            }
        }

        public List<SalesReportBo> saleReport()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check =             from p in data.Items
                                        join c in data.Sales
                                        on p.PID equals c.PID
                                        select new
                                        {
                                            p.PID,
                                            p.Price,
                                            p.Category,
                                            p.Size,
                                            p.Color,
                                            p.Brand,
                                            c.Sale_Date


                                        };
                if (check.Any())
                {
                    List<SalesReportBo> ls = new List<SalesReportBo>();
                    foreach (var i in check)
                    {
                        SalesReportBo itBO = new SalesReportBo();
                        itBO.Pid = i.PID;
                        itBO.Price = (int)i.Price;
                        itBO.Category = i.Category;
                        itBO.Size = (int)i.Size;
                        itBO.Color = i.Color;
                        itBO.Brand = i.Brand;
                        itBO.SaleDate = i.Sale_Date;
                        //itBO.Quantity = (int)i.Quantity;

                        ls.Add(itBO);
                    }
                    return ls;

                }
                else
                {
                    return null;
                }
            }
           
        }

        public List<ItemBO> getStockReport(string from, string to)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            select a;
                if (check.Any())
                {
                    List<ItemBO> ls = new List<ItemBO>();
                    foreach (var i in check)
                    {
                        if (DateTime.Parse(i.Date) >= DateTime.Parse(from) && DateTime.Parse(i.Date) <= DateTime.Parse(to))
                        {
                            if (i.Quantity != 0)
                            {
                                ItemBO itBO = new ItemBO();
                                itBO.Pid = i.PID;
                                itBO.Price = (int)i.Price;
                                itBO.Category = i.Category;
                                itBO.Size = (int)i.Size;
                                itBO.Color = i.Color;
                                itBO.Brand = i.Brand;
                                itBO.Date = i.Date;
                                //itBO.Quantity = (int)i.Quantity;

                                ls.Add(itBO);
                            }
                        }
                    }
                    return ls;

                }
                else
                {
                    return null;
                }
            }

            
        }
    

        public List<ItemBO> getItems()
        {



            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            select a;
                if (check.Any())
                {
                    List<ItemBO> ls= new List<ItemBO>();
                    foreach (var i in check)
                    {
                        if (i.Quantity != 0)
                        {
                            ItemBO itBO = new ItemBO();
                            itBO.Pid = i.PID;
                            itBO.Price = (int)i.Price;
                            itBO.Category = i.Category;
                            itBO.Size = (int)i.Size;
                            itBO.Color = i.Color;
                            itBO.Brand = i.Brand;
                            itBO.Date = i.Date;
                            //itBO.Quantity = (int)i.Quantity;

                            ls.Add(itBO);
                        }
                    }
                    return ls;

                }
                else
                {
                    return null;
                }
            }

        }

        public static int updateItem(ItemBO item)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            where a.PID == item.Pid
                            select a;

                if (!check.Any())
                {
                    return 3;
                }

                Item newItem = data.Items.SingleOrDefault(x => x.PID == item.Pid);
                newItem.Price = item.Price;
                newItem.Category = item.Category;
                newItem.Size = item.Size;
                newItem.Color = item.Color;
                newItem.Brand = item.Brand;
                //newItem.Quantity = item.Quantity;
               
                try
                {
                    data.SubmitChanges();
                    return 0;
                }
                catch (Exception e)
                {

                    return 1;
                }

            }
        }

        public static ItemBO searchItem(ItemBO item)
        {

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            where a.PID == item.Pid
                            select a;
                if (check.Any())
                {
                    ItemBO itBO = new ItemBO();
                    foreach (var i in check)
                    {
                        itBO.Pid = i.PID;
                        itBO.Price = (int)i.Price;
                        itBO.Category = i.Category;
                        itBO.Size = (int)i.Size;
                        itBO.Color = i.Color;
                        itBO.Brand = i.Brand;
                        itBO.Date = i.Date;
                        itBO.Quantity = (int)i.Quantity;
                    }
                    if (itBO.Quantity != 0)
                    {
                        return itBO;
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }

        }

        public static int deleteItem(ItemBO item)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            where a.PID == item.Pid
                            select a;

                if (!check.Any())
                {
                    return 3;
                }

                Item newItem = data.Items.SingleOrDefault(x => x.PID == item.Pid);
                data.Items.DeleteOnSubmit(newItem);

                try
                {
                    data.SubmitChanges();
                    return 0;
                }
                catch (Exception e)
                {

                    return 1;
                }

            }
        }
    }
}
