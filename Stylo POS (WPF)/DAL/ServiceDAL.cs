using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class ServiceDAL
    {
        public ItemBO searchIteam(ItemBO item)
        {

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check1 = from a in data.Services
                            where a.PID == item.Pid
                            select a;
                if(check1.Any())
                {
                    return null; 
                }



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
                    if (itBO.Quantity ==0)
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

        public int UpdateService(ServiceBO item)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Services
                            where a.PID == item.Pid
                            select a;

                if (!check.Any() )
                {
                    return 3;
                }

                Service newItem = data.Services.SingleOrDefault(x => x.PID == item.Pid);
                newItem.Phone = item.Phone;
                newItem.Return_Date = item.ReturnDate;
                

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

        public ServiceForUpdateBO searchToUpdateIteam(ServiceForUpdateBO item)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from p in data.Items
                            join c in data.Services
                            on p.PID equals c.PID
                            select new {
                               c.PID,
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
                int flag = 0;
                if (check.Any())
                {
                    ServiceForUpdateBO itBO = new ServiceForUpdateBO();
                    foreach (var i in check)
                    {
                        if (i.PID == item.Pid)
                        {
                            itBO.Pid = i.PID;
                            itBO.Price = (int)i.Price;
                            itBO.Category = i.Category;
                            itBO.Size = (int)i.Size;
                            itBO.Color = i.Color;
                            itBO.Brand = i.Brand;
                            itBO.Date = i.Date;
                            itBO.CustomerName = i.Customer_Name;
                            itBO.Address = i.Address;
                            itBO.Phone = i.Phone;
                            itBO.Charges = (int)i.Charges;
                            itBO.ServiceDate = i.Service_Date;
                            itBO.ReturnDate = i.Return_Date;
                            flag = 1;
                            break;
                        }
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                    if (itBO.Quantity == 0 && flag ==1)
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

        public int newService(ServiceBO item)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                
                Service newItem = new Service
                {
                    PID = item.Pid,
                    Customer_Name = item.CustomerName,
                    Address = item.Address,
                    Phone = item.Phone,
                    Charges = item.Charges,
                    Service_Date = item.ServiceDate,
                    Return_Date = item.ReturnDate,
                };

                data.Services.InsertOnSubmit(newItem);
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
