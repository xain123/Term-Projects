using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ServiceBO
    {
        string pid;
        string customerName;
        string address;
        string phone;
        int charges;
        string serviceDate;
        string returnDate;

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

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public int Charges
        {
            get
            {
                return charges;
            }

            set
            {
                charges = value;
            }
        }

        public string ServiceDate
        {
            get
            {
                return serviceDate;
            }

            set
            {
                serviceDate = value;
            }
        }

        public string ReturnDate
        {
            get
            {
                return returnDate;
            }

            set
            {
                returnDate = value;
            }
        }
    }
}
