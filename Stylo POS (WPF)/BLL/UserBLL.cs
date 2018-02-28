using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;
namespace BLL
{
    public class UserBLL
    {
        public int register(UserBO ub)
        {
            UserDLL ud = new UserDLL();
            return ud.registerUser(ub); 
        }

        public int updateUser(UserBO ub)
        {
            UserDLL ud = new UserDLL();
            return ud.updateRegUser(ub);
        }
    }
}
