using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class saleBLL
    {
        SaleDAL saleDal = new SaleDAL();
        public int ssaleItem(saleBO sale)
        {
            return saleDal.saleItem(sale);
           
        }

        public ItemBO searchItem(ItemBO item)
        {
            
            return saleDal.searchItem(item);
        }
    }
}
