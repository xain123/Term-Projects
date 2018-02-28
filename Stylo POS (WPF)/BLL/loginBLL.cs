using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class loginBLL
    {
        public int login(loginBO lBO)
        {
            
            loginDAL lDAL = new loginDAL();

            return lDAL.login(lBO);
        }
    }
}
