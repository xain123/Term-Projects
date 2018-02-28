using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class saleBO
    {
        string pid;
        string purchaseDate;

        public string Pid
        {
            get
            {
                return pid;
            }

            set
            {
                pid = value;
            }
        }

        public string PurchaseDate
        {
            get
            {
                return purchaseDate;
            }

            set
            {
                purchaseDate = value;
            }
        }

        public saleBO searchItem(saleBO item)
        {
            throw new NotImplementedException();
        }
    }
}
