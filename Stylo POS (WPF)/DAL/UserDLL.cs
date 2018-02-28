using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class UserDLL
    {
        public int registerUser(UserBO ub)
        {


            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Users
                            where a.Username == ub.Username
                            select a;


                if (check.Any())
                {
                    return 3;
                }



                User newUser = new User
                {
                    Username = ub.Username,
                    Password = ub.Password,
                    Role = ub.Role
                };

                data.Users.InsertOnSubmit(newUser);
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

        public int updateRegUser(UserBO ub)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BCS DATA\Samester 6\C Sharp\Assingment 1\DAL\styloDatabase.mdf;Integrated Security=True";
            using (DataClassesDataContext data = new DataClassesDataContext(constr))
            {
                var check = from a in data.Users
                            where a.Username == ub.Username
                            select a;

                if (!check.Any())
                {
                    return 3;
                }

                User newUser = data.Users.SingleOrDefault(x => x.Username == ub.Username);
                newUser.Password = ub.Password;

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
