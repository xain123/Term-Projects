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
    public class loginDAL
    {
        public int login(loginBO lBO)
        {
            string conectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";


            using (DataClassesDataContext dc = new DataClassesDataContext(conectionString) )
            {
                User us = dc.Users.SingleOrDefault(x => x.Username == lBO.Username);
                if (us == null)
                {
                    return 3;
                }
                else
                {
                    if (us.Role.Equals("Admin"))
                    {
                        if(us.Username.Equals(lBO.Username) && us.Password.Equals(lBO.Password))
                            return 1;
                    }
                    else if (us.Role.Equals("Staff"))
                    {
                        if (us.Username.Equals(lBO.Username) && us.Password.Equals(lBO.Password))
                            return 2;
                    }


                }
                return 4;

            }
        }
    }
}
