using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class SaleDAL
    {
        public int saleItem(saleBO sale)
        {
            DataClassesDataContext data;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Items
                            where a.PID == sale.Pid
                            select a;
                if (!check.Any())
                {
                    return 3;
                }
                else
                {
                    foreach (var s in check)
                    {
                        s.Quantity = 0;

                    }
                }
                Sale newItem = new Sale
                {
                    PID = sale.Pid,
                    Sale_Date = sale.PurchaseDate
                    

                };

                data.Sales.InsertOnSubmit(newItem);
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

        public ItemBO searchItem(ItemBO item)
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
    }
}
