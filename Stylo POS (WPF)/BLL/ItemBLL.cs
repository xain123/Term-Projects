using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class ItemBLL
    {
        public int addItem(ItemBO item)
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.addItem(item);   
        }

        public ItemBO searchItem(ItemBO item)
        {
            ItemDAL itemdal = new ItemDAL();
            return ItemDAL.searchItem(item);
        }

        public int updateItem(ItemBO item)
        {
            ItemDAL itemdal = new ItemDAL();
            return ItemDAL.updateItem(item);
        }
        public int deleteItem(ItemBO item)
        {
            ItemDAL itemdal = new ItemDAL();
            return ItemDAL.deleteItem(item);
        }

        public List<ServiceForUpdateBO> getServiceReport()
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.ServiceReport();
        }

        public List<ItemBO> getItem()
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.getItems();
        }
        public List<SalesReportBo> getSalesReport()
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.saleReport();
        }

        public List<ItemBO> getStockReport(string from, string to)
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.getStockReport(from, to);
        }

        public List<SalesReportBo> getAdminSalekReportBW(string from, string to)
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.getSaleReportBW(from, to);
        }

        public List<ServiceForUpdateBO> getUserServiceReportBW(string from, string to)
        {
            ItemDAL itemdal = new ItemDAL();
            return itemdal.getServiceReportBW(from, to);
        }
    }
}
